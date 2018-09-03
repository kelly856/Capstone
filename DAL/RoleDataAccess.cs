using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL.Objects;
using System.Data;
using System.Data.SqlClient;
using Utility_Logger;

namespace DAL
{
    class RoleDataAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Clothing Elaine"].ConnectionString;

        public List<RoleDAO> GetAllRoles()
        {//Create a method that will get all my Books and place them in a list named _booklist
            List<RoleDAO> _rolelist = new List<RoleDAO>();


            try
            {
                //Establishing the connection for the database 
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("SP_Role_View", _connection))
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
                                RoleDAO _roleToList = new RoleDAO();
                                _roleToList.RoleID = _reader.GetInt32(0);
                                _roleToList.Descript = _reader.GetString(1);
                                _rolelist.Add(_roleToList);

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
            return _rolelist;
        }
    }
}
