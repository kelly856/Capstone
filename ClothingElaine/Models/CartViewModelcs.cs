using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingElaine.Models
{
    public class CartViewModel
    {
        public Carts SingleCart { get; set; }
        public List<Carts> CartList { get; set; }

        public CartViewModel()
        {
            SingleCart = new Carts();
            CartList = new List<Carts>();
        }
    }
}