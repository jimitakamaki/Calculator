using Calculator.Model;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorModelTests
    {
        [DataTestMethod]
        [DataRow("5+5", 10)]
        [DataRow("1+900+2", 903)]
        public void Calculate_addition_differentValues(string calculation, double expectedResult)
        {
            CalculatorModel calculator = new CalculatorModel();
            double result = calculator.Calculate(calculation);
            Assert.AreEqual(expectedResult, result);
        }
    }
}