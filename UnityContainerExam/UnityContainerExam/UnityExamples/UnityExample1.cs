using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Linq;
namespace UnityContainerExam.UnityExamples
{
    [TestClass]
    public class UnityExample1
    {
        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine(ConfigurationManager.AppSettings["yusoof"]);
        }

        public XDocument GetDocumentContext()
        {
            //Console.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RuntimeConfig.xml"));
            //Console.WriteLine(File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RuntimeConfig.xml")));
            XmlReader reader = XmlReader.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RuntimeConfig.xml"));
            XDocument document = XDocument.Load(reader);
            return document;
        }

        [TestMethod]
        public void LinqExample1()
        {           
            XDocument document = GetDocumentContext();
            var items1 = document.Root.Elements().Where(
                element => element.HasAttributes == true).Select(item1 => item1.Name.LocalName);

            var items = from element in document.Root.Elements()
                        where element.HasAttributes == true
                        select element;
            var tagElements = from element in document.Root.Elements()
                              select element;

            var tagElement = document.Root.Elements().Where((digit, index) => index == 1);


            var indexElement = from element in document.Root.Elements()
                               select element;
            Console.WriteLine(indexElement.First().Name.LocalName);
            foreach(var tag in tagElements){
                Console.WriteLine(tag.Name);
            }
            Console.WriteLine("------------------------------------------------");
            foreach (var item in items)
            {
                Console.WriteLine(item.Name.LocalName);
            }
            
        }
        [TestMethod]
        public void ProjectionMethod1()
        {
            XDocument document = GetDocumentContext();
            var items1 = from element in document.Root.Elements()
                         select element.Name.LocalName + " yusoof concat";
            foreach (var item12 in items1)
            {
                Console.WriteLine(item12.ToString());
            }
        }

        [TestMethod]
        public void ProjectionMethod2()
        {
            XDocument document = GetDocumentContext();
            var AttributeElements = from element in document.Root.Elements()
                         where element.HasAttributes == false
                             select element;
            var ConfigElements = AttributeElements.Elements().Where(it => it.Name.LocalName == "ConfigImports");

            var ConditionalElement = from ConfigElement in ConfigElements
                                 select ConfigElement.Attributes();

            var Attributes1 = from attribute in ConditionalElement
                              from names in attribute
                              select names.Name.LocalName;

        }
    }
}
