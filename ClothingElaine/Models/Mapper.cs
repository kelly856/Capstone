using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Objects;

namespace ClothingElaine.Models
{
    public class Mapper
    {   //Mapper used to get all the data from the DAL for the bookview mode from the BookDAO object.
        //Use this mapper in the HttpGET book controller action.
        public List<User> Map(List<UsersDAO> UserListToMap)
        {
            List<User> UserListToReturn = new List<User>();
            foreach (UsersDAO UserToMap in UserListToMap)
            {
                User UserViewModel = new User();
                UserViewModel.UserID = UserToMap.UserID;
                UserViewModel.Firstname = UserToMap.Firstname;
                UserViewModel.Lastname = UserToMap.Lastname;
                UserViewModel.Address = UserToMap.Address;
                UserViewModel.Zipcode = UserToMap.Zipcode;
                UserViewModel.Phonenumber = UserToMap.Phonenumber;
                UserViewModel.Password = UserToMap.Password;
                UserViewModel.RoleID = UserToMap.RoleID;
                UserViewModel.Username = UserToMap.Username;
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


        public UsersDAO Map1(User userToUpdate)
        {
             UsersDAO _userToUpdate = new UsersDAO();
            _userToUpdate.UserID = userToUpdate.UserID;
            _userToUpdate.Firstname = userToUpdate.Firstname;
            _userToUpdate.Lastname = userToUpdate.Lastname;
            _userToUpdate.Address = userToUpdate.Address;
            _userToUpdate.Zipcode = userToUpdate.Zipcode;
            _userToUpdate.Phonenumber = userToUpdate.Phonenumber;
            _userToUpdate.Password = userToUpdate.Password;
            _userToUpdate.RoleID = userToUpdate.RoleID;
            _userToUpdate.Username = userToUpdate.Username;

            return _userToUpdate;
        }



        public List<Shirt> MapListShirt(List<ShirtsDAO> ShirtListToMap)
        {
            List<Shirt> ShirtListToReturn = new List<Shirt>();
            foreach (ShirtsDAO ShirtToMap in ShirtListToMap)
            {
                Shirt ShirtViewModel = new Shirt();
                ShirtViewModel.ShirtsID = ShirtToMap.ShirtsID;
                ShirtViewModel.Size = ShirtToMap.Size;
                ShirtViewModel.Color = ShirtToMap.Color;
                ShirtViewModel.Price = ShirtToMap.Price;
                ShirtListToReturn.Add(ShirtViewModel);


            }
            return ShirtListToReturn;

        }
        public ShirtsDAO mapshirt(Shirt _shirtToUpdate)
        {
             ShirtsDAO _ShirtToUpdate = new ShirtsDAO();
            _ShirtToUpdate.ShirtsID = _shirtToUpdate.ShirtsID;
            _ShirtToUpdate.Size = _shirtToUpdate.Size;
            _ShirtToUpdate.Color = _shirtToUpdate.Color;
            _ShirtToUpdate.Price = _shirtToUpdate.Price;
            return _ShirtToUpdate;
        }
        public ShirtsDAO mapshirts(Shirt shirtToCreate)
        {
            ShirtsDAO daShirtToCreate = new ShirtsDAO();
            daShirtToCreate.ShirtsID = shirtToCreate.ShirtsID;
            daShirtToCreate.Size = shirtToCreate.Size;
            daShirtToCreate.Color = shirtToCreate.Color;
            daShirtToCreate.Price = shirtToCreate.Price;

            return daShirtToCreate;
        }
        public List<Pant> mapuser(List<PantsDAO> _PantListToMap)
        {
            List<Pant> _PantListToReturn = new List<Pant>();
            foreach (PantsDAO _PantToMap in _PantListToMap)
            {
                Pant PantViewModel = new Pant();
                 PantViewModel.PantsID = _PantToMap.PantsID;
                 PantViewModel.Size = _PantToMap.Size;
                 PantViewModel.Color = _PantToMap.Color;
                 PantViewModel.Price = _PantToMap.Price;
                _PantListToReturn.Add(PantViewModel);


            }
            return _PantListToReturn;

        }
        public PantsDAO mappants(Pant pantToCreate)
        {
            PantsDAO daPantToCreate = new PantsDAO();
            daPantToCreate.PantsID = pantToCreate.PantsID;
            daPantToCreate.Size = pantToCreate.Size;
            daPantToCreate.Color = pantToCreate.Color;
            daPantToCreate.Price = pantToCreate.Price;

            return daPantToCreate;
        }
        public PantsDAO Mappants(Pant _pantToUpdate)
        {
            PantsDAO _PantToUpdate = new PantsDAO();
            _PantToUpdate.PantsID = _pantToUpdate.PantsID;
            _PantToUpdate.Size = _pantToUpdate.Size;
            _PantToUpdate.Color = _pantToUpdate.Color;
            _PantToUpdate.Price = _pantToUpdate.Price;
            return _PantToUpdate;
        }
    }
}