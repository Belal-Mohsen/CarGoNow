using CarGoNowApp.Models;
using CarGoNowApp.Views;

namespace CarGoNowAppTest
{
    public class Tests
    {
        BillCalc bill { get; set; } = null;
        [SetUp]
        public void Setup()
        {
            bill = new BillCalc();
        }

        [Test]
        public void Test1()
        {
            //Arrange 
            int numOfDays = 4;
            double price = 75;
            double expected = 300;

            //Act 
            double actual = bill.billAmount(numOfDays, price);

            //Assert

            Assert.AreEqual(expected, actual);
            Assert.That(actual, Is.TypeOf<double>());

        }
    }
}