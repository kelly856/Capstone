using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Objects;
using DAL;
using ClothingElaine.Models;

namespace ClothingElaine.Controllers
{
    public class CartController : Controller
    {
        static Mapper _Mapper = new Mapper();
        static CartsDataAccess CartsDataAccess = new CartsDataAccess();
        [HttpGet]
        public ActionResult CartView()
        {
            CartViewModel CartViewModel = new CartViewModel();
            CartViewModel.CartList = _Mapper.Mapcart(CartsDataAccess.GetAllCarts());

            return View(CartViewModel);
        }
        [HttpGet]
        public ActionResult CreateCart()
        {
            Carts cart = new Carts();
            return View();
        }
        [HttpPost]
        public ActionResult CreateCart(Carts cartToCreate)
        {

            {

                CartsDataAccess._createCart(_Mapper.Mapcart(cartToCreate));
                return RedirectToAction("CartView");
            }

        }

        [HttpGet]
        public ActionResult UpdateCart(int CartID)
        {
            Carts cart = _Mapper.Mapcart(CartsDataAccess.GetCartById(CartID));

            return View(cart);

        }

        [HttpPost]
        public ActionResult UpdateCart(Carts cartToUpdate)
        {
            if ((int)Session["RoleID"] == 1)
            {
                CartsDataAccess.UpdateCart(_Mapper.Mapcart(cartToUpdate));
                return RedirectToAction("CartView");
            }

            return View();
        }

        [HttpGet]
        public ActionResult _DeleteCart(int Delete_Cart)
        {
            if ((int)Session["RoleID"] == 1)
            {
                CartDAO _DeleteCart = new CartDAO();
                _DeleteCart.CartID = Delete_Cart;
                CartsDataAccess.deleteCart(_DeleteCart);

            }
            return RedirectToAction("CartView");
        }

    }
}
