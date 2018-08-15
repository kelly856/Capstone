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
    public class PantController : Controller
    {
        static Mapper _Mapper = new Mapper();
        static PantsDataAccess PantsDataAccess = new PantsDataAccess();
        [HttpGet]
        public ActionResult PantView()
        {
            PantViewModel PantViewModel = new PantViewModel();
            PantViewModel.PantList = _Mapper.mapuser(PantsDataAccess.GetAllPants());

            return View(PantViewModel);
        }
        [HttpGet]
        public ActionResult CreatePant()
        {
            Pant pant = new Pant();
            return View();
        }
        [HttpPost]
        public ActionResult CreatePant(Pant pantToCreate)
        {
            if ((int)Session["RoleID"] == 1)
            {

                PantsDataAccess.createPant(_Mapper.mappants(pantToCreate));
                return RedirectToAction("PantView");
            }
            return View();
        }
        [HttpGet]
        public ActionResult UpdatePant()
        {

            {

                return View();
            }


        }
        [HttpPost]
        public ActionResult UpdatePant(Pant pantToUpdate)
        {
            if ((int)Session["RoleID"] == 1)
            {
                PantsDataAccess.UpdatePant(_Mapper.Mappants(pantToUpdate));
                return RedirectToAction("Login");
            }

            return View();
        }
        [HttpGet]
        public ActionResult _DeletePant(int Delete_Pant)
        {
            if ((int)Session["RoleID"] == 1)
            {
                PantsDAO _DeletePant = new PantsDAO();
                _DeletePant.PantsID = Delete_Pant;
                PantsDataAccess.deletePant(_DeletePant);

            }
            return RedirectToAction("ViewPant");
        }

    }
}
