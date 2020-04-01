using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static IdeasApp.Models.PeopleRepoTest;

namespace IdeasApp.ViewModels {
    public class TasksListViewModel : Screen {


        public BindableCollection<PersonModel> People { get; set; }

        public TasksListViewModel() {
            DataAccess da = new DataAccess();
            People = new BindableCollection<PersonModel>(da.GetPeople());
        }
    }
}
