using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class CalculationSplitter
    {
        public List<string> SplitIntoList(string calculation)
        {
            // Divide calculation string into a list of numbers and mathematical operators.
            string formattedCalculation = calculation.Replace(" ", string.Empty);
            //formattedCalculation = calculation.Replace(" ", string.Empty); unknown character?
            List<string> parts = new List<string>();
            int n = 0;
            int loops = 0;
            foreach (char c in formattedCalculation)
            {
                try
                {
                    double.Parse(c.ToString(), CultureInfo.CurrentCulture);
                    if (parts.Count == n) parts.Add(c.ToString());
                    else parts[n] += (c.ToString());
                }
                catch
                {
                    if (loops == 0 && c.Equals('-')) // Calculation starts with negative number
                    {
                        parts.Add(c.ToString());
                    }
                    else if (c.Equals('.') || c.Equals(','))
                    {
                        parts[n] += c.ToString();
                    }
                    else
                    {
                        n++;
                        parts.Add(c.ToString());
                        n++;
                    }
                }
                loops++;
            }
            return parts;
        }
    }
}
