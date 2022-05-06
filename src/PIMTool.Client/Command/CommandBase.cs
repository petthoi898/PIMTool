using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PIMTool.Client.Command
{
    public abstract class CommandBase : ICommand
    {
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged;

        protected void OnCanExcutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}