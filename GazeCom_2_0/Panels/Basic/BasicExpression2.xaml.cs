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
    public partial class BasicSelfExpression2 : UserControl
    {
        public BasicSelfExpression2()
        {
            InitializeComponent();
        }

        private void Btn1_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            TextToSpeech.Speak("That is good!");
        }

        private void Btn2_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            TextToSpeech.Speak("That is bad!");
        }

        private void Btn3_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            TextToSpeech.Speak("That is Weird!");
        }
    }
}
