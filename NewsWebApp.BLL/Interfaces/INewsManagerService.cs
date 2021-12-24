using System;
using System.Collections.Generic;
using NewsWebApp.BLL.DTO;

namespace NewsWebApp.BLL.Interfaces
{
    public interface INewsManagerService
    {
        NewsDTO Get(int? id);
        AuthorDTO GetAuthor(int? id);
        HeadingDTO GetHeading(int? id);
        IEnumerable<HeadingDTO> GetHeading();
        IEnumerable<NewsDTO> GetNewsByName(string newsName);
        IEnumerable<NewsDTO> GetNewsByDate(DateTime fromDateTime, DateTime toDateTime);
        IEnumerable<NewsDTO> GetNewsByTopic(string topic);
        IEnumerable<NewsDTO> GetNewsByHeading(int? HeadingId);
        IEnumerable<NewsDTO> GetNews();
        void Dispose();
    }
}
