using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LoowooTech.LEDController.Server.API
{
    [ServiceContract]
    public interface IAPIService
    {
        [OperationContract]
        bool ShowText(string clientId, string content);

        [OperationContract]
        string DownloadConfig(string clientId);
    }
}
