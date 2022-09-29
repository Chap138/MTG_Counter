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
        int rowCount = 0;

        public SettingsPage(Player player)
        {
            InitializeComponent();
            this.player = player;
        }

        private void CreateCommTax_Clicked(object sender, EventArgs e)
        {
            player.CommTaxVis = true;
            CreateCommTax.IsEnabled = false;
            rowCount += 1;
            player.NewBtnRow = rowCount;
        }

        private void CreateExp_Clicked(object sender, EventArgs e)
        {
            player.ExpVis = true;
            CreateExp.IsEnabled = false;
            rowCount += 1;
            player.NewBtnRow = rowCount;
        }

        private void CreatePoison_Clicked(object sender, EventArgs e)
        {
            player.ExpVis = true;
            CreatePoison.IsEnabled = false;
            rowCount += 1;
            player.NewBtnRow = rowCount;
        }

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

    }
}