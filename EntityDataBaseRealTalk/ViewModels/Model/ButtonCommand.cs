using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EntityDataBaseRealTalk.ViewModels.Model
{
    class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged // оповещает форму активна ли кнопка
        {
            add { CommandManager.RequerySuggested += value; } 
            remove { CommandManager.RequerySuggested -= value; }
        }
        Action<object> _action; // void
        Func<bool> _func; // имеет возвращаемый тип
        public ButtonCommand (Action <object> action, Func <bool> func=null)
        {
            _action = action;
            _func = func;
        } 

        public bool CanExecute(object parameter)
        {
            return _func == null || _func(); // if(_func == null || _func())
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}