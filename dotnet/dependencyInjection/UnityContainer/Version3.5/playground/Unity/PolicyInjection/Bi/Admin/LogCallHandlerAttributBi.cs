using Microsoft.Practices.EnterpriseLibrary.Logging.PolicyInjection;

namespace PolicyInjection.Bi.Admin
{
    public interface ILogCallHandlerAttributBi
    {
        int LoadConfig();
        void SaveConfig();
    }

    public class LogCallHandlerAttributBi : ILogCallHandlerAttributBi
    {
        [LogCallHandler(AfterMessage = "After call",
            BeforeMessage = "Before call",
            Categories = new string[] { "General" },
            EventId = 9002,
            IncludeCallStack = false,
            IncludeCallTime = true,
            IncludeParameters = true,
            LogAfterCall = true,
            LogBeforeCall = true,
            Priority = 10,
            Severity = System.Diagnostics.TraceEventType.Information,
            Order = 1)]
        public int LoadConfig()
        {
            return 1;
        }

        public void SaveConfig() { }
    }
}
