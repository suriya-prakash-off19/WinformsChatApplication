using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ChatApplication
{
    public enum MessageType
    {
        Send,
        Receive
    }
    static class DataManager
    {
        static DataManager()
        {
            FilePath = "FileData.xml";
            try
            {
                LoadXml();
            }
            catch(Exception ex)
            {
                CreateXML();
                MessageBox.Show(ex.Message);
            }
        }

        private static void LoadXml()
        {
            xmlDocument = new XmlDocument();
            xmlDocument.Load(FilePath);
        }

        private static void CreateXML()
        {
            xmlDocument = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDocument.AppendChild(xmlDeclaration);
            XmlElement messageElement = xmlDocument.CreateElement("Message");
            xmlDocument.AppendChild(messageElement);
            xmlDocument.Save(FilePath);
        }
        private static string FilePath;
        private static XmlDocument xmlDocument;

        public static void SetData(string ip,string Message,MessageType type)
        {
            string s;
            if (type == MessageType.Send)
            {
                s = "{}S[]" + Message;
            }
            else
            {
                s = "{}R[]" + Message;
            }
            try
            {
                XmlNode xmlElement = xmlDocument.SelectSingleNode("Message")["C"+ip];
                xmlElement.InnerText += s;
            }
            catch (Exception ex)
            {   
                XmlNode xmlElement = xmlDocument.SelectSingleNode("Message");
                XmlNode temp = xmlDocument.CreateElement("C" + ip);
                temp.InnerText = s;
                xmlElement.AppendChild(temp);
                xmlDocument.Save(FilePath);
            }
        }


        public static string GetData(string ip)
        {
            try
            {
                XmlElement root = xmlDocument.DocumentElement;
                string val;
                val=root.SelectSingleNode("Message").SelectSingleNode("C" + ip).InnerText;
                return val;
                
            }
            catch (Exception ex)
            {

                return "";
            }
        }



    }

    public class MessageAddress
    {
        public static string IP;
        public static string Message;
    }
}
