using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StackOverfortress
{
    public class CommandBase: ICommand
    {
        private Action<object> _exec;

        public CommandBase(Action<object> exec)
        {
            _exec = exec;
        }

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public virtual void Execute(object parameter)
        {
            _exec(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
