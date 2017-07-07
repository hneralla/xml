using System.Collections.Generic;
using System.Linq;

namespace XmlOps
{
    public class XmlService : IXmlService
    {
        // Takes a URL for an XML document and an XML Schema document and verifies them. Returns error information.
        public string verification(string xmlUrl, string xsdUrl)
        {
            string output = " "; // default output 

            return output;
        }

        // Takes URLs for XML and XSL documents and transforms the XML into HTML. Returns HTML in the form of a string.
        public string transformation(string xmlUrl, string xslUrl)
        {
            string output = " "; // default output

            return output;
        }

        // Takes a URL and returns the node's content information related to the key.
        public string[] search(string xmlUrl, string key)
        {
            List<string> output = new List<string>(); // default output

            return output.ToArray<string>();
        }

        // Returns the path expression value of the given path.
        public string XPathSearch(string xmlUrl, string path)
        {
            string output = " "; // default output

            return output;
        }
    }
}
