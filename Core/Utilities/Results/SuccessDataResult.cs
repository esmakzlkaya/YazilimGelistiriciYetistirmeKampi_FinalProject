using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message):base(data,true,message)
                                            //işlem sonucunu default true verdik
        {
        }
        public SuccessDataResult(T data):base(data,true)
        {
        }
        public SuccessDataResult(string message):base(default, true,message)
            //default - dataya karşılık gelir
        {       
        }
        public SuccessDataResult():base(default,true)
        //default - dataya karşılık gelir
        {
        }
    }
}
