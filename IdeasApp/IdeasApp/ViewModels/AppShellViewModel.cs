using System.Data.Common;
using System.Data.SQLite;
using Caliburn.Micro;

namespace IdeasApp.ViewModels {
    class AppShellViewModel : Conductor<object>.Collection.OneActive {
        public DbConnection DatabaseConnection { get; set; } = new SQLiteConnection(@"data source=..\..\..\IdeasDb.db");

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
