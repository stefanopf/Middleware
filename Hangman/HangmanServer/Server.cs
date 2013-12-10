using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace HangmanServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]   
    class Server: HangmanContract.IHangman
    {
        private HangmanContract.IHangmanCallBack player;
        private string[] gameWords = { "CAT", "TABLE", "ELEPHANT", "BICYCLE", "UMBRELLA", "FONTYS" };
        private string gameWord;
        private int attemptsLeft = 10;


        public Server() 
        {
            
        }

        public bool login(string username, string password) 
        {
            return ServerInfo.checkLoginInfo(username, password);
        }

        public bool register(string username, string password)
        {
            return ServerInfo.registerPlayer(username, password);
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

            if (attemptsLeft == 0)
            {
                player.endGame(new string[] { "Computer" }, gameWord);
            }
            else 
            {
                player.receiveResult(letter, isRight, pos.ToArray());
            }
        }

        public void guessWord(string word, string username) 
        {
            if (word == gameWord)
            {
                player.receiveResult(word, true, null);
                player.endGame(new string[] { username }, gameWord);
            }
            else
                player.receiveResult(word, false, null);
        }

        public void timeUp(string username) { }

        public void chat(string message, string username) { }

        public void leaveGame(string username) { }
    }
}
