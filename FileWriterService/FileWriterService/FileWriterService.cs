using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Web.UI.WebControls;

namespace FileWriterService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class FileWriterService : IService
    {
        private const string Path = "..\\general.txt";
        
        private readonly List<bool> _entering = new List<bool>();
        private readonly List<int> _number = new List<int>();

        private static readonly int _maxUsers = 40;
        private int _maxValue = 0;

        List<string> _buf = new List<string>();
        
        void IService.WriteToFile(int pid, string value)
        {
            try
            {
               // Lock(pid);

                Console.WriteLine("start  thread " + pid);
                byte[] buffer = Encoding.ASCII.GetBytes(value);
                //fs.Write(buffer, 0, buffer.Length);

                foreach (byte b in buffer)
                {
                    using (FileStream fs = File.Open(Path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {

                        fs.WriteByte(b);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
               // Unlock(pid);
            }
        }

        void Lock(int id) //в секцию входит поток с идентификатором id
        {
            _entering[id] = true; //отмечаем, что поток вошел в КС
            _number[id] = ++_maxValue; //выдаем номерок потоку
            _entering[id] = false; //сделано, чтобы предыдущее дейстие было атомарно, на случай если было два потока с одним номерком

            for (var j = 0; j < _maxUsers; j++) // блочим тут всех остальных
            {
                while (_entering[j]) //ждем пока поток j получит свой номерок. 
                {
                    Thread.Yield(); //переключаемся на другой поток
                } 

                while (_number[j] != 0 && Compare(j, id)) // Ждём пока все потоки с меньшим номером или с таким же номером, 
                                                           // но с более высоким приоритетом, закончат свою работу
                {
                    Thread.Yield(); //переключаемся на другой поток
                } 
            }
        }

        void Unlock(int id) //удаление потока из очереди
        {
            _number[id] = 0;
        }

        private bool Compare(int j, int i)
        {
            return _number[j] < _number[i] || (_number[j] == _number[i] && j < i);
        }

        public void InitializeCollections()
        {
            for (var j = 0; j < _maxUsers; j++)
            {
                _number.Add(0);
                _entering.Add(false);
                _buf.Add("");
            }
        }
    }
}