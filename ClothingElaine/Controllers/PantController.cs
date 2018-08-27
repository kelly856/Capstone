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
            PantViewModel.PantList = _Mapper.Map(PantsDataAccess.GetAllPants());

            return View(PantViewModel);
        }
        [HttpGet]
        public ActionResult CreatePant()
        {
            Pant pant = new Pant();
            return View();
        }
        [HttpPost]
        public ActionResult createPant(Pant pantToCreate)
        {
            
            {

                PantsDataAccess.createPant(_Mapper.Map(pantToCreate));
                return RedirectToAction("PantView");
            }
            
        }

        [HttpGet]
        public ActionResult UpdatePant(int PantsID)
        {
            Pant pant = _Mapper.Map(PantsDataAccess.GetPantById(PantsID));
           
            return View(pant);

        }

        [HttpPost]
        public ActionResult UpdatePant(Pant pantToUpdate)
        {
            if ((int)Session["RoleID"] == 1)
            {
                PantsDataAccess.UpdatePant(_Mapper.Map(pantToUpdate));
                return RedirectToAction("ViewPant");
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
            return RedirectToAction("PantView");
        }

    }
}
