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
using GazeCom_2_0.Utilities;
using Tobii.Interaction.Wpf;

namespace GazeCom_2_0.Panels.Basic
{
    /// <summary>
    /// Interaction logic for BasicSelfExpression.xaml
    /// </summary>
    public partial class BasicSelfExpression : UserControl
    {
        public BasicSelfExpression()
        {
            InitializeComponent();
        }

        private void BtnHungry_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            TextToSpeech.Speak("I'm Hungry");
        }

        private void BtnBored_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            TextToSpeech.Speak("I'm Bored");
        }

        private void BtnTired_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            TextToSpeech.Speak("I'm Tired");
        }
    }
}
