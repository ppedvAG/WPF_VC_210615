using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Dieser Code wird bei Start der App ausgeführt
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            //Dieser Code wird beim Schließen der App ausgeführt
        }
    }
}
