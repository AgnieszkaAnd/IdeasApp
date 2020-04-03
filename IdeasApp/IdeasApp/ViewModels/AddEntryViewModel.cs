using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Caliburn.Micro;
using IdeasApp.Models;

namespace IdeasApp.ViewModels {
	public partial class AddEntryViewModel : Window {
		public string NewEntryCategory { get; set; }
		public string NewEntryTaskName { get; set; }
		public string NewEntryPriority { get; set; }
		public int NewEntryEstTime { get; set; }
		public DateTime NewEntryDeadline { get; set; }

		public Entry NewEntry { get; set; }

		public void AddButton_Click(object sender, EventArgs e) {
			NewEntry = new Entry();
			this.NewEntry.Category = NewEntryCategory;
			this.NewEntry.TaskName = NewEntryTaskName;
			this.NewEntry.Priority = NewEntryPriority;
			this.NewEntry.EstimatedTime = NewEntryEstTime;
			this.NewEntry.Deadline = DateTime.Now;
			MainMenu.ideasDataTable.Create(NewEntry);
			MainMenuViewModel.taskTableView.Ideas.Refresh();
		}
	}
}
