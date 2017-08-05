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
using Tobii.Interaction;
using Tobii.Interaction.Wpf;

namespace GazeCom_2_0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private App _appInstance;

        //Tobii
        private static Host _tobiiHost;

        //Tobii, fixation
        private static bool _fixationStart;
        private static double _fixationBeginTimeStamp;
        private static double _fixationActivationDuration;

        public MainWindow()
        {
            //This
            _fixationStart = false;
            _fixationBeginTimeStamp = 0;
            _fixationActivationDuration = 500;

            //Tobii
            _appInstance = Application.Current as App;
            _tobiiHost = _appInstance?.TobiiHost;

            var gazePointDataStream = _tobiiHost.Streams.CreateGazePointDataStream();
            gazePointDataStream.GazePoint(OnGazePointDataStream);

            var fixationDataStream = _tobiiHost.Streams.CreateFixationDataStream();
            fixationDataStream.Begin(OnFixationDataStreamBegin);
            fixationDataStream.Data(OnFixationDataStreamData);
            fixationDataStream.End(OnFixationDataStreamEnd);

            InitializeComponent();
        }

        //Tobii Gaze, Stream
        private static void OnGazePointDataStream(double x, double y, double timeStamp)
        {
            
        }

        //Tobii Fixation, Begin
        private static void OnFixationDataStreamBegin(double x, double y, double timeStamp)
        {
            _fixationStart = true;
            _fixationBeginTimeStamp = timeStamp;
        }

        //Tobii Fixation, Data
        private static bool IsFixationActivated(double timeStamp)
        {
            return timeStamp - _fixationBeginTimeStamp > _fixationActivationDuration;
        }

        private static void OnFixationDataStreamData(double x, double y, double timeStamp)
        {
            if (!IsFixationActivated(timeStamp))
                return;

            _fixationBeginTimeStamp = 0;

            if (!_fixationStart)
                return;

            _tobiiHost.Commands.Input.SendActivation();
            _fixationStart = false;
        }

        //Tobii Fixation, End
        private static void OnFixationDataStreamEnd(double x, double y, double timeStamp)
        {
            _fixationStart = false;
            _fixationBeginTimeStamp = 0;
        }

        
        //Activation Events
        private void BtnYes_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            MessageBox.Show("BtnYes_OnActivated is indeed activated!");
        }

        private void BtnNo_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            MessageBox.Show("BtnNo_OnActivated is indeed activated!");
        }

        private void BtnMaybe_OnActivated(object sender, ActivationRoutedEventArgs e)
        {
            MessageBox.Show("BtnMaybe_OnActivated is indeed activated!");
        }
    }
}
