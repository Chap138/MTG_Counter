using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Xaml;

namespace MTG_Counter
{
    class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private int life = 40;
        public int Life
        {
            get { return life; }

            set
            {
                life = value;
                OnPropertyChanged("Life");
            }
        }
        private int commTax = 0;
        public int CommTax
        {
            get { return commTax; }

            set
            {
                commTax = value;
                OnPropertyChanged("CommTax");
            }
        }
        private int expCtr = 0;
        public int ExpCtr
        {
            get { return expCtr; }

            set
            {
                expCtr = value;
                OnPropertyChanged("ExpCtr");
            }
        }

        private int poisonCtr = 0;
        public int PoisonCtr
        {
            get { return poisonCtr; }

            set
            {
                poisonCtr = value;
                OnPropertyChanged("PoisonCtr");
            }
        }
        private int commDmg1 = 0;
        public int CommDmg1
        {
            get { return commDmg2; }

            set
            {
                commDmg1 = value;
                OnPropertyChanged("CommDmg1");
            }
        }

        private int commDmg2 = 0;
        public int CommDmg2 
        {
            get { return commDmg2; }
            
            set 
            {
                commDmg2 = value;
                OnPropertyChanged("CommDmg2");
            }
        }

        private int commDmg3 = 0;
        public int CommDmg3
        {
            get { return commDmg3; }

            set
            {
                commDmg3 = value;
                OnPropertyChanged("CommDmg3");
            }
        }

        private int commDmg4 = 0;
        public int CommDmg4
        {
            get { return commDmg4; }

            set
            {
                commDmg4 = value;
                OnPropertyChanged("CommDmg4");
            }
        }

    }
}
