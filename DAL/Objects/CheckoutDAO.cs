using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Objects
{
    public class CheckoutDAO
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int ShirtsID { get; set; }
        public int PantsID { get; set; }
    }
}
