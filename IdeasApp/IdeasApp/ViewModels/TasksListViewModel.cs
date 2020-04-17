using Caliburn.Micro;
using IdeasApp.Models;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;

namespace IdeasApp.ViewModels {

    public class TasksListViewModel : Conductor<object>.Collection.OneActive {

        public static WindowManager manager = new WindowManager();
        private AddEntryViewModel addingWindow;
        private UpdateEntryViewModel updateWindow;
        private DbConnection DatabaseConnection { get; set; }
        private IDataAccessObject IdeasDataTable { get; set; }
        public List<Entry> IdeasList { get; set; } 
        public BindableCollection<Entry> Ideas { get; set; }
        public static Entry SelectedEntry { get; set; }

        public TasksListViewModel(DbConnection DBconnection) {
            this.DatabaseConnection = DBconnection;
            IdeasDataTable = new EntryRepository((SQLiteConnection)DBconnection);
            IdeasList = IdeasDataTable.ReadAll();
            Ideas = new BindableCollection<Entry>(IdeasList);
        }
        public void RefreshIdeas() {
            Ideas = new BindableCollection<Entry>();
            DbConnection DatabaseConnection_test = new SQLiteConnection(@"data source=C:\Users\asus\Documents\CODECOOL\2_OOP\6_\IdeasApp_v10\IdeasApp\IdeasApp\IdeasDb.db");
            IdeasDataTable = new EntryRepository((SQLiteConnection)DatabaseConnection_test);
            IdeasList = IdeasDataTable.ReadAll();
            Ideas = new BindableCollection<Entry>(IdeasList);
            Ideas.Refresh();
        }
        public void AddEntry() {
            this.addingWindow = new AddEntryViewModel(DatabaseConnection);
            manager.ShowWindow(addingWindow, null, null);
            ActivateItem(addingWindow);
        }

        public void UpdateEntry() {
            this.updateWindow = new UpdateEntryViewModel(DatabaseConnection);
            manager.ShowWindow(updateWindow, null, null);
            ActivateItem(updateWindow);
        }

        public void DeleteEntry() {
            IdeasDataTable.Delete(SelectedEntry);
            MainMenuViewModel.taskTableView.Ideas.Remove(SelectedEntry);
        }
    }
}
