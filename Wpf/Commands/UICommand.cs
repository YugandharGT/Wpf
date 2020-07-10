using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpf.Commands
{
    /// <summary>
    /// It represents the Hook Up between View and ViewModel
    /// </summary>
    public class UICommand : ICommand
    {
        Action<object> _TargetExecuteMethod;
        Func<object,bool> _TargetCanExecuteMethod;

        public UICommand(Action<object> executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public UICommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {

            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod(parameter);
            }

            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }
		
      // Beware - should use weak references if command instance lifetime 
      //  is longer than lifetime of UI objects that get hooked up to command

      // Prism commands solve this in their implementation 
        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod(parameter);
            }
        }
    }
}
