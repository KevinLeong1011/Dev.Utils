/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/19 3:10:41
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICloneable<T>
        where T : class
    {
        T Clone();
    }
}
