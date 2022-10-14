using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MTG_Counter
{
    public partial class App : Application
    {
        public static string FileName;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        public App(string fileName)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            FileName = fileName;
            //DeleteTable();
            CreatePlayerTable();
        }

        private void CreatePlayerTable()
        {
            using (SQLiteConnection conn = new SQLiteConnection(FileName))
            {
                conn.CreateTable<Player>();
            }
        }//end CreatePlayerTable

        private void DeleteTable()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FileName))
            {
                conn.DropTable<Player>();
            }
        }//end DeleteTable

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
