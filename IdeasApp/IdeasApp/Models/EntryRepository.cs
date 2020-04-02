using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Data.SqlClient;
using System.Data;

namespace IdeasApp.Models {
    class EntryRepository: IDataAccessObject {
        private readonly SQLiteConnection Con;
        public EntryRepository(SQLiteConnection DbPath) => Con = DbPath;

        public List<Entry> ReadAll() {
            var queryResult = runQuery($"SELECT * FROM Tasks");
            return ConvertResultToEntryList(queryResult);
        }

        private EnumerableRowCollection<DataRow> runQuery(string query) {
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            DataTable dataTable = new DataTable();
            SQLiteCommand command = new SQLiteCommand(query, this.Con);
            adapter.SelectCommand = command;
            Con.Open();
            command.ExecuteNonQuery();
            //adapter.SelectCommand.ExecuteNonQuery();

            adapter.Fill(dataTable); Con.Close();
            return dataTable.AsEnumerable();
        }

        public List<Entry> ConvertResultToEntryList(EnumerableRowCollection<DataRow> QueryResult) {
            var Entries = (from row in QueryResult
                           select new Entry {
                               Id = (int)row.Field<long>("Id"),
                               Category = row.Field<string>("Category"),
                               TaskName = row.Field<string>("TaskName"),
                               Deadline = row.Field<string>("Deadline"),
                               Priority = row.Field<string>("Priority"),
                               EstimatedTime = row.Field<string>("EstimatedTime"),
                           }).ToList();
            return Entries;
        }

        public void Create() { }
        public void Update() { }
        public void Delete() { }
        public Entry ReadById(int id) {
            var queryResult = runQuery($"SELECT * FROM Tasks WHERE Id = {id}");
            //return ConvertResultToEntryList(queryResult);
            return null;
        }

        /*  public Entry ConvertResultToEntry(int id) {
              // returns populated Entry list object with table results
              SQLiteDataAdapter adapter = new SQLiteDataAdapter();
              DataTable dataTable = new DataTable();
              SQLiteCommand command = new SQLiteCommand($"SELECT * FROM Tasks WHERE Id = {id}", this.Con);
              adapter.SelectCommand = command;
              Con.Open(); adapter.SelectCommand.ExecuteNonQuery();
              adapter.Fill(dataTable); Con.Close();

              var entri = new Entry();
              var entry = (from row in dataTable where 
                           select new Entry {
                               Category = row.Field<string>("Category"),
                               TaskName = row.Field<string>("TaskName"),
                               Deadline = row.Field<string>("Deadline"),
                               Priority = row.Field<string>("Priority"),
                               EstimatedTime = row.Field<decimal>("EstimatedTime"),
                           });
              return entry;
          }*/

        /* To do:
        + ReadByEntryDate
        + ReadByTask
        + ReadByPriority
        Misc methods
        */
    }
}
