using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes
{
    public class Product
    {
        public Product(string name, Category productCategory, double price, bool isImported)
        {
            Name = name;
            ProductCategory = productCategory;
            Price = price;
            IsImported = isImported;
        }
        
        public string Name { get; set; }
        public Category ProductCategory { get; set; }
        public double Price { get; set; }
        public bool IsImported { get; set; }
    }


    public enum Category
    {
        Food, Books, Medical, Other
    }


    class ProductsComparer : IEqualityComparer<Product>
    {
        public ProductsComparer()
        {
        }

        public bool Equals(Product product1, Product product2)
        {
            return (product1.Name == product2.Name
         && product1.Price == product2.Price);
        }

        public int GetHashCode(Product product)
        {
            int hash = 5381;

            foreach (var c in product.Name)
                hash = ((hash << 5) + hash) + c;

            return hash + (int)product.Price;

        }
    }
}
