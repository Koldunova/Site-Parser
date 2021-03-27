using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ScanerShow.xml
{
    class MyXMLWriter
    {
        public static void WriteNewGame(string game) {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("res//config.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlElement gameEl = xDoc.CreateElement("game");
            XmlText gameText = xDoc.CreateTextNode(game);

            gameEl.AppendChild(gameText);
            xRoot.AppendChild(gameEl);

            xDoc.Save("res//config.xml");
        }

        public static void DeleteGame(string game) {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("res//config.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlNode forRemoute = null;

            foreach (XmlNode node in xRoot.ChildNodes)
            {
                if (node.Name == "game" && node.InnerText.Equals(game))
                {
                    forRemoute = node;
                }
            }

            if (forRemoute != null)
            {
                xRoot.RemoveChild(forRemoute);
            }
            xDoc.Save("res//config.xml");
        }
    }
}
