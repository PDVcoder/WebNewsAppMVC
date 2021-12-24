using System;
using NewsWebApp.DAL.EF;
using NewsWebApp.DAL.Entities;
using NewsWebApp.DAL.Interfaces;


namespace NewsWebApp.DAL.Reposiotories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private DataContext db;
        private AuthorRepository authorRepository;
        private HeadingRepository headingRepository;
        private NewsRepository newsRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new DataContext(connectionString);
        }

        public IRepository<Author> Author 
        { 
            get
            {
                if(authorRepository == null)
                {
                    authorRepository = new AuthorRepository(db);
                }
                return authorRepository;
            } 
        }

        public IRepository<News> News
        {
            get
            {
                if(newsRepository == null)
                {
                    newsRepository = new NewsRepository(db);
                }
                return newsRepository;
            }
        }

        public IRepository<Heading> Heading
        {
            get
            {
                if (headingRepository == null)
                {
                    headingRepository = new HeadingRepository(db);
                }
                return headingRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }
    }
}
