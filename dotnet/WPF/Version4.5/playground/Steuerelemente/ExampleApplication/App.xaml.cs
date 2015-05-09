using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

using Newtonsoft.Json;

namespace ExampleApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly string _storageFileName = "MyAppSettings.txt";
        private static readonly string _storageProtetedFileName = "MyAppSettingsProtected.txt";

        public App() : base()
        {
            this.Startup += OnStartup;
            this.Exit += OnExit;
            this.Activated += OnActivated;
            this.Deactivated += OnDeactivated;
            this.SessionEnding += OnSessionEnding;
            this.DispatcherUnhandledException += OnDispatcherUnhandledException;
        }

        async void OnStartup(object sender, StartupEventArgs e)
        {
            Console.WriteLine("OnStartup");
            var arguments = new StringBuilder();
            foreach (var arg in e.Args)
            {
                arguments.Append("[" + arg + "]");
            }
            Console.WriteLine("OnStartup - arguments: " + arguments);

//            try
//            {
//                var storage = IsolatedStorageFile.GetUserStoreForDomain();
//                using (var stream = new IsolatedStorageFileStream(_storageFileName, FileMode.Open, storage))
//                using (var reader = new StreamReader(stream))
//                {
//                    while (!reader.EndOfStream)
//                    {
//                        var line = await reader.ReadLineAsync();
//                        var keyValue = line.Split(new char[] { ',' });
//                        this.Properties.Add(keyValue[0], keyValue[1]);
//                    }
//                }
//            }
//            catch (FileNotFoundException)
//            {
//                this.Properties.Add("MyProperty1", "Value1");
//            }

            try
            {
                var storage = IsolatedStorageFile.GetUserStoreForDomain();
                using (var stream = new IsolatedStorageFileStream(_storageProtetedFileName, FileMode.Open, storage))
                using (var reader = new StreamReader(stream).BaseStream)
                {
                    var propertiesProtect = new byte[reader.Length];
                    await reader.ReadAsync(propertiesProtect, 0, propertiesProtect.Length);

                    var propertiesByte = ProtectedData.Unprotect(propertiesProtect, null, DataProtectionScope.LocalMachine);
                    var propertiesJson = Encoding.UTF8.GetString(propertiesByte, 0, propertiesByte.Length);
                    var properties = JsonConvert.DeserializeObject<List<KeyValuePair<string, object>>>(propertiesJson);

                    foreach (var pair in properties)
                    {
                        this.Properties.Add(pair.Key, pair.Value);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                this.Properties.Add("MyProperty1", "Value1");
            }
        }

        async void OnExit(object sender, ExitEventArgs args)
        {
            Console.WriteLine("OnExit");
//            var storage = IsolatedStorageFile.GetUserStoreForDomain();
//            using (var stream = new IsolatedStorageFileStream(_storageFileName, FileMode.Create, storage))
//            using (var writer = new StreamWriter(stream))
//            {
//                foreach (var key in this.Properties.Keys)
//                {
//                    var property = string.Format("{0},{1}", key, this.Properties[key]);
//                    await writer.WriteLineAsync(property);
//                }
//            }

            var properties = (from string key in this.Properties.Keys select new KeyValuePair<string, object>(key, this.Properties[key])).ToList();
            var storage = IsolatedStorageFile.GetUserStoreForDomain();
            using (var stream = new IsolatedStorageFileStream(_storageProtetedFileName, FileMode.Create, storage))
            using (var writer = new StreamWriter(stream).BaseStream)
            {
                var propertiesJson = JsonConvert.SerializeObject(properties);
                var propertiesByte = Encoding.UTF8.GetBytes(propertiesJson);
                var propertiesProtect = ProtectedData.Protect(propertiesByte, null, DataProtectionScope.LocalMachine);
                await writer.WriteAsync(propertiesProtect, 0, propertiesProtect.Length);
            }
        }

        void OnSessionEnding(object sender, SessionEndingCancelEventArgs args)
        {
            Console.WriteLine("OnSessionEnding");
        }

        void OnActivated(object sender, EventArgs args)
        {
            Console.WriteLine("OnActivated");
        }

        void OnDeactivated(object sender, EventArgs args)
        {
            Console.WriteLine("OnDeactivated");
        }

        void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            Console.WriteLine("OnDispatcherUnhandledException");
            Console.WriteLine(args.Exception.StackTrace);
            var errorMessage = string.Format("An unhandled exception occurred: {0}", args.Exception.Message);
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            args.Handled = true;
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            //((NavigationWindow)this.MainWindow).Navigate(new Uri("HomePage.xaml", UriKind.Relative));
        }
    }
}
