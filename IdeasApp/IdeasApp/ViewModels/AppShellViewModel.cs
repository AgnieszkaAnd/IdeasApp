using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using IdeasApp.Models;

namespace IdeasApp.ViewModels {
    class AppShellViewModel : Conductor<object>.Collection.OneActive {
        public DbConnection DatabaseConnection { get; set; } = new SQLiteConnection(@"data source=C:\Users\asus\Documents\CODECOOL\2_OOP\6_\IdeasApp_v10\IdeasApp\IdeasApp\IdeasDb.db");

        public AppShellViewModel() {
            ShowMainMenu();
        }

        public void ShowMainMenu() {
            ActivateItem(new MainMenuViewModel(DatabaseConnection));
        }

        public void ShowTasksList() {
            ActivateItem(new TasksListViewModel(DatabaseConnection));
        }

    }
}
