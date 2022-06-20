using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class CalculatorModel
    {
        public double Calculate(string calculation)
        {
            // Divide calculation string into a list of numbers and mathematical operators.
            List<string> parts = new List<string>();
            int n = 0;
            int loops = 0;
            foreach (char c in calculation)
            {
                try
                {
                    double.Parse(c.ToString());
                    if (parts.Count < n - 1 || parts.Count == 0) parts.Add(c.ToString());
                    else parts[n] += (c.ToString());
                }
                catch
                {
                    if (loops != 0)
                    {
                        n++;
                        parts.Add(c.ToString());
                        n++;
                    }
                    else
                    {
                        n++;
                        parts[n] += (c.ToString());
                    }
                }
                loops++;
            }

            // Multiplication & division
            for (int i = 0; i < parts.Count; i++)
            {
                if (parts[i].Equals("*"))
                {
                    parts[i - 1] = (double.Parse(parts[i - 1]) * double.Parse(parts[i + 1])).ToString();
                    parts.RemoveAt(i);
                    parts.RemoveAt(i);
                    i--;
                }
                else if (parts[i].Equals("/"))
                {
                    parts[i + 1] = (double.Parse(parts[i - 1]) / double.Parse(parts[i + 1])).ToString();
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
                    parts[i - 1] = (double.Parse(parts[i - 1]) + double.Parse(parts[i + 1])).ToString();
                    parts.RemoveAt(i);
                    parts.RemoveAt(i);
                    i--;
                }
                else if (parts[i].Equals("-"))
                {
                    parts[i - 1] = (double.Parse(parts[i - 1]) - double.Parse(parts[i + 1])).ToString();
                    parts.RemoveAt(i);
                    parts.RemoveAt(i);
                    i--;
                }
            }

            return double.Parse(parts[0]);
        }
    }
}
