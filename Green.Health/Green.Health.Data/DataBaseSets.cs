using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Web;

namespace Green.Health.Data
{
    public class DataBaseManager
    {
        private string provider = "";
        private string connectString = "";
        private DataBaseSet dataBaseSet = null;
        private XmlDocument document = null;
        private string dalfile = "";

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
            try
            {
#if Release
                dalfile = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,"Config","dal.xml");
#endif
                dalfile =Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,"Config","dal.xml");

                document = new XmlDocument();
                document.Load(dalfile);
                XmlNodeList nodes = document.SelectNodes("//dal//databaseSets//databaseSet");
                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes["name"].Value == dbname)
                    {
                        dataBaseSet = new DataBaseSet();
                        dataBaseSet.DBItems = new List<DBItem>();
                        provider = node.Attributes["provider"].Value;
                        dataBaseSet.Provider = provider;
                        XmlNodeList childNodes = node.ChildNodes;
                        DBItem item = null;
                        foreach (XmlNode childNode in childNodes)
                        {
                            item = new DBItem();
                            item.ConnectString = childNode.Attributes["connectionString"].Value;
                            item.DataBaseType = childNode.Attributes["databaseType"].Value;
                            item.Name = childNode.Attributes["name"].Value;
                            dataBaseSet.DBItems.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally 
            {

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
