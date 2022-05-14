using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace Job_Offers_Website.Models
{
    public class Job
    {
        public int Id { get; set; }
        [DisplayName("Item Name")]
        public string JobTitle { get; set; }
        [DisplayName("Item decription")]
        [AllowHtml]
        public string JobContent { get; set; }
        [DisplayName("Item image")]
        public string JobImage { get; set; }

        [DisplayName("Item Category")]
        public int CategoryId { get; set; }

        public string UserID { get; set; }

        public virtual Category Category { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}