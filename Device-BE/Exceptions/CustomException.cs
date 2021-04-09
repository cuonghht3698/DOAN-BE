using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Exceptions
{
    [Serializable]
    public class CustomException:Exception
    {
        private string custom;

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="paramName">Name or Data</param>
        public CustomException(string message)
        {

            custom = message;


        }
        public override string Message
        {
            get
            {
                return custom;
            }
        }
    }
}
