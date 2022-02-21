using System;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.CreateXmlFile();
        }
        public void CreateXmlFile()
        {
            XmlDocument xmlDoc = new XmlDocument();
            //创建类型声明节点  
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmlDoc.AppendChild(node);
            //创建根节点  
            XmlNode root = xmlDoc.CreateElement("foods");
            xmlDoc.AppendChild(root);
            List<string> meat = new List<string> { "瘦肉", "牛肉", "鸡肉" };
            List<string> zhushi = new List<string> { "粥", "煲仔饭", "肠粉" };
            for (int i = 1; i < 10; i++)
            {
                int m = i % 3;
                int z = (i - 1) / 3;
                XmlNode node1 = xmlDoc.CreateNode(XmlNodeType.Element, "food", null);
                CreateNode(xmlDoc, node1, "number", (i + 1).ToString());
                CreateNode(xmlDoc, node1, "name", meat[m] + zhushi[z]);
                CreateNode(xmlDoc, node1, "classname", zhushi[z]);
                root.AppendChild(node1);
            }
            try
            {
                xmlDoc.Save("D://Development//SimpleMvvmDemo.Client//SimpleMvvmDemo.Client//DishesClassification.xml");
            }
            catch (Exception e)
            {
                //显示错误信息  
                Console.WriteLine(e.Message);
            }
            //Console.ReadLine();  

        }

        /// <summary>    
        /// 创建节点    
        /// </summary>    
        /// <param name="xmldoc"></param>  xml文档  
        /// <param name="parentnode"></param>父节点    
        /// <param name="name"></param>  节点名  
        /// <param name="value"></param>  节点值  
        ///   
        public void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            parentNode.AppendChild(node);
        }
    }
}
