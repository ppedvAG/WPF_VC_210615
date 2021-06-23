using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM
{
    public class CustomCommand : ICommand
    {
        public Action<object> ExecuteMethode { get; set; }
        public Func<object, bool> CanExecuteMethode { get; set; }

        public CustomCommand(Action<object> exe, Func<object, bool> can = null)
        {
            ExecuteMethode = exe;

            CanExecuteMethode = (can == null) ? (p => true) : can;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteMethode(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteMethode(parameter);
        }
    }
}
