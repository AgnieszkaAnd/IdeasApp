using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Data.SqlClient;

namespace IdeasApp.Models {
    class EntryRepository {
        private readonly SQLiteConnection Con;
        public EntryRepository(SqlConnection DbPath) => Con = new SQLiteConnection($"{DbPath}");

        private Entry ConvertResultToEntry(string result) {
            // returns populated Entry object with table results
            return null;
        }
        private List<Entry> ConvertResultToEntryList(string[] results) {
            // returns populated Entry list object with table results
            return null;
        }

        /* To do:
        + ReadByEntryDate
        + ReadByTask
        + ReadByPriority
        Misc methods
        */
    }
}
