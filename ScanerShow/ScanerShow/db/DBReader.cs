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

        public static String findGameWithMinCost(string from, string to)
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


            string query = "SELECT top 1 Min(cost.cost) AS cost, games.title FROM cost LEFT JOIN games ON cost.idGame = games.id WHERE (((cost.[cost])>0) AND ((cost.dateCost) Between CDate('" + from + "') And CDate('" + to + "'))) GROUP BY games.title, cost.idGame ORDER BY Min(cost.cost);";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                String minCost = "Минимальная стоимость у игры: " + reader[1].ToString() + " (" + reader[0].ToString() + ")";
                reader.Close();

                myConnection.Close();

                return minCost;
            }

            return "";
        }

        public static String findGamesInDiap(string when, string from, string to) {
            myConnection = new OleDbConnection(ConnectString);
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            string query = "SELECT games.title FROM games INNER JOIN cost ON games.id = cost.idGame WHERE(((cost.cost) >= "+from+" And(cost.cost) <= "+to+")) and(cost.dateCost) >= CDate('"+when.Substring(0, 10) + " 00:00:00') and(cost.dateCost) <= CDate('" + when.Substring(0, 10) + " 23:59:59') GROUP BY games.title;";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            string result = "Результат: ";

            while (reader.Read())
            {
                result = result + reader[0].ToString() + "     ";

            }
            reader.Close();

            myConnection.Close();
            return result;
        }

        public static string getOrderListGames() {
            
            myConnection = new OleDbConnection(ConnectString);
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            string query = "SELECT games.title FROM games ORDER BY games.dateRealize;";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            string result = "Результат: ";

            while (reader.Read())
            {
                result = result + reader[0].ToString() + "     ";

            }
            reader.Close();

            myConnection.Close();
            return result;
        }

        public static String findGameWithMaxCost(string from, string to)
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

            string query = "SELECT top 1 Max(cost.cost) AS cost, games.title FROM cost LEFT JOIN games ON cost.idGame = games.id WHERE (((cost.[cost])>0) AND ((cost.dateCost) Between CDate('" + from + "') And CDate('" + to + "'))) GROUP BY games.title, cost.idGame ORDER BY Min(cost.cost);";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                String maxCost = "Максимальная стоимость у игры: " + reader[1].ToString() + " (" + reader[0].ToString() + ")";
                reader.Close();

                myConnection.Close();

                return maxCost;
            }

            return "";
        }

        public static String findGameWithAvgCost(string from, string to, Game game)
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

            List<Game> games = new List<Game>();

            string query = "SELECT  Avg(cost.cost) AS cost FROM cost LEFT JOIN games ON cost.idGame = games.id WHERE (((cost.[cost])>0) AND ((cost.dateCost) Between CDate('"+from+"') And CDate('"+to+"'))) and games.title like '"+game.Name+"'";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                String avgCost = "Средняя цена игры: " + reader[0].ToString();
                reader.Close();

                myConnection.Close();

                return avgCost;
            }

            return "";
        }

        public static int selectIdGame(string gameName)
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

            String query = $"Select id From games where title like '{gameName}'";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            try
            {
                int result = int.Parse(command.ExecuteScalar().ToString());
                myConnection.Close();
                return result;
            }
            catch (NullReferenceException e)
            {
                myConnection.Close();
                return -1;

            }

        }

    }
}
