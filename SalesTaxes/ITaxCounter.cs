using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes
{
    interface ITaxCounter
    {
        double TaxCount(Category productCategory, double price, bool isImported);
    }
}
