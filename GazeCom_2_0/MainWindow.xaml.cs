﻿using System;
using System.Collections.Generic;
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
using Tobii.Interaction.Wpf;

namespace GazeCom_2_0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Tobii
            var appInstance = Application.Current as App;
            var tobiiHost = appInstance?.TobiiHost;

            //FixationHelper
            var fixationActivator = new FixationActivator(ref tobiiHost);
            fixationActivator.DurationToActivate = 500;
            fixationActivator.OnActivate += OnFixationActivation;

            //Tobii, Gaze Data Stream
            var gazePointDataStream = tobiiHost.Streams.CreateGazePointDataStream();
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
    }
}
