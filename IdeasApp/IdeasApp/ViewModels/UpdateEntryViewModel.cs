using Caliburn.Micro;
using IdeasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IdeasApp.ViewModels {
    class UpdateEntryViewModel : Screen {
		public string UpdateEntryCategory { get; set; } = TasksListViewModel.SelectedEntry.Category;
		public string UpdateEntryTaskName { get; set; } = TasksListViewModel.SelectedEntry.TaskName;
		public string UpdateEntryPriority { get; set; } = TasksListViewModel.SelectedEntry.Priority;
		public int UpdateEntryEstTime { get; set; } = TasksListViewModel.SelectedEntry.EstimatedTime;
		public DateTime UpdateEntryDeadline { get; set; } = TasksListViewModel.SelectedEntry.Deadline;

		public List<string> Priorities { get; set; } = new List<string>() {
			"IMPORTANT_URGENT",
			"IMPORTANT_NOT_URGENT",
			"NOT_IMPORTANT_URGENT",
			"NOT_IMPORTANT_NOT_URGENT"
		};
		public void UpdateButton_Click(object sender, EventArgs e) {
			try {
				TasksListViewModel.SelectedEntry.Category = UpdateEntryCategory;
				TasksListViewModel.SelectedEntry.TaskName = UpdateEntryTaskName;
				TasksListViewModel.SelectedEntry.Priority = UpdateEntryPriority;
				TasksListViewModel.SelectedEntry.EstimatedTime = UpdateEntryEstTime;
				TasksListViewModel.SelectedEntry.Deadline = UpdateEntryDeadline;
				Startup.ideasDataTable.Update(TasksListViewModel.SelectedEntry);
			// TODO add logic under catch statement
			} catch (NullReferenceException) { }
			MainMenuViewModel.taskTableView.Ideas.Refresh();
			this.TryClose();
		}

	}
}
