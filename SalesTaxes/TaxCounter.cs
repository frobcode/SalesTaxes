using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes
{
   public class TaxCounter : ITaxCounter
    {
        public double TaxCount(Category productCategory, double price, bool isImported)
        {
            double tax = 0;
            switch (productCategory)
            {
                case Category.Books:
                case Category.Food:
                case Category.Medical:

                    tax = isImported ? price * 5 / 100 : 0;
 
                    break;

                default:
                    tax = isImported ? price * 5 / 100 + price * 10 / 100 : price * 10 / 100;
                    break;
            }
            var pow = Math.Pow(10, 1);
            var truncated = Math.Truncate(tax * pow) / pow;
            var temp = tax - truncated;
            if (temp < 0.05 && temp > 0)
            {
                tax = truncated + 0.05;
            }
            else if (temp > 0.05)
            {
                tax += (0.1 - temp); 
            }
                return Math.Round(tax, 2, MidpointRounding.AwayFromZero); 
        }
    }
}
