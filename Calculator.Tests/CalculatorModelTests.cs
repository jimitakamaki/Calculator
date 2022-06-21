using Calculator.Model;
using System.Globalization;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorModelTests
    {
        CultureInfo culture = CultureInfo.CurrentCulture;

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

        [TestMethod]
        public void Calculate_negativeFirstNumber_zero()
        {
            CalculatorModel calculator = new CalculatorModel();
            string calculation = "-5+5";
            double result = calculator.Calculate(calculation);
            Assert.AreEqual(0, result);
        }

        [DataTestMethod]
        [DataRow("63.7/3.8734", 0.001, 16.446)]
        [DataRow("5.123+6.88*0.11-5.5", 0.001, 0.380)]
        public void Calculate_decimalNumbers_differentValues(string calculation, double delta, double expectedResult)
        {
            CalculatorModel calculator = new CalculatorModel();
            double result = calculator.Calculate(calculation);
            Assert.AreEqual(expectedResult, result, delta);
        }

        [DataTestMethod]
        [DataRow("10-5*2+3/7", 0.001, 0.429)]
        [DataRow("-500.22-2-77.4*6", 0.001, -966.62)]
        [DataRow("99-1*5.5+77.7", 0.001, 171.2)]
        public void Calculate_complexCalculations_differentValues(string calculation, double delta, double expectedResult)
        {
            CalculatorModel calculator = new CalculatorModel();
            double result = calculator.Calculate(calculation);
            Assert.AreEqual(expectedResult, result, delta);
        }
    }
}