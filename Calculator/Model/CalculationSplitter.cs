using System.Collections.Generic;
using System.Globalization;

namespace Calculator.Model
{
    public class CalculationSplitter
    {
        private NumberFormatInfo _nfi;

        public CalculationSplitter()
        {
            _nfi = new NumberFormatInfo();
            _nfi.NumberGroupSeparator = " "; // Whitespace character
            if (CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.Equals("."))
                _nfi.NumberDecimalSeparator = ".";
            else _nfi.NumberDecimalSeparator = ",";
        }
        public List<string> SplitIntoList(string calculation)
        {
            string formattedCalculation = calculation.Replace(" ", string.Empty);
            List<string> parts = new List<string>();
            int n = 0;
            int loops = 0;
            foreach (char c in formattedCalculation)
            {
                try
                {
                    decimal.Parse(c.ToString(), _nfi);
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
