using LibraryConsoleApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp.DAL.Interfaces
{
    public interface ILocationRepository
    {
        public void Add(Room item);
        public void Add(Row item);
        public void Add(Shelf item);

        public void Update(Room item);
        public void Update(Row item);
        public void Update(Shelf item);
          


        


    }
}
