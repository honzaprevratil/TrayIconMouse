using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrayIcon
{
    public class MouseProfile
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MouseSpeed { get; set; }
        public int DoubleClickTime { get; set; }
        public int WheelScrollLines { get; set; }

        public MouseProfile() { }
        public MouseProfile(int id, string name, int mouseSpeed, int doubleClickTime, int wheelScrollLines)
        {
            Id = id;
            Name = name;
            MouseSpeed = mouseSpeed;
            DoubleClickTime = doubleClickTime;
            WheelScrollLines = wheelScrollLines;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
