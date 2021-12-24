using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NewsWebApp.DAL.Entities;

namespace NewsWebApp.DAL.EF
{
    class StoreDbInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            _addAuthors(context);
            context.SaveChanges();
        }

        private void _addAuthors(DataContext context)
        {
            context.Authors.Add(new Author
            {
                Id = 1,
                Email = "payevskyidima@gmail.com",
                Firstname = "Dmytro",
                Lastname = "Paieskyi",
                Username = "SmemO",
                Password = "password",
                RegistrationDate = new DateTime(2021, 11, 02, 16, 29, 15)
            });
            context.Authors.Add(new Author
            {
                Id = 2,
                Email = "wotfan2002@gmail.com",
                Firstname = "Dima",
                Lastname = "Dimon",
                Username = "MEM",
                Password = "password",
                RegistrationDate = new DateTime(2021, 11, 02, 16, 32, 15)
            });

            context.Headings.Add(new Heading { 
                Id = 1,
                Name = "Sport"
            });
            context.Headings.Add(new Heading
            {
                Id = 2,
                Name = "Politic"
            });
            context.Headings.Add(new Heading
            {
                Id = 3,
                Name = "Peoples"
            });
            context.Headings.Add(new Heading
            {
                Id = 4,
                Name = "Education"
            });
            context.Headings.Add(new Heading
            {
                Id = 5,
                Name = "IT"
            });
            context.Headings.Add(new Heading
            {
                Id = 6,
                Name = "Sciens"
            });
            context.Headings.Add(new Heading
            {
                Id = 7,
                Name = "Others"
            });

            context.News.Add(new News
            {
                Id = 0,
                NewsName = "Football",
                NewsText = "Some Text",
                PublishDate = new DateTime(2021, 11, 18, 19, 21, 25),
                Topic = "football worldcup",
                HeadingId = 1,
                Heading = context.Headings.Find(1),
                AuthorId = 1,
                Author = context.Authors.Find(1)
            });

            context.News.Add(new News
            {
                Id = 1,
                NewsName = "Metro",
                NewsText = "Some Text again",
                PublishDate = new DateTime(2021, 11, 19, 19, 22, 25),
                Topic = "football worldcup",
                HeadingId = 3,
                Heading = context.Headings.Find(3),
                AuthorId = 2,
                Author = context.Authors.Find(2)
            });

        }
    }
}
