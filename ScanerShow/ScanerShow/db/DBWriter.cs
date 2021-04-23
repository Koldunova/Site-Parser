using ScannerSite.entity;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanerShow.db
{
    class DBWriter
    {
        private static string ConnectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=res/DBGames.mdb;";
        private static OleDbConnection myConnection;

        public static void deleteCostsIfGame(Game game, string from, string to) {
            myConnection = new OleDbConnection(ConnectString);
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            string query = "delete * from cost where idGame= (Select id from games where title like '" + game.Name + "')and ( dateCost  between Cdate('"+from+"') and  Cdate('"+to+"') )";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();

            myConnection.Close();
        }

        public static void insertNewCost(Game game, int id)
        {

            myConnection = new OleDbConnection(ConnectString);
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            String query = $"INSERT INTO cost (dateCost,idGame,cost) values ('{game.Date}',{id},'{game.Cost.ToString().Replace(".", ",")}')";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            myConnection.Close();
             
        }
    }
}
