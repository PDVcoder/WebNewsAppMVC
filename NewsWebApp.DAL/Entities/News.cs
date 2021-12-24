using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWebApp.DAL.Entities
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "News name is reqired")]
        [Display(Name = "NewsName")]
        public string NewsName { get; set; }

        [Required(ErrorMessage = "News text is required")]
        [Display(Name = "NewsText")]
        [DataType(DataType.Text)]
        public string NewsText { get; set; }
        
        [Required]
        [Display(Name = "PublishDate")]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Topics is required")]
        [Display(Name = "Topics")]
        public string Topic { get; set; }

        public int HeadingId { get; set; }

        [ForeignKey("HeadingId")]
        [Display(Name = "Heading")]
        public Heading Heading { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        [Display(Name = "Author")]
        public Author Author { get; set; }
    }
}
