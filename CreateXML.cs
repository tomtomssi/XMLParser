using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
namespace ParseSpreadsheetXML
{
    class CreateXML : Parser
    {
        private string fileName = @"D:\root.xml";
        private XDocument doc;

        public CreateXML()
        {
            doc = new XDocument();
            XElement tree = new XElement("Workouts");
            List<XElement> elements = new List<XElement>();

            int offset = nodes.Count;

            for (int i = 0; i < nodes.Count; ++i)
            {
                tree.Add(
                    new XElement("Workout",
                        new XElement("Pvm", getColValue(i + offset * 4)),
                        new XElement("Movement",
                            new XElement("Name", nodes[i].Value),
                                new XElement("Sarjat", getColValue(i + offset)),
                                new XElement("Toistot", getColValue(i + offset * 2)),
                                new XElement("Painot", getColValue(i + offset * 3))))
                    );
            }

            doc.Add(tree);

            Save(doc);

            Console.WriteLine(doc + "\nXML TREE CREATED");
        }

        private void Save(XDocument tree)
        {
            doc.Save(this.fileName, SaveOptions.None);
        }
    }
}
