using System;
using System.Xml;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument document = new XmlDocument();
            document.Load("TelephoneBook.xml");

            Console.WriteLine("Content TelephoneBook.xml: ");
            Console.WriteLine(document.InnerXml);
        }
    }
}
