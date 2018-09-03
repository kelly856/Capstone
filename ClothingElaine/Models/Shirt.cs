using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Objects;

namespace ClothingElaine.Models
{
    public class Shirt
    {
        public int ShirtsID { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int ShirtPrice { get; set; }
    }
}
