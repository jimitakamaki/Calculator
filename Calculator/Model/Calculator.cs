using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Model
{
    public class Calculator
    {
        public string Text { get; set; }
        public Calculator()
        {
            Text = "";
        }
    }
}
