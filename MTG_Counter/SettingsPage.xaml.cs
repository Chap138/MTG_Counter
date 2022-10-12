using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MTG_Counter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        Player player;
        List<Player> playerList;
        int rowCount = 0;

        public SettingsPage(Player player, List<Player> pList)
        {
            InitializeComponent();
            this.player = player;
            this.playerList = pList;
            BindingContext = player;
        }

        protected override void OnAppearing()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FileName))
            {
                foreach (Player row in playerList)
                {
                    player.CreateCommTaxEnabled = row.CreateCommTaxEnabled;
                    player.CreateExpCtrEnabled = row.CreateExpCtrEnabled;
                    player.CreatePoisonCtrEnabled = row.CreatePoisonCtrEnabled;
                }
            }
        }

        private void CreateCommTax_Clicked(object sender, EventArgs e)
        {
            //player.CreateCommTaxEnabled = false;

            using (SQLiteConnection conn = new SQLiteConnection(App.FileName))
            {
                foreach (Player row in playerList)
                {
                    row.CommTaxVis = true;
                    player.CreateCommTaxEnabled = row.CreateCommTaxEnabled = false;
                    row.CommTaxRow = row.NewBtnRow += 1;
                    conn.Update(row);
                    break;
                }
            }
        }

        private void CreateExp_Clicked(object sender, EventArgs e)
        {
            //CreateExp.IsEnabled = false;

            using (SQLiteConnection conn = new SQLiteConnection(App.FileName))
            {
                foreach (Player row in playerList)
                {
                    row.ExpVis = true;
                    player.CreateExpCtrEnabled = row.CreateExpCtrEnabled = false;
                    row.ExpBtnRow = row.NewBtnRow += 1;
                    conn.Update(row);
                    break;
                }
            }
        }

        private void CreatePoison_Clicked(object sender, EventArgs e)
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.FileName))
            {
                foreach (Player row in playerList)
                {
                    row.PoisonVis = true;
                    player.CreatePoisonCtrEnabled = row.CreatePoisonCtrEnabled = false;
                    row.PoisonBtnRow = row.NewBtnRow += 1;
                    conn.Update(row);
                    break;
                }
            }
        }


        private void CreateCommDmg_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FileName))
            {
                foreach (Player row in playerList)
                {

                    if (row.CommDmgButtonCount == 0)
                    {
                        row.CommDmgButtonCount += 1;

                        row.CmmDmg1Vis = true;
                        row.CommDmgBtnRow1 = row.NewBtnRow += 1;
                        conn.Update(row);
                        break;
                    }
                    else if (row.CommDmgButtonCount == 1)
                    {
                        row.CommDmgButtonCount += 1;

                        row.CmmDmg2Vis = true;
                        row.CommDmgBtnRow2 = row.NewBtnRow += 1;
                        conn.Update(row);
                        break;
                    }
                    else if (row.CommDmgButtonCount == 2)
                    {
                        row.CommDmgButtonCount += 1;

                        row.CmmDmg3Vis = true;
                        row.CommDmgBtnRow3 = row.NewBtnRow += 1;
                        conn.Update(row);
                        break;
                    }
                    else if (row.CommDmgButtonCount == 3)
                    {
                        row.CommDmgButtonCount += 1;

                        row.CmmDmg4Vis = true;
                        player.CreateCommDmgEnable = row.CreateCommDmgEnable = false;
                        row.CommDmgBtnRow4 = row.NewBtnRow += 1;
                        conn.Update(row);
                        break;
                    }
                }
            }
        }

        //private void CreateCommDmg2_Clicked(object sender, EventArgs e)
        //{
        //    player.CmmDmg2Vis = true;
        //    //CreateCommDmg2.IsEnabled = false;
        //    rowCount += 1;
        //    player.NewBtnRow = rowCount;
        //}

        //private void CreateCommDmg3_Clicked(object sender, EventArgs e)
        //{
        //    player.CmmDmg3Vis = true;
        //    //CreateCommDmg3.IsEnabled = false;
        //    rowCount += 1;
        //    player.NewBtnRow = rowCount;
        //}

        //private void CreateCommDmg4_Clicked(object sender, EventArgs e)
        //{
        //    player.CmmDmg4Vis = true;
        //    //CreateCommDmg4.IsEnabled = false;
        //    rowCount += 1;
        //    player.NewBtnRow = rowCount;
        //    DisplayAlert("Row Count", Convert.ToString(player.NewBtnRow), "Cancel");
        //}
        //#endregion


        private async void ResetBtn_Clicked(object sender, EventArgs e)
        {
            bool confirmReset = await DisplayAlert("", "Are you sure you want to reset the buttons?", "Yes", "No");

            if (confirmReset)
            {
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
                        row.Life = 40;
                        row.NewBtnRow = 0;//Need 

                        row.CommTax = 0;
                        player.CreateCommTaxEnabled = row.CreateCommTaxEnabled = true;
                        row.CommTaxRow = 0;
                        row.CommTaxVis = false;

                        row.ExpCtr = 0;
                        player.CreateExpCtrEnabled = row.CreateExpCtrEnabled = true;
                        row.ExpBtnRow = 0;
                        row.ExpVis = false;

                        row.PoisonCtr = 0;
                        player.CreatePoisonCtrEnabled = row.CreatePoisonCtrEnabled = true;
                        row.PoisonBtnRow = 0;
                        row.PoisonVis = false;

                        row.CommDmg1 = 0;
                        //player.CreatePoisonCtrEnabled = row.CreatePoisonCtrEnabled = true; //Minus commDmgButton number of buttons created
                        row.CommDmgBtnRow1 = 0;
                        row.CmmDmg1Vis = false;

                        row.CommDmg2 = 0;
                        //player.CreatePoisonCtrEnabled = row.CreatePoisonCtrEnabled = true; //Minus commDmgButton number of buttons created
                        row.CommDmgBtnRow2 = 0;
                        row.CmmDmg2Vis = false;

                        row.CommDmg3 = 0;
                        //player.CreatePoisonCtrEnabled = row.CreatePoisonCtrEnabled = true; //Minus commDmgButton number of buttons created
                        row.CommDmgBtnRow3 = 0;
                        row.CmmDmg3Vis = false;

                        row.CommDmg4 = 0;
                        //player.CreatePoisonCtrEnabled = row.CreatePoisonCtrEnabled = true; //Minus commDmgButton number of buttons created
                        row.CommDmgBtnRow4 = 0;
                        row.CmmDmg4Vis = false;

                        player.CreateCommDmgEnable = row.CreateCommDmgEnable = true;
                        row.CommDmgButtonCount = 0;

                        conn.Update(row);
                    }
                }//end using statement
            }//end if
        }//end ResetBtn_Clicked
    }
}