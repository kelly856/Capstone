using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL.Objects;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class PantsDataAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Clothing Elaine"].ConnectionString;
        // This is the method used to delete a book
        public bool deletePant(PantsDAO pantToDelete)
        {
            bool yes = false;
            try
            {
                //This is creating a connection to the database 
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    //This specifies what type of command
                    using (SqlCommand _command = new SqlCommand("SP_Pant_Delete", _connection))
                    {
                        //This specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //Here is where the Values will be passed to the command
                        _command.Parameters.AddWithValue("@PantsID", pantToDelete.PantsID);
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
                //Console.WriteLine("You have successfully deleted a Book");
                // Console.ReadLine();



            }
            return yes;
        }

        public void UpdatePant(PantsDAO pantsDAO)
        {
            throw new NotImplementedException();
        }

        public List<PantsDAO> GetAllPants()

        {//Create a method that will get all my Books and place them in a list named _booklist
            List<PantsDAO> _pantlist = new List<PantsDAO>();


            try
            {
                //Establishing the connection for the database 
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("SP_Pant_Read", _connection))
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
                                PantsDAO _pantToList = new PantsDAO();
                                _pantToList.PantsID = _reader.GetInt32(0);
                                _pantToList.Size = _reader.GetInt32(1);
                                _pantToList.Color = _reader.GetString(2);
                                _pantToList.Price = _reader.GetDecimal(3);
                                _pantlist.Add(_pantToList);

                            }
                        }
                    }
                }
            }
            catch
            {

            }
            return _pantlist;
        }
        public void createPant(PantsDAO pantToCreate)
        {
            try
            {
                //This is creating a connection to the database 
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    //This specifies what type of command
                    using (SqlCommand _command = new SqlCommand("SP_Pant_Create", _connection))
                    {
                        //This specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //Here is where the Values will be passed to the command
                        _command.Parameters.AddWithValue("PantsID", pantToCreate.PantsID);
                        _command.Parameters.AddWithValue("@Size", pantToCreate.Size);
                        _command.Parameters.AddWithValue("@Color", pantToCreate.Color);
                        _command.Parameters.AddWithValue("@Price", pantToCreate.Price);
                        //Here is where the connection is opened
                        _connection.Open();
                        //This will excute the command
                        _command.ExecuteNonQuery();

                        _connection.Close();
                    }
                }
            }
            catch
            {

            }
        }
        public void UpdatePant(ShirtsDAO pantToUpdate)
        {
            try
            {
                //This specifies what type of command
                using (SqlConnection _connection = new SqlConnection(connectionString))
                using (SqlCommand _command = new SqlCommand("SP_Pant_Update", _connection))
                {

                    //This specifies what type of command is being used
                    _command.CommandType = CommandType.StoredProcedure;
                    //Here is where the Values will be passed to the command
                    _command.Parameters.AddWithValue("@PantsID", pantToUpdate.ShirtsID);
                    _command.Parameters.AddWithValue("@Size", pantToUpdate.Size);
                    _command.Parameters.AddWithValue("@Color", pantToUpdate.Color);
                    _command.Parameters.AddWithValue("@Price", pantToUpdate.Price);
                    //Here is where the connection is opened
                    _connection.Open();
                    //This will excute the command
                    _command.ExecuteNonQuery();
                    _connection.Close();
                }
            }
            catch
            {

            }
        }
        public PantsDAO GetPantById(int PantsID)

        {//Create a method that will get all my Books and place them in a list named _booklist
            PantsDAO _pantReturn = new PantsDAO();

            try
            {
                //Establishing the connection for the database 
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("SP_Get_Pant_By_PantID",_connection))
                    {
                        //Establishing the command to pass to the database
                        //and defining the command
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@PantsID", PantsID);
                        //connect to the database
                        _connection.Open();
                        //Open the sql data reader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            //Loop through the data sets or command and write each element
                            //to the _bookToList using the book object
                            while (_reader.Read())
                            {
                                
                                _pantReturn.PantsID = _reader.GetInt32(0);
                                _pantReturn.Size = _reader.GetInt32(1);
                                _pantReturn.Color = _reader.GetString(2);
                                _pantReturn.Price = _reader.GetDecimal(3);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
            return _pantReturn;
        }
    }
}

