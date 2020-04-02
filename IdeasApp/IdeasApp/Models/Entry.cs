using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeasApp.Models {
    public class Entry {
        // Stores table values for particular columns listed below
        public int Id { get; set; }
        public string Category { get; set; }
        public string TaskName { get; set; }
        public string Deadline { get; set; }
        public string Priority { get; set; }
        public string EstimatedTime { get; set; }
        
    }
}
