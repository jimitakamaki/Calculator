using System;
using System.Collections.Generic;
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
        private string _text;
        public string Text 
        { 
            get { return _text; } 
            set { SetProperty(ref _text, value); } 
        }
        public ICommand AddNumberCommand { get; }
        public ICommand ClearTextCommand { get; }
        public ICommand EraseCharacterCommand { get; }
        public ICommand CalculateCommand { get; }
        public MainWindowViewModel()
        {
            calculator = new CalculatorModel();
            _text = "";
            AddNumberCommand = new RelayCommand<string>(addNumber);
            ClearTextCommand = new RelayCommand(clearText);
            EraseCharacterCommand = new RelayCommand(eraseCharacter);
            CalculateCommand = new RelayCommand(calculate);
        }

        private void addNumber(string n)
        {
            Text += n;
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
