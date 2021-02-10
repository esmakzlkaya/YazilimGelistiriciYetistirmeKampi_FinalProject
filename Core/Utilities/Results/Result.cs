using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success)
        {
            //Message aslında sadece get'tir dı,yani sadece read only idi
            //ancak constructor içinde set edilebilir
            Message = message;
            //Success = success; - DRY - bunun yerine - :this(success) aşağıdakini de çalıştırır
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        //Message is read only
        public string Message { get; }
        
    }
}
