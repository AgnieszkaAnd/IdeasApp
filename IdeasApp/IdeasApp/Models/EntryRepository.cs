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
    public class EntryRepository: IDataAccessObject {
        private readonly SQLiteConnection Con;

        public EntryRepository(SQLiteConnection DbPath) => Con = DbPath;

        
        private EnumerableRowCollection<DataRow> runQuery(string query) {

            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            DataTable dataTable = new DataTable();
            SQLiteCommand command = new SQLiteCommand(query, this.Con);
            adapter.SelectCommand = command;
            Con.Open();
            command.ExecuteNonQuery();
            adapter.Fill(dataTable); Con.Close();
            return dataTable.AsEnumerable();
        }

        public List<Entry> ConvertResultToEntryList(EnumerableRowCollection<DataRow> QueryResult) {
            var Entries = (from row in QueryResult
                           select new Entry {
                               Id = row.Field<long>("Id"),
                               Category = row.Field<string>("Category"),
                               TaskName = row.Field<string>("TaskName"),
                               Deadline = row.Field<DateTime>("Deadline"),
                               Priority = row.Field<string>("Priority"),
                               EstimatedTime = row.Field<int>("EstimatedTime"),
                           }).ToList();
            return Entries;
        }


        public Entry ConvertResultToEntry(DataRow QueryResult) {
            Entry entry = new Entry();
            entry.Id = QueryResult.Field<long>("Id");
            entry.Category = QueryResult.Field<string>("Category");
            entry.TaskName = QueryResult.Field<string>("TaskName");
            entry.Deadline = QueryResult.Field<DateTime>("Deadline");
            entry.Priority = QueryResult.Field<string>("Priority");
            entry.EstimatedTime = QueryResult.Field<int>("EstimatedTime");
            return entry;
        }

        public List<Entry> ReadAll() {
        var queryResult = runQuery($"SELECT * FROM Tasks");
        return ConvertResultToEntryList(queryResult);
        }

        public void Create(Entry entry) {

            Con.Open();
            SQLiteCommand insertCommand = new SQLiteCommand(
                  "INSERT INTO Tasks(Category, TaskName, EstimatedTime, Deadline, Priority) " +
                   "VALUES(@Category, @TaskName, @EstimatedTime, @Deadline, @Priority); ", this.Con);
            insertCommand.CommandType = CommandType.Text;
            insertCommand.Parameters.AddWithValue("Category", entry.Category);
            insertCommand.Parameters.AddWithValue("TaskName", entry.TaskName);
            insertCommand.Parameters.AddWithValue("EstimatedTime", entry.EstimatedTime);
            insertCommand.Parameters.AddWithValue("Deadline", entry.Deadline);
            insertCommand.Parameters.AddWithValue("Priority", entry.Priority);

            try {
                insertCommand.ExecuteNonQuery();
            } catch ( Exception e) {
                Console.WriteLine(e);
            }
            Con.Close();
        }

        public void Update(Entry entry) {
            Con.Open();
            SQLiteCommand updateCommand = new SQLiteCommand(
                "UPDATE Tasks SET " +
                "Category = @Category, " +
                "TaskName = @TaskName, " +
                "EstimatedTime = @EstimatedTime, " +
                "Deadline = @Deadline, " +
                "Priority = @Priority " +
                "WHERE Id=@Id;", this.Con);

            updateCommand.CommandType = CommandType.Text;
            updateCommand.Parameters.AddWithValue("Category", entry.Category);
            updateCommand.Parameters.AddWithValue("TaskName", entry.TaskName);
            updateCommand.Parameters.AddWithValue("EstimatedTime", entry.EstimatedTime);
            updateCommand.Parameters.AddWithValue("Deadline", entry.Deadline);
            updateCommand.Parameters.AddWithValue("Priority", entry.Priority);
            updateCommand.Parameters.AddWithValue("Id", entry.Id);

            try {
                updateCommand.ExecuteNonQuery();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            Con.Close();
        }
        public void Delete(Entry entry) {
            Con.Open();
            SQLiteCommand insertCommand = new SQLiteCommand(
                  "Delete from Tasks where Id=@Id", this.Con);
            insertCommand.CommandType = CommandType.Text;
            // TODO fill catch action - e.g. write info to log file
            try { insertCommand.Parameters.AddWithValue("Id", entry.Id); } catch(NullReferenceException) {  }
            
            try {
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            Con.Close();
        }
        public Entry ReadById(int id) {
            var queryResult = runQuery($"SELECT * FROM Tasks WHERE Id = {id}");
            //return ConvertResultToEntryList(queryResult);
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
