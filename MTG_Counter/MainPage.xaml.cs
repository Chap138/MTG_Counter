using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

namespace MTG_Counter
{
    public partial class MainPage : ContentPage
    {
        Player player;
        private List<Player> playerList;

        public MainPage()
        {
            InitializeComponent();
            player = new Player();
            BindingContext = player;
            //DeleteTable();//DELETE WHEN FINISHED WITH PROJECT
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.FileName))
            {
                if (conn.Table<Player>().Count() == 0)
                {
                    int count = conn.Table<Player>().Count();//DELETE 
                    conn.Insert(player);
                }
                playerList = conn.Table<Player>().ToList();

                foreach (Player row in playerList)
                {
                    player.Life = row.Life;

                    player.CommTax = row.CommTax;
                    player.CommTaxRow = row.CommTaxRow;
                    player.CommTaxVis = row.CommTaxVis;

                    player.ExpCtr = row.ExpCtr;
                    player.ExpBtnRow = row.ExpBtnRow;
                    player.ExpVis = row.ExpVis;

                    player.PoisonCtr = row.PoisonCtr;
                    player.PoisonBtnRow = row.PoisonBtnRow;
                    player.PoisonVis = row.PoisonVis;

                    player.CommDmg1 = row.CommDmg1;
                    player.CommDmgName1 = row.CommDmgName1;
                    player.CommDmgBtnRow1 = row.CommDmgBtnRow1;
                    player.CmmDmg1Vis = row.CmmDmg1Vis;

                    player.CommDmg2 = row.CommDmg2;
                    player.CommDmgName2 = row.CommDmgName2;
                    player.CommDmgBtnRow2 = row.CommDmgBtnRow2;
                    player.CmmDmg2Vis = row.CmmDmg2Vis;

                    player.CommDmg3 = row.CommDmg3;
                    player.CommDmgName3 = row.CommDmgName3;
                    player.CommDmgBtnRow3 = row.CommDmgBtnRow3;
                    player.CmmDmg3Vis = row.CmmDmg3Vis;

                    player.CommDmg4 = row.CommDmg4;
                    player.CommDmgName4 = row.CommDmgName4;
                    player.CommDmgBtnRow4 = row.CommDmgBtnRow4;
                    player.CmmDmg4Vis = row.CmmDmg4Vis;

                    player.CreateCommDmgEnable = row.CreateCommDmgEnable;
                }

            }

        }

        protected override void OnDisappearing()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FileName))
            {
                if (conn.Table<Player>().Count() == 0)
                {
                    int count = conn.Table<Player>().Count();//DELETE 
                    conn.Insert(player);
                }

                foreach(Player row in playerList)
                {
                    row.Life = player.Life;
                    row.CommTax = player.CommTax;
                    row.ExpCtr = player.ExpCtr;
                    row.PoisonCtr = player.PoisonCtr;
                    row.CreateCommDmgEnable = player.CreateCommDmgEnable;
                    row.CommDmgButtonCount = player.CommDmgButtonCount;
                    row.CommDmg1 = player.CommDmg1;
                    row.CommDmg2 = player.CommDmg2;
                    row.CommDmg3 = player.CommDmg3;
                    row.CommDmg4 = player.CommDmg4;
                    conn.Update(row);
                }
                
            }
        }

        private void SettingsBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage(player, playerList));
        }

        private void LifeMinusBtn_Clicked(object sender, EventArgs e)
        {
            player.Life -= 1;
        }

        private void LifePlusBtn_Clicked(object sender, EventArgs e)
        {
            player.Life += 1;
        }

        private void CommTaxMinusBtn_Clicked(object sender, EventArgs e)
        {
            player.CommTax -= 2;

        }

        private void CommTaxPlusBtn_Clicked(object sender, EventArgs e)
        {
            player.CommTax += 2;
        }

        private void ExpMinusBtn_Clicked(object sender, EventArgs e)
        {
            player.ExpCtr -= 1;
        }

        private void ExpPlusBtn_Clicked(object sender, EventArgs e)
        {
            player.ExpCtr += 1;
        }

        private void PoisonMinusBtn_Clicked(object sender, EventArgs e)
        {
            player.PoisonCtr -= 1;
        }

        private void PoisonPlusBtn_Clicked(object sender, EventArgs e)
        {
            player.PoisonCtr += 1;
        }

        private void CommDmgBtn1MinusBtn_Clicked(object sender, EventArgs e)
        {
            player.CommDmg1 -= 1;
        }

        private void CommDmgBtn1PlusBtn_Clicked(object sender, EventArgs e)
        {
            player.CommDmg1 += 1;
        }

        private void CommDmgBtn2MinusBtn_Clicked(object sender, EventArgs e)
        {
            player.CommDmg2 -= 1;
        }
        private void CommDmgBtn2PlusBtn_Clicked(object sender, EventArgs e)
        {
            player.CommDmg2 += 1;
        }
        private void CommDmgBtn3MinusBtn_Clicked(object sender, EventArgs e)
        {
            player.CommDmg3 -= 1;
        }

        private void CommDmgBtn3PlusBtn_Clicked(object sender, EventArgs e)
        {
            player.CommDmg3 += 1;
        }

        private void CommDmgBtn4MinusBtn_Clicked(object sender, EventArgs e)
        {
            player.CommDmg4 -= 1;
        }
        private void CommDmgBtn4PlusBtn_Clicked(object sender, EventArgs e)
        {
            player.CommDmg4 += 1;
        }

    }
}
