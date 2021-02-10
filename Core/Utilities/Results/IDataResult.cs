using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult //hemde mesaj içersin diye IResult
    {
        T Data { get; }
    }
}
