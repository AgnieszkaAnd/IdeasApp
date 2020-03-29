using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeasApp.ViewModels {
    public class MainMenuViewModel : Conductor<object> {

        public void LoadTasksList() {
            ActivateItem(new TasksListViewModel());
        }
    }
}
