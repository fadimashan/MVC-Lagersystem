using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Lagersystem.Models
{
    public class Product
    {
   
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Max 30 tecken")]
        public string Name { get; set; }

        [Range(0, 100000)]
        public int Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime Orderdate { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Max 50 tecken")]
        public string Category { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Max 250 tecken")]
        public string Chelf { get; set; }

        [Range(1, 100000)]
        public int Count { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Max 300 tecken")]
        public string Description { get; set; }

    }
}
