using System;
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
    /// Interaction logic for BasicQuestions1.xaml
    /// </summary>
    public partial class BasicQuestions1 : UserControl
    {
        public BasicQuestions1()
        {
            var appInstance = Application.Current as App;

            InitializeComponent();
        }

        private void BtnHowAreYou_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            TextToSpeech.Speak("How are you?");
        }

        private void BtnHowIsEveryone_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            TextToSpeech.Speak("How is everyone?");
        }
    }
}
