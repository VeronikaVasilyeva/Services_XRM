using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Lesson_6.Models;

namespace Services.Lesson_6.Warehouse
{
    public class EntryWh
    {
        public readonly List<Entry> _entries = new List<Entry>();

        public object GiveBook(int idBook, int idPerson)
        {
            var books = _entries.FindAll(i => i.IdPerson == idPerson);

            if (books.Count > 5) return "Много книг берешь";
            if (books.Find(i => i.BeginDate.Month > DateTime.Now.Month) != null) return "Ты должник!";

            _entries.Add(
                new Entry
                {
                    Id = _entries.Count,
                    IdBook = idBook,
                    IdPerson = idPerson,
                    BeginDate = DateTime.Now
                });

            return "Ok";
        }

        public void ReturnBook(int idBook, int idPerson)
        {
            var entry = _entries.Find(i => i.IdBook == idBook && i.IdPerson == idPerson);
            _entries.Remove(entry);
        }
    }


    public class Entry
    {
        public int Id { get; set; }
        public int IdBook { get; set; }
        public int IdPerson { get; set; }

        public DateTime BeginDate { get; set; }

    }
}
