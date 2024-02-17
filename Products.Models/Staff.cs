using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Products.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Street Addrress")]
        public string StreetAddress { get; set; }


        [DisplayName("City")]
        public string City { get; set; }


        [Required]
        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Phone Number")]
        public int PhoneNumber { get; set; }


        [Required]
        [DisplayName("Email Addrress")]
        public string EmailAddress { get; set; }



        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

    }
}
