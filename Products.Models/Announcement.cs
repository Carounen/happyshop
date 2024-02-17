using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Products.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Purpose")]
        public string Purpose { get; set; }


        [Required]
        [DisplayName("Announcement")]
        public string Announce { get; set; }


       



        [Required]
        [DisplayName("Image")]

        [ValidateNever]
        public string image { get; set; }


        public DateTime Date { get; set; } = DateTime.Now;


       
    }

}

