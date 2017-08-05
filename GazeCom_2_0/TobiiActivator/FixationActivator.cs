using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tobii.Interaction;

namespace GazeCom_2_0.TobiiActivator
{
    public class FixationActivator
    {
        //Delegates
        public delegate void OnActivateDelegate(ref Host tobiiHost);
        public OnActivateDelegate OnActivate;

        //Tobii
        private static Host _tobiiHost;

        //Tobii, fixation
        private bool _fixationStart;
        private double _fixationBeginTimeStamp;

        //Property
        //Time to stare to invoke OnActivate, in Miliseconds
        public double DurationToActivate { get; set; }

        public FixationActivator(ref Host tobiiHost)
        {
            _tobiiHost = tobiiHost;

            _fixationStart = false;
            _fixationBeginTimeStamp = 0;
            DurationToActivate = 500; //miliseconds

            var fixationDataStream = tobiiHost.Streams.CreateFixationDataStream();
            fixationDataStream.Begin(OnFixationDataStreamBegin);
            fixationDataStream.Data(OnFixationDataStreamData);
            fixationDataStream.End(OnFixationDataStreamEnd);
        }

        //Tobii Fixation, Begin
        private void OnFixationDataStreamBegin(double x, double y, double timeStamp)
        {
            _fixationStart = true;
            _fixationBeginTimeStamp = timeStamp;
        }

        //Tobii Fixation, Data
        private bool IsFixationActivated(double timeStamp)
        {
            return timeStamp - _fixationBeginTimeStamp > DurationToActivate;
        }

        private void OnFixationDataStreamData(double x, double y, double timeStamp)
        {
            if (!IsFixationActivated(timeStamp))
                return;

            _fixationBeginTimeStamp = 0;

            if (!_fixationStart)
                return;

            OnActivate?.Invoke(ref _tobiiHost);
            _fixationStart = false;
        }

        //Tobii Fixation, End
        private void OnFixationDataStreamEnd(double x, double y, double timeStamp)
        {
            _fixationStart = false;
            _fixationBeginTimeStamp = 0;
        }


    }
}
