using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingElaine.Models
{
    public class TransactionHistory
    {
        public int UserID { get; set; }
        public int CartID { get; set; }
        public decimal DateOfTransaction { get; set; }
        public int TransactionID { get; set; }
    }
}