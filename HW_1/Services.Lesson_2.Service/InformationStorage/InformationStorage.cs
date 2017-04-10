using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Services.Lesson_2.Service
{
    public class InformationStorage
    {
        private static Dictionary<Person, List<Book>> _libraryInfo;

        public InformationStorage()
        {
            if (_libraryInfo == null) {
                _libraryInfo = new Dictionary<Person, List<Book>>();
            }

        }

        public void AddEntry(Book book, Person person) {
            if (_libraryInfo.ContainsKey(person))
            {
                var books = _libraryInfo.Where(i => i.Key == person).Distinct().Select(i => i.Value).ToArray()[0];
                books.Add(book);
            }
            else
            {
                _libraryInfo.Add(person, new List<Book> { book });
            }
        }

        public void RemoveEntry(Book book, Person person) {
            if (_libraryInfo.ContainsKey(person))
            {
                var entry = _libraryInfo.Where(i => i.Key == person && i.Value.Contains(book)).ToArray()[0];
                _libraryInfo.Remove(entry.Key);
            }
        }

    }
}