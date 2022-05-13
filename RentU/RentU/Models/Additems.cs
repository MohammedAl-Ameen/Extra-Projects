using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace RentU.Models
{
    public class Additems
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Buydate { get; set; }
        public int Itemid { get; set; }
        public string Userid { get; set; }

        public virtual Item Item { get; set; }

        public virtual ApplicationUser user { get; set; }


    }
}


