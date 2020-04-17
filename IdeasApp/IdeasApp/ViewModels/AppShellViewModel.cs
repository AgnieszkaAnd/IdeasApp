using System.Data.Common;
using System.Data.SQLite;
using Caliburn.Micro;

namespace IdeasApp.ViewModels {
    class AppShellViewModel : Conductor<object>.Collection.OneActive {
        public DbConnection DatabaseConnection { get; set; } = new SQLiteConnection(@"data source=C:\Users\asus\Documents\CODECOOL\2_OOP\6_\IdeasApp_v10\IdeasApp\IdeasApp\IdeasDb.db");
        //public string DBfilepath { get; set; }
        //public DbConnection DatabaseConnection { get; set; }

        public AppShellViewModel() {
            //string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            //DBfilepath = System.IO.Path.GetDirectoryName(path).TrimStart('f','i','l','e',':');
            //DBfilepath = "data source=" + DBfilepath + "\\..\\..\\..\\IdeasDb.db";
            //DatabaseConnection = new SQLiteConnection(DBfilepath);
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
