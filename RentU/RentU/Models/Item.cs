using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RentU.Models
{
    public class Item
    {
        public int id { get; set; }
        [Display(Name = "Item Name")]
        public string ItemTitle { get; set; }
        [Display(Name = "Item Description")]
        public string ItemContent { get; set; }
        [Display(Name = "Item Image")]
        public string ItemImage { get; set; }

        [Display(Name = "Item Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}