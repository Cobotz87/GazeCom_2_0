using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GazeCom_2_0.Utilities
{
    public static class AppResources
    {
        //in Miliseconds, -1 if not found
        public static double GetFixation2ActivateTime()
        {
            var appInstance = Application.Current as App;

            if (appInstance == null)
                return -1;

            var resource = appInstance.FindResource("Fixation2ActivateTime");

            if (resource == null)
                return -1;

            try
            {
                var duration = ((Duration) resource);

                if (!duration.HasTimeSpan)
                    return -1;

                return duration.TimeSpan.TotalMilliseconds;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR @ Constants.GetFixation2ActivateTime");
                Console.WriteLine(e);
            }

            return -1;
        }

    }
}
