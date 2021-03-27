using ScannerSite.entity;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanerShow.db
{
    class DBReader
    {
        private static string ConnectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=res/DBGames.mdb;";
        private static OleDbConnection myConnection;


        public static List<Game> SelectAllGames() {
            myConnection = new OleDbConnection(ConnectString);
            try { 
                myConnection.Open(); 
            }
            catch (Exception e) {
                Console.WriteLine(e); 
            }
            
            List<Game> games = new List<Game>();

            string query = "SELECT cost.cost, games.title, cost.dateCost FROM games INNER JOIN cost ON games.id = cost.idGame";
          
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                games.Add(new Game(reader[1].ToString(), double.Parse(reader[0].ToString()), DateTime.Parse(reader[2].ToString())));
            }

            reader.Close();

            myConnection.Close();

            return games;
        }
    }
}
