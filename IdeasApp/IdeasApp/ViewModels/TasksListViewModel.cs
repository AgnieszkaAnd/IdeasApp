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

        public static IWindowManager manager = new WindowManager();
        public static Entry SelectedEntry { get; set; }

        public BindableCollection<Entry> Ideas { get; set; }

        public TasksListViewModel() {
            var ideasList = MainMenu.ideasDataTable.ReadAll();
            Ideas = new BindableCollection<Entry>(ideasList);
        }
        public void AddEntry() {
            AddEntryViewModel addingWindow = new AddEntryViewModel();
            manager.ShowWindow(addingWindow, null, null);
            ActivateItem(addingWindow);
        }

        public void UpdateEntry() {
            UpdateEntryViewModel updateWindow = new UpdateEntryViewModel();
            manager.ShowWindow(updateWindow, null, null);
            ActivateItem(updateWindow);
        }

        public void DeleteEntry() {
            MainMenu.ideasDataTable.Delete(SelectedEntry);
            MainMenuViewModel.taskTableView.Ideas.Refresh();
        }
    }
}
