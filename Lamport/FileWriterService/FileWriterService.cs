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
       
        void IService.WriteToFile(int pid, string value)
        {
            try
            {
                Console.WriteLine("start  thread " + pid);

                Lock(pid);

                byte[] buffer = Encoding.ASCII.GetBytes(value);

                using (var fs2 = new FileStream(Path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite, 1, FileOptions.WriteThrough))
                {
                    foreach (byte b in buffer)
                    {
                        fs2.WriteByte(b);
                        fs2.Flush();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
               Console.WriteLine("Before end: " + pid);
               Unlock(pid);
               Console.WriteLine("unlocked: " + pid);
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

                while (_number[j] != 0 && Compare(j, id)) // Ждём пока потоки с меньшим номером или с таким же номером, 
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
            }
        }
    }
}