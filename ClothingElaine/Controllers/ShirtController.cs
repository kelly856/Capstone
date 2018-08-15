using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothingElaine.Models;
using DAL;
using DAL.Objects;

namespace ClothingElaine.Controllers
{
    public class ShirtController : Controller
    {
        static Mapper _Mapper = new Mapper();
        static ShirtsDataAccess ShirtsDataAccess = new ShirtsDataAccess();
        [HttpGet]
        public ActionResult ShirtView()
        {
            ShirtViewModel ShirtViewModel = new ShirtViewModel();
            ShirtViewModel.ShirtList = _Mapper.MapListShirt(ShirtsDataAccess.GetAllShirts());

            return View(ShirtViewModel);
        }
        [HttpGet]
        public ActionResult CreateShirt()
        {
            Shirt book = new Shirt();
            return View();
        }
        [HttpPost]
        public ActionResult CreateShirt(Shirt shirtToCreate)
        {
            if ((int)Session["RoleID"] == 1)
            {

                ShirtsDataAccess.createShirt(_Mapper.mapshirts(shirtToCreate));
                return RedirectToAction("ShirtView");
            }
            return View();
        }
        [HttpGet]
        public ActionResult UpdateShirt(int ShirtID)
        {

            {

                return View();
            }


        }
        [HttpPost]
        public ActionResult UpdateShirt(Shirt shirtToUpdate)
        {
            if ((int)Session["RoleID"] == 1)
            {
                ShirtsDataAccess.UpdateShirt(_Mapper.mapshirt(shirtToUpdate));
                return RedirectToAction("Login");
            }

            return View();
        }
        [HttpGet]
        public ActionResult _DeleteShirt(int Delete_Shirt)
        {
            if ((int)Session["RoleID"] == 1)
            {
                ShirtsDAO _DeleteShirt = new ShirtsDAO();
                _DeleteShirt.ShirtsID = Delete_Shirt;
                ShirtsDataAccess.deleteShirt(_DeleteShirt);

            }
            return RedirectToAction("ViewShirt");
        }

    }
}

