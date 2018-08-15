using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Objects;

namespace ClothingElaine.Models
{
    public class Pant
    {
        public int PantsID { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
    }
}