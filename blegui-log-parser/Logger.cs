using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotPajamas
{
    public class Logger
    {
        Process _process;
        IntPtr _logHandle;
        bool _isLogging;

        public bool Initialize()
        {
            _process = GetBleGuiProcess("blegui2");
            if (_process == null)
            {
                return false;
            }

            _logHandle = GetLogWindow();
            if (_logHandle == (IntPtr)0)
            {
                return false;
            }

            return true;
        }

        public bool IsLogging()
        {
            return _isLogging;
        }

        public void Start()
        {
            _isLogging = true;
        }

        public void Stop()
        {
            _isLogging = false;
        }

        public String Capture()
        {
            SendMessage(_logHandle, WM_LBUTTONDOWN, (IntPtr)0, (IntPtr)0);
            SendMessage(_logHandle, WM_LBUTTONUP, (IntPtr)0, (IntPtr)0);

            return Clipboard.GetText();
        }

        public String ProcessCapture(String capturedText, String filterString)
        {
            if (String.IsNullOrEmpty(filterString))
            {
                return capturedText;
            }

            var filteredText = new StringBuilder();
            foreach (var line in capturedText.Split('\n'))
            {
                if (line.Contains(filterString))
                { 
                        filteredText.Append(line);
                        filteredText.Append(Environment.NewLine);
                        //Console.WriteLine(line);
                        //var timestamp = line.Substring(0, 23);
                        //var valueStart = line.IndexOf("value:") + 6;
                        //var valueEnd = line.Length - 1;
                        //var hexValue = line.Substring(valueStart, (valueEnd - valueStart));

                        //var value = new StringBuilder();
                        //for (int i = 0; i < hexValue.Length; i += 2)
                        //{
                        //    string hs = hexValue.Substring(i, 2);
                        //    value.Append(Convert.ToChar(Convert.ToUInt32(hs, 16)));
                        //} 

                        //filteredText.Append(timestamp);
                        //filteredText.Append(" ");
                        //filteredText.Append(value.ToString());
                        //filteredText.Append(Environment.NewLine);
                }
            }
            return filteredText.ToString();
        }


        private Process GetBleGuiProcess(String processName)
        {
            var bleGuiProcesses = Process.GetProcessesByName(processName);
            Process bleGuiProcess = null;
            if (bleGuiProcesses == null || bleGuiProcesses.Length == 0)
            {

            }
            else
            {
                bleGuiProcess = bleGuiProcesses[0];
            }

            return bleGuiProcess;
        }

        private IntPtr GetLogWindow()
        {
            foreach (ProcessThread threadInfo in _process.Threads)
            {
                IntPtr[] windows = GetWindowHandlesForThread(threadInfo.Id);
                if (windows != null && windows.Length > 0)
                {
                    foreach (IntPtr hWnd in windows)
                        if (GetText(hWnd) == ("pushLogCopy"))
                        {
                            return hWnd;
                        }
                }
            }

            return (IntPtr)0;
        }

        private static IntPtr[] GetWindowHandlesForThread(int threadHandle)
        {
            _results.Clear();
            EnumWindows(WindowEnum, threadHandle);
            return _results.ToArray();
        }

        // enum windows

        private delegate int EnumWindowsProc(IntPtr hwnd, int lParam);

        [DllImport("user32.Dll")]
        private static extern int EnumWindows(EnumWindowsProc x, int y);
        [DllImport("user32")]
        private static extern bool EnumChildWindows(IntPtr window, EnumWindowsProc callback, int lParam);
        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        private static List<IntPtr> _results = new List<IntPtr>();

        private static int WindowEnum(IntPtr hWnd, int lParam)
        {
            int processID = 0;
            int threadID = GetWindowThreadProcessId(hWnd, out processID);
            if (threadID == lParam)
            {
                _results.Add(hWnd);
                EnumChildWindows(hWnd, WindowEnum, threadID);
            }
            return 1;
        }

        // get window text

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        private static string GetText(IntPtr hWnd)
        {
            int length = GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        // get richedit text 

        public const int GWL_ID = -12;
        public const int WM_GETTEXT = 0x000D;
        public const int BM_CLICK = 0x00F5;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;

        [DllImport("User32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int index);
        [DllImport("User32.dll")]
        public static extern IntPtr SendDlgItemMessage(IntPtr hWnd, int IDDlgItem, int uMsg, int nMaxCount, StringBuilder lpString);
        [DllImport("User32.dll")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        private static StringBuilder GetEditText(IntPtr hWnd)
        {
            Int32 dwID = GetWindowLong(hWnd, GWL_ID);
            IntPtr hWndParent = GetParent(hWnd);
            StringBuilder title = new StringBuilder(128);
            SendDlgItemMessage(hWnd, dwID, WM_GETTEXT, 128, title);
            if (title.Equals("pushLogCopy"))
            {
                SendMessage(hWndParent, BM_CLICK, (IntPtr)0, (IntPtr)0);
            }
            
            return title;
        }
    }
}

