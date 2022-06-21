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

        public CalculatorModel()
        {
            culture = CultureInfo.InvariantCulture;
        }

        public double Calculate(string calculation)
        {
            calculation = calculation.Replace(" ", string.Empty);
            calculation = calculation.Replace(",", ".");

            // Divide calculation string into a list of numbers and mathematical operators.
            List<string> parts = new List<string>();
            int n = 0;
            int loops = 0;
            foreach (char c in calculation)
            {
                try
                {
                    double.Parse(c.ToString(), culture);
                    if (parts.Count == n) parts.Add(c.ToString());
                    else parts[n] += (c.ToString());
                }
                catch
                {
                    if (loops == 0 && c.Equals('-')) // Calculation starts with negative number
                    {
                        parts.Add(c.ToString());
                    }
                    else if (c.Equals('.'))
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

            // Multiplication & division
            for (int i = 0; i < parts.Count; i++)
            {
                if (parts[i].Equals("*"))
                {
                    parts[i - 1] = (double.Parse(parts[i - 1], culture) * double.Parse(parts[i + 1], culture)).ToString("n12", culture);
                    parts.RemoveAt(i);
                    parts.RemoveAt(i);
                    i--;
                }
                else if (parts[i].Equals("/"))
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
