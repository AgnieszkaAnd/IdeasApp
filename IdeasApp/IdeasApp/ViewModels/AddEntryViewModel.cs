using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using Caliburn.Micro;
using IdeasApp.Models;

namespace IdeasApp.ViewModels {
	public partial class AddEntryViewModel : Screen {
		public string NewEntryCategory { get; set; }
		public string NewEntryTaskName { get; set; }
		public string NewEntryPriority { get; set; }
		public int NewEntryEstTime { get; set; }
		public DateTime NewEntryDeadline { get; set; } = DateTime.Now;

		public Entry NewEntry { get; set; }

		public List<string> Priorities { get; set; } = new List<string>() {
			"IMPORTANT_URGENT",
			"IMPORTANT_NOT_URGENT",
			"NOT_IMPORTANT_URGENT",
			"NOT_IMPORTANT_NOT_URGENT"
		};
		private IDataAccessObject IdeasDataTable { get; set; }


		public AddEntryViewModel(DbConnection DBconnection) {
			this.IdeasDataTable = new EntryRepository((SQLiteConnection)DBconnection);
		}

		public void AddButton_Click(object sender, EventArgs e) {
			NewEntry = new Entry();
			this.NewEntry.Category = NewEntryCategory;
			this.NewEntry.TaskName = NewEntryTaskName;
			this.NewEntry.Priority = NewEntryPriority;
			this.NewEntry.EstimatedTime = NewEntryEstTime;
			this.NewEntry.Deadline = NewEntryDeadline;
			IdeasDataTable.Create(NewEntry);
			// TODO: Update workaround to final version
			// --- WORKAROUND TO UPDATE ID'S IN DATAGRID ---
			int index = MainMenuViewModel.taskTableView.Ideas.Count - 1;
			this.NewEntry.Id = MainMenuViewModel.taskTableView.Ideas[index].Id + 1;
			MainMenuViewModel.taskTableView.Ideas.Add(NewEntry);
			// ---------------------------------------------------
			//MainMenuViewModel.taskTableView.RefreshIdeas();
			//MainMenuViewModel.taskTableView.Ideas.Refresh();
			this.TryClose();
		}
	}
}
