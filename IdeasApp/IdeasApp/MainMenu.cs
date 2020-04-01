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
        public MainMenu() {
            Initialize();
            LetGo();

        }

        public void LetGo() {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\PCx\source\repos\IdeasApp\IdeasApp\IdeasApp\IdeasDb.db");
            EntryRepository cosTam = new EntryRepository(conn);
            var swag = cosTam.ReadAll();
            //cosTam.ConvertResultToEntry();
        }
        protected override void OnStartup(object sender, StartupEventArgs e) {
        }
    }
}
