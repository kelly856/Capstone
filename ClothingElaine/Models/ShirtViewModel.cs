using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingElaine.Models
{
    public class ShirtViewModel
    {
        public Shirt SingleShirt { get; set; }
        public List<Shirt> ShirtList { get; set; }

        public ShirtViewModel()
        {
            SingleShirt = new Shirt();
            ShirtList = new List<Shirt>();
        }
    }
}