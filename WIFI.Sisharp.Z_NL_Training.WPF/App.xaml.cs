using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WIFI.Sisharp.Z_NL_Training.WPF
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        [System.STAThread]
        public static void Main()
        {
            WIFI.Sisharp.Z_NL_Training.WPF.App app = new WIFI.Sisharp.Z_NL_Training.WPF.App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
