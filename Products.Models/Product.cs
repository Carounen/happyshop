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
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public string Name { get; set; }


        [Required]
        [DisplayName("Product Description")]
        public string Description { get; set; }


        [Required]
        [DisplayName("Price")]
        [Range(1, 1000, ErrorMessage = "Price out of range")]
        public double Price { get; set; }



        [Required]
        [DisplayName("Product image")]

        [ValidateNever]
        public string image { get; set; }


        public DateTime Date { get; set; } = DateTime.Now;


        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        [ValidateNever]
        public Category Category { get; set; }
    }

}

