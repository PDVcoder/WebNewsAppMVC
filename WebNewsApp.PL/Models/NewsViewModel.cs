using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebApp.PL.Models
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string NewsName { get; set; }
        public string NewsText { get; set; }
        public DateTime PublishDate { get; set; }
        public string Topyc { get; set; }
        public int AuthorId { get; set; }
        public int HeadingId { get; set; }
        public AuthorViewModel Author{ get; set; }
        public HeadingViewModel Heading{ get; set; }
    }
}
