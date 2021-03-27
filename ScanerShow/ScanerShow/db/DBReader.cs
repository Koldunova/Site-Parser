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

            List<Game> games = new List<Game>();

            string query = "SELECT top 1 Min(cost.cost) AS cost, games.title FROM cost LEFT JOIN games ON cost.idGame = games.id WHERE (((cost.[cost])>0) AND ((cost.dateCost) Between CDate('" + from + "') And CDate('" + to + "'))) GROUP BY games.title, cost.idGame ORDER BY Min(cost.cost);";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                String minCost = "Минимальная стоимость у игры: " + reader[1].ToString() + " (" + reader[0].ToString() + ")";
                games.Add(new Game(reader[1].ToString(), double.Parse(reader[0].ToString()), DateTime.Parse(reader[2].ToString())));
                reader.Close();

                myConnection.Close();

                return minCost;
            }

            return "";
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

            List<Game> games = new List<Game>();

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
    }
}
