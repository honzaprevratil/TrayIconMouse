using System;
using System.Runtime.InteropServices;
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
using System.Diagnostics;
using System.Windows.Forms;

namespace TrayIcon
{
    public class MouseSettings
    {
        private const UInt32 SPI_SETMOUSESPEED = 0x0071;
        private const UInt32 SPI_SETDOUBLECLICKTIME = 0x0020;
        private const UInt32 SPI_SETWHEELSCROLLLINES = 0x0069;

        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, UInt32 pvParam, UInt32 fWinIni);

        // SETTERS
        public static void SetMouseSpeed(int mouseSpeed)
        {
            SystemParametersInfo(
                SPI_SETMOUSESPEED,
                0,
                (uint)mouseSpeed,
                0);
            Debug.WriteLine("Actual speed of cursor: " + mouseSpeed);
        }
        public static void SetDoubleClickTime(int doubleClickSpeed)
        {
            SystemParametersInfo(
                SPI_SETDOUBLECLICKTIME,
                (uint)doubleClickSpeed, 
                0,
                0);
            Debug.WriteLine("Actual double click time: " + doubleClickSpeed + " ms");
        }
        public static void SetWheelScrollLines(int scrollLines)
        {
            SystemParametersInfo(
                SPI_SETWHEELSCROLLLINES,
                (uint)scrollLines,
                0,
                0);
            Debug.WriteLine("Actual wheel scroll lines: " + scrollLines);
        }

        // GETTERS
        public static int GetMouseSpeed()
        {
            return SystemInformation.MouseSpeed;
        }
        public static int GetDoubleClickTime()
        {
            return SystemInformation.DoubleClickTime;
        }
        public static int GetWheelScrollLines()
        {
            return SystemInformation.MouseWheelScrollLines;
        }
    }
}
