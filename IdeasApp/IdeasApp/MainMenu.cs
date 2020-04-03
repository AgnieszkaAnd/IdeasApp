using Caliburn.Micro;
using IdeasApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IdeasApp.Models;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Data.SqlClient;
using System.Data;

namespace IdeasApp {
    public class MainMenu : BootstrapperBase {
        public int SwitchView { get; set; }
        public static SQLiteConnection connectionToDB;
        public static EntryRepository ideasDataTable;

        public MainMenu() {
            Initialize();

            connectionToDB = new SQLiteConnection(@"Data Source=C:\Users\asus\Documents\CODECOOL\2_OOP\6_\IdeasApp_v10\IdeasApp\IdeasApp\IdeasDb.db");
            ideasDataTable = new EntryRepository(connectionToDB);
        }

        protected override void OnStartup(object sender, StartupEventArgs e) {
            DisplayRootViewFor<MainMenuViewModel>();
        }
    }
}
