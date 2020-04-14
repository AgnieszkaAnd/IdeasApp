using Caliburn.Micro;
using IdeasApp.ViewModels;
using System;
using System.Windows;
using IdeasApp.Models;
using System.Data.SQLite;
using System.Collections.Generic;

namespace IdeasApp {
    public class Startup : BootstrapperBase {
        public int SwitchView { get; set; }

        //TODO: Use Dependency Injection design pattern

        //FIXME: no static fields, move that to ViewModel
        //public static SQLiteConnection connectionToDB;
        //public static EntryRepository ideasDataTable;

        public Startup() {
            Initialize();
            //connectionToDB = new SQLiteConnection(@"data source=C:\Users\asus\Documents\CODECOOL\2_OOP\6_\IdeasApp_v10\IdeasApp\IdeasApp\IdeasDb.db");
            //connectionToDB = new SQLiteConnection("Data Source=" + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\..\\IdeasDb.db");
            //ideasDataTable = new EntryRepository(connectionToDB);
        }

        protected override void OnStartup(object sender, StartupEventArgs e) {
            //TODO Pass Entry Repository as parameter in DisplayRootViewFor to MainMenuViewModel constructor
            //var shellView = new AppShellViewModel(new SQLiteConnection(@"data source=C:\Users\asus\Documents\CODECOOL\2_OOP\6_\IdeasApp_v10\IdeasApp\IdeasApp\IdeasDb.db"));
            //Dictionary<string, object> parameters = new Dictionary<string, object>();
            //parameters.Add("sqliteConnection", new SQLiteConnection(@"data source=C:\Users\asus\Documents\CODECOOL\2_OOP\6_\IdeasApp_v10\IdeasApp\IdeasApp\IdeasDb.db"));
            DisplayRootViewFor<AppShellViewModel>();
        }

        protected override void OnExit(object sender, EventArgs e) {
            base.OnExit(sender, e);
        }
    }
}
