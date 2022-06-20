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

        [DataTestMethod]
        [DataRow("5-5", 0)]
        [DataRow("1-900-2", -901)]
        public void Calculate_subtraction_differentValues(string calculation, double expectedResult)
        {
            CalculatorModel calculator = new CalculatorModel();
            double result = calculator.Calculate(calculation);
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow("5*5", 25)]
        [DataRow("1*900*2", 1800)]
        public void Calculate_multiplication_differentValues(string calculation, double expectedResult)
        {
            CalculatorModel calculator = new CalculatorModel();
            double result = calculator.Calculate(calculation);
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow("5/5", 1)]
        [DataRow("12/2/3", 2)]
        public void Calculate_division_differentValues(string calculation, double expectedResult)
        {
            CalculatorModel calculator = new CalculatorModel();
            double result = calculator.Calculate(calculation);
            Assert.AreEqual(expectedResult, result);
        }
    }
}