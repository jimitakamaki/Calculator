using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace Calculator.ViewModel
{
    class MainWindowViewModel
    {
        public ICommand AddNumberCommand { get; }
        public MainWindowViewModel()
        {
            AddNumberCommand = new RelayCommand(addNumber);
        }

        private void addNumber()
        {

        }
    }
}
