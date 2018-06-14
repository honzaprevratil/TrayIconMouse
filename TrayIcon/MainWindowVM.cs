using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TrayIcon
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ObservableCollection<MouseProfile> MouseProfiles { get; set; } = new ObservableCollection<MouseProfile>();

        private MouseSettingDatabase DB = new MouseSettingDatabase();

        private MouseProfile selectedMouseProfile;
        public MouseProfile SelectedMouseProfile
        {
            get
            {
                return selectedMouseProfile;
            }
            set
            {
                selectedMouseProfile = value;

                if (selectedMouseProfile != null)
                {
                    MouseSpeed = selectedMouseProfile.MouseSpeed;
                    DoubleClickTime = selectedMouseProfile.DoubleClickTime;
                    WheelScrollLines = selectedMouseProfile.WheelScrollLines;
                }

                OnPropertyChanged("SelectedMouseProfile");
            }
        }

        public MainWindowVM()
        {
            MouseSpeed = MouseSettings.GetMouseSpeed();
            DoubleClickTime = MouseSettings.GetDoubleClickTime();
            WheelScrollLines = MouseSettings.GetWheelScrollLines();

            foreach (MouseProfile profile in DB.GetItems())
            {
                MouseProfiles.Add(profile);
            }

            SelectedMouseProfile = MouseProfiles.Count > 0 ? MouseProfiles[0] : null;
        }

        private int mouseSpeed;
        public int MouseSpeed
        {
            get
            {
                return mouseSpeed;
            }
            set
            {
                mouseSpeed = value;
                MouseSettings.SetMouseSpeed(value);

                if (selectedMouseProfile != null)
                {
                    selectedMouseProfile.MouseSpeed = value;
                    DB.SaveItem(selectedMouseProfile);
                }

                OnPropertyChanged("MouseSpeed");
            }
        }

        private int doubleClickTime;
        public int DoubleClickTime
        {
            get
            {
                return doubleClickTime;
            }
            set
            {
                doubleClickTime = value;
                MouseSettings.SetDoubleClickTime(value);

                if (selectedMouseProfile != null)
                {
                    selectedMouseProfile.DoubleClickTime = value;
                    DB.SaveItem(selectedMouseProfile);
                }

                OnPropertyChanged("DoubleClickTime");
            }
        }

        private int wheelScrollLines;
        public int WheelScrollLines
        {
            get
            {
                return wheelScrollLines;
            }
            set
            {
                wheelScrollLines = value;
                MouseSettings.SetWheelScrollLines(value);

                if (selectedMouseProfile != null)
                {
                    selectedMouseProfile.WheelScrollLines = value;
                    DB.SaveItem(selectedMouseProfile);
                }

                OnPropertyChanged("WheelScrollLines");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
