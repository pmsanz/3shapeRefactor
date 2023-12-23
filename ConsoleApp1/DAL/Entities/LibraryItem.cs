﻿using LibraryConsoleApp.DAL.Interfaces;

namespace LibraryConsoleApp.DAL.Entities
{
    public abstract class LibraryItem : ILibraryItem
    {
        public long ItemId { get; protected set; }
        public long ShelfId { get; protected set; }
        public string Title { get; protected set; }
        public string ISBN { get; protected set; }
        public bool IsAvailable { get; protected set; }
        public virtual Shelf Shelf { get; set; }
        public abstract void Borrow();
        public abstract void Return();

    }
}
