using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeasApp.Models {
    interface IDataAccessObject {
        public void Create(Entry entry);
        public void Update(Entry entry);
        public void Delete(Entry entry);
        public Entry ReadById(int id);
        public List<Entry> ReadAll();
    }
}
