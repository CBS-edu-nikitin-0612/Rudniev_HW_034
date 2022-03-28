using System;
using System.Xml;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new XmlTextReader("TelephoneBook.xml");

            Console.WriteLine("Telephone numbers: ");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("Contact"))
                    {
                        Console.WriteLine(reader.GetAttribute("TelephoneNumber"));
                    }
                }
            }
        }
    }
}
