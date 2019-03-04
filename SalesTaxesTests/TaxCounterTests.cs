using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxes;
namespace SalesTaxesTests
{

    [TestClass]
    public class TaxCounterTests
    {
        private const double Actual = 0.5;
        private TaxCounter TaxCounter;

        [TestInitialize]
        public void Initialize() => TaxCounter = new TaxCounter();

        [TestMethod]
        public void TaxCountShouldSuccessWhenNonExemptNonImportProduct()
        {
            var tax = TaxCounter.TaxCount(Category.Other, 10, false);
            Assert.AreEqual(tax, 1);
        }

        [TestMethod]
        public void TaxCountShouldSuccessWhenNonExemptImportProduct()
        {

            var tax = TaxCounter.TaxCount(Category.Other, 47.5, true);
            Assert.AreEqual(tax, 7.15);
        }

        [TestMethod]
        public void TaxCountShouldSuccessWhenFoodNonImportProduct()
        {
            var tax = TaxCounter.TaxCount(Category.Food, 10, false);
            Assert.AreEqual(tax, 0);
        }

        [TestMethod]
        public void TaxCountShouldSuccessWhenBooksNonImportProduct()
        {
            var tax = TaxCounter.TaxCount(Category.Books, 10, false);
            Assert.AreEqual(tax, 0);
        }

        [TestMethod]
        public void TaxCountShouldSuccessWhenMedicalNonImportProduct()
        {
            var tax = TaxCounter.TaxCount(Category.Medical, 10, false);
            Assert.AreEqual(tax, 0);
        }

        [TestMethod]
        public void TaxCountShouldSuccessWhenFoodImportProduct()
        {
            var tax = TaxCounter.TaxCount(Category.Medical, 47.5, true);
            Assert.AreEqual(tax, actual: 2.4);
        }

        [TestMethod]
        public void TaxCountShouldSuccessWhenBooksImportProduct()
        {
            var tax = TaxCounter.TaxCount(Category.Books, 10, true);
            Assert.AreEqual(tax, Actual);
        }

        [TestMethod]
        public void TaxCountShouldSuccessWhenMedicalImportProduct()
        {
            var tax = TaxCounter.TaxCount(Category.Medical, 10, true);
            Assert.AreEqual(tax, Actual);
        }

    }
}
