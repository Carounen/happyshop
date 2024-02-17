using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Name of User")]
        public string Name { get; set; }

        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        [DisplayName("Product image")]

        [ValidateNever]
        public string image { get; set; }

        [Required]
        [DisplayName("Review of user")]
        public string Rev { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;



    }
}
