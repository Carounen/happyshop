using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Models
{
    public class Faq
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Question")]
        public string Question { get; set; }

   
        [DisplayName("Proposed Answer")]
        public string? Answer { get; set; }

        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        
        public DateTime Date { get; set; } = DateTime.Now;



    }
}
