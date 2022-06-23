using System.Collections.Generic;
using System.Globalization;

namespace Calculator.Model
{
    public class CalculationFormatter
    {
        private CalculationSplitter _calcSplitter;
        private NumberFormatInfo _nfi;
        public CalculationFormatter()
        {
            _calcSplitter = new CalculationSplitter();

            _nfi = new NumberFormatInfo();
            _nfi.NumberGroupSeparator = " "; // Whitespace character
            if (CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.Equals("."))
                _nfi.NumberDecimalSeparator = ".";
            else _nfi.NumberDecimalSeparator = ",";
        }
        public string FormatCalculationString(string calc)
        {
            List<string> parts = _calcSplitter.SplitIntoList(calc);
            for (int i = 0; i < parts.Count; i++)
            {
                try
                {
                    decimal number = decimal.Parse(parts[i], _nfi);
                    if (number >= 1000)
                    {
                        if (parts[i].Contains(_nfi.NumberDecimalSeparator))
                        {
                            string firstPart = parts[i].Substring(0, parts[i].IndexOf(_nfi.NumberDecimalSeparator));
                            string lastPart = parts[i].Substring(parts[i].IndexOf(_nfi.NumberDecimalSeparator));
                            firstPart = decimal.Parse(firstPart).ToString("n0", _nfi);
                            parts[i] = firstPart + lastPart;
                        }
                        else parts[i] = decimal.Parse(parts[i]).ToString("n0", _nfi);
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
