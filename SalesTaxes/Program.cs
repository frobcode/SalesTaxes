using System;

namespace SalesTaxes
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Input1();
            program.Input2();
            program.Input3();

            Console.ReadKey();
        }

        public void Input1()
        {
            var salesManager = new SalesTaxManager();
            salesManager.AddProduct("book", Category.Books, 12.49, false);
            salesManager.AddProduct("music CD", Category.Other, 14.99, false);
            salesManager.AddProduct("chocolate", Category.Food, 0.85, false);

            Console.WriteLine("Output1");
            Console.WriteLine(salesManager.GenerateReceipt());
        }

        public void Input2()
        {
            var salesManager = new SalesTaxManager();
            salesManager.AddProduct("imported box of chocolates", Category.Food, 10, true);
            salesManager.AddProduct("imported bottle of perfume", Category.Other, 47.50, true);

            Console.WriteLine("Output2");
            Console.WriteLine(salesManager.GenerateReceipt());
        }

        public void Input3()
        {
            var salesManager = new SalesTaxManager();
            salesManager.AddProduct("imported bottle of perfume", Category.Other, 27.99, true);
            salesManager.AddProduct("bottle of perfume", Category.Other, 18.99, false);
            salesManager.AddProduct("packet of headache pills", Category.Medical, 9.75, false);
            salesManager.AddProduct("box of imported chocolates", Category.Food, 11.25, true);

            Console.WriteLine("Output3");
            Console.WriteLine(salesManager.GenerateReceipt());
        }

    }
}
