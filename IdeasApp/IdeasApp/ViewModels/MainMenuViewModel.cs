﻿using Caliburn.Micro;
using IdeasApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeasApp.ViewModels {
    public class MainMenuViewModel : Conductor<object>.Collection.OneActive {

        //TODO
        /*public MainMenuViewModel(EntryRepository databaseConnenction) {
                
        }*/
        public SQLiteConnection SqliteConnection { get; set; }

        public MainMenuViewModel(SQLiteConnection sqliteConnection) {
            this.SqliteConnection = sqliteConnection;
        }

        public static TasksListViewModel taskTableView;

        public void LoadTasksList() {
            taskTableView = new TasksListViewModel(SqliteConnection);
            ActivateItem(taskTableView);
        }
    }
}
