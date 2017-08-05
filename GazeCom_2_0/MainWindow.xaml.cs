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
        private Host _tobiiHost;

        public MainWindow()
        {
            //Tobii
            var appInstance = Application.Current as App;
            _tobiiHost = appInstance?.TobiiHost;

            //FixationHelper
            var fixationActivator = new FixationActivator(ref _tobiiHost);
            fixationActivator.DurationToActivate = AppResources.GetFixation2ActivateTime();
            fixationActivator.OnActivate += OnFixationActivation;

            //Tobii, Gaze Data Stream
            var gazePointDataStream = _tobiiHost.Streams.CreateGazePointDataStream();
            gazePointDataStream.GazePoint(OnGazePointDataStream);

            InitializeComponent();
        }

        //Tobii Gaze, Stream
        private static void OnGazePointDataStream(double x, double y, double timeStamp)
        {
            
        }

        //Tobii, Fixation
        private static void OnFixationActivation(ref Host tobiiHost)
        {
            tobiiHost.Commands.Input.SendActivation();
        }
        
        //Activation Events
        private void BtnYes_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            TextToSpeech.Speak("Yes!");
        }

        private void BtnNo_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            TextToSpeech.Speak("No!");
        }

        private void BtnMaybe_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            TextToSpeech.Speak("Maybe!");
        }

        private void BtnCalibrate_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            //TODO: how to relaunch calibration?
            //var currProfileName = _tobiiHost.States.GetUserProfileNameAsync();

            const string configurationPath = @"C:\Program Files (x86)\Tobii\Tobii EyeX Interaction\Tobii.EyeX.Interaction.TestEyeTracking.exe";
            using (Process calibrate = Process.Start(configurationPath))
            {
                calibrate.WaitForExit();
            }
        }
    }
}
