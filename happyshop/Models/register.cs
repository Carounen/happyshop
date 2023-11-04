using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace happyshop.Models
{

 

    public class register
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string lName { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string uName { get; set; }

        [Required]
        [DisplayName("Email")]
        public string email { get; set; }


        [Required]
        [DisplayName("Password")]
        public string pass { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display order must be in range of 1 - 100 only!!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        


    }
}
