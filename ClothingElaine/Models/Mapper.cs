using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Objects;
using DAL;
using ClothingElaine.Models;
using BLL;


namespace ClothingElaine.Models
{
    public class Mapper
    {   //Mapper used to get all the data from the DAL for the clothingview mode from the DAO object.
        //Use this mapper in the HttpGET controller action.
        public List<User> Map(List<UsersDAO> UserListToMap)
        {
            List<User> UserListToReturn = new List<User>();
            foreach (UsersDAO UserToMap in UserListToMap)
            {
                User UserViewModel = Map(UserToMap);
                UserListToReturn.Add(UserViewModel);


            }
            return UserListToReturn;

        }
        public UsersDAO Map(User userToCreate)
        {
            UsersDAO daUserToCreate = new UsersDAO();
            daUserToCreate.UserID = userToCreate.UserID;
            daUserToCreate.Firstname = userToCreate.Firstname;
            daUserToCreate.Lastname = userToCreate.Lastname;
            daUserToCreate.Address = userToCreate.Address;
            daUserToCreate.Zipcode = userToCreate.Zipcode;
            daUserToCreate.Phonenumber = userToCreate.Phonenumber;
            daUserToCreate.Password = userToCreate.Password;
            daUserToCreate.RoleID = userToCreate.RoleID;
            daUserToCreate.Username = userToCreate.Username;

            return daUserToCreate;
        }


        public User Map(UsersDAO userToUpdate)
        {
            User _userToUpdate = new User();
            _userToUpdate.UserID = userToUpdate.UserID;
            _userToUpdate.Firstname = userToUpdate.Firstname;
            _userToUpdate.Lastname = userToUpdate.Lastname;
            _userToUpdate.Address = userToUpdate.Address;
            _userToUpdate.Zipcode = userToUpdate.Zipcode;
            _userToUpdate.Phonenumber = userToUpdate.Phonenumber;
            _userToUpdate.Password = userToUpdate.Password;
            _userToUpdate.Username = userToUpdate.Username;
            _userToUpdate.RoleID = userToUpdate.RoleID;


            return _userToUpdate;
        }



        public List<Shirt> Map(List<ShirtsDAO> ShirtListToMap)
        {
            List<Shirt> ShirtListToReturn = new List<Shirt>();
            foreach (ShirtsDAO ShirtToMap in ShirtListToMap)
            {
                Shirt ShirtViewModel = new Shirt();
                ShirtViewModel.ShirtsID = ShirtToMap.ShirtsID;
                ShirtViewModel.Size = ShirtToMap.Size;
                ShirtViewModel.Color = ShirtToMap.Color;
                ShirtViewModel.ShirtPrice = ShirtToMap.ShirtPrice;
                ShirtListToReturn.Add(ShirtViewModel);


            }
            return ShirtListToReturn;

        }
        public ShirtsDAO Map(Shirt _shirtToUpdate)
        {
            ShirtsDAO _ShirtToUpdate = new ShirtsDAO();
            _ShirtToUpdate.ShirtsID = _shirtToUpdate.ShirtsID;
            _ShirtToUpdate.Size = _shirtToUpdate.Size;
            _ShirtToUpdate.Color = _shirtToUpdate.Color;
            _ShirtToUpdate.ShirtPrice = _shirtToUpdate.ShirtPrice;
            return _ShirtToUpdate;
        }
        public Shirt Map(ShirtsDAO shirtToCreate)
        {
            Shirt daShirtToCreate = new Shirt();
            daShirtToCreate.ShirtsID = shirtToCreate.ShirtsID;
            daShirtToCreate.Size = shirtToCreate.Size;
            daShirtToCreate.Color = shirtToCreate.Color;
            daShirtToCreate.ShirtPrice = shirtToCreate.ShirtPrice;

            return daShirtToCreate;
        }
        public List<Pant> Map(List<PantsDAO> _PantListToMap)
        {
            List<Pant> _PantListToReturn = new List<Pant>();
            foreach (PantsDAO _PantToMap in _PantListToMap)
            {
                Pant PantViewModel = new Pant();
                PantViewModel.PantsID = _PantToMap.PantsID;
                PantViewModel.Size = _PantToMap.Size;
                PantViewModel.Color = _PantToMap.Color;
                PantViewModel.PantPrice = _PantToMap.PantPrice;
                _PantListToReturn.Add(PantViewModel);


            }
            return _PantListToReturn;

        }
        public PantsDAO Map(Pant pantToCreate)
        {
            PantsDAO daPantToCreate = new PantsDAO();
            daPantToCreate.PantsID = pantToCreate.PantsID;
            daPantToCreate.Size = pantToCreate.Size;
            daPantToCreate.Color = pantToCreate.Color;
            daPantToCreate.PantPrice = pantToCreate.PantPrice;

            return daPantToCreate;
        }
        public Pant Map(PantsDAO _pantToUpdate)
        {
            Pant _PantToUpdate = new Pant();
            _PantToUpdate.PantsID = _pantToUpdate.PantsID;
            _PantToUpdate.Size = _pantToUpdate.Size;
            _PantToUpdate.Color = _pantToUpdate.Color;
            _PantToUpdate.PantPrice = _pantToUpdate.PantPrice;
            return _PantToUpdate;
        }

        public List<Carts> Map(List<CartDAO> CartListToMap)
        {
            List<Carts> CartListToReturn = new List<Carts>();
            foreach (CartDAO CartToMap in CartListToMap)
            {
                Carts CartViewModel = Map(CartToMap);
                CartListToReturn.Add(CartViewModel);


            }
            return CartListToReturn;

        }
        public CartDAO Map(Carts cartToCreate)
        {
            CartDAO daCartToCreate = new CartDAO();
            daCartToCreate.CartID = cartToCreate.UserID;
            daCartToCreate.PantsID = cartToCreate.PantsID;
            daCartToCreate.ShirtsID = cartToCreate.ShirtsID;
            daCartToCreate.UserID = cartToCreate.UserID;
            daCartToCreate.ShirtQuanity = cartToCreate.ShirtQuanity;
            daCartToCreate.PantQuanity = cartToCreate.PantQuanity;
            daCartToCreate.ShirtPrice = cartToCreate.ShirtPrice;
            daCartToCreate.PantPrice = cartToCreate.PantPrice;
            daCartToCreate.TotalPrice = cartToCreate.TotalPrice;

            return daCartToCreate;
        }


        public Carts Map(CartDAO cartToUpdate)
        {
            Carts _cartToUpdate = new Carts();
            _cartToUpdate.UserID = cartToUpdate.UserID;
            _cartToUpdate.PantsID = cartToUpdate.PantsID;
            _cartToUpdate.ShirtsID = cartToUpdate.ShirtsID;
            _cartToUpdate.ShirtQuanity = cartToUpdate.ShirtQuanity;
            _cartToUpdate.PantQuanity = cartToUpdate.PantQuanity;
            _cartToUpdate.ShirtPrice = cartToUpdate.ShirtPrice;
            _cartToUpdate.PantPrice = cartToUpdate.PantPrice;
            _cartToUpdate.TotalPrice = cartToUpdate.TotalPrice;
            


            return _cartToUpdate;
        }

        public CartsBLO Mapcarts(Carts _SingleCartLogic)
        {
            CartsBLO LogicToReturn = new CartsBLO();
            {
                CartsBLO _cartLogicView = new CartsBLO();
                _cartLogicView.CartID = _SingleCartLogic.CartID;
                _cartLogicView.PantsID = _SingleCartLogic.PantsID;
                _cartLogicView.ShirtsID = _SingleCartLogic.ShirtsID;
                _cartLogicView.UserID = _SingleCartLogic.UserID;
                _cartLogicView.ShirtQuanity = _SingleCartLogic.ShirtQuanity;
                _cartLogicView.PantQuanity = _SingleCartLogic.PantQuanity;
                _cartLogicView.TotalPrice = _SingleCartLogic.TotalPrice;
                _cartLogicView.ShirtPrice = _SingleCartLogic.ShirtPrice;
                _cartLogicView.PantPrice = _SingleCartLogic.PantPrice;
            }
            return LogicToReturn;

        }
        public Carts Map(CartsBLO _SelectCartLogic)
        {
            Carts LogicToReturn = new Carts();
            {
                Carts _cartLogicView = new Carts();
                _cartLogicView.CartID = _SelectCartLogic.CartID;
                _cartLogicView.PantsID = _SelectCartLogic.PantsID;
                _cartLogicView.ShirtsID = _SelectCartLogic.ShirtsID;
                _cartLogicView.UserID = _SelectCartLogic.UserID;
                _cartLogicView.ShirtQuanity = _SelectCartLogic.ShirtQuanity;
                _cartLogicView.PantQuanity = _SelectCartLogic.PantQuanity;
                _cartLogicView.TotalPrice = _SelectCartLogic.TotalPrice;
                _cartLogicView.ShirtPrice = _SelectCartLogic.ShirtPrice;
                _cartLogicView.PantPrice = _SelectCartLogic.PantPrice;
            }
            return LogicToReturn;
        }

        public List<Carts> Mapcart(List<CartsBLO> _CartListToMap)
        {
            List<Carts> _CartListToReturn = new List<Carts>();
            foreach (CartsBLO _CartToMap in _CartListToMap)
            {
                Carts _CartViewModel = new Carts();
                _CartViewModel.CartID = _CartToMap.UserID;
                _CartViewModel.PantsID = _CartToMap.PantsID;
                _CartViewModel.ShirtsID = _CartToMap.ShirtsID;
                _CartViewModel.UserID = _CartToMap.UserID;
                _CartViewModel.ShirtQuanity = _CartToMap.ShirtQuanity;
                _CartViewModel.PantQuanity = _CartToMap.PantQuanity;
                _CartViewModel.TotalPrice = _CartToMap.TotalPrice;
                _CartViewModel.ShirtPrice = _CartToMap.ShirtPrice;
                _CartViewModel.PantPrice = _CartToMap.PantPrice;

                _CartListToReturn.Add(_CartViewModel);


            }
            return _CartListToReturn;
        }
    }
}