using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GazeCom_2_0.Panels.Basic;
using GazeCom_2_0.TobiiActivator;
using GazeCom_2_0.Utilities;
using Tobii.Interaction;
using Tobii.Interaction.Client.Interop;
using Tobii.Interaction.Wpf;

namespace GazeCom_2_0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainPanelSet1Manager _mainPanelSet1Manager;

        public MainWindow()
        {
            _mainPanelSet1Manager = new MainPanelSet1Manager();

            //Tobii
            var appInstance = Application.Current as App;
            var tobiiHost = appInstance?.TobiiHost;

            //Fixation Activation Engine
            var fixationEngine = new FixationActivationEngine(ref tobiiHost);
            fixationEngine.Initialize();

            InitializeComponent();

            //Add content into the main layout
            if(_mainPanelSet1Manager.HasPanel())
                MainPanel.Content = _mainPanelSet1Manager.GetCurrentPanel();
        }

        private void BtnPrevious_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            if (!_mainPanelSet1Manager.HasPanel())
                return;

            MainPanel.Content = _mainPanelSet1Manager.GetPreviousPanel(true);
        }

        private void BtnNext_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            if (!_mainPanelSet1Manager.HasPanel())
                return;

            MainPanel.Content = _mainPanelSet1Manager.GetNextPanel(true);
        }

        private void MainWindow_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C)
            {
                //TODO, how to relaunch calibration in new Tobii SDK?
                //var currProfileName = _tobiiHost.States.GetUserProfileNameAsync();

                const string configurationPath = @"C:\Program Files (x86)\Tobii\Tobii EyeX Interaction\Tobii.EyeX.Interaction.TestEyeTracking.exe";
                using (Process calibrate = Process.Start(configurationPath))
                {
                    calibrate.WaitForExit();
                }
            }
            else if(e.Key == Key.Right)
            {
                if (!_mainPanelSet1Manager.HasPanel())
                    return;

                MainPanel.Content = _mainPanelSet1Manager.GetNextPanel(true);
            }
            else if (e.Key == Key.Left)
            {
                if (!_mainPanelSet1Manager.HasPanel())
                    return;

                MainPanel.Content = _mainPanelSet1Manager.GetPreviousPanel(true);
            }
            else if(e.Key == Key.Escape)
            {
                this.Close();
            }

        }
    }
}
