using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CalculatorApp.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace CalculatorApp.ViewModel
{
    class MainWindowViewModel : ObservableObject
    {
        Calculator calculator;
        public string Text 
        { 
            get { return calculator.Text; } 
            set { SetProperty(calculator.Text, value, calculator, (c, t) => c.Text = t); } 
        }
        public ICommand AddNumberCommand { get; }
        public MainWindowViewModel()
        {
            calculator = new Calculator();
            AddNumberCommand = new RelayCommand<string>(addNumber);
        }

        private void addNumber(string n)
        {
            Text += n;
        }
    }
}
