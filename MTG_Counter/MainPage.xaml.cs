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

                }

                //player.Life = playerList[0].Life;
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

    }
}
