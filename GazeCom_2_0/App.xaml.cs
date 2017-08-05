using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tobii.Interaction;
using Tobii.Interaction.Wpf;

namespace GazeCom_2_0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Host TobiiHost { get; private set; }
        public WpfInteractorAgent WpfInteractorAgent { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            TobiiHost = new Host();
            WpfInteractorAgent = TobiiHost.InitializeWpfAgent();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            TobiiHost.Dispose();
            base.OnExit(e);
        }
    }
}
