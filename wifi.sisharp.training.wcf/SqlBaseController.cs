using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//namespace wifi.sisharp.training.wcf
//{
//    /// <summary>
//    /// Provides base utilities for creating a Sql Server Controller.
//    /// </summary>
//    public class SqlBaseController
//    {

//        /// <summary>
//        /// Gets or sets the path where the dabasebase file is saved.
//        /// </summary>
//        /// <remarks>Leave this setting empty 
//        /// if it's an attached Sql Server Database.</remarks>
//        public string DatabasePath = "C:\\MyProjects\\Wifi-Kurs\\WIFI-Sisharp-Training\\wifi.sisharp.training.web\\App_Data";

//        /// <summary>
//        /// Gets or sets the address of the used sql server.
//        /// </summary>
//        /// <remarks>Use (LocalDB)\MSSQLLocalDB it the
//        /// datebase is attached by the current application.</remarks>
//        public string SqlServer = "(LocalDB)\\MSSQLLocalDB";

//        /// <summary>
//        /// Gets or sets the name of the database.
//        /// </summary>
//        /// <remarks>Include the extension, if the
//        /// database is attached by the current application.</remarks>
//        public string Database = "AndritzHydro2019";

//        /// <summary>
//        /// String needed to connect to the database.
//        /// </summary>
//        private static string _ConnectionString = null;

//        /// <summary>
//        /// Gets the connection object initialized with
//        /// the information provided by the application context.
//        /// </summary>
//        private string ConnectionString
//        {
//            get
//            {
//                if (SqlBaseController._ConnectionString == null)
//                {
//                    var builder = new System.Data.SqlClient.SqlConnectionStringBuilder();

//                    if (this.DatabasePath == string.Empty)
//                    {
//                        //The database is attached to the server
//                        builder.InitialCatalog = System.IO.Path.GetFileNameWithoutExtension(this.Database);
//                    }
//                    else
//                    {
//                        //The database is dynamically attached
//                        builder.AttachDBFilename = System.IO.Path.Combine(this.DatabasePath, this.Database);
//                    }

//                    builder.DataSource = this.SqlServer;

//                    //The databases users are managed by the Active Directory,
//                    //so no password is needed. Always use this technique.
//                    //Only using Microsoft Cloud Azure you need user and password
//                    builder.IntegratedSecurity = true;

//                    SqlBaseController._ConnectionString = builder.ConnectionString;

//                }

//                return SqlBaseController._ConnectionString;
//            }
//        }
//    }
//}