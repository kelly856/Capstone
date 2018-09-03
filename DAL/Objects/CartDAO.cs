using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Objects
{
    public class CartDAO
    {
        public int CartID { get; set; }
        public int PantsID { get; set; }
        public int ShirtsID { get; set; }
        public int UserID { get; set; }
        public int ShirtQuanity { get; set; }
        public int PantQuanity { get; set; }
        public int PantPrice { get; set; }
        public int ShirtPrice { get; set; }
        public int TotalPrice { get; set; }

    }
}
