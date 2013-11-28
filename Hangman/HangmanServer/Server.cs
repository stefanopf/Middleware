using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace HangmanServer
{
    
    class Server: HangmanContract.IGamePlay, HangmanContract.IPortal
    {
        public Server() 
        {
            
        }

        public bool login(string username, string password) 
        {
            return false;
        }

        public bool register(string username, string password)
        {
            return false;
        }

        public void invitePlayers(string[] invitedPlayerNames, string username) //invites players to a game
        { 
            
        }
        
        public void acceptInvitation(bool userAccepted) 
        { 
        
        }

        public void chooseGameWord(string gameWord, string username) { }

        public void guessLetter(char letter, string username){}

        public void guessWord(string word, string username) { }

        public void timeUp(string username) { }

        public void chat(string message, string username) { }

        public void leaveGame(string username) { }
    }
}
