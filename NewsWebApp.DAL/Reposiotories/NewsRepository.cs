using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using NewsWebApp.DAL.EF;
using NewsWebApp.DAL.Entities;
using NewsWebApp.DAL.Interfaces;

namespace NewsWebApp.DAL.Reposiotories
{
    public class NewsRepository : IRepository<News> 
    {
        private DataContext db;

        public NewsRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<News> GetAll()
        {
            return db.News.Include(o => o.Author)
                .Include(o => o.Heading);
        }

        public News Get(int id)
        {
            return db.News.Find(id);
        }

        public void Create(News item)
        {
            db.News.Add(item);
        }

        public void Update(News item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            News news = db.News.Find(id);
            if(news != null)
            {
                db.News.Remove(news);
            }
        }

        public IEnumerable<News> Find(Expression<Func<News, bool>> predicate)
        {
            return db.News.Include(o => o.Author).Include(o => o.Heading).Where(predicate).ToList();
        }
    }
}
