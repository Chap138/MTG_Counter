using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MTG_Counter
{
    public partial class MainPage : ContentPage
    {
        Player player;
        public MainPage()
        {
            InitializeComponent();
            player = new Player(); ;
            BindingContext = player;
        }

        private void SettingsBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
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
            player.CommTax -= 1;
        }

        private void CommTaxPlusBtn_Clicked(object sender, EventArgs e)
        {
            player.CommTax += 1;
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
