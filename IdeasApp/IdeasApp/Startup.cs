using Caliburn.Micro;
using IdeasApp.ViewModels;
using System;
using System.Windows;
using IdeasApp.Models;
using System.Data.SQLite;

namespace IdeasApp {
    public class Startup : BootstrapperBase {
        public int SwitchView { get; set; }

        //TODO: Use Dependency Injection design pattern

        //FIXME: no static fields, move that to ViewModel
        public static SQLiteConnection connectionToDB;
        public static EntryRepository ideasDataTable;

        //TODO: update class name to Startup/Bootstrapper - not Menu
        public Startup() {
            Initialize();

            connectionToDB = new SQLiteConnection(@"data source=C:\Users\asus\Documents\CODECOOL\2_OOP\6_\IdeasApp_v10\IdeasApp\IdeasApp\IdeasDb.db");
            ideasDataTable = new EntryRepository(connectionToDB);
        }

        protected override void OnStartup(object sender, StartupEventArgs e) {
            //TODO Pass Entry Repository as parameter in DisplayRootViewFor to MainMenuViewModel constructor
            new AppShellViewModel();
            DisplayRootViewFor<AppShellViewModel>();
        }
    }
}
