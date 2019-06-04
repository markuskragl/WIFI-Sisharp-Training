using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace wifi.sisharp.training.wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.




    public class MathService :  IMathService
    { 

        


        public int Calc(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Returns the supported countries.
        /// </summary>
        /// <param name="language">Code of the language that should be used.</param>
        /// <remarks>Shows how to call a stored procedure.</remarks>
        public Countries GetCountries(string language)
        {
            var result = new Countries();


            //First: A connection is needed
            using (var connection = new System.Data.SqlClient.SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\MyProjects\\Wifi-Kurs\\WIFI-Sisharp-Training\\wifi.sisharp.training.web\\App_Data\\AndritzHydro2019.mdf"))
            {
                //Second: A command is needed
                using (var command = new System.Data.SqlClient.SqlCommand("GetCountries", connection))
                {
                    //Configure the command
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@language", language);

                    //The Sql Server should cache the procedure...
                    command.Prepare();

                    //Don't forget:
                    connection.Open();

                    //Third: (Not needed with INSERT, UPDATE or DELETE: command.ExecuteNonQuery() is used)
                    // - only with SELECT
                    using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        //Map the data to the data transfer objects
                        while (reader.Read())
                        {
                            result.Add(new Country
                            {
                                Code = reader["ISO"].ToString(),
                                Name = reader["Name"].ToString(),
                                MaxNumber = (int)reader["MaxNumber"],
                                NumberCount = (int)reader["NumberCount"]
                            });
                        }
                    }
                }
            }

            return result;

        }

        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }




    }
}
