using CalculatorApp;
namespace CalculatorApp.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        Calculator calculator;

        // [SetUp] //this will execute SetUp() method every time before executing each test method
        [OneTimeSetUp] //this will execute SetUp() method first time only before executing any test method
        public void Setup()
        {
            //Arrange
            calculator = new Calculator();
        }

        [Test]
        [TestCase(10,5)]
        [TestCase(1,0)]
        public void Add_WhenCalled_Return_Sum(int a,int b)
        {
            //Act
           var actualResult= calculator.Add(a, b);

            var expectedResult = (a+b);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(10,5)]
        [TestCase(5,5)]
        public void Subtract_WhenCalled_Returns_Difference(int a, int b)
        {
            //Act
          var actualResult=  calculator.Subtract(a, b);

           var expectedResult = (a-b);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(10,5)]
        [TestCase(10,2)]
        public void Divide_TwoNumbers_ReturnsQuotient(int a, int b)
        {
            //Act
            var actualResult=calculator.Divide(a, b);
            var expectedResult = (a / b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Ignore("Skip this test method because it is under progress")]
        public void DivideByZero_ThrowsException()
        {
            //Act & Assert
          Assert.Throws<System.DivideByZeroException>(()=> calculator.Divide(10,0));
        }
    }
}