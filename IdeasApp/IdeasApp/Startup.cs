using Caliburn.Micro;
using IdeasApp.ViewModels;
using System;
using System.Windows;

namespace IdeasApp {
    //TODO: Use Dependency Injection design pattern
    public class Startup : BootstrapperBase {

        public Startup() {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e) {
            DisplayRootViewFor<AppShellViewModel>();
        }

        protected override void OnExit(object sender, EventArgs e) {
            base.OnExit(sender, e);
        }
    }
}
