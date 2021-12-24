using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebApp.DAL.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [Display(Name = "MobileNumber")]
        public string Modile { get; set; }

        [Display(Name = "RegistrationDate")]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        [Display(Name = "News")]
        public ICollection<News> News { get; set; }
    }
}
