using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace UnitTestPerformance
{
    public class TestBase
    {
        private readonly Dictionary<TimerKey, IList<TimerValue>> _timer = new Dictionary<TimerKey, IList<TimerValue>>();

        [SetUp]
        public void SetUp()
        {
            _timer.Clear();
        }

        [TearDown]
        public void TearDown()
        {
            StopAllTimer();
            CheckAllTimer();
            _timer.Clear();
        }

        protected void StartTimer(string subTestcase = "", [CallerMemberName] string testcase = "", int warnTime = 250, int errorTime = 500)
        {
            var key = new TimerKey(testcase, subTestcase);
            if (_timer.ContainsKey(key))
            {
                _timer[key].Add(new TimerValue(warnTime, errorTime));
            }
            else
            {
                _timer.Add(key, new List<TimerValue> { new TimerValue(warnTime, errorTime) });
            }
        }

        protected void StopTimer(string subTestcase = "", [CallerMemberName] string testcase = "")
        {
            var key = new TimerKey(testcase, subTestcase);
            if (_timer.ContainsKey(key))
            {
                _timer[key].ToList().ForEach(value => value.Timer.Stop());
            }
        }

        protected void StopAllTimer()
        {
            _timer.Values.ToList().ForEach(timers => timers.ToList().ForEach(value => value.Timer.Stop()));
        }

        protected void CheckAllTimer(bool stopAllTimers = false)
        {
            if (stopAllTimers)
                StopAllTimer();

            foreach (var key in _timer.Keys)
            {
                var timers = _timer[key];

                foreach (var value in timers.Where(value => !value.Timer.IsRunning))
                {
                    var time = value.Timer.ElapsedMilliseconds;
                    if (time > value.ErrorTime)
                        Assert.Fail("Duration to long! [Maximal time: " + value.ErrorTime + "][Real time: " + time + "]" + key);
                    else if (time > value.WarnTime)
                        System.Diagnostics.Debug.WriteLine("Duration maybe to long! [Wished time: " + value.ErrorTime + "][Real time: " + time + "]" + key);
                }

                timers.ToList().RemoveAll(value => !value.Timer.IsRunning);
            }

            _timer.Clear();
        }
    }

    class TimerKey
    {
        public TimerKey(string testcase, string subTestcase)
        {
            Testcase = testcase;
            SubTestcase = subTestcase;
        }

        public string Testcase { get; private set; }
        public string SubTestcase { get; private set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(SubTestcase)
                ? "[TimerKey [Testcase: " + Testcase + "]]"
                : "[TimerKey [Testcase: " + Testcase + "][SubTestcase: " + SubTestcase + "]]";
        }

        public override bool Equals(object obj)
        {
            return ToString().Equals(obj.ToString());
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }

    class TimerValue
    {
        public TimerValue(int warnTime, int errorTime)
        {
            WarnTime = warnTime;
            ErrorTime = errorTime;
            Timer = Stopwatch.StartNew();
        }

        public int WarnTime { get; private set; }
        public int ErrorTime { get; private set; }
        public Stopwatch Timer { get; private set; }
    }
}
