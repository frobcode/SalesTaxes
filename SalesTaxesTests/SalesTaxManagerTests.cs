using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxes;

namespace SalesTaxesTests
{
    [TestClass]
    public class SalesTaxManagerTests
    {
        private SalesTaxManager SalesManager;

        [TestInitialize]
        public void Initialize() => SalesManager = new SalesTaxManager();

        [TestMethod]
        public void SalesTaxManagerShouldGenerateReceiptForSingleProduct()
        {
            SalesManager.AddProduct("Apple", Category.Food, 10, false);
            var expected = "1 Apple : 10\nSales Taxes: 0\nTotal: 10\n";
            string res = SalesManager.GenerateReceipt();
            Assert.AreEqual(res, expected);
        }

        [TestMethod]
        public void SalesTaxManagerShouldGenerateReceiptForMultipleProductsWithoutImported()
        {
            var expected = "1 book : 12.49\n1 music CD : 16.49\n1 chocolate : 0.85\nSales Taxes: 1.5\nTotal: 29.83\n";

            SalesManager.AddProduct("book", Category.Books, 12.49, false);
            SalesManager.AddProduct("music CD", Category.Other, 14.99, false);
            SalesManager.AddProduct("chocolate", Category.Food, 0.85, false);
            string res = SalesManager.GenerateReceipt();

            Assert.AreEqual(res, expected);
        }

        [TestMethod]
        public void SalesTaxManagerShouldGenerateReceiptForMultipleProductsWithImported()
        {
            var expected = "1 imported bottle of perfume : 32.19\n1 bottle of perfume : 20.89\n1 packet of headache pills : 9.75\n1 box of imported chocolates : 11.85\nSales Taxes: 6.7\nTotal: 74.68\n";

            SalesManager.AddProduct("imported bottle of perfume", Category.Other, 27.99, true);
            SalesManager.AddProduct("bottle of perfume", Category.Other, 18.99, false);
            SalesManager.AddProduct("packet of headache pills", Category.Medical, 9.75, false);
            SalesManager.AddProduct("box of imported chocolates", Category.Food, 11.25, true);
            string res = SalesManager.GenerateReceipt();

            Assert.AreEqual(res, expected);
        }

        [TestMethod]
        public void SalesTaxManagerShouldGenerateEmptyReceiptForNoProducts()
        {
            var expected = "Sales Taxes: 0\nTotal: 0\n";
            string res = SalesManager.GenerateReceipt();

            Assert.AreEqual(res, expected);
        }

        [TestMethod]
        public void SalesTaxManagerShouldGenerateReceiptWithRightProductsNumberOfSameKind()
        {
            var expected = "3 imported bottle of perfume : 96.57\n2 packet of headache pills : 19.5\n1 box of imported chocolates : 11.85\nSales Taxes: 13.2\nTotal: 127.92\n";

            SalesManager.AddProduct("imported bottle of perfume", Category.Other, 27.99, true);
            SalesManager.AddProduct("imported bottle of perfume", Category.Other, 27.99, true);
            SalesManager.AddProduct("imported bottle of perfume", Category.Other, 27.99, true);
            SalesManager.AddProduct("packet of headache pills", Category.Medical, 9.75, false);
            SalesManager.AddProduct("packet of headache pills", Category.Medical, 9.75, false);
            SalesManager.AddProduct("box of imported chocolates", Category.Food, 11.25, true);
            string res = SalesManager.GenerateReceipt();

            Assert.AreEqual(res, expected);
        }
    }
}
