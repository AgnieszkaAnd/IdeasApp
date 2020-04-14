﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows;
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


		public AddEntryViewModel(SQLiteConnection sqliteConnecton) {
			this.IdeasDataTable = new EntryRepository(sqliteConnecton);
		}

		public void AddButton_Click(object sender, EventArgs e) {
			NewEntry = new Entry();
			this.NewEntry.Category = NewEntryCategory;
			this.NewEntry.TaskName = NewEntryTaskName;
			this.NewEntry.Priority = NewEntryPriority;
			this.NewEntry.EstimatedTime = NewEntryEstTime;
			this.NewEntry.Deadline = NewEntryDeadline;
			IdeasDataTable.Create(NewEntry);
			MainMenuViewModel.taskTableView.Ideas.Add(NewEntry);
			this.TryClose();
		}
	}
}
