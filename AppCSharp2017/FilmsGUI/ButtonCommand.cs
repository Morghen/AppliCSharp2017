using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FilmsGUI
{
    public class ButtonCommand : ICommand
    {
        private Action WhattoExecute;
        private Func<bool> WhentoExecute;

        public ButtonCommand(Action What, Func<bool> When, INotifyPropertyChanged npc)
        {
            WhattoExecute = What;
            WhentoExecute = When;

            if (npc != null)
            {
                npc.PropertyChanged += new PropertyChangedEventHandler(npc_PropertyChanged);
            }
        }

        void npc_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return WhentoExecute();
        }

        public void Execute(object parameter)
        {
            WhattoExecute();
        }

        public event EventHandler CanExecuteChanged;
    }
}
