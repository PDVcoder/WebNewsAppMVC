using NewsWebApp.BLL.DTO;
using System.Collections.Generic;

namespace NewsWebApp.BLL.Interfaces
{
    public interface INewsPublishService
    {
        AuthorDTO GetAuthor(int? id);
        void PublishNews(NewsDTO newsDTO);
        HeadingDTO Get(int? id);
        IEnumerable<HeadingDTO> GetHeadingByName(string name);
        IEnumerable<HeadingDTO> GetHeadings();
        void AddHeading(HeadingDTO headingDTO);
        void Dispose();
    }
}
