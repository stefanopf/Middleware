using HangmanContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace HangmanServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]   
    class Server: HangmanContract.IHangman
    {
        private delegate void listChanged(string[] players, string[] correctGuesses, string[] totalGuesses);
        private event listChanged listHasChanged;

        private IHangmanCallBack player;
        private static List<Player> listOfPlayers;//this is our database
        private static List<Invitation> listOfInvitations = new List<Invitation>();
        private static List<Game> listOfGame = new List<Game>();
        private string[] gameWords = { "CAT", "TABLE", "ELEPHANT", "BICYCLE", "UMBRELLA", "FONTYS" };
        private string gameWord, playerName;
        private int attemptsLeft = 10;
        private decimal count = 0;

        public Server() 
        {
            if(listOfPlayers==null)
                listOfPlayers = new List<Player>();
        }

        public void login(string username, string password) 
        {
            IHangmanCallBack context = (IHangmanCallBack)OperationContext.Current.GetCallbackChannel<IHangmanCallBack>();
            try
            {
                Player player = listOfPlayers.Find(p => p.Username.ToLower() == username.ToLower() && p.Password == password);//tries to find a player whose name and password match
                player.Context = context;
                player.IsOnline = true;
                string [] usernames = ((List<string>)getOnlinePlayersList()[0]).ToArray();
                string [] totalGuesses = getOnlinePlayersList()[1].ToArray();
                string[] correctGuesses = getOnlinePlayersList()[2].ToArray();

                player.Context.loginConfirmation(true);

                listHasChanged += player.Context.updatePlayersList;
                listHasChanged( usernames, correctGuesses, totalGuesses);

                //return new object[] { usernames, totalGuesses, correctGuesses };
            }
            catch
            {
                context.loginConfirmation(false);
            }
        }

        public void logout(string username)
        {
            try
            {
                Player player = listOfPlayers.Find(p => p.Username.ToLower() == username.ToLower());//tries to find a player whose name matches
                player.IsOnline = false;
                string[] usernames = ((List<string>)getOnlinePlayersList()[0]).ToArray();
                string[] totalGuesses = getOnlinePlayersList()[1].ToArray();
                string[] correctGuesses = getOnlinePlayersList()[2].ToArray();

                listHasChanged -= player.Context.updatePlayersList;
                listHasChanged(usernames, correctGuesses, totalGuesses);

                //return new object[] { usernames, totalGuesses, correctGuesses };
            }
            catch
            {
                Console.WriteLine("Problems logging out \""+username+"\".");
            }
        }

        public bool register(string username, string password)
        {
            try
            {
                if (listOfPlayers.Find(p => p.Username.ToLower() == username.ToLower()) == null) //if couldnt find player whose name is "username"
                {
                    listOfPlayers.Add(new Player(username, password));
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public void invitePlayers(string[] invitedPlayerNames, string username) //invites players to a game
        {
            List<Player> invitedPlayers = new List<Player>();
            Player inviter = listOfPlayers.Find(p => p.Username.ToLower() == username.ToLower());
            for (int i = 0; i < invitedPlayerNames.Count<string>(); i++)
            {
                try
                {
                    invitedPlayers.Add(listOfPlayers.Find(p => p.Username.ToLower() == invitedPlayerNames[i].ToLower()));
                }
                catch
                {
                }
            }
            listOfInvitations.Add(new Invitation(invitedPlayers,inviter,count, 15000));
            count++;
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

        public void leaveGame(string username) 
        {
            try//tries to find a player whose name matches
            {
                Player player = listOfPlayers.Find(p => p.Username == username);
                player.Game = null;
                player.Invitation = null;
                player.Context = null;
                player.IsOnline = false;
            }
            catch
            {
                Console.WriteLine("Problems logging out \""+username+"\"");
            }
        }

        public static List<List<string>> getOnlinePlayersList()
        {
            List<string> userNames = new List<string>();//0 = username
            List<string> totalGuesses = new List<string>();//1 = total guesses
            List<string> correctGuesses = new List<string>();//2 = correct guesses
            List<string> gameIDs = new List<string>();
            List<List<string>> returnList = new List<List<string>>();

            foreach (Player p in listOfPlayers)
            {
                if (p.IsOnline)
                {
                    userNames.Add(p.Username);
                    totalGuesses.Add(p.TotalGuesses.ToString());
                    correctGuesses.Add(p.CorrectGuesses.ToString());
                    if (p.Game != null)
                        gameIDs.Add(p.Game.Id.ToString());
                    else
                        gameIDs.Add("-");
                }
            }
            returnList.Add(userNames);
            returnList.Add(totalGuesses);
            returnList.Add(correctGuesses);
            returnList.Add(gameIDs);

            return returnList;
        }

    }
}
