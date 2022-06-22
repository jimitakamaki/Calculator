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
        private CalculatorModel _calculator;
        private CalculationFormatter _calcFormatter;
        private CultureInfo _culture = CultureInfo.CurrentCulture;

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
            _calculator = new CalculatorModel();
            _calcFormatter = new CalculationFormatter();

            if (_culture.NumberFormat.NumberDecimalSeparator.Equals(",")) DecimalSeparator = ",";
            else DecimalSeparator = ".";
            
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
            Text = _calcFormatter.FormatCalculationString(Text);
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
            Text = _calcFormatter.FormatCalculationString(Text);
        }

        private void calculate()
        {
            Text = _calculator.Calculate(Text).ToString();
        }
    }
}
