using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace BLL
{
    public class CartLogic
    {
        public int cartLogic(List<CartsBLO> CartLogic)
        {
            int Total = 0;
            foreach (CartsBLO _singleProduct in CartLogic)
            {
                int PantSubTotal; int ShirtSubTotal; int SubTotal; int AllSubTotal = 0; int Shipping = 0;
                int AllSubTax = 0; int Tax = 0;
                PantSubTotal = _singleProduct.PantPrice * _singleProduct.PantQuanity;
                ShirtSubTotal = _singleProduct.ShirtPrice * _singleProduct.ShirtQuanity;
                {
                    SubTotal = PantSubTotal + ShirtSubTotal + Shipping;
                    AllSubTax = AllSubTotal * Tax;
                    Total += AllSubTotal + AllSubTax;
                }
                 
            }
              return Total;
        }
    }      /*try catch error logger*/
        
}










