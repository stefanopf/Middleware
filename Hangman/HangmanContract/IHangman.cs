using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace HangmanContract
{
    [ServiceContract(Namespace = "HangmanContract", CallbackContract = typeof(IHangmanCallBack))]
    public interface IHangman
    {
        [OperationContract]
        bool login(string username, string password);

        [OperationContract]
        bool register(string username, string password);

        [OperationContract(IsOneWay = true)]
        void invitePlayers(string[] invitedPlayerNames, string username); //invites players to a game

        [OperationContract(IsOneWay = true)]
        void acceptInvitation(bool userAccepted);

        [OperationContract(IsOneWay = true)]
        void chooseGameWord(string gameWord, string username);

        [OperationContract(IsOneWay = true)]
        void guessLetter(string letter, string username);

        [OperationContract(IsOneWay = true)]
        void guessWord(string word, string username);

        [OperationContract(IsOneWay = true)]
        void timeUp(string username);

        [OperationContract(IsOneWay = true)]
        void chat(string message, string username);

        [OperationContract(IsOneWay = true)]
        void leaveGame(string username);
    }

    public interface IHangmanCallBack
    {
        [OperationContract(IsOneWay = true)]
        void startNewGame(string[] guessers, string wordPicker, int[] wordRange);

        [OperationContract(IsOneWay = true)]
        void setWordLength(int length);

        [OperationContract(IsOneWay = true)]
        void updatePlayersList(string[] players, int[] stats);

        [OperationContract(IsOneWay = true)]
        void receiveResult(string guess, bool isRight, int[] positions); //receives the result of a guess

        [OperationContract(IsOneWay = true)]
        void endGame(string[] winners, string gameWord);

        [OperationContract(IsOneWay = true)]
        void receiveMessage(string message);

        [OperationContract(IsOneWay = true)]
        void receiveInvitation(string inviter, int invitees);
    }
}
