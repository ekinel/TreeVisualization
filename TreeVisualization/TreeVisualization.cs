using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace TestApp
{
    class TreeVisualization
    {
        private XmlDocument _xmlDocument;

        public TreeVisualization()
        {
        }

        public TreeVisualization(string url)
        {
            DownloadXmlDocument(url);
            OpenXmlDocument();
            DisplayXmlTree();
            DeleteXmlDocument();
        }

        public XmlDocument Document
        {
            get => _xmlDocument;
            private set => _xmlDocument = value;
        }

        public void DownloadXmlDocument(string url)
        {
            var xDoc = XDocument.Load(url);
            xDoc.Save("url.xml");
        }

        public void OpenXmlDocument()
        {
            _xmlDocument = new XmlDocument();

            if (File.Exists("url.xml"))
            {
                _xmlDocument.Load("url.xml");
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public void DisplayXmlTree()
        {
            var rootTree = _xmlDocument.DocumentElement;
            ParseNode(rootTree, 0);
        }

        public void DeleteXmlDocument()
        {
            if (File.Exists("url.xml"))
            {
                File.Delete("url.xml");
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        ~TreeVisualization()
        {
        }

        private static void ParseNode(XmlNode root, int position)
        {
            StringBuilder tabulationString = new StringBuilder();

            for (int i = 0; i < position; i++)
            {
                tabulationString.Append("\t");
            }

            if (root.Attributes != null)
            {
                Console.WriteLine(tabulationString.ToString() + root.Name);
                Console.WriteLine(tabulationString.ToString() + "< params: ");

                foreach (XmlNode attribute in root.Attributes)
                {
                    Console.WriteLine(tabulationString.ToString() + attribute.Name + " - " + attribute.InnerText);
                }

                Console.WriteLine(tabulationString.ToString() + ">");
            }

            if (root.ChildNodes.Count < 1)
                return;

            foreach (XmlNode childnode in root.ChildNodes)
                ParseNode(childnode, position + 1);
        }
    }
}