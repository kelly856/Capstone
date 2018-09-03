using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL.Objects;
using System.Data.SqlClient;
using System.Data;
using Utility_Logger;

namespace DAL
{
    public class ShirtsDataAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Clothing Elaine"].ConnectionString;
        // This is the method used to delete a book
        public bool deleteShirt(ShirtsDAO shirtToDelete)
        {
            bool yes = false;
            try
            {
                //This is creating a connection to the database 
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    //This specifies what type of command
                    using (SqlCommand _command = new SqlCommand("SP_Shirt_Delete", _connection))
                    {
                        //This specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //Here is where the Values will be passed to the command
                        _command.Parameters.AddWithValue("@ShirtsID", shirtToDelete.ShirtsID);
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
            if (yes == true)
            {
                //Console.WriteLine("You have successfully deleted a Book");
                // Console.ReadLine();



            }
            return yes;
        }
        public List<ShirtsDAO> GetAllShirts()

        {//Create a method that will get all my Books and place them in a list named _booklist
            List<ShirtsDAO> _shirtlist = new List<ShirtsDAO>();


            try
            {
                //Establishing the connection for the database 
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("SP_Shirt_Read", _connection))
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
                                ShirtsDAO _shirtToList = new ShirtsDAO();
                                _shirtToList.ShirtsID = _reader.GetInt32(0);
                                _shirtToList.Size = _reader.GetString(1);
                                _shirtToList.Color = _reader.GetString(2);
                                _shirtToList.ShirtPrice = _reader.GetInt32(3);
                                _shirtlist.Add(_shirtToList);

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
            return _shirtlist;
        }
        public void createShirt(ShirtsDAO shirtToCreate)
        {
            try
            {
                //This is creating a connection to the database 
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    //This specifies what type of command
                    using (SqlCommand _command = new SqlCommand("SP_Shirt_Create", _connection))
                    {
                        //This specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //Here is where the Values will be passed to the command
                        _command.Parameters.AddWithValue("@Size", shirtToCreate.Size);
                        _command.Parameters.AddWithValue("@Color", shirtToCreate.Color);
                        _command.Parameters.AddWithValue("@ShirtPrice", shirtToCreate.ShirtPrice);
                        //Here is where the connection is opened
                        _connection.Open();
                        //This will excute the command
                        _command.ExecuteNonQuery();

                        _connection.Close();
                    }
                }
            }
            catch (Exception error)
            {
                Error_Logger Log = new Error_Logger();
                Log.Errorlogger(error);
            }
        }
        public void UpdateShirt(ShirtsDAO shirtToUpdate)
        {
            try
            {
                //This specifies what type of command
                using (SqlConnection _connection = new SqlConnection(connectionString))
                using (SqlCommand _command = new SqlCommand("SP_Shirt_Update", _connection))
                {

                    //This specifies what type of command is being used
                    _command.CommandType = CommandType.StoredProcedure;
                    //Here is where the Values will be passed to the command
                    _command.Parameters.AddWithValue("@ShirtsID", shirtToUpdate.ShirtsID);
                    _command.Parameters.AddWithValue("@Size", shirtToUpdate.Size);
                    _command.Parameters.AddWithValue("@Color", shirtToUpdate.Color);
                    _command.Parameters.AddWithValue("@ShirtPrice", shirtToUpdate.ShirtPrice);
                    //Here is where the connection is opened
                    _connection.Open();
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

        public ShirtsDAO GetShirtById(int ShirtsID)

        {//Create a method that will get all my Books and place them in a list named _booklist
            ShirtsDAO _shirtReturn = new ShirtsDAO();

            try
            {
                //Establishing the connection for the database 
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("SP_Get_Shirt_By_ID", _connection))
                    {
                        //Establishing the command to pass to the database
                        //and defining the command
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@ShirtsID", ShirtsID);
                        //connect to the database
                        _connection.Open();
                        //Open the sql data reader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            //Loop through the data sets or command and write each element
                            //to the _bookToList using the book object
                            while (_reader.Read())
                            {
                                _shirtReturn.ShirtsID = _reader.GetInt32(0);
                                _shirtReturn.Size = _reader.GetString(1);
                                _shirtReturn.Color = _reader.GetString(2);
                                _shirtReturn.ShirtPrice = _reader.GetInt32(3);
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
            return _shirtReturn;
        }
    }

}
