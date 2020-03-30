using Caliburn.Micro;
using IdeasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;

namespace IdeasApp.ViewModels {
    public class TasksListViewModel : Screen {

        //public BindableCollection<Entry> Ideas { get; set; }

        public TasksListViewModel() {
            //SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
            SqlConnection ideas = new SqlConnection("Data Source=IdeasDb.db;;New=True;Compess=True;");
            EntryRepository db = new EntryRepository(ideas);

        }

    }
}
