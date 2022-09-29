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

            //DeleteTable();//DELETE WHEN FINISHED WITH PROJECT
            //CreatePlayerTable();

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
                    //LifeLabel.Text = Convert.ToString(row.Life);
                    player.Life = row.Life;
                }

                //player.Life = playerList[0].Life;
            }

        }

        protected override void OnDisappearing()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FileName))
            {
                //if (conn.Table<Player>().Count() <= 0)
                //{
                //    DisplayAlert("!", conn.Table<Player>().Count().ToString(), "OK");
                //}
                if (conn.Table<Player>().Count() == 0)
                {
                    int count = conn.Table<Player>().Count();//DELETE 
                    conn.Insert(player);
                }
                //playerList[0].Life = player.Life;

                foreach(Player row in playerList)
                {
                    row.Life = player.Life;
                    //int rows = conn.Update(row);
                    conn.Update(row);
                }
                
            }
        }

        //private void CreatePlayerTable()
        //{
        //    using (SQLiteConnection conn = new SQLiteConnection(App.FileName))
        //    {
        //        conn.CreateTable<Player>();

        //        if (conn.Table<Player>().Count() <= 0)
        //        {
        //            conn.Insert(player);
        //            //playerInfo = conn.Table<Player>().ToList();
        //        }
        //    }
        //}

        private void SettingsBtn_Clicked(object sender, EventArgs e)
        {
        //    using (SQLiteConnection conn = new SQLiteConnection(App.FileName))
        //    {
        //        if (conn.Table<Player>().Count() == 0)
        //        {
        //            int count = conn.Table<Player>().Count();//DELETE 
        //            conn.Insert(player);
        //        }

        //        playerList[0].Life = player.Life;
        //        playerList[0].CommTax = player.CommTax;
        //        playerList[0].CommTaxRow = player.CommTaxRow;
        //        playerList[0].CommTaxVis = player.CommTaxVis;
        //        playerList[0].ExpCtr = player.ExpCtr;
        //        playerList[0].ExpBtnRow = player.ExpBtnRow;
        //        playerList[0].ExpVis = player.ExpVis;
        //        playerList[0].PoisonCtr = player.PoisonCtr;
        //        playerList[0].PoisonVis = player.PoisonVis;
        //        //playerList[0].PoisonBtnRow = player.Life;

        //        conn.Update(player);
        //    }
            Navigation.PushAsync(new SettingsPage(player));
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

        private void DeleteTable()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FileName))
            {
                //playerInfo.Clear();
                conn.DropTable<Player>();
                //conn.CreateTable<Player>();
            }
        }
    }
}
