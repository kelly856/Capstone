using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingElaine.Models
{
    public class PantViewModel
    {
        public Pant SinglePant { get; set; }
        public List<Pant> PantList { get; set; }

        public PantViewModel()
        {
            SinglePant = new Pant();
            PantList = new List<Pant>();
        }
    }
}