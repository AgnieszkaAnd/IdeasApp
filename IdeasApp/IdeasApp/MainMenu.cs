﻿using Caliburn.Micro;
using IdeasApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IdeasApp {
    public class MainMenu : BootstrapperBase {
        public MainMenu() {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e) {
            DisplayRootViewFor<TasksListViewModel>();
        }
    }
}
