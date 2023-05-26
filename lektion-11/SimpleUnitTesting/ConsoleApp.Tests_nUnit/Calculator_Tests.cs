namespace ConsoleApp.Tests_nUnit
{
    public class Calculator_Tests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            // Arrange
            calculator = new Calculator();
            calculator.Total = 0;
        }

        [Test]
        public void Add__Should_Add_One_Number_To_Total()
        {
            // Act
            calculator.Add(0.1m);

            // Assert
            Assert.That(calculator.Total, Is.EqualTo(0.1m));
        }
    }
}