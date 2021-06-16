using NI_Fonakolos_játék.Model;
using NI_Fonakolos_játék;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace NI_Fonakolos_játék.ModelView
{
  
    class ScoreBoardView
    {
        public static void CreatePlayer()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("CREATE TABLE if not exists Player (ID int IDENTITY(1, 1),firstName nvarchar(50) not NULL,Score int);");
            }
        }

        public static List<Player> LoadPeople()
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
        public static void SavePlayer(Player player)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Player (firstName ,Score) values (@firstName, @Score)", player);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
