using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
   public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)//iş kurallarını(logics) parametre olarak verebilmemizi sağlar
        {
            foreach (var logic in logics)//iş kurallarını gezer
            {
                if (!logic.Success)//iş kuralı başarısızsa
                {
                    return logic; //bussinese başarısız kuralı döndürüyoruz
                }
            }
            return null;
        }
    }
}
