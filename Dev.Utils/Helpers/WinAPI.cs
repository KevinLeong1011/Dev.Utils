/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/19 20:04:13
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.Utils.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class WinAPI
    {
        #region Keyboard

        public static void SendKey(VirtualKeys Key, bool State)
        {
            if (State != GetKeybdState(Key))
            {
                keybd_event(Key, MapVirtualKey((byte)Key, 0), 0, 0);
                Thread.Sleep(100);
                keybd_event(Key, MapVirtualKey((byte)Key, 0), KEYEVENTF_KEYUP, 0);
            }
        }

        #endregion
    }
}
