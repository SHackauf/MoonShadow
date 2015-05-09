using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Resources;

namespace ExampleResourcen.Xaml
{
    /// <summary>
    /// Interaction logic for ResourceDictionaryExample.xaml
    /// </summary>
    public partial class ResourceDictionaryExample : Page
    {
        public ResourceDictionaryExample()
        {
            InitializeComponent();
        }

        private void Merge_Click(object sender, RoutedEventArgs e)
        {
//            MergedDictionaries1();
//            MergedDictionaries2();
            MergedDictionaries3();
        }

        private void MergedDictionaries1()
        {
            //var resource1 = Application.LoadComponent(new Uri("Xaml/Style/MyResourceDictionary.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;
            //this.Resources = resource1;
            var resource2 = Application.LoadComponent(new Uri("Xaml/Style/MyResourceDictionary2.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;
            this.Resources.MergedDictionaries.Add(resource2);
        }

        private void MergedDictionaries2()
        {
            this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("Xaml/Style/MyResourceDictionary2.xaml", UriKind.RelativeOrAbsolute) });
        }

        private void MergedDictionaries3()
        {
            this.Resources = new ResourceDictionary();

            var root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!String.IsNullOrEmpty(root))
            {
                var resourcesDirectory = Path.Combine(root, "Xaml\\Style");
                var content = new ParserContext
                {
                    BaseUri = new Uri(resourcesDirectory, UriKind.Absolute)
                };
                if (Directory.Exists(resourcesDirectory))
                {
                    foreach (var file in Directory.GetFiles(resourcesDirectory, "*.xaml"))
                    {
                        using (var stream = File.Open(file, FileMode.Open, FileAccess.Read))
                        {
                            try
                            {
                                var resourceDictionary = XamlReader.Load(stream, content) as ResourceDictionary;
                                if (resourceDictionary != null)
                                {
                                    Resources.MergedDictionaries.Add(resourceDictionary);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Invalid xaml: " + file);
                            }
                        }
                    }
                }
            }
        }
    }
}
