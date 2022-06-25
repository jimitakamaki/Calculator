using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class CalculatorModel
    {
        CultureInfo culture;
        CalculationSplitter calcSplitter;

        public CalculatorModel()
        {
            culture = CultureInfo.InvariantCulture;
            calcSplitter = new CalculationSplitter();
        }

        public double Calculate(string calculation)
        {
            string formattedCalculation = calculation.Replace(" ", string.Empty);
            formattedCalculation = calculation.Replace(",", ".");

            List<string> parts = calcSplitter.SplitIntoList(formattedCalculation);

            // Multiplication & division
            for (int i = 0; i < parts.Count; i++)
            {
                if (parts[i].Equals("*") || parts[i].Equals("×"))
                {
                    parts[i - 1] = (double.Parse(parts[i - 1], culture) * double.Parse(parts[i + 1], culture)).ToString("n12", culture);
                    parts.RemoveAt(i);
                    parts.RemoveAt(i);
                    i--;
                }
                else if (parts[i].Equals("/") || parts[i].Equals("÷"))
                {
                    parts[i - 1] = (double.Parse(parts[i - 1], culture) / double.Parse(parts[i + 1], culture)).ToString("n12", culture);
                    parts.RemoveAt(i);
                    parts.RemoveAt(i);
                    i--;
                }
            }

            // Addition & subtraction
            for (int i = 0; i < parts.Count; i++)
            {
                if (parts[i].Equals("+"))
                {
                    parts[i - 1] = (double.Parse(parts[i - 1], culture) + double.Parse(parts[i + 1], culture)).ToString("n12", culture);
                    parts.RemoveAt(i);
                    parts.RemoveAt(i);
                    i--;
                }
                else if (parts[i].Equals("-"))
                {
                    parts[i - 1] = (double.Parse(parts[i - 1], culture) - double.Parse(parts[i + 1], culture)).ToString("n12", culture);
                    parts.RemoveAt(i);
                    parts.RemoveAt(i);
                    i--;
                }
            }

            return double.Parse(parts[0], culture);
        }
    }
}
