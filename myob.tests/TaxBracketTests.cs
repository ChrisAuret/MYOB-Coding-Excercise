using myob.domain;
using NUnit.Framework;

namespace myob.tests
{
    [TestFixture]
    public class TaxBracketTests
    {
        private TaxTable _taxBracket;

        [OneTimeSetUp]
        public void Setup()
        {
            _taxBracket = new TaxTable();
        }

        [Test]
        public void GetTaxRate_should_return_correct_tax_rate_for_tax_bracket_1()
        {
            Assert.AreEqual(0, _taxBracket.GetTaxBracket(0).Rate);
            Assert.AreEqual(0, _taxBracket.GetTaxBracket(10000).Rate);
            Assert.AreEqual(0, _taxBracket.GetTaxBracket(18200).Rate);
        }

        [Test]
        public void GetTaxRate_should_return_correct_tax_rate_for_tax_bracket_2()
        {
            Assert.AreEqual(19, _taxBracket.GetTaxBracket(18201).Rate);
            Assert.AreEqual(19, _taxBracket.GetTaxBracket(25000).Rate);
            Assert.AreEqual(19, _taxBracket.GetTaxBracket(37000).Rate);
        }

        [Test]
        public void GetTaxRate_should_return_correct_tax_rate_for_tax_bracket_3()
        {
            Assert.AreEqual(32.5, _taxBracket.GetTaxBracket(37001).Rate);
            Assert.AreEqual(32.5, _taxBracket.GetTaxBracket(60000).Rate);
            Assert.AreEqual(32.5, _taxBracket.GetTaxBracket(80000).Rate);
        }

        [Test]
        public void GetTaxRate_should_return_correct_tax_rate_for_tax_bracket_4()
        {
            Assert.AreEqual(37, _taxBracket.GetTaxBracket(80001).Rate);
            Assert.AreEqual(37, _taxBracket.GetTaxBracket(150000).Rate);
            Assert.AreEqual(37, _taxBracket.GetTaxBracket(180000).Rate);
        }

        [Test]
        public void GetTaxRate_should_return_correct_tax_rate_for_tax_bracket_5()
        {
            Assert.AreEqual(45, _taxBracket.GetTaxBracket(180001).Rate);
            Assert.AreEqual(45, _taxBracket.GetTaxBracket(1000000).Rate);
            Assert.AreEqual(45, _taxBracket.GetTaxBracket(10000000).Rate);
        }
    }
}
