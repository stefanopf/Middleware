using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace HangmanContract
{
    [ServiceContract(Namespace = "HangmanContract")]
    interface IGamePlay
    {
        [OperationContract]
        void chooseGameWord(string gameWord, string username);

        [OperationContract]
        void guessLetter(char letter, string username);

        [OperationContract]
        void guessWord(string word, string username);

        [OperationContract]
        void timeUp(string username);

        [OperationContract]
        void chat(string message, string username);

        [OperationContract]
        void leaveGame(string username);
    }
}
