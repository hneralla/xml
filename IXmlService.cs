using System.ServiceModel;
using System.ServiceModel.Web;

namespace XmlOps
{
    [ServiceContract]
    public interface IXmlService
    {
        // Takes a URL for XML validation
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        string verification(string xmlUrl, string xslUrl); 

        // Transforms the XML to HTML using the XSL
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        string transformation(string xmlUrl, string xslUrl); 

        // Takes a URL and returns the node's content information related to the key.
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        string[] search(string xmlUrl, string key); 

        // Returns the path expression value of the given path.
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        string XPathSearch(string xmlUrl, string path); 
    }
}
