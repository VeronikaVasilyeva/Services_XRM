using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using Services.Lesson_3.Service.Library.InformationStorage;

namespace Services.Lesson_3.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class LibraryFacade : ILibrary
    {
        private List<int> _handOverBooks = new List<int>();
        private List<int> _choosedBooks = new List<int>();
        private Person _currentPerson;
        private readonly Library.Library _library = new Library.Library();

        public void IntroduceYourself(int idPerson, string name)
        {
            _currentPerson = new Person
            {
                Id = idPerson,
                Name = name
            };
            Console.WriteLine("Person " + name + " SessionId " + OperationContext.Current.SessionId);
        }

        public void GoAway()
        {
            _currentPerson = null;
            _choosedBooks = null;
            _handOverBooks = null;
            Console.WriteLine("The person with sessionId " + OperationContext.Current.SessionId +
                              " go away from library");
        }

        public void ChooseNewBooks(List<int> ids)
        {
            _choosedBooks.AddRange(ids);
        }

        public void HandOverBooks(List<int> ids)
        {
            _handOverBooks.AddRange(ids);
            ;
        }

        public string ApplayChanges()
        {
            if (_handOverBooks != null)
            {
                foreach (int i in _handOverBooks)
                {
                    _library.ReturnBook(i, _currentPerson.Id);
                }
            }

            if (_choosedBooks.Count > 5) return "Вы привысили лимит, не более 5 книг";

            foreach (int i in _choosedBooks)
            {
                _library.GiveBook(i, _currentPerson.Id);
            }

            return "Операции успешно применены";
        }
    }
}