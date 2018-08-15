using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingElaine.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int ShirtsID { get; set; }
        public int PantsID { get; set; }
    }
}