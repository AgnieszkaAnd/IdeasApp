using Caliburn.Micro;
using IdeasApp.ViewModels;
using System;
using System.Windows;
using IdeasApp.Models;
using System.Data.SQLite;
using System.Collections.Generic;

namespace IdeasApp {
    //TODO: Use Dependency Injection design pattern
    public class Startup : BootstrapperBase {

        public Startup() {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e) {
            //TODO Pass Entry Repository as parameter in DisplayRootViewFor to AppShellViewModel constructor
            DisplayRootViewFor<AppShellViewModel>();
        }

        protected override void OnExit(object sender, EventArgs e) {
            base.OnExit(sender, e);
        }
    }
}
