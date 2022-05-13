using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RentU.Models
{
    public class Category
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string categoryName { get; set; }
        [Required]
        [Display(Name = "Category Description")]
        public string categoryDescription { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}