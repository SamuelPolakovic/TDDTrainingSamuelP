using NUnit.Framework;
using CashRegister;

namespace CashRegisterTests
{
    public class ScanItemsTests
    {
        [Test]
        public void ScanOneItemTest()
        {
            CashRegisterBE.FillItems();
            var barcode = "123456789";
            var expectedPrice = "$12.51";

            var sut = CashRegisterBE.Scan(barcode);

            Assert.AreEqual(expectedPrice,sut.Price);
        }

        [Test]
        public void ScanOneItemEmptyStringTest()
        {
            CashRegisterBE.FillItems();
            var barcode = "";
            var expectedResult = "Barcode is empty";

            var sut = CashRegisterBE.Scan(barcode);

            Assert.AreEqual(expectedResult, sut.Price);
        }
    }
}