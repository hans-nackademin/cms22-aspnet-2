using System.Reflection.Metadata;

namespace ConsoleApp.Tests__MSTest
{
    [TestClass]
    public class Calculator_Tests
    {
        [TestMethod]
        public void Add__Should_Add_One_Number_To_Total()
        {
            // Arrange - f�rberedelser
            Calculator calculator = new Calculator();
            calculator.Total = 0.0m;


            // Act - utf�rande
            calculator.Add(0.1m);


            // Assert - utv�rdering
            Assert.AreEqual(0.1m, calculator.Total);
        }
    }
}