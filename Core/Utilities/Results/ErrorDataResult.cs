using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        //işlem sonucunu default false verdik
        {
        }
        public ErrorDataResult(T data) : base(data, false)
        {
        }
        public ErrorDataResult(string message) : base(default, false, message)
        //default - dataya karşılık gelir
        {
        }
        public ErrorDataResult() : base(default, false)
        //default - dataya karşılık gelir
        {
        }
    }
}
