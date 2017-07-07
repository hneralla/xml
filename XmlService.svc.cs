using System.Linq;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Xsl;

namespace XmlOps
{
    public class XmlService : IXmlService
    {
        // Takes a URL for an XML document and an XML Schema document and verifies them. Returns error information.
        public string verification(string xmlUrl, string xsdUrl)
        {
            // Default output 
            string output = "No Errors"; 
            string xml;
            var set = new XmlSchemaSet();

            using (var wc = new WebClient())
            {
                try
                {
                    // Download the XML document
                    xml = wc.DownloadString(xmlUrl); 
                }
                catch (WebException e)
                {
                    return e.ToString();
                }
            }

            var xd = new XmlDocument(); 
            try
            {
                // Load XML into XmlDocument object
                xd.Load(xmlUrl);
            }
            catch (XmlException e)
            {
                return e.ToString();
            }

            var xdoc = XDocument.Load(new XmlNodeReader(xd));

            // Add schema into schema set
            set.Add(null, xsdUrl);

            // Try to validate XML document
            xdoc.Validate(set, (o, e) => 
            {
                output = e.Message;
            });

            return output;
        }

        // Takes URLs for XML and XSL documents and transforms the XML into HTML. Returns HTML in the form of a string.
        public string transformation(string xmlUrl, string xslUrl)
        {
            string xml; // to store the xml string
            string xsl; // to store the xsl string
            var htmlResult = new StringWriter(); // to store the html string
            var trans = new XslCompiledTransform(); // to transform the XML data

            using (var wc = new System.Net.WebClient())
            {
                try
                {
                    // Download XML and XSL documents
                    xml = wc.DownloadString(xmlUrl); 
                    xsl = wc.DownloadString(xslUrl); 
                }
                catch
                {
                    return "Invalid Links";
                }
            }

            // Load XSL file
            trans.Load(XmlReader.Create(new StringReader(xsl))); 

            try
            {
                try
                {
                    // Transform XML to HTML
                    trans.Transform(XmlReader.Create(new StringReader(xml)), null, htmlResult); 
                }
                catch (XmlException e)
                {
                    return e.ToString();
                }

            }
            catch (XsltException e1)
            {
                return e1.ToString(); 
            }

            return htmlResult.ToString();
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
