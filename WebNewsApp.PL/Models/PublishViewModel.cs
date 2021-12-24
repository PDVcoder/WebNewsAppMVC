using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.PL.Models
{
    public class PublishViewModel
    {
        public AuthorViewModel AuthorModel { get; set; }
        public NewsViewModel NewsModel { get; set; }
        public IEnumerable<HeadingViewModel> HeadingListModel { get; set; }
        public int HeadingId { get; set; }
    }
}
