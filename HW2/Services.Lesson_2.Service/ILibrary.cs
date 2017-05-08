using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Services.Lesson_2.Service
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ILibrary
    {

        [OperationContract(IsInitiating = true)]
        void IntroduceYourself(int idPerson, string name);

        [OperationContract(IsTerminating = true)]
        void GoAway();

        [OperationContract(IsInitiating = false)]
        void ChooseNewBooks(List<int> ids);

        [OperationContract(IsInitiating = false)]
        void HandOverBooks(List<int> ids);

        [OperationContract(IsInitiating = false)]
        string ApplayChanges();

    }
}

/* 
Выбрать новые книги
Сдать старые книги
Завершить обслуживание (применить изменения)
 * */
