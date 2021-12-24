using System.Collections.Generic;
using NewsWebApp.BLL.DTO;
using NewsWebApp.BLL.Interfaces;
using NewsWebApp.DAL.Entities;
using NewsWebApp.DAL.Interfaces;
using NewsWebApp.BLL.Infrastructure;
using AutoMapper;


namespace NewsWebApp.BLL.Services
{
    public class NewsPublishService : INewsPublishService
    {
        private IUnitOfWork Database;

        public NewsPublishService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddHeading(HeadingDTO headingDTO)
        {
            if (headingDTO == null) throw new ValidationException("Heading is null", "");

            Heading heading = new Heading
            {
                Id = headingDTO.Id,
                Name = headingDTO.Name
            };

            Database.Heading.Create(heading);
            Database.Save();
        }

        public HeadingDTO Get(int? id)
        {
            if (id == null) throw new ValidationException("Id is null", "");

            Heading heading = Database.Heading.Get(id.Value);

            if (heading == null) throw new ValidationException("Heading not found", "");

            return new HeadingDTO { Id = heading.Id, Name = heading.Name };
        }
        
        public IEnumerable<HeadingDTO> GetHeadingByName(string name)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Heading, HeadingDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Heading>, List<HeadingDTO>>(Database.Heading.Find(e => e.Name.Contains(name)));
        }

        public IEnumerable<HeadingDTO> GetHeadings()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Heading, HeadingDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Heading>, List<HeadingDTO>>(Database.Heading.GetAll());
        }

        public void PublishNews(NewsDTO newsDTO)
        {
            Author author = Database.Author.Get(newsDTO.AuthorId);
            if (author == null) throw new ValidationException("Author not found", "");

            Heading heading = Database.Heading.Get(newsDTO.HeadingId);
            if (heading == null) throw new ValidationException("Heading not found", "");

            if (newsDTO == null) throw new ValidationException("News is null", "");

            News news = new News
            {
                Id = newsDTO.Id,
                NewsName = newsDTO.NewsName,
                NewsText = newsDTO.NewsText,
                Topic = newsDTO.Topyc,
                AuthorId = author.Id,
                HeadingId = heading.Id,
                Author = author,
                Heading = heading
            };

            Database.News.Create(news);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public AuthorDTO GetAuthor(int? id)
        {
            if (id == null) throw new ValidationException("Id is null", "");
            var author = Database.Author.Get(id.Value);
            if (author == null) throw new ValidationException("User not found", "");

            return new AuthorDTO
            {
                Id = author.Id,
                Username = author.Username,
                Firstname = author.Firstname,
                Lastname = author.Lastname,
                Email = author.Email,
                RegistrationDate = author.RegistrationDate,
                Password = author.Password
            };
        }
    }
}
