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

namespace GazeCom_2_0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private App _appInstance;
        private Host _tobiiHost;

        public MainWindow()
        {
            _appInstance = Application.Current as App;
            _tobiiHost = _appInstance?.TobiiHost;

            var gazePointDataStream = _tobiiHost.Streams.CreateGazePointDataStream();
            gazePointDataStream.GazePoint(OnGazePointDataStream);

            InitializeComponent();
        }

        private static void OnGazePointDataStream(double x, double y, double timeStamp)
        {
            
        }
    }
}
