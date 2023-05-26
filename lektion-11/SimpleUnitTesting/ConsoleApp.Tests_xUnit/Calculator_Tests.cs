namespace ConsoleApp.Tests_xUnit
{
    public class Calculator_Tests
    {
        [Fact]
        public void Add__Should_Add_One_Number_To_Total()
        {
            // Arrange
            var calculator = new Calculator();
            calculator.Total = 0;

            // Act
            calculator.Add(0.1m);

            // Assert
            Assert.Equal(0.1m, calculator.Total);
        }
    }
}