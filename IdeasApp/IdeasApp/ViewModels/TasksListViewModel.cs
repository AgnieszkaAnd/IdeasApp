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
    public class TasksListViewModel : Conductor<object> {


        public BindableCollection<Entry> Ideas { get; set; }

        public TasksListViewModel() {
            SQLiteConnection connectionToDB = new SQLiteConnection(@"Data Source=C:\Users\asus\Documents\CODECOOL\2_OOP\6_\IdeasApp_v10\IdeasApp\IdeasApp\IdeasDb.db");

            EntryRepository ideasDataTable = new EntryRepository(connectionToDB);
            var ideasList = ideasDataTable.ReadAll();
            Ideas = new BindableCollection<Entry>(ideasList);
        }
        public void AddEntry() {
            ActivateItem(new AddEntryViewModel());
        }

        public void UpdateEntry() {
        }

        public void DeleteEntry() {
        }
        /*private void btnEnterName_Click(object sender, RoutedEventArgs e) {
            AddEntryViewModel inputDialog = new AddEntryViewModel("Please enter your name:", "John Doe");
        }*/

    }
}
