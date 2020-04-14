using Caliburn.Micro;
using IdeasApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;

namespace IdeasApp.ViewModels {
    class UpdateEntryViewModel : Screen {
		public string UpdateEntryCategory { get; set; }
		public string UpdateEntryTaskName { get; set; }
		public string UpdateEntryPriority { get; set; }
		public int UpdateEntryEstTime { get; set; }
		public DateTime UpdateEntryDeadline { get; set; }

		public List<string> Priorities { get; set; } = new List<string>() {
			"IMPORTANT_URGENT",
			"IMPORTANT_NOT_URGENT",
			"NOT_IMPORTANT_URGENT",
			"NOT_IMPORTANT_NOT_URGENT"
		};
		private IDataAccessObject IdeasDataTable { get; set; }


		public UpdateEntryViewModel(DbConnection DBconnection) {
			this.IdeasDataTable = new EntryRepository((SQLiteConnection)DBconnection);
			try {
				UpdateEntryCategory = TasksListViewModel.SelectedEntry.Category;
				UpdateEntryTaskName = TasksListViewModel.SelectedEntry.TaskName;
				UpdateEntryPriority = TasksListViewModel.SelectedEntry.Priority;
				UpdateEntryEstTime = TasksListViewModel.SelectedEntry.EstimatedTime;
				UpdateEntryDeadline = TasksListViewModel.SelectedEntry.Deadline;
			} catch { }
		}

		public void UpdateButton_Click(object sender, EventArgs e) {
			try {
				TasksListViewModel.SelectedEntry.Category = UpdateEntryCategory;
				TasksListViewModel.SelectedEntry.TaskName = UpdateEntryTaskName;
				TasksListViewModel.SelectedEntry.Priority = UpdateEntryPriority;
				TasksListViewModel.SelectedEntry.EstimatedTime = UpdateEntryEstTime;
				TasksListViewModel.SelectedEntry.Deadline = UpdateEntryDeadline;
				IdeasDataTable.Update(TasksListViewModel.SelectedEntry);
			// TODO add logic under catch statement
			} catch (NullReferenceException) { }
			MainMenuViewModel.taskTableView.Ideas.Refresh();
			this.TryClose();
		}

	}
}
