using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MTG_Counter
{
    public class Button : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public int CounterValue { get; set; }

        public bool ButtonVisibilty { get; set; } = false;
        
        public int ButtonRow { get; set; }

        public bool CreateButtonVisibility { get; set; } = true;
    }
}
