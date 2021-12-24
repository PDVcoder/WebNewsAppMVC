using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.PL.Models
{
    public class ViewPage
    {
        public IEnumerable<NewsViewModel> News { get; set; }
        public FilterViewModel Filter { get; set; }
        public IEnumerable<HeadingViewModel> Headings { get; set; }
    }
}
