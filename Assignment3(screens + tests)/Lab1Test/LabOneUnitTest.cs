
using Lab1.Models;
namespace Lab1Test
{
    public class Tests
    {
        private labOneFunc lof { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            lof = new labOneFunc();
        }

        [Test]
        public void getMonthlyFeesBankChargesTest()
        {
            //Arrange
            int a = 10;
            double b = 600;
            double expected = 11;

            // Act 
            double actual = lof.monthlyFees(a, b);

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.That(actual, Is.TypeOf<double>());
        }

        [Test]
        public void getShippingCostProblem2Test()
        {
            //Arrange
            double a = 13;
            double b = 15;
            double expected = 4.8;

            // Act 
            double actual = lof.shippingCost(a, b);

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.That(actual, Is.TypeOf<double>());
        }

        [Test]
        public void getcalcDayPopulationRateProblem2Test()
        {
            //Arrange
            int a = 1000;
            double b = 0.16;
            double expected = 160;

            // Act 
            double actual = lof.calcDayPopulationRate(a, b);

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.That(actual, Is.TypeOf<double>());
        }
    }
}