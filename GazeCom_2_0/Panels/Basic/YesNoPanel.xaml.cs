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

namespace GazeCom_2_0.Panels.Basic
{
    /// <summary>
    /// Interaction logic for YesNoPanel.xaml
    /// </summary>
    public partial class YesNoPanel : UserControl
    {
        public YesNoPanel()
        {
            //Tobii
            var appInstance = Application.Current as App;

            InitializeComponent();
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
