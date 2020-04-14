using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeasApp.Models {
    // public enum Priorities { HIGH, MEDIUM, LOW };
    public enum PriorityLevel {
        IMPORTANT_URGENT,
        IMPORTANT_NOT_URGENT,
        NOT_IMPORTANT_URGENT,
        NOT_IMPORTANT_NOT_URGENT,
    };

    public class Entry {
        // Stores table values for particular columns listed below
        public long Id { get; set; }
        public string Category { get; set; }
        public string TaskName { get; set; }
        public DateTime Deadline { get; set; }
        //public List<PriorityLevel> Priorities { get; set; } = Enum.GetValues(typeof(PriorityLevel)).Cast<PriorityLevel>().ToList();
        //public List<string> Priorities { get; set; } = new List<string>() {
        //    "IMPORTANT_URGENT",
        //    "IMPORTANT_NOT_URGENT",
        //    "NOT_IMPORTANT_URGENT",
        //    "NOT_IMPORTANT_NOT_URGENT"
        //};
        public string Priority { get; set; }
        public int EstimatedTime { get; set; }
    }
}
