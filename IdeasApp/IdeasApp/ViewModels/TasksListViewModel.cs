using Caliburn.Micro;
using IdeasApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IdeasApp.ViewModels {

    public class TasksListViewModel : Conductor<object>.Collection.OneActive {

        public static WindowManager manager = new WindowManager();
        public static Entry SelectedEntry { get; set; }
        private AddEntryViewModel addingWindow;
        private UpdateEntryViewModel updateWindow;
        private SQLiteConnection SqliteConn { get; set; }
        private EntryRepository IdeasDataTable { get; set; }
        private List<Entry> IdeasList { get; set; } 
        public BindableCollection<Entry> Ideas { get; set; }


        public TasksListViewModel(SQLiteConnection sqliteConnection) {
            this.SqliteConn = sqliteConnection;
            IdeasDataTable = new EntryRepository(sqliteConnection);
            IdeasList = IdeasDataTable.ReadAll();
            Ideas = new BindableCollection<Entry>(IdeasList);
        }
        public void AddEntry() {
            this.addingWindow = new AddEntryViewModel(SqliteConn);
            manager.ShowWindow(addingWindow, null, null);
            ActivateItem(addingWindow);
        }

        public void UpdateEntry() {
            this.updateWindow = new UpdateEntryViewModel(SqliteConn);
            manager.ShowWindow(updateWindow, null, null);
            ActivateItem(updateWindow);
        }

        public void DeleteEntry() {
            IdeasDataTable.Delete(SelectedEntry);
            MainMenuViewModel.taskTableView.Ideas.Remove(SelectedEntry);
        }
    }
}
