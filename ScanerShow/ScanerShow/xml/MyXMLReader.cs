using ScannerSite.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ScanerShow.xml
{
    class MyXMLReader
    {
        public static List<Game> readXMLConfig()
        {
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
