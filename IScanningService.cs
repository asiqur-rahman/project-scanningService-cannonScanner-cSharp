using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ScannerService
{
    [ServiceContract]
    public interface IScanningService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/scan", ResponseFormat = WebMessageFormat.Json)]
        string Scan();
    }
}
