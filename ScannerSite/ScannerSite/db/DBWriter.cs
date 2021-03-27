using ScannerSite.entity;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace ScannerSite.db
{
    class DBWriter
    {
        private static string ConnectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=res/DBGames.mdb;";
        private static OleDbConnection myConnection;
        public static void writeToDB(List<Game> listGames) {
            myConnection = new OleDbConnection(ConnectString);

            myConnection.Open();

            foreach (Game game in listGames) {
                int idGame = checkExistOrNoGameIfNoCreateIt(game.Name, game.DateRealize);
                if (idGame != -1)
                {
                    insertNewCost(idGame, game.Cost);
                }

            }

            myConnection.Close();
        }

        private static int selectIdGame(string gameName) {
            String query = $"Select id From games where title like '{gameName}'";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            try
            {
                int result = int.Parse(command.ExecuteScalar().ToString());

                return result;
            }
            catch (NullReferenceException e) {
                return -1;
            }
        }

        private static int insertNewGame(string gameName, DateTime realiz) {
            String query = $"INSERT INTO games (title, dateRealize) values ('{gameName}','{realiz}')";

            OleDbCommand command = new OleDbCommand(query, myConnection);

            return command.ExecuteNonQuery();
        }

        private static int insertNewCost(int idGame, double cost) {
            String query = $"INSERT INTO cost (dateCost,idGame,cost) values ('{DateTime.Now}',{idGame},'{cost.ToString().Replace(".",",")}')";

            OleDbCommand command = new OleDbCommand(query, myConnection);

            return command.ExecuteNonQuery();
        }

        private static int checkExistOrNoGameIfNoCreateIt(string gameName, DateTime realiz) {
            int idGame = selectIdGame(gameName);
            if (idGame == -1)
            {
                if (insertNewGame(gameName,realiz) != 0)
                {
                    idGame = selectIdGame(gameName);
                    if (idGame == -1) {
                        return -1;
                    }
                }
            }
            return idGame;
        }
    }
}
