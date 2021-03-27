using ScannerSite.entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ScannerSite
{
    class MyXMLReader
    {
        public static List<Game> readXMLConfig() {
            List<Game> games = new List<Game>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("res//config.xml");

            XmlElement xRoot = xDoc.DocumentElement;


            foreach (XmlNode node in xRoot.ChildNodes)
            {
                if (node.Name == "game")
                {
                    games.Add(new Game(node.InnerText));
                }
            }

            return games;
        }
    }
}
