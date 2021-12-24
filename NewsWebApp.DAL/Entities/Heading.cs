using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebApp.DAL.Entities
{
    public class Heading
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Heading")]
        public string Name { get; set; }

        [Display(Name = "News")]
        public ICollection<News> News { get; set; }
    }
}
