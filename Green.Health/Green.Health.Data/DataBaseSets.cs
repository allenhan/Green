using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Green.Health.Data
{
    public class DataBaseManager
    {
        private string provider = "";
        private string connectString = "";
        private DataBaseSet dataBaseSet = null;
        private XmlDocument document = null;

        public string Provider
        {
            set { this.provider = value; }
            get { return this.provider; }
        }

        public string ConnectString {
            get { return this.connectString; }
            set { this.connectString = value; }
        }

        public DataBaseManager(string dbname)
        {
            document = new XmlDocument();
            document.LoadXml("");
            XmlNodeList nodes = document.SelectNodes("");
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["name"].Value == dbname)
                {
                    dataBaseSet = new DataBaseSet();
                    provider = node.Attributes["provider"].Value;
                    XmlNodeList childNodes = node.ChildNodes;
                    foreach (XmlNode childNode in childNodes)
                    {
                        
                    }
                }
            }
        }

        public DataBaseSet GetDataBaseSet()
        {
            return dataBaseSet;
        }
    }

    public class DataBaseSet
    {
        public string Provider { get; set; }

        public string Name { get; set; }

        public List<DBItem> DBItems { get; set; }
    }

    public class DBItem
    {
        public string Name { get; set; }

        public string DataBaseType { get; set; }

        public string ConnectString { get; set; }
    }

}
