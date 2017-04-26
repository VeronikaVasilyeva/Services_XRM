using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace FileWriterService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class FileWriterService : IService
    {
        private static readonly string path = "..\\general.txt";
        
        void IService.WriteToFile(int thread, string value)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(value);
            }
            Console.WriteLine(value);
        }
    }
}