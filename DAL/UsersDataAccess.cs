using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using DAL.Objects;


namespace DAL
{
    public class UserDataAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Clothing Elaine"].ConnectionString;
        public UsersDAO _login(UsersDAO _userLogin)
        {
            UsersDAO _loginUser = new UsersDAO();
            try
            {


                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("SP_User_Login", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@Username", _userLogin.Username);
                        _connection.Open();
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            while (_reader.Read())
                            {
                                _loginUser.UserID = _reader.GetInt32(0);
                                _loginUser.Password = _reader.GetString(1);
                                _loginUser.Firstname = _reader.GetString(2);
                                _loginUser.Lastname = _reader.GetString(3);
                                _loginUser.Username = _reader.GetString(4);
                                _loginUser.RoleID = _reader.GetInt32(5);
                            }
                            _connection.Close();
                        }

                    }
                }
            }
            catch
            {

            }

            return _loginUser;
        }

        public UsersDAO _createUser(UsersDAO _userCreate)
        {
            UsersDAO _createUser = new UsersDAO();
            try
            {


                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("SP_User_Create1", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@Firstname", _userCreate.Firstname);
                        _command.Parameters.AddWithValue("@Lastname", _userCreate.Lastname);
                        _command.Parameters.AddWithValue("@Address", _userCreate.Address);
                        _command.Parameters.AddWithValue("@Zipcode", _userCreate.Zipcode);
                        _command.Parameters.AddWithValue("@Phonenumber", _userCreate.Phonenumber);
                        _command.Parameters.AddWithValue("@Password", _userCreate.Password);
                        _command.Parameters.AddWithValue("@Username", _userCreate.Username);
                        _connection.Open();
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            while (_reader.Read())
                            {
                                _createUser.Firstname = _reader.GetString(2);
                                _createUser.Lastname = _reader.GetString(3);
                                _createUser.Address = _reader.GetString(6);
                                _createUser.Zipcode = _reader.GetInt32(9);
                                _createUser.Phonenumber = _reader.GetString(7);
                                _createUser.Password = _reader.GetString(1);
                                _createUser.Username = _reader.GetString(0);
                            }
                            _connection.Close();
                        }

                    }
                }
            }
            catch
            {

            }

            return _createUser;
        }
        public void UpdateUser(UsersDAO userToUpdate)
        {
            try
            {
                //This is creating a connection to the database 


                //This specifies what type of command
                using (SqlConnection _connection = new SqlConnection(connectionString))
                using (SqlCommand _command = new SqlCommand("SP_User_Update", _connection))
                {

                    //This specifies what type of command is being used
                    _command.CommandType = CommandType.StoredProcedure;
                    //Here is where the Values will be passed to the command
                    _command.Parameters.AddWithValue("@UserID", userToUpdate.UserID);
                    _command.Parameters.AddWithValue("@Firstname", userToUpdate.Firstname);
                    _command.Parameters.AddWithValue("@Lastname", userToUpdate.Lastname);
                    _command.Parameters.AddWithValue("@Address", userToUpdate.Address);
                    _command.Parameters.AddWithValue("@Zipcode", userToUpdate.Zipcode);
                    _command.Parameters.AddWithValue("@Phonenumber", userToUpdate.Phonenumber);
                    _command.Parameters.AddWithValue("@Username", userToUpdate.Username);
                    _command.Parameters.AddWithValue("@RoleID", userToUpdate.RoleID);

                    //Here is where the connection is opened
                    _connection.Open();
                    using (SqlDataReader _reader = _command.ExecuteReader())
                    {
                        while (_reader.Read())
                        {
                            userToUpdate.UserID = _reader.GetInt32(0);
                            userToUpdate.Firstname = _reader.GetString(1);
                            userToUpdate.Lastname = _reader.GetString(2);
                            userToUpdate.Address = _reader.GetString(3);
                            userToUpdate.Zipcode = _reader.GetInt32(4);
                            userToUpdate.Phonenumber = _reader.GetString(5);
                            userToUpdate.Username = _reader.GetString(6);
                            userToUpdate.RoleID = _reader.GetInt32(7);
                        }
                        _connection.Close();
                    }

                    //This will excute the command
                    _command.ExecuteNonQuery();
                    _connection.Close();
                }
            }
            catch
            {

            }


        }
        public List<UsersDAO> GetAllUsers()
        {//Create a method that will get all my Books and place them in a list named _booklist
            List<UsersDAO> _userlist = new List<UsersDAO>();


            try
            {
                //Establishing the connection for the database 
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("SP_User_Read", _connection))
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
                                UsersDAO _userToList = new UsersDAO();
                                _userToList.Firstname = _reader.GetString(0);
                                _userToList.Lastname = _reader.GetString(1);
                                _userToList.Address = _reader.GetString(2);
                                _userToList.Zipcode = _reader.GetInt32(3);
                                _userToList.Phonenumber = _reader.GetString(4);
                                _userToList.Password = _reader.GetString(5);
                                _userToList.Username = _reader.GetString(6);
                                _userToList.UserID = _reader.GetInt32(7);
                                _userToList.RoleID = _reader.GetInt32(8);
                                _userlist.Add(_userToList);

                            }
                        }
                    }
                }
            }

            catch
            {

            }
            return _userlist;
        }
        public bool deleteUser(UsersDAO userToDelete)
        {
            bool yes = false;
            try
            {
                //This is creating a connection to the database 
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    //This specifies what type of command
                    using (SqlCommand _command = new SqlCommand("SP_User_Delete", _connection))
                    {
                        //This specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //Here is where the Values will be passed to the command
                        _command.Parameters.AddWithValue("@UserID", userToDelete.UserID);
                        //Here is where the connection is opened
                        _connection.Open();
                        //This will excute the command
                        _command.ExecuteNonQuery();
                        yes = true;
                        _connection.Close();
                    }
                }
            }
            catch
            {

            }
            if (yes == true)
            {


            }
            return yes;

        }
        public UsersDAO GetUserByID(int userID)
        {//Create a method that will get all my Books and place them in a list named _booklist
            UsersDAO _userReturn = new UsersDAO();


            try
            {
                //Establishing the connection for the database 
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("SP_Get_User_By_UserID", _connection))
                    {
                        //Establishing the command to pass to the database
                        //and defining the command
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@UserID", userID);
                        //connect to the database
                        _connection.Open();
                        //Open the sql data reader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            //Loop through the data sets or command and write each element
                            //to the _bookToList using the book object
                            while (_reader.Read())
                            {
                                _userReturn.UserID = _reader.GetInt32(0);
                                _userReturn.Firstname = _reader.GetString(1);
                                _userReturn.Lastname = _reader.GetString(2);
                                _userReturn.Address = _reader.GetString(3);
                                _userReturn.Zipcode = _reader.GetInt32(4);
                                _userReturn.Phonenumber = _reader.GetString(5);
                                _userReturn.Username = _reader.GetString(6);
                                _userReturn.RoleID = _reader.GetInt32(7);
                            }
                        }
                    }
                }
            }

            catch
            {

            }
            return _userReturn;
        }
    }
}
