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
        private CalculationSplitter _calcSplitter;
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
        public ICommand AddMathematicalOperatorCommand { get; }
        public ICommand AddDecimalSeparatorCommand { get; }
        public ICommand ClearTextCommand { get; }
        public ICommand EraseCharacterCommand { get; }
        public ICommand CalculateCommand { get; }
        public MainWindowViewModel()
        {
            _calculator = new CalculatorModel();
            _calcFormatter = new CalculationFormatter();
            _calcSplitter = new CalculationSplitter();

            if (_culture.NumberFormat.NumberDecimalSeparator.Equals(",")) DecimalSeparator = ",";
            else DecimalSeparator = ".";

            _text = "0";

            AddNumberCommand = new RelayCommand<string>(addNumber);
            AddMathematicalOperatorCommand = new RelayCommand<string>(addMathematicalOperator);
            AddDecimalSeparatorCommand = new RelayCommand(addDecimalSeparator);
            ClearTextCommand = new RelayCommand(clearText);
            EraseCharacterCommand = new RelayCommand(eraseCharacter);
            CalculateCommand = new RelayCommand(calculate);
        }

        private void addNumber(string n)
        {
            if (_calcSplitter.SplitIntoList(Text).Last().Length <= 28)
            {
                if (Text.Equals("0")) Text = n;
                else Text += n;
                Text = _calcFormatter.FormatCalculationString(Text);
            }
        }

        private void addMathematicalOperator(string m)
        {
            try
            {
                decimal.Parse(_calcSplitter.SplitIntoList(Text).Last());
                Text += m;
            }
            catch
            {
                Text = Text.Remove(Text.Length - 1);
                Text += m;
            }
        }

        private void addDecimalSeparator()
        {
            if (_calcSplitter.SplitIntoList(Text).Last().Length <= 27) Text += DecimalSeparator;
        }

        private void clearText()
        {
            Text = "0";
        }

        private void eraseCharacter()
        {
            Text = Text.Remove(Text.Length - 1);
            Text = _calcFormatter.FormatCalculationString(Text);
            if (Text.Length == 0) Text = "0";
        }

        private void calculate()
        {
            Text = _calculator.Calculate(Text).ToString();
        }
    }
}
