using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.BLL.DTO;

namespace GameStore.BLL.BusinessModels
{
  public class Discount
    {
        private decimal _value=0;
        public Discount(decimal val)
        {
            _value = val;
        }
        public decimal Value { get { return _value; } }
        public decimal GetDiscounedPrice (decimal sum)
        {
            if (DateTime.Now.Day == 1)
                return sum - sum * _value;
            return sum;
        }
    }
}
