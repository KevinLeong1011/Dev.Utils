/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 18:24:00
 * ***********************************************/
using System.Runtime.Serialization;

namespace System
{
    [Serializable]
    public class DataValidationException : Exception
    {
        public DataValidationException()
        {
        }

        public DataValidationException(string message) : base(message)
        {
        }

        public DataValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}