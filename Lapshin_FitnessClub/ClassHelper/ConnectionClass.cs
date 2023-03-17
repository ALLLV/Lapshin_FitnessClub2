using Lapshin_FitnessClub.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lapshin_FitnessClub.ClassHelper
{
    public class ConnectionClass
    {
        public static Entities context { get; set; } = new Entities();

        public User newUser;

        public static List<Service> cartServices = new List<Service>();

        //static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Entities"].ConnectionString;

        //static SqlConnection connection = new SqlConnection(connectionString);
    }
}
