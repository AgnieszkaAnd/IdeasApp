using Caliburn.Micro;
using System.Data.Common;

namespace IdeasApp.ViewModels {
    public class MainMenuViewModel : Conductor<object>.Collection.OneActive {
        public static TasksListViewModel taskTableView;

        public DbConnection DatabaseConnection { get; set; }

        public MainMenuViewModel(DbConnection DBconnection) {
            this.DatabaseConnection = DBconnection;
        }

        public void LoadTasksList() {
            taskTableView = new TasksListViewModel(DatabaseConnection);
            ActivateItem(taskTableView);
        }
    }
}
