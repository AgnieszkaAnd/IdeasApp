using IdeasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IdeasApp.ViewModels {
    class UpdateEntryViewModel : Window {
		public string UpdateEntryCategory { get; set; }
		public string UpdateEntryTaskName { get; set; }
		public string UpdateEntryPriority { get; set; }
		public int UpdateEntryEstTime { get; set; }

		public void UpdateButton_Click(object sender, EventArgs e) {
			TasksListViewModel.SelectedEntry.Category = UpdateEntryCategory;
			TasksListViewModel.SelectedEntry.TaskName = UpdateEntryTaskName;
			TasksListViewModel.SelectedEntry.Priority = UpdateEntryPriority;
			TasksListViewModel.SelectedEntry.EstimatedTime = UpdateEntryEstTime;
			TasksListViewModel.SelectedEntry.Deadline = DateTime.Now;
			MainMenu.ideasDataTable.Update(TasksListViewModel.SelectedEntry);
			MainMenuViewModel.taskTableView.Ideas.Refresh();
		}

	}
}
