using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace FileWriterService
{
    //[ServiceContract(SessionMode = SessionMode.Required)]
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void WriteToFile(int pid, string value);

    }
}
