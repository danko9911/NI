using NI_Fonakolos_játék.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
//using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NI_Fonakolos_játék.ModelView
{
    class ScoreBoardView
    {
       /* public static List<Player> LoadPeople()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Player>("select * from Player", new DynamicParameters());
                return output.ToList();
            }
        }


        /// <summary>
        /// Saving the Person to the database.
        /// </summary>
        /// <param name="player"></param>
        public static void SavePerson(Player player)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Person (firstName , lastName,time,bestScore) values (@firstName, @lastName, @time, @bestScore)", player);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }*/
    }
}
