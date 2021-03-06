﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Objects;
using DAL;
using ClothingElaine.Models;

namespace ClothingElaine.Controllers
{
    public class UserController : Controller
    {
        static Mapper _Mapper = new Mapper();
        static UserDataAccess _UserDataAccess = new UserDataAccess();
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        // Post send usermodel so that user may login.
        [HttpPost]
        public ActionResult Login(User UserToMap)
        {
            // Check to make sure user is accessing view in the browser.
            if (ModelState.IsValid)
            {
                // Run the login SP using my view model.
                UsersDAO _user1 = _UserDataAccess._login(_Mapper.Map(UserToMap));

                // Put the _user1 values into the session variable.
                Session["UserID"] = _user1.UserID;
                Session["RoleID"] = _user1.RoleID;
            }
            return RedirectToAction("MultiView", "Home");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult UpdateUser(int userID)
        {
            User user = _Mapper.Map(UserDataAccess.GetUserByID(userID));

            {
                return View(user);
            }

        }
        [HttpPost]
        public ActionResult UpdateUser(User userToUpdate)
        {
            if ((int)Session["RoleID"] == 1)
            {
                _UserDataAccess.UpdateUser(_Mapper.Map(userToUpdate));
                return RedirectToAction("UserView");
            }
            return View();
        }

        static UserDataAccess UserDataAccess = new UserDataAccess();
        [HttpGet]
        public ActionResult UserView()
        {
            UserViewModel UserViewModel = new UserViewModel();
            UserViewModel.UserList = _Mapper.Map(UserDataAccess.GetAllUsers());

            return View(UserViewModel);
        }
        [HttpGet]
        public ActionResult _DeleteUser(int Delete_User)
        {
            if ((int)Session["RoleID"] == 1)
            {
                UsersDAO _DeleteUser = new UsersDAO();
                _DeleteUser.UserID = Delete_User;
                UserDataAccess.deleteUser(_DeleteUser);

            }
            return RedirectToAction("UserView");
        }
        [HttpGet]
        public ActionResult RegisterUser()
        {
            User user = new User();
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(User userRegister)
        {
            {

                _UserDataAccess._createUser(_Mapper.Map(userRegister));
                return RedirectToAction("MultiView", "Home");
            }
        }
    }

}
