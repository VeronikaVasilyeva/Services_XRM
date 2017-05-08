using System.Collections.Generic;
using System.Linq;

namespace Services.Lesson_2.Service.Library.InformationStorage
{
    public class InformationStorage
    {
        private static Dictionary<Person, List<BookStorage.Book>> _libraryInfo;

        public InformationStorage()
        {
            if (_libraryInfo == null)
            {
                _libraryInfo = new Dictionary<Person, List<BookStorage.Book>>();
            }
        }

        public void AddEntry(BookStorage.Book book, Person person)
        {
            if (_libraryInfo.ContainsKey(person))
            {
                var books = _libraryInfo.Where(i => i.Key == person).Distinct().Select(i => i.Value).ToArray()[0];
                books.Add(book);
            }
            else
            {
                _libraryInfo.Add(person, new List<BookStorage.Book> { book });
            }
        }

        public void RemoveEntry(BookStorage.Book book, Person person)
        {
            if (_libraryInfo.ContainsKey(person))
            {
                var entry = _libraryInfo.Where(i => i.Key == person && i.Value.Contains(book)).ToArray()[0];
                _libraryInfo.Remove(entry.Key);
            }
        }

    }
}