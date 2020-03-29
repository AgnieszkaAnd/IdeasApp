using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeasApp.Models {
    interface IDataAccessObject {
        public void Create();
        public void Read();
        public void Update();
        public void Delete();
        public Entry ReadById(int id);
        public List<Entry> ReadAll();
    }
}
