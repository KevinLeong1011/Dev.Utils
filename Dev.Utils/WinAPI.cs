/******************************************
* 类名称：WinAPI
* 类描述：WindowsAPI操作
* 创建人：梁超
* 创建时间：2017/1/18 18:30
* 修改时间：
* 修改说明：
* @Version 1.0
 * *****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace DevAssistant.Common.SysHelpers
{

    //    key kk = new key();
    //            //  IntPtr a = new IntPtr();
    //            kk.sendwinio();
    //            kk.MykeyDown((int)key.VirtualKeys.VK_F1);
    //            System.Threading.Thread.Sleep(2000);
    //            kk.MykeyUp((int)key.VirtualKeys.VK_F1);
    //这是模拟键盘的调用方式

    public class WinAPI1
    {
        #region Const

        const uint PROCESS_ALL_ACCESS = 0x001F0FFF;
        const uint KEYEVENTF_EXTENDEDKEY = 0x1;
        const uint KEYEVENTF_KEYUP = 0x2;
        const uint KBC_KEY_CMD = 0x64;
        const uint KBC_KEY_DATA = 0x60;

        #endregion

        #region Public Methods

        #region 键盘操作

        /// <summary>
        /// 发送键盘事件
        /// </summary>
        /// <returns></returns>
        public static void SendKey(VirtualKeys Key, bool State)
        {
            if (State != GetKeybdState(Key))
            {
                keybd_event(Key, MapVirtualKey((byte)Key, 0), 0, 0);
                Thread.Sleep(100);
                keybd_event(Key, MapVirtualKey((byte)Key, 0), KEYEVENTF_KEYUP, 0);
            }
        }

        /// <summary>
        /// 发送组合键
        /// </summary>
        /// <param name="keys"></param>
        public static void SendKeys(params VirtualKeys[] keys)
        {
            foreach (VirtualKeys key in keys)
            {
                keybd_event(key, MapVirtualKey((byte)key, 0), 0, 0);
            }

            foreach (VirtualKeys key in keys.Reverse())
            {
                keybd_event(key, MapVirtualKey((byte)key, 0), KEYEVENTF_KEYUP, 0);
            }
        }

        /// <summary>
        /// 获取键盘状态
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        private static bool GetKeybdState(VirtualKeys Key)
        {
            return (GetKeyState((int)Key) == 1);
        }

        #endregion

        #endregion

        #region API Definitions

        // 得到当前活动窗口的句柄
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        // 键盘事件
        [DllImport("user32.dll")]
        public static extern byte MapVirtualKey(byte wCode, int wMap);

        /// <summary>
        /// 获取指定虚拟键状态
        /// </summary>
        /// <param name="nVirtKey"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(VirtualKeys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        //得到窗体句柄的函数,FindWindow函数用来返回符合指定的类名( ClassName )和窗口名( WindowTitle )的窗口句柄
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 获取指定窗口句柄进程ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
        public static extern int GetWindowThreadProcessId(IntPtr id, out int pid);

        /// <summary>
        /// 获取指定窗口句柄进程ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
        public static extern int GetWindowThreadProcessId(IntPtr id, int pid);

        [DllImport("user32.dll")]
        static extern void mouse_event(mouseeventflag flags, int dx, int dy, uint data, UIntPtr extrainfo);

        //读取进程内存的函数
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(uint hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, uint nSize, ref   uint lpNumberOfBytesRead);

        #endregion

        #region Fields

        private readonly int MOUSEEVENTF_LEFTDOWN = 0x2;
        private readonly int MOUSEEVENTF_LEFTUP = 0x4;

        #endregion




        [DllImport("kernel32.dll")]
        private static extern void CloseHandle(uint hObject);

        //得到目标进程句柄的函数
        [DllImport("kernel32.dll")]
        public static extern uint OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        //鼠标事件声明
        [DllImport("user32.dll")]
        static extern bool setcursorpos(int x, int y);


        //键盘事件声明winio
        [DllImport("winio.dll")]
        public static extern bool InitializeWinIo();
        [DllImport("winio.dll")]
        public static extern bool GetPortVal(IntPtr wPortAddr, out int pdwPortVal, byte bSize);
        [DllImport("winio.dll")]
        public static extern bool SetPortVal(uint wPortAddr, IntPtr dwPortVal, byte bSize);
        [DllImport("winio.dll")]
        public static extern byte MapPhysToLin(byte pbPhysAddr, uint dwPhysSize, IntPtr PhysicalMemoryHandle);
        [DllImport("winio.dll")]
        public static extern bool UnmapPhysicalMemory(IntPtr PhysicalMemoryHandle, byte pbLinAddr);
        [DllImport("winio.dll")]
        public static extern bool GetPhysLong(IntPtr pbPhysAddr, byte pdwPhysVal);
        [DllImport("winio.dll")]
        public static extern bool SetPhysLong(IntPtr pbPhysAddr, byte dwPhysVal);
        [DllImport("winio.dll")]
        public static extern void ShutdownWinIo();

        /// <summary>
        /// 获取进程pid
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int pid(String name)
        {
            try
            {

                ObjectQuery oQuery = new ObjectQuery("select * from Win32_Process where Name='" + name + "'");
                ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oQuery);
                ManagementObjectCollection oReturnCollection = oSearcher.Get();

                string pid = "";
                string cmdLine;
                StringBuilder sb = new StringBuilder();
                foreach (ManagementObject oReturn in oReturnCollection)
                {
                    pid = oReturn.GetPropertyValue("ProcessId").ToString();
                    //cmdLine = (string)oReturn.GetPropertyvalue("CommandLine");

                    //string pattern = "-ap "(.*)"";
                    //Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                    // Match match = regex.Match(cmdLine);
                    //string appPoolName = match.Groups[1].ToString();
                    //sb.AppendFormat("W3WP.exe PID: {0}   AppPoolId:{1} ", pid, appPoolName);
                }
                return Convert.ToInt32(pid);
            }
            catch (Exception ss)
            { return 0; }

        }
        private int pid(IntPtr id)
        {
            int pid = 0;
            pid = GetWindowThreadProcessId(id, pid);
            return 260;
        }
        /// <summary>
        /// 读取内存值
        /// </summary>
        /// <param name="name">进程id</param>
        /// <param name="dizhi">读取的内存地址</param>
        /// <returns></returns>
        //public String getread(String QEC,String EC, IntPtr dizhi, uint size)
        //{
        //    Byte bt = new Byte();
        //    IntPtr id=FindWindow(QEC, EC);
        //    uint hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, pid(id));
        //    IntPtr fanhui = new IntPtr();
        //    String gg = null;
        //    if (hProcess == 0)
        //    {
        //       // gg = ReadProcessMemory(hProcess, dizhi, fanhui, size, 0);
        //       // CloseHandle(hProcess);


        //    }
        //    return gg;
        //}
        public String getread(String jincheng, String EC, IntPtr dizhi, uint size)
        {
            byte[] vBuffer = new byte[4];
            IntPtr vBytesAddress = Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0); // 得到缓冲区的地址 

            uint vNumberOfBytesRead = 0;
            Byte bt = new Byte();
            //IntPtr id = FindWindow(QEC, EC);
            uint hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, pid(jincheng));
            //pid(0);
            IntPtr fanhui = new IntPtr();
            String gg = null;
            //if (hProcess == 0)
            //{
            if (ReadProcessMemory(hProcess, dizhi, vBytesAddress, (uint)vBuffer.Length, ref hProcess))
            {
                CloseHandle(hProcess);
            }
            else
            {
                CloseHandle(hProcess);
            }

            // }
            int vInt = Marshal.ReadInt32(vBytesAddress);
            return vInt.ToString();
        }



        /// <summary>
        /// 初始化winio
        /// </summary>
        public void sendwinio()
        {
            if (InitializeWinIo())
            {
                KBCWait4IBE();
            }
        }
        private void KBCWait4IBE() //等待键盘缓冲区为空
        {
            //int[] dwVal = new int[] { 0 };
            int dwVal = 0;
            do
            {
                //这句表示从&H64端口读取一个字节并把读出的数据放到变量dwVal中
                //GetPortVal函数的用法是GetPortVal 端口号,存放读出数据的变量,读入的长度
                bool flag = GetPortVal((IntPtr)0x64, out dwVal, 1);
            }
            while ((dwVal & 0x2) > 0);
        }
        /// <summary>
        /// 模拟键盘标按下
        /// </summary>
        /// <param name="vKeyCoad"></param>
        public void MykeyDown(int vKeyCoad)
        {
            int btScancode = 0;

            btScancode = MapVirtualKey((byte)vKeyCoad, 0);
            // btScancode = vKeyCoad;

            KBCWait4IBE(); // '发送数据前应该先等待键盘缓冲区为空
            SetPortVal(KBC_KEY_CMD, (IntPtr)0xD2, 1);// '发送键盘写入命令
            //SetPortVal函数用于向端口写入数据，它的用法是SetPortVal 端口号,欲写入的数据，写入数据的长度
            KBCWait4IBE();
            SetPortVal(KBC_KEY_DATA, (IntPtr)0xe2, 1);// '写入按键信息,按下键
            KBCWait4IBE(); // '发送数据前应该先等待键盘缓冲区为空
            SetPortVal(KBC_KEY_CMD, (IntPtr)0xD2, 1);// '发送键盘写入命令
            //SetPortVal函数用于向端口写入数据，它的用法是SetPortVal 端口号,欲写入的数据，写入数据的长度
            KBCWait4IBE();
            SetPortVal(KBC_KEY_DATA, (IntPtr)btScancode, 1);// '写入按键信息,按下键

        }

        /// <summary>
        /// 模拟键盘弹出
        /// </summary>
        /// <param name="vKeyCoad"></param>
        public void MykeyUp(int vKeyCoad)
        {
            int btScancode = 0;
            btScancode = MapVirtualKey((byte)vKeyCoad, 0);
            //btScancode = vKeyCoad;

            KBCWait4IBE(); // '发送数据前应该先等待键盘缓冲区为空
            SetPortVal(KBC_KEY_CMD, (IntPtr)0xD2, 1); //'发送键盘写入命令
            KBCWait4IBE();
            SetPortVal(KBC_KEY_DATA, (IntPtr)0xe0, 1);// '写入按键信息，释放键
            KBCWait4IBE(); // '发送数据前应该先等待键盘缓冲区为空
            SetPortVal(KBC_KEY_CMD, (IntPtr)0xD2, 1); //'发送键盘写入命令
            KBCWait4IBE();
            SetPortVal(KBC_KEY_DATA, (IntPtr)btScancode, 1);// '写入按键信息，释放键
        }

        /// <summary>
        /// 模拟鼠标按下
        /// </summary>
        /// <param name="vKeyCoad"></param>
        public void MyMouseDown(int vKeyCoad)
        {
            int btScancode = 0;

            btScancode = MapVirtualKey((byte)vKeyCoad, 0);
            //btScancode = vKeyCoad;

            KBCWait4IBE(); // '发送数据前应该先等待键盘缓冲区为空
            SetPortVal(KBC_KEY_CMD, (IntPtr)0xD3, 1);// '发送键盘写入命令
            //SetPortVal函数用于向端口写入数据，它的用法是SetPortVal 端口号,欲写入的数据，写入数据的长度
            KBCWait4IBE();
            SetPortVal(KBC_KEY_DATA, (IntPtr)(btScancode | 0x80), 1);// '写入按键信息,按下键

        }
        /// <summary>
        /// 模拟鼠标弹出
        /// </summary>
        /// <param name="vKeyCoad"></param>
        public void MyMouseUp(int vKeyCoad)
        {
            int btScancode = 0;
            btScancode = MapVirtualKey((byte)vKeyCoad, 0);
            // btScancode = vKeyCoad;

            KBCWait4IBE(); // '发送数据前应该先等待键盘缓冲区为空
            SetPortVal(KBC_KEY_CMD, (IntPtr)0xD3, 1); //'发送键盘写入命令
            KBCWait4IBE();
            SetPortVal(KBC_KEY_DATA, (IntPtr)(btScancode | 0x80), 1);// '写入按键信息，释放键
        }
        /// <summary>
        /// 发送鼠标事件
        /// </summary>
        /// <returns></returns>
        public void SendMouse()
        {

        }
        /// <summary>
        /// 鼠标动作枚举
        /// </summary>
        public enum mouseeventflag : uint
        {
            move = 0x0001,
            leftdown = 0x0002,
            leftup = 0x0004,
            rightdown = 0x0008,
            rightup = 0x0010,
            middledown = 0x0020,
            middleup = 0x0040,
            xdown = 0x0080,
            xup = 0x0100,
            wheel = 0x0800,
            virtualdesk = 0x4000,
            absolute = 0x8000
        }



        ///// <summary>
        ///// 键盘动作枚举
        ///// </summary>
        //public enum VirtualKeys : byte
        //{
        //    //VK_NUMLOCK = 0x90, //数字锁定键
        //    //VK_SCROLL = 0x91,  //滚动锁定
        //    //VK_CAPITAL = 0x14, //大小写锁定
        //    //VK_A = 62,         //键盘A
        //    VK_LBUTTON = 1,      //鼠标左键 
        //    VK_RBUTTON = 2,　    //鼠标右键 
        //    VK_CANCEL = 3,　　　 //Ctrl+Break(通常不需要处理) 
        //    VK_MBUTTON = 4,　　  //鼠标中键 
        //    VK_BACK = 8, 　　　  //Backspace 
        //    VK_TAB = 9,　　　　  //Tab 
        //    VK_CLEAR = 12,　　　 //Num Lock关闭时的数字键盘5 
        //    VK_RETURN = 13,　　　//Enter(或者另一个) 
        //    VK_SHIFT = 16,　　　 //Shift(或者另一个) 
        //    VK_CONTROL = 17,　　 //Ctrl(或者另一个） 
        //    VK_MENU = 18,　　　　//Alt(或者另一个) 
        //    VK_PAUSE = 19,　　　 //Pause 
        //    VK_CAPITAL = 20,　　 //Caps Lock 
        //    VK_ESCAPE = 27,　　　//Esc 
        //    VK_SPACE = 32,　　　 //Spacebar 
        //    VK_PRIOR = 33,　　　 //Page Up 
        //    VK_NEXT = 34,　　　　//Page Down 
        //    VK_END = 35,　　　　 //End 
        //    VK_HOME = 36,　　　　//Home 
        //    VK_LEFT = 37,　　　  //左箭头 
        //    VK_UP = 38,　　　　  //上箭头 
        //    VK_RIGHT = 39,　　　 //右箭头 
        //    VK_DOWN = 40,　　　  //下箭头 
        //    VK_SELECT = 41,　　  //可选 
        //    VK_PRINT = 42,　　　 //可选 
        //    VK_EXECUTE = 43,　　 //可选 
        //    VK_SNAPSHOT = 44,　　//Print Screen 
        //    VK_INSERT = 45,　　　//Insert 
        //    VK_DELETE = 46,　　  //Delete 
        //    VK_HELP = 47,　　    //可选 
        //    VK_NUM0 = 48,        //0
        //    VK_NUM1 = 49,        //1
        //    VK_NUM2 = 50,        //2
        //    VK_NUM3 = 51,        //3
        //    VK_NUM4 = 52,        //4
        //    VK_NUM5 = 53,        //5
        //    VK_NUM6 = 54,        //6
        //    VK_NUM7 = 55,        //7
        //    VK_NUM8 = 56,        //8
        //    VK_NUM9 = 57,        //9
        //    VK_A = 65,           //A
        //    VK_B = 66,           //B
        //    VK_C = 67,           //C
        //    VK_D = 68,           //D
        //    VK_E = 69,           //E
        //    VK_F = 70,           //F
        //    VK_G = 71,           //G
        //    VK_H = 72,           //H
        //    VK_I = 73,           //I
        //    VK_J = 74,           //J
        //    VK_K = 75,           //K
        //    VK_L = 76,           //L
        //    VK_M = 77,           //M
        //    VK_N = 78,           //N
        //    VK_O = 79,           //O
        //    VK_P = 80,           //P
        //    VK_Q = 81,           //Q
        //    VK_R = 82,           //R
        //    VK_S = 83,           //S
        //    VK_T = 84,           //T
        //    VK_U = 85,           //U
        //    VK_V = 86,           //V
        //    VK_W = 87,           //W
        //    VK_X = 88,           //X
        //    VK_Y = 89,           //Y
        //    VK_Z = 90,           //Z
        //    VK_NUMPAD0 = 96,     //0
        //    VK_NUMPAD1 = 97,     //1
        //    VK_NUMPAD2 = 98,     //2
        //    VK_NUMPAD3 = 99,     //3
        //    VK_NUMPAD4 = 100,    //4
        //    VK_NUMPAD5 = 101,    //5
        //    VK_NUMPAD6 = 102,    //6
        //    VK_NUMPAD7 = 103,    //7
        //    VK_NUMPAD8 = 104,    //8
        //    VK_NUMPAD9 = 105,    //9
        //    VK_NULTIPLY = 106,　 //数字键盘上的* 
        //    VK_ADD = 107,　　　　//数字键盘上的+ 
        //    VK_SEPARATOR = 108,　//可选 
        //    VK_SUBTRACT = 109,　 //数字键盘上的- 
        //    VK_DECIMAL = 110,　　//数字键盘上的. 
        //    VK_DIVIDE = 111,　　 //数字键盘上的/
        //    VK_F1 = 112,
        //    VK_F2 = 113,
        //    VK_F3 = 114,
        //    VK_F4 = 115,
        //    VK_F5 = 116,
        //    VK_F6 = 117,
        //    VK_F7 = 118,
        //    VK_F8 = 119,
        //    VK_F9 = 120,
        //    VK_F10 = 121,
        //    VK_F11 = 122,
        //    VK_F12 = 123,
        //    VK_NUMLOCK = 144,　　//Num Lock 
        //    VK_SCROLL = 145 　   // Scroll Lock 
        //}
    }

    public enum VirtualKeys
    {
        // Summary:
        //     The bitmask to extract modifiers from a key value.
        Modifiers = -65536,
        //
        // Summary:
        //     No key pressed.
        None = 0,
        //
        // Summary:
        //     The left mouse button.
        LButton = 1,
        //
        // Summary:
        //     The right mouse button.
        RButton = 2,
        //
        // Summary:
        //     The CANCEL key.
        Cancel = 3,
        //
        // Summary:
        //     The middle mouse button (three-button mouse).
        MButton = 4,
        //
        // Summary:
        //     The first x mouse button (five-button mouse).
        XButton1 = 5,
        //
        // Summary:
        //     The second x mouse button (five-button mouse).
        XButton2 = 6,
        //
        // Summary:
        //     The BACKSPACE key.
        Back = 8,
        //
        // Summary:
        //     The TAB key.
        Tab = 9,
        //
        // Summary:
        //     The LINEFEED key.
        LineFeed = 10,
        //
        // Summary:
        //     The CLEAR key.
        Clear = 12,
        //
        // Summary:
        //     The ENTER key.
        Enter = 13,
        //
        // Summary:
        //     The RETURN key.
        Return = 13,
        //
        // Summary:
        //     The SHIFT key.
        ShiftKey = 16,
        //
        // Summary:
        //     The CTRL key.
        ControlKey = 17,
        //
        // Summary:
        //     The ALT key.
        Menu = 18,
        //
        // Summary:
        //     The PAUSE key.
        Pause = 19,
        //
        // Summary:
        //     The CAPS LOCK key.
        CapsLock = 20,
        //
        // Summary:
        //     The CAPS LOCK key.
        Capital = 20,
        //
        // Summary:
        //     The IME Kana mode key.
        KanaMode = 21,
        //
        // Summary:
        //     The IME Hanguel mode key. (maintained for compatibility; use HangulMode)
        HanguelMode = 21,
        //
        // Summary:
        //     The IME Hangul mode key.
        HangulMode = 21,
        //
        // Summary:
        //     The IME Junja mode key.
        JunjaMode = 23,
        //
        // Summary:
        //     The IME final mode key.
        FinalMode = 24,
        //
        // Summary:
        //     The IME Kanji mode key.
        KanjiMode = 25,
        //
        // Summary:
        //     The IME Hanja mode key.
        HanjaMode = 25,
        //
        // Summary:
        //     The ESC key.
        Escape = 27,
        //
        // Summary:
        //     The IME convert key.
        IMEConvert = 28,
        //
        // Summary:
        //     The IME nonconvert key.
        IMENonconvert = 29,
        //
        // Summary:
        //     The IME accept key. Obsolete, use System.Windows.Forms.Keys.IMEAccept instead.
        IMEAceept = 30,
        //
        // Summary:
        //     The IME accept key, replaces System.Windows.Forms.Keys.IMEAceept.
        IMEAccept = 30,
        //
        // Summary:
        //     The IME mode change key.
        IMEModeChange = 31,
        //
        // Summary:
        //     The SPACEBAR key.
        Space = 32,
        //
        // Summary:
        //     The PAGE UP key.
        Prior = 33,
        //
        // Summary:
        //     The PAGE UP key.
        PageUp = 33,
        //
        // Summary:
        //     The PAGE DOWN key.
        Next = 34,
        //
        // Summary:
        //     The PAGE DOWN key.
        PageDown = 34,
        //
        // Summary:
        //     The END key.
        End = 35,
        //
        // Summary:
        //     The HOME key.
        Home = 36,
        //
        // Summary:
        //     The LEFT ARROW key.
        Left = 37,
        //
        // Summary:
        //     The UP ARROW key.
        Up = 38,
        //
        // Summary:
        //     The RIGHT ARROW key.
        Right = 39,
        //
        // Summary:
        //     The DOWN ARROW key.
        Down = 40,
        //
        // Summary:
        //     The SELECT key.
        Select = 41,
        //
        // Summary:
        //     The PRINT key.
        Print = 42,
        //
        // Summary:
        //     The EXECUTE key.
        Execute = 43,
        //
        // Summary:
        //     The PRINT SCREEN key.
        PrintScreen = 44,
        //
        // Summary:
        //     The PRINT SCREEN key.
        Snapshot = 44,
        //
        // Summary:
        //     The INS key.
        Insert = 45,
        //
        // Summary:
        //     The DEL key.
        Delete = 46,
        //
        // Summary:
        //     The HELP key.
        Help = 47,
        //
        // Summary:
        //     The 0 key.
        D0 = 48,
        //
        // Summary:
        //     The 1 key.
        D1 = 49,
        //
        // Summary:
        //     The 2 key.
        D2 = 50,
        //
        // Summary:
        //     The 3 key.
        D3 = 51,
        //
        // Summary:
        //     The 4 key.
        D4 = 52,
        //
        // Summary:
        //     The 5 key.
        D5 = 53,
        //
        // Summary:
        //     The 6 key.
        D6 = 54,
        //
        // Summary:
        //     The 7 key.
        D7 = 55,
        //
        // Summary:
        //     The 8 key.
        D8 = 56,
        //
        // Summary:
        //     The 9 key.
        D9 = 57,
        //
        // Summary:
        //     The A key.
        A = 65,
        //
        // Summary:
        //     The B key.
        B = 66,
        //
        // Summary:
        //     The C key.
        C = 67,
        //
        // Summary:
        //     The D key.
        D = 68,
        //
        // Summary:
        //     The E key.
        E = 69,
        //
        // Summary:
        //     The F key.
        F = 70,
        //
        // Summary:
        //     The G key.
        G = 71,
        //
        // Summary:
        //     The H key.
        H = 72,
        //
        // Summary:
        //     The I key.
        I = 73,
        //
        // Summary:
        //     The J key.
        J = 74,
        //
        // Summary:
        //     The K key.
        K = 75,
        //
        // Summary:
        //     The L key.
        L = 76,
        //
        // Summary:
        //     The M key.
        M = 77,
        //
        // Summary:
        //     The N key.
        N = 78,
        //
        // Summary:
        //     The O key.
        O = 79,
        //
        // Summary:
        //     The P key.
        P = 80,
        //
        // Summary:
        //     The Q key.
        Q = 81,
        //
        // Summary:
        //     The R key.
        R = 82,
        //
        // Summary:
        //     The S key.
        S = 83,
        //
        // Summary:
        //     The T key.
        T = 84,
        //
        // Summary:
        //     The U key.
        U = 85,
        //
        // Summary:
        //     The V key.
        V = 86,
        //
        // Summary:
        //     The W key.
        W = 87,
        //
        // Summary:
        //     The X key.
        X = 88,
        //
        // Summary:
        //     The Y key.
        Y = 89,
        //
        // Summary:
        //     The Z key.
        Z = 90,
        //
        // Summary:
        //     The left Windows logo key (Microsoft Natural Keyboard).
        LWin = 91,
        //
        // Summary:
        //     The right Windows logo key (Microsoft Natural Keyboard).
        RWin = 92,
        //
        // Summary:
        //     The application key (Microsoft Natural Keyboard).
        Apps = 93,
        //
        // Summary:
        //     The computer sleep key.
        Sleep = 95,
        //
        // Summary:
        //     The 0 key on the numeric keypad.
        NumPad0 = 96,
        //
        // Summary:
        //     The 1 key on the numeric keypad.
        NumPad1 = 97,
        //
        // Summary:
        //     The 2 key on the numeric keypad.
        NumPad2 = 98,
        //
        // Summary:
        //     The 3 key on the numeric keypad.
        NumPad3 = 99,
        //
        // Summary:
        //     The 4 key on the numeric keypad.
        NumPad4 = 100,
        //
        // Summary:
        //     The 5 key on the numeric keypad.
        NumPad5 = 101,
        //
        // Summary:
        //     The 6 key on the numeric keypad.
        NumPad6 = 102,
        //
        // Summary:
        //     The 7 key on the numeric keypad.
        NumPad7 = 103,
        //
        // Summary:
        //     The 8 key on the numeric keypad.
        NumPad8 = 104,
        //
        // Summary:
        //     The 9 key on the numeric keypad.
        NumPad9 = 105,
        //
        // Summary:
        //     The multiply key.
        Multiply = 106,
        //
        // Summary:
        //     The add key.
        Add = 107,
        //
        // Summary:
        //     The separator key.
        Separator = 108,
        //
        // Summary:
        //     The subtract key.
        Subtract = 109,
        //
        // Summary:
        //     The decimal key.
        Decimal = 110,
        //
        // Summary:
        //     The divide key.
        Divide = 111,
        //
        // Summary:
        //     The F1 key.
        F1 = 112,
        //
        // Summary:
        //     The F2 key.
        F2 = 113,
        //
        // Summary:
        //     The F3 key.
        F3 = 114,
        //
        // Summary:
        //     The F4 key.
        F4 = 115,
        //
        // Summary:
        //     The F5 key.
        F5 = 116,
        //
        // Summary:
        //     The F6 key.
        F6 = 117,
        //
        // Summary:
        //     The F7 key.
        F7 = 118,
        //
        // Summary:
        //     The F8 key.
        F8 = 119,
        //
        // Summary:
        //     The F9 key.
        F9 = 120,
        //
        // Summary:
        //     The F10 key.
        F10 = 121,
        //
        // Summary:
        //     The F11 key.
        F11 = 122,
        //
        // Summary:
        //     The F12 key.
        F12 = 123,
        //
        // Summary:
        //     The F13 key.
        F13 = 124,
        //
        // Summary:
        //     The F14 key.
        F14 = 125,
        //
        // Summary:
        //     The F15 key.
        F15 = 126,
        //
        // Summary:
        //     The F16 key.
        F16 = 127,
        //
        // Summary:
        //     The F17 key.
        F17 = 128,
        //
        // Summary:
        //     The F18 key.
        F18 = 129,
        //
        // Summary:
        //     The F19 key.
        F19 = 130,
        //
        // Summary:
        //     The F20 key.
        F20 = 131,
        //
        // Summary:
        //     The F21 key.
        F21 = 132,
        //
        // Summary:
        //     The F22 key.
        F22 = 133,
        //
        // Summary:
        //     The F23 key.
        F23 = 134,
        //
        // Summary:
        //     The F24 key.
        F24 = 135,
        //
        // Summary:
        //     The NUM LOCK key.
        NumLock = 144,
        //
        // Summary:
        //     The SCROLL LOCK key.
        Scroll = 145,
        //
        // Summary:
        //     The left SHIFT key.
        LShiftKey = 160,
        //
        // Summary:
        //     The right SHIFT key.
        RShiftKey = 161,
        //
        // Summary:
        //     The left CTRL key.
        LControlKey = 162,
        //
        // Summary:
        //     The right CTRL key.
        RControlKey = 163,
        //
        // Summary:
        //     The left ALT key.
        LMenu = 164,
        //
        // Summary:
        //     The right ALT key.
        RMenu = 165,
        //
        // Summary:
        //     The browser back key (Windows 2000 or later).
        BrowserBack = 166,
        //
        // Summary:
        //     The browser forward key (Windows 2000 or later).
        BrowserForward = 167,
        //
        // Summary:
        //     The browser refresh key (Windows 2000 or later).
        BrowserRefresh = 168,
        //
        // Summary:
        //     The browser stop key (Windows 2000 or later).
        BrowserStop = 169,
        //
        // Summary:
        //     The browser search key (Windows 2000 or later).
        BrowserSearch = 170,
        //
        // Summary:
        //     The browser favorites key (Windows 2000 or later).
        BrowserFavorites = 171,
        //
        // Summary:
        //     The browser home key (Windows 2000 or later).
        BrowserHome = 172,
        //
        // Summary:
        //     The volume mute key (Windows 2000 or later).
        VolumeMute = 173,
        //
        // Summary:
        //     The volume down key (Windows 2000 or later).
        VolumeDown = 174,
        //
        // Summary:
        //     The volume up key (Windows 2000 or later).
        VolumeUp = 175,
        //
        // Summary:
        //     The media next track key (Windows 2000 or later).
        MediaNextTrack = 176,
        //
        // Summary:
        //     The media previous track key (Windows 2000 or later).
        MediaPreviousTrack = 177,
        //
        // Summary:
        //     The media Stop key (Windows 2000 or later).
        MediaStop = 178,
        //
        // Summary:
        //     The media play pause key (Windows 2000 or later).
        MediaPlayPause = 179,
        //
        // Summary:
        //     The launch mail key (Windows 2000 or later).
        LaunchMail = 180,
        //
        // Summary:
        //     The select media key (Windows 2000 or later).
        SelectMedia = 181,
        //
        // Summary:
        //     The start application one key (Windows 2000 or later).
        LaunchApplication1 = 182,
        //
        // Summary:
        //     The start application two key (Windows 2000 or later).
        LaunchApplication2 = 183,
        //
        // Summary:
        //     The OEM 1 key.
        Oem1 = 186,
        //
        // Summary:
        //     The OEM Semicolon key on a US standard keyboard (Windows 2000 or later).
        OemSemicolon = 186,
        //
        // Summary:
        //     The OEM plus key on any country/region keyboard (Windows 2000 or later).
        Oemplus = 187,
        //
        // Summary:
        //     The OEM comma key on any country/region keyboard (Windows 2000 or later).
        Oemcomma = 188,
        //
        // Summary:
        //     The OEM minus key on any country/region keyboard (Windows 2000 or later).
        OemMinus = 189,
        //
        // Summary:
        //     The OEM period key on any country/region keyboard (Windows 2000 or later).
        OemPeriod = 190,
        //
        // Summary:
        //     The OEM question mark key on a US standard keyboard (Windows 2000 or later).
        OemQuestion = 191,
        //
        // Summary:
        //     The OEM 2 key.
        Oem2 = 191,
        //
        // Summary:
        //     The OEM tilde key on a US standard keyboard (Windows 2000 or later).
        Oemtilde = 192,
        //
        // Summary:
        //     The OEM 3 key.
        Oem3 = 192,
        //
        // Summary:
        //     The OEM 4 key.
        Oem4 = 219,
        //
        // Summary:
        //     The OEM open bracket key on a US standard keyboard (Windows 2000 or later).
        OemOpenBrackets = 219,
        //
        // Summary:
        //     The OEM pipe key on a US standard keyboard (Windows 2000 or later).
        OemPipe = 220,
        //
        // Summary:
        //     The OEM 5 key.
        Oem5 = 220,
        //
        // Summary:
        //     The OEM 6 key.
        Oem6 = 221,
        //
        // Summary:
        //     The OEM close bracket key on a US standard keyboard (Windows 2000 or later).
        OemCloseBrackets = 221,
        //
        // Summary:
        //     The OEM 7 key.
        Oem7 = 222,
        //
        // Summary:
        //     The OEM singled/double quote key on a US standard keyboard (Windows 2000
        //     or later).
        OemQuotes = 222,
        //
        // Summary:
        //     The OEM 8 key.
        Oem8 = 223,
        //
        // Summary:
        //     The OEM 102 key.
        Oem102 = 226,
        //
        // Summary:
        //     The OEM angle bracket or backslash key on the RT 102 key keyboard (Windows
        //     2000 or later).
        OemBackslash = 226,
        //
        // Summary:
        //     The PROCESS KEY key.
        ProcessKey = 229,
        //
        // Summary:
        //     Used to pass Unicode characters as if they were keystrokes. The Packet key
        //     value is the low word of a 32-bit virtual-key value used for non-keyboard
        //     input methods.
        Packet = 231,
        //
        // Summary:
        //     The ATTN key.
        Attn = 246,
        //
        // Summary:
        //     The CRSEL key.
        Crsel = 247,
        //
        // Summary:
        //     The EXSEL key.
        Exsel = 248,
        //
        // Summary:
        //     The ERASE EOF key.
        EraseEof = 249,
        //
        // Summary:
        //     The PLAY key.
        Play = 250,
        //
        // Summary:
        //     The ZOOM key.
        Zoom = 251,
        //
        // Summary:
        //     A constant reserved for future use.
        NoName = 252,
        //
        // Summary:
        //     The PA1 key.
        Pa1 = 253,
        //
        // Summary:
        //     The CLEAR key.
        OemClear = 254,
        //
        // Summary:
        //     The bitmask to extract a key code from a key value.
        KeyCode = 65535,
        //
        // Summary:
        //     The SHIFT modifier key.
        Shift = 65536,
        //
        // Summary:
        //     The CTRL modifier key.
        Control = 131072,
        //
        // Summary:
        //     The ALT modifier key.
        Alt = 262144,
    }
}
