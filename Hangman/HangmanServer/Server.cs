using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace HangmanServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]   
    class Server: HangmanContract.IHangman
    {
        private HangmanContract.IHangmanCallBack player;
        private string[] gameWords = { "CAT", "TABLE", "ELEPHANT", "BICYCLE", "UMBRELLA", "FONTYS" };
        private string gameWord;
        int attemptsLeft = 10;

        public Server() 
        {
            
        }

        public bool login(string username, string password) 
        {
            ServerInfo.playersList.Add(username);
            return false;
        }

        public bool register(string username, string password)
        {
            return false;
        }

        public void invitePlayers(string[] invitedPlayerNames, string username) //invites players to a game
        {
            player = OperationContext.Current.GetCallbackChannel<HangmanContract.IHangmanCallBack>();
            player.startNewGame(null, null, null);
            gameWord = gameWords[new Random().Next(0, 5)];
            attemptsLeft = 10;
            player.setWordLength(gameWord.Length);
        }
        
        public void acceptInvitation(bool userAccepted) 
        { 
        
        }

        public void chooseGameWord(string gameWord, string username) { }

        public void guessLetter(string letter, string username)
        {
            char c = letter.ToCharArray()[0]; //gets first char of the string
            List<int> pos = new List<int>();
            bool isRight = false;

            if(gameWord.Contains(letter.ToCharArray()[0]))
            {
                for (int i = 0; i < gameWord.Length; i++) 
                {
                    if (gameWord[i] == c)
                    {
                        pos.Add(i);
                        
                    }
                }
                isRight = true;
            }

            if (!isRight)
                attemptsLeft--;

            player.getResult(letter, isRight, pos.ToArray());

            if(attemptsLeft==0)            
            {
                string[] gameResults = {"You have lost", gameWord };
                player.endGame(gameResults);
            }
        }

        public void guessWord(string word, string username) { }

        public void timeUp(string username) { }

        public void chat(string message, string username) { }

        public void leaveGame(string username) { }
    }
}
