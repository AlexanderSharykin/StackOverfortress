using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StackOverfortress
{
    public class NavigationCommand: ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Process.Start(new ProcessStartInfo((string)parameter));
        }

        public event EventHandler CanExecuteChanged;
    }
}
