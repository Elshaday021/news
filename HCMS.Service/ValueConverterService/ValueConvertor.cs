using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Service.ValueConverterService
{
    public class ValueConvertor:IValueConvertor
    {
        public Task<int> TwoDigitConvertorMethod(int value)
        {
            var twoDigit = value.ToString("D2");
            return Task.FromResult(int.Parse(twoDigit));
        }

        public Task<int> ThreeDigitConvertorMethod(int value)
        {
            var twoDigit = value.ToString("D3");
            return Task.FromResult(int.Parse(twoDigit));
        }
    }
  

}
