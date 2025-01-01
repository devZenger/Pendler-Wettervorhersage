using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage.Service
{
    internal class SettingsManager
    {
        public string HometownLocation
        {
            get => Properties.Settings.Default.HometownLocation;
            set
            {
                Properties.Settings.Default.HometownLocation = value;
                Properties.Settings.Default.Save();
            }
        }
        public string HometownSartTime 
        {
            get => Properties.Settings.Default.HometownStartTime;
            set
            {
                Properties.Settings.Default.HometownStartTime = value;
                Properties.Settings.Default.Save();
            }
        }
        public string HometownEndTime
        {
            get => Properties.Settings.Default.HometownEndTime;
            set
            {
                Properties.Settings.Default.HometownEndTime = value;
                Properties.Settings.Default.Save();
            }
        }

        public string WorkplaceLocation
        {
            get => Properties.Settings.Default.HometownLocation;
            set
            {
                Properties.Settings.Default.HometownLocation = value;
                Properties.Settings.Default.Save();
            }
        }
        public string WorkplaceSartTime
        {
            get => Properties.Settings.Default.WorkplaceStartTime;
            set
            {
                Properties.Settings.Default.WorkplaceStartTime = value;
                Properties.Settings.Default.Save();
            }
        }
        public string WorkplaceEndTimer
        {
            get => Properties.Settings.Default.WorkplaceEndTime;
            set
            {
                Properties.Settings.Default.WorkplaceEndTime = value;
                Properties.Settings.Default.Save();
            }
        }



    }
}
