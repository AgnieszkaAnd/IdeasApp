using Caliburn.Micro;
using IdeasApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IdeasApp.Models;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Data.SqlClient;
using System.Data;

namespace IdeasApp {
    public class MainMenu : BootstrapperBase {
        public int SwitchView { get; set; }

        public MainMenu() {
           // Initialize();
            LetGo();

        }

        public void LetGo() {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\PCx\source\repos\IdeasApp\IdeasApp\IdeasApp\IdeasDb.db");
            EntryRepository cosTam = new EntryRepository(conn);
            Entry entry = new Entry();
            entry.Category = "asd";
            entry.TaskName = "usd";
            entry.EstimatedTime = 2;
            entry.Deadline = DateTime.Now;
            entry.Priority = "HIPEREXTRAHEHESZKI";
            
            cosTam.Create(entry);
            var readAll = cosTam.ReadAll();
            var entryToRemove = readAll.First();
            var entryToUpdate = readAll.Last();
            cosTam.Delete(entryToRemove);
            entryToUpdate.TaskName="Cowabunga!";
            cosTam.Update(entryToUpdate);
            
            //cosTam.ConvertResultToEntry();
        }
        protected override void OnStartup(object sender, StartupEventArgs e) {
            DisplayRootViewFor<MainMenuViewModel>();
        }
    }
}
