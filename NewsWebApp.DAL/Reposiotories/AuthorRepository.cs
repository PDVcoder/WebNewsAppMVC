using System;
using System.Collections.Generic;
using System.Linq;
using NewsWebApp.DAL.Interfaces;
using NewsWebApp.DAL.EF;
using NewsWebApp.DAL.Entities;
using System.Data.Entity;
using System.Linq.Expressions;

namespace NewsWebApp.DAL.Reposiotories
{
    class AuthorRepository : IRepository<Author>
    {
        private DataContext db;

        public AuthorRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return db.Authors;
        }

        public Author Get(int id)
        {
            return db.Authors.Find(id);
        }

        public IEnumerable<Author> Find(Expression<Func<Author, bool>> predicate)
        {
            return db.Authors.Where(predicate).ToList();
        }

        public void Create(Author item)
        {
            db.Authors.Add(item);
        }

        public void Delete(int id)
        {
            Author author = db.Authors.Find(id);
            if(author != null)
            {
                db.Authors.Remove(author);
            }
        }

        public void Update(Author item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
