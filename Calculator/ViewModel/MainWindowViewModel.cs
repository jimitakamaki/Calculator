using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Calculator.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace Calculator.ViewModel
{
    class MainWindowViewModel : ObservableObject
    {
        CalculatorModel calculator;
        CultureInfo culture = CultureInfo.CurrentCulture;

        private string _text;
        private string _decimalSeparator;
        public string Text 
        { 
            get { return _text; } 
            set { SetProperty(ref _text, value); } 
        }
        public string DecimalSeparator
        {
            get { return _decimalSeparator; }
            set { SetProperty(ref _decimalSeparator, value); }
        }
        public ICommand AddNumberCommand { get; }
        public ICommand AddDecimalSeparatorCommand { get; }
        public ICommand ClearTextCommand { get; }
        public ICommand EraseCharacterCommand { get; }
        public ICommand CalculateCommand { get; }
        public MainWindowViewModel()
        {
            calculator = new CalculatorModel();

            if (culture.NumberFormat.NumberDecimalSeparator.Equals(",")) DecimalSeparator = ",";
            else if (culture.NumberFormat.NumberDecimalSeparator.Equals(".")) DecimalSeparator = ".";
            
            _text = "";

            AddNumberCommand = new RelayCommand<string>(addNumber);
            AddDecimalSeparatorCommand = new RelayCommand(addDecimalSeparator);
            ClearTextCommand = new RelayCommand(clearText);
            EraseCharacterCommand = new RelayCommand(eraseCharacter);
            CalculateCommand = new RelayCommand(calculate);
        }

        private void addNumber(string n)
        {
            Text += n;
        }

        private void addDecimalSeparator()
        {
            Text += DecimalSeparator;
        }

        private void clearText()
        {
            Text = "";
        }

        private void eraseCharacter()
        {
            Text = Text.Remove(Text.Length - 1);
        }

        private void calculate()
        {
            Text = calculator.Calculate(Text).ToString();
        }
    }
}
