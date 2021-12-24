using NewsWebApp.DAL.Entities;

namespace NewsWebApp.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Author> Author { get; }
        IRepository<News> News { get; }
        IRepository<Heading> Heading { get; }
        void Save();
        void Dispose();
    }
}
