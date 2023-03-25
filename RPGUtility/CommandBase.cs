using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RPGUtility
{
    internal abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            //throw new NotImplementedException();
            return true;
        }

        public abstract void Execute(object? parameter);
        
        public void RaiseCanExecuteChanged() 
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());//nie dokonczone
        }
    }
}
