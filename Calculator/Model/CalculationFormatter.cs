using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class CalculationFormatter
    {
        private CalculationSplitter _calcSplitter;
        public CalculationFormatter()
        {
            _calcSplitter = new CalculationSplitter();
        }
        public string FormatCalculationString(string calc)
        {
            List<string> parts = _calcSplitter.SplitIntoList(calc);
            for (int i = 0; i < parts.Count; i++)
            {
                try
                {
                    //parts[i] = double.Parse(parts[i], CultureInfo.CurrentCulture).ToString("n", CultureInfo.CurrentCulture);
                    double number = double.Parse(parts[i], CultureInfo.CurrentCulture);
                    if (number >= 1000)
                    {
                        string decimalSeparator;
                        if (CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.Equals(",")) decimalSeparator = ",";
                        else decimalSeparator = ".";

                        if (parts[i].Contains(decimalSeparator))
                        {
                            string firstPart = parts[i].Substring(parts[i].IndexOf(decimalSeparator) - 1);
                            string lastPart = parts[i].Substring(0, parts[i].IndexOf(decimalSeparator));
                            firstPart = int.Parse(firstPart).ToString(CultureInfo.CurrentCulture);
                            parts[i] = firstPart + lastPart;
                        }
                        else
                        {
                            parts[i] = int.Parse(parts[i]).ToString("n0", CultureInfo.CurrentCulture);
                        }
                        
                    }
                }
                catch { }
            }

            string formattedCalculation = "";
            foreach (string part in parts)
            {
                formattedCalculation += part;
            }
            return formattedCalculation;
        }
    }
}
