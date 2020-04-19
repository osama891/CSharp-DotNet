using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace XMLReader
{
    class Program
    {
        private const string Url = "/Users/osamasohail/Projects/XMLReader/SEC-0000950123-09-019360.xml";

        static void Main(string[] args)
        {
      

            XElement xml =   XElement.Load(Url);
            //Console.WriteLine(xml);

           

           IEnumerable<string> risk =  from el in xml.Descendants("Section")
                                        where (string)el.Attribute("long-name") == "Risk Factors"
                                        select (string) el;
            foreach (string el in risk)
            {
                try
                {

                    //Pass the filepath and filename to the StreamWriter Constructor
                    StreamWriter sw = new StreamWriter("Test.txt");

                    //Write a line of text
                    sw.Write(el);

                    //Close the file
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }

        }
    }
}
