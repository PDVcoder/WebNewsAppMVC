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
    class HeadingRepository : IRepository<Heading>
    {
        private DataContext db;

        public HeadingRepository(DataContext context)
        {
            this.db = context;
        }

        public void Create(Heading item)
        {
            db.Headings.Add(item);
        }

        public void Delete(int id)
        {
            Heading heading = db.Headings.Find(id);
            if(heading != null)
            {
                db.Headings.Remove(heading);
            }
        }


        public IEnumerable<Heading> Find(Expression<Func<Heading, bool>> predicate)
        {
            return db.Headings.Where(predicate).ToList();
        }

        public Heading Get(int id)
        {
            return db.Headings.Find(id);
        }

        public IEnumerable<Heading> GetAll()
        {
            return db.Headings;
        }

        public void Update(Heading item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
