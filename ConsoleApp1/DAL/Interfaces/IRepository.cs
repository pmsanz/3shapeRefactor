namespace LibraryConsoleApp.DAL.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Items { get; }
        public void Add(T item);
        public T? GetByIdOrDefault(long id);
        public T GetRandomItem();
        public T Update(T item);
        public bool Remove(long id);

    }

}
