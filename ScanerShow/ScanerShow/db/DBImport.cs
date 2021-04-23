using ScannerSite.entity;
using System;
using System.Collections.Generic;
using System.Data.OleDb;


namespace ScanerShow.db
{
    class DBImport
    {
        private static string ConnectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
        private static OleDbConnection myConnection;

        public static void importData(string path, String game) {
            string connPath = ConnectString + path + ";";
            myConnection = new OleDbConnection(connPath);
            try
            {
                myConnection.Open();
                List<Game> gamesForImport = readFromImportDB(myConnection, game);
                myConnection.Close();

                //сначала проверка
                List<Game> gamesFromCurrentDB = DBReader.SelectAllGames();

                foreach (Game imp in gamesForImport) {
                    bool costExist = false;
                    foreach (Game exist in gamesFromCurrentDB) {
                        if (exist.Date.Equals(imp.Date) && exist.Name.Equals(imp.Name)) {
                            costExist = true;
                            break;
                        }
                    }
                    //потом запись
                    if (!costExist) {
                        int idGame = DBReader.selectIdGame(imp.Name);
                        if (idGame > 0) {
                            DBWriter.insertNewCost(imp, idGame);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public static List<Game> readFromImportDB(OleDbConnection connection, string gameName) {
            string query = "SELECT cost.cost, games.title, cost.dateCost FROM games INNER JOIN cost ON games.id=cost.idGame  where games.title like '"+gameName+"'";

            List<Game> games = new List<Game>();

            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                games.Add(new Game(reader[1].ToString(), double.Parse(reader[0].ToString()), DateTime.Parse(reader[2].ToString())));
            }

            reader.Close();
            return games;
        }
    }
}
