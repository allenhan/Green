using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Green.Utility
{
    public class XmlHelper
    {
        private XmlDocument document;

        public XmlHelper(string filename)
        {
            document = new XmlDocument();
            try
            {
                document.LoadXml(filename);
            }
            catch (Exception ex)
            {
                
            }
        }

        public string GetAttributeValue(string rootPath,string name)
        {
            XmlNode node = document.SelectSingleNode(rootPath);

            return node.InnerXml;
        }
    }
}
