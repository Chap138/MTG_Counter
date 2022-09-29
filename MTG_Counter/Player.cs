using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Xaml;
using SQLite;

namespace MTG_Counter
{
    /// <summary> 
    /// <remarks> All the properties for the player's button customization. Also properties for counters. </remarks>
    /// </summary>

    public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

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

        private bool commTaxVis = false;
        public bool CommTaxVis
        {
            get { return commTaxVis; }

            set
            {
                commTaxVis = value;
                OnPropertyChanged("CommTaxVis");
            }
        }

        private int commTaxRow = 0;
        public int CommTaxRow
        {
            get { return commTaxRow; }

            set
            {
                commTaxRow = value;
                OnPropertyChanged("CommTaxRow");
            }
        }

        private bool expVis = false;
        public bool ExpVis
        {
            get { return expVis; }

            set
            {
                expVis = value;
                OnPropertyChanged("ExpVis");
            }
        }

        private bool poisonVis = false;
        public bool PoisonVis
        {
            get { return poisonVis; }

            set
            {
                poisonVis = value;
                OnPropertyChanged("PoisonVis");
            }
        }

        private int poisonBtnRow = 0;
        public int PoisonBtnRow
        {
            get { return poisonBtnRow; }

            set
            {
                poisonBtnRow = value;
                OnPropertyChanged("PoisonBtnRow");
            }
        }

        private bool cmmDmg1Vis = false;
        public bool CmmDmg1Vis
        {
            get { return cmmDmg1Vis; }

            set
            {
                cmmDmg1Vis = value;
                OnPropertyChanged("CmmDmg1Vis");
            }
        }

        private bool cmmDmg2Vis = false;
        public bool CmmDmg2Vis
        {
            get { return cmmDmg2Vis; }

            set
            {
                cmmDmg2Vis = value;
                OnPropertyChanged("CmmDmg2Vis");
            }
        }

        private bool cmmDmg3Vis = false;
        public bool CmmDmg3Vis
        {
            get { return cmmDmg3Vis; }

            set
            {
                cmmDmg3Vis = value;
                OnPropertyChanged("CmmDmg3Vis");
            }
        }

        private bool cmmDmg4Vis = false;
        public bool CmmDmg4Vis
        {
            get { return cmmDmg4Vis; }

            set
            {
                cmmDmg4Vis = value;
                OnPropertyChanged("CmmDmg4Vis");
            }
        }

        private int newBtnRow = 0;
        public int NewBtnRow
        {
            get { return newBtnRow; }

            set
            {
                newBtnRow = value;
                OnPropertyChanged("NewBtnRow");
            }
        }

        private int expBtnRow = 0;
        public int ExpBtnRow
        {
            get { return expBtnRow; }

            set
            {
                expBtnRow = value;
                OnPropertyChanged("ExpBtnRow");
            }
        }

        private bool createCommTaxEnabled = true;
        public bool CreateCommTaxEnabled
        {
            get { return createCommTaxEnabled; }

            set
            {
                createCommTaxEnabled = value;
                OnPropertyChanged("CreateCommTaxEnabled");
            }
        }

        private bool createExpCtrEnabled = true;
        public bool CreateExpCtrEnabled
        {
            get { return createExpCtrEnabled; }

            set
            {
                createExpCtrEnabled = value;
                OnPropertyChanged("CreateExpCtrEnabled");
            }
        }
        private bool createPoisonCtrEnabled = true;
        public bool CreatePoisonCtrEnabled
        {
            get { return createPoisonCtrEnabled; }

            set
            {
                createPoisonCtrEnabled = value;
                OnPropertyChanged("CreatePoisonCtrEnabled");
            }
        }

    }
}
