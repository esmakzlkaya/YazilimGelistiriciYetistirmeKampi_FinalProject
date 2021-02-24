using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    //iş motoru
    public class BusinessRules
    {
        //logics  - iş kuralları
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic; //şu logic hatalı haberin olsun (business a diyoruz)
                } 
            }
            return null; //success logics
        }
    }
}
