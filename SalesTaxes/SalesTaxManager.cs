using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes
{
    public class SalesTaxManager
    {
        private Dictionary<Product, int> Products = new Dictionary<Product, int>(new ProductsComparer());
        private TaxCounter taxCounter = new TaxCounter();
        private double SalesTaxes = 0;
        private double Total = 0;
        public void AddProduct(string name, Category productCategory, double price, bool isImported)
        {
            var product = new Product(name, productCategory, price, isImported);

            if (Products.ContainsKey(product))
            {
                Products[product]++;
            }
            else
            {
                Products.Add(product, 1);
            }
            
            
        }
      
        public string GenerateReceipt()
        {
            StringBuilder res = new StringBuilder();
            foreach (var key in Products.Keys)
            {
                double tax = taxCounter.TaxCount(key.ProductCategory, key.Price, key.IsImported);
                SalesTaxes += tax * Products[key];
                Total += (key.Price + tax) * Products[key]; 
                res.Append(Products[key].ToString() + " " + key.Name + " : " + Math.Round( key.Price + tax, 2, MidpointRounding.AwayFromZero) * Products[key] + "\n");

            }
                res.Append("Sales Taxes: " + SalesTaxes + "\n");
                res.Append("Total: " + Total + "\n"); 
            return res.ToString();
        }

    }
}
