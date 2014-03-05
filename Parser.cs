using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace ParseSpreadsheetXML
{
    class Parser
    {
        private XDocument root;
        private IEnumerable<XElement> elements;
        protected List<XElement> nodes;
        protected List<string> columns;


        private string rootAddress = @"D:\Painot.xml";

        public Parser()
        {
            root = XDocument.Load(rootAddress);

            nodes = new List<XElement>();
            columns = new List<string>();

            getNodes();

            for (int i = 0; i < 6; ++i)
            {
                getCol(i);
            }
        }

        private void getNodes()
        {
            elements =
                    from el in root.Descendants("ooo_row")
                    select el;

            foreach (XElement el in elements)
                nodes.Add((XElement)el.FirstNode);
        }

        private void getCol(int i)
        {
            elements = from el in root.Descendants("column_" + i) select el;

            foreach (XElement el in elements)
            {
                columns.Add(el.Value);
            }
        }

        protected string getColValue(int i)
        {
            return columns[i];
        }
    }
}
