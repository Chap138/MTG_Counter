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
            using(SQLiteConnection conn = new SQLiteConnection(App.FileName))
            {
                foreach(Player row in playerList)
                {
                    player.CreateCommTaxEnabled = row.CreateCommTaxEnabled;
                }
            }
        }

        private void CreateCommTax_Clicked(object sender, EventArgs e)
        {
            //player.CommTaxVis = true;
            //CreateCommTax.IsEnabled = false;
            //player.CreateCommTaxEnabled = false;
            //rowCount = ;
            //player.NewBtnRow = rowCount;
            //player.CommTaxRow = player.NewBtnRow;
            player.CreateCommTaxEnabled = false;

            using (SQLiteConnection conn = new SQLiteConnection(App.FileName))
            {
                foreach (Player row in playerList)
                {
                    row.CommTaxVis = true;
                    row.CreateCommTaxEnabled = false;
                    //row.CommTaxVis = player.CommTaxVis;
                    //row.NewBtnRow += 1;
                    row.CommTaxRow = row.NewBtnRow += 1;
                    conn.Update(row);
                    break;
                }
            }
        }

        private void CreateExp_Clicked(object sender, EventArgs e)
        {
            //player.ExpVis = true;
            CreateExp.IsEnabled = false;
            //rowCount += 1;
            //player.NewBtnRow = rowCount;

            //player.CommTaxVis = true;
            //CreateCommTax.IsEnabled = false;
            //rowCount = ;
            //player.NewBtnRow = rowCount;
            //player.CommTaxRow = player.NewBtnRow;

            using (SQLiteConnection conn = new SQLiteConnection(App.FileName))
            {
                foreach (Player row in playerList)
                {
                    row.ExpVis = true;
                    //row.CommTaxVis = player.CommTaxVis;
                    //row.NewBtnRow += 1;
                    row.ExpBtnRow = row.NewBtnRow += 1;
                    conn.Update(row);
                    break;
                }
            }
        }

        private void CreatePoison_Clicked(object sender, EventArgs e)
        {
            player.ExpVis = true;
            CreatePoison.IsEnabled = false;
            rowCount += 1;
            player.NewBtnRow = rowCount;
        }


        #region
        private void CreateCommDmg1_Clicked(object sender, EventArgs e)
        {
            player.CmmDmg1Vis = true;
            CreateCommDmg1.IsEnabled = false;
            rowCount += 1;
            player.NewBtnRow = rowCount;
        }

        private void CreateCommDmg2_Clicked(object sender, EventArgs e)
        {
            player.CmmDmg2Vis = true;
            CreateCommDmg2.IsEnabled = false;
            rowCount += 1;
            player.NewBtnRow = rowCount;
        }

        private void CreateCommDmg3_Clicked(object sender, EventArgs e)
        {
            player.CmmDmg3Vis = true;
            CreateCommDmg3.IsEnabled = false;
            rowCount += 1;
            player.NewBtnRow = rowCount;
        }

        private void CreateCommDmg4_Clicked(object sender, EventArgs e)
        {
            player.CmmDmg4Vis = true;
            CreateCommDmg4.IsEnabled = false;
            rowCount += 1;
            player.NewBtnRow = rowCount;
            DisplayAlert("Row Count", Convert.ToString(player.NewBtnRow), "Cancel");
        }
#endregion 



        private void ResetBtn_Clicked(object sender, EventArgs e)
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
                    row.NewBtnRow = 0;
                    row.CommTax = 0;
                    player.CreateCommTaxEnabled = row.CreateCommTaxEnabled = true;
                    row.CommTaxRow = 0;
                    row.CommTaxVis = false;
                    row.ExpCtr = 0;
                    row.ExpBtnRow = 0;
                    row.ExpVis = false;
                    //row.PoisonCtr = player.PoisonCtr;
                    row.PoisonVis = false;
                    //playerList[0].PoisonBtnRow = player.Life;
                    //int rows = conn.Update(row);
                    conn.Update(row);
                }
            }
        }
    }
}