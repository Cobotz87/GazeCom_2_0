using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GazeCom_2_0.Utilities;
using Tobii.Interaction;

namespace GazeCom_2_0.TobiiActivator
{
    public class FixationActivationEngine
    {
        //Delegates
        public delegate void OnPreActivateDelegate(ref Host tobiiHost);
        public delegate void OnPostActivateDelegate(ref Host tobiiHost);
        public OnPreActivateDelegate OnPreActivate;
        public OnPostActivateDelegate OnPostActivate;

        private Host _tobiiHost;

        public FixationActivationEngine(ref Host tobiiHost)
        {
            _tobiiHost = tobiiHost;
        }

        public void Initialize()
        {
            var fixationActivator =
                new FixationActivator(ref _tobiiHost) { DurationToActivate = AppResources.GetFixation2ActivateTime() };
            fixationActivator.OnActivate += OnFixationActivation;
        }

        private void OnFixationActivation(ref Host tobiiHost)
        {
            OnPreActivate?.Invoke(ref tobiiHost);
            tobiiHost.Commands.Input.SendActivation();
            OnPostActivate?.Invoke(ref tobiiHost);
        }
    }
}
