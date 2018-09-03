using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Objects;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Utility_Logger;

namespace DAL
{
    public class CartsDataAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Clothing Elaine"].ConnectionString;
        public List<CartDAO> GetAllCarts()

        {//Create a method that will get all my Books and place them in a list named _booklist
            List<CartDAO> _cartlist = new List<CartDAO>();


            try
            {
                //Establishing the connection for the database 
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("SP_CartView", _connection))
                    {
                        //Establishing the command to pass to the database
                        //and defining the command
                        _command.CommandType = CommandType.StoredProcedure;
                        //connect to the database
                        _connection.Open();
                        //Open the sql data reader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            //Loop through the data sets or command and write each element
                            //to the _bookToList using the book object
                            while (_reader.Read())
                            {
                                CartDAO _cartToList = new CartDAO();
                                _cartToList.CartID = _reader.GetInt32(0);
                                _cartToList.PantsID = _reader.GetInt32(1);
                                _cartToList.ShirtsID = _reader.GetInt32(2);
                                _cartToList.UserID = _reader.GetInt32(3);
                                _cartToList.ShirtQuanity = _reader.GetInt32(4);
                                _cartToList.PantQuanity = _reader.GetInt32(5);
                                _cartToList.PantPrice = _reader.GetInt32(6);
                                _cartToList.ShirtPrice = _reader.GetInt32(7);
                                _cartToList.TotalPrice = _reader.GetInt32(8);

                                _cartlist.Add(_cartToList);

                            }
                        }
                    }
                }
            }

            catch (Exception error)
            {
                Error_Logger Log = new Error_Logger();
                Log.Errorlogger(error);
            }
            return _cartlist;
        }
        public bool deleteCart(CartDAO cartToDelete)
        {
            {
                bool yes = false;
                try
                {
                    //This is creating a connection to the database 
                    using (SqlConnection _connection = new SqlConnection(connectionString))
                    {
                        //This specifies what type of command
                        using (SqlCommand _command = new SqlCommand("SP_Cart_Delete", _connection))
                        {
                            //This specifies what type of command is being used
                            _command.CommandType = CommandType.StoredProcedure;
                            //Here is where the Values will be passed to the command
                            _command.Parameters.AddWithValue("@CartID", cartToDelete.CartID);
                            //Here is where the connection is opened
                            _connection.Open();
                            //This will excute the command
                            _command.ExecuteNonQuery();
                            yes = true;
                            _connection.Close();
                        }
                    }
                }
                catch (Exception error)
                {
                    Error_Logger Log = new Error_Logger();
                    Log.Errorlogger(error);
                }
                return yes;
            }
        }
        public void UpdateCart(CartDAO cartToUpdate)
        {
            try
            {
                //This is creating a connection to the database 


                //This specifies what type of command
                using (SqlConnection _connection = new SqlConnection(connectionString))
                using (SqlCommand _command = new SqlCommand("SP_Cart_Update", _connection))
                {

                    //This specifies what type of command is being used
                    _command.CommandType = CommandType.StoredProcedure;
                    //Here is where the Values will be passed to the command
                    _command.Parameters.AddWithValue("@CartID", cartToUpdate.CartID);
                    _command.Parameters.AddWithValue("@PantsID", cartToUpdate.PantsID);
                    _command.Parameters.AddWithValue("@ShirtsID", cartToUpdate.ShirtsID);
                    _command.Parameters.AddWithValue("@UserID", cartToUpdate.UserID);
                    _command.Parameters.AddWithValue("@ShirtQuanity", cartToUpdate.ShirtQuanity);
                    _command.Parameters.AddWithValue("@PantQuanity", cartToUpdate.PantQuanity);
                    _command.Parameters.AddWithValue("@TotalPrice", cartToUpdate.TotalPrice);
                    _command.Parameters.AddWithValue("@ShirtPrice", cartToUpdate.ShirtPrice);
                    _command.Parameters.AddWithValue("@PantPrice", cartToUpdate.PantPrice);

                    //Here is where the connection is opened
                    _connection.Open();
                    using (SqlDataReader _reader = _command.ExecuteReader())
                    {
                        while (_reader.Read())
                        {
                            cartToUpdate.CartID = _reader.GetInt32(0);
                            cartToUpdate.PantsID = _reader.GetInt32(1);
                            cartToUpdate.ShirtsID = _reader.GetInt32(2);
                            cartToUpdate.UserID = _reader.GetInt32(3);
                            cartToUpdate.ShirtQuanity = _reader.GetInt32(4);
                            cartToUpdate.PantQuanity = _reader.GetInt32(5);
                            cartToUpdate.TotalPrice = _reader.GetInt32(6);
                            cartToUpdate.ShirtPrice = _reader.GetInt32(7);
                            cartToUpdate.PantPrice = _reader.GetInt32(8);
                        }
                        _connection.Close();
                    }

                    //This will excute the command
                    _command.ExecuteNonQuery();
                    _connection.Close();
                }
            }
            catch (Exception error)
            {
                Error_Logger Log = new Error_Logger();
                Log.Errorlogger(error);
            }
        }
        public CartDAO _createCart(CartDAO _cartCreate)
        {
            CartDAO _createCart = new CartDAO();
            try
            {


                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("SP_Cart_Create", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@CartID", _cartCreate.CartID);
                        _command.Parameters.AddWithValue("@PantsID", _cartCreate.PantsID);
                        _command.Parameters.AddWithValue("@ShirtsID", _cartCreate.ShirtsID);
                        _command.Parameters.AddWithValue("@UserID", _cartCreate.UserID);
                        _command.Parameters.AddWithValue("@ShirtQuanity", _cartCreate.ShirtQuanity);
                        _command.Parameters.AddWithValue("@PantQuanity", _cartCreate.PantQuanity);
                        _command.Parameters.AddWithValue("@TotalPrice", _cartCreate.TotalPrice);
                        _command.Parameters.AddWithValue("@ShirtPrice", _cartCreate.ShirtPrice);
                        _command.Parameters.AddWithValue("@PantPrice", _cartCreate.PantPrice);
                        _connection.Open();
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            while (_reader.Read())
                            {
                                _createCart.CartID = _reader.GetInt32(0);
                                _createCart.PantsID = _reader.GetInt32(1);
                                _createCart.ShirtsID = _reader.GetInt32(2);
                                _createCart.UserID = _reader.GetInt32(3);
                                _createCart.ShirtQuanity = _reader.GetInt32(4);
                                _createCart.PantQuanity = _reader.GetInt32(5);
                                _createCart.TotalPrice = _reader.GetInt32(6);
                                _createCart.ShirtPrice = _reader.GetInt32(6);
                                _createCart.PantPrice = _reader.GetInt32(6);
                            }
                            _connection.Close();
                        }

                    }
                }
            }
            catch (Exception error)
            {
                Error_Logger Log = new Error_Logger();
                Log.Errorlogger(error);
            }
            return _createCart;
        }
        public CartDAO GetCartById(int CartID)

        {//Create a method that will get all my Books and place them in a list named _booklist
            CartDAO _cartReturn = new CartDAO();

            try
            {
                //Establishing the connection for the database 
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("SP_Get_Cart_By_CartID", _connection))
                    {
                        //Establishing the command to pass to the database
                        //and defining the command
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@CartID", CartID);
                        //connect to the database
                        _connection.Open();
                        //Open the sql data reader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            //Loop through the data sets or command and write each element
                            //to the _bookToList using the book object
                            while (_reader.Read())
                            {

                                _cartReturn.CartID = _reader.GetInt32(0);
                                _cartReturn.PantsID = _reader.GetInt32(1);
                                _cartReturn.ShirtsID = _reader.GetInt32(2);
                                _cartReturn.UserID = _reader.GetInt32(3);
                                _cartReturn.ShirtQuanity = _reader.GetInt32(4);
                                _cartReturn.PantQuanity = _reader.GetInt32(4);
                                _cartReturn.TotalPrice = _reader.GetInt32(5);
                                _cartReturn.ShirtPrice = _reader.GetInt32(5);
                                _cartReturn.PantPrice = _reader.GetInt32(5);

                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                Error_Logger Log = new Error_Logger();
                Log.Errorlogger(error);
            }
            return _cartReturn;
        }

    }
}



