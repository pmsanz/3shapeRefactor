using LibraryConsoleApp.DAL.Interfaces;
using System.Security.Cryptography;

namespace LibraryConsoleApp.DAL.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        public List<T> Items { get; protected set; } = new List<T>();
        protected abstract void CheckConstraints(T item);
        public virtual void Add(T item)
        {
            CheckConstraints(item);
            Items.Add(item);
        }

        public abstract T? GetByIdOrDefault(long id);


        public virtual T GetRandomItem()
        {
            int count = Items.Count;
            int random = RandomNumberGenerator.GetInt32(0, count);
            return Items[random];
        }

        public virtual bool Remove(long id)
        {
            T? item = GetByIdOrDefault(id);
            if (item == null)
                throw new NullReferenceException(string.Format("Item with id : {0} not exists in the collection.", id));
            return Items.Remove(item);
        }

        public virtual T Update(T item)
        {
            CheckConstraints(item);
            int index = Items.IndexOf(item);
            Items[index] = item;
            return Items[index];
        }

        public abstract long GetLastKeyIdPlusOne();


    }
}
