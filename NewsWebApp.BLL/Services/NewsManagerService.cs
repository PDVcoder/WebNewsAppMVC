using System;
using System.Collections.Generic;
using NewsWebApp.BLL.DTO;
using NewsWebApp.BLL.Interfaces;
using NewsWebApp.DAL.Entities;
using NewsWebApp.DAL.Interfaces;
using NewsWebApp.BLL.Infrastructure;
using AutoMapper;

namespace NewsWebApp.BLL.Services
{
    public class NewsManagerService : INewsManagerService
    {
        private IUnitOfWork Database;

        public NewsManagerService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public NewsDTO Get(int? id)
        {
            if (id == null) throw new ValidationException("News ID is null", "");

            News news = Database.News.Get(id.Value);

            if(news == null) throw new ValidationException("News not found", "");

            return new NewsDTO
            {
                Id = news.Id,
                NewsName = news.NewsName,
                NewsText = news.NewsText,
                PublishDate = news.PublishDate,
                Topyc = news.Topic,
                AuthorId = news.AuthorId,
                HeadingId = news.HeadingId
            };
        }

        public IEnumerable<HeadingDTO> GetHeading()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Heading, HeadingDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Heading>, List<HeadingDTO>>(Database.Heading.GetAll());
        }

        public IEnumerable<NewsDTO> GetNewsByDate(DateTime fromDateTime, DateTime toDateTime)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<News, NewsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.Find(e => e.PublishDate.CompareTo(fromDateTime) > 0 && e.PublishDate.CompareTo(toDateTime) < 0));
        }

        public IEnumerable<NewsDTO> GetNewsByHeading(int? HeadingId)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<News, NewsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.Find(e => e.HeadingId == HeadingId));
        }

        public IEnumerable<NewsDTO> GetNewsByName(string newsName)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<News, NewsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.Find(e => e.NewsName.Contains(newsName)));
        }

        public IEnumerable<NewsDTO> GetNewsByTopic(string topic)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<News, NewsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.Find(e => e.Topic.Contains(topic)));
        }

        public IEnumerable<NewsDTO> GetNews()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<News, NewsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.GetAll());
        }

        //public IEnumerable<NewsDTO> GetNewsByFilter(DateTime? fromDateTime, DateTime? toDateTime, string topic, string newsName, int? HeadingId)
        //{
        //    var mapper = new MapperConfiguration(config => config.CreateMap<News, NewsDTO>()).CreateMapper();
        //    if (fromDateTime != null && toDateTime != null && topic.Length != 0 && (HeadingId != null && HeadingId != 0))
        //    {
        //        return mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.Find(e => e.PublishDate.CompareTo(fromDateTime) > 0 &&
        //                                                                                    e.PublishDate.CompareTo(toDateTime) < 0 && 
        //                                                                                    e.NewsName.Contains(newsName) &&
        //                                                                                    e.Topic.Contains(topic) &&
        //                                                                                    e.HeadingId == HeadingId));
        //    }else if()

        //}

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

        public HeadingDTO GetHeading(int? id)
        {
            if (id == null) throw new ValidationException("Id is null", "");
            var heading = Database.Heading.Get(id.Value);
            if (heading == null) throw new ValidationException("Heading not found", "");

            return new HeadingDTO
            {
                Id = heading.Id,
                Name = heading.Name
            };
        }
    }
}
