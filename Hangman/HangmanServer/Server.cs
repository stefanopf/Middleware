using HangmanContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace HangmanServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]   
    public class Server: HangmanContract.IHangman
    {
        private delegate void listChanged(string[] players, string[] correctGuesses, string[] totalGuesses);
        private event listChanged listHasChanged;

        private static List<Player> _listOfPlayers;//this is our database
        private static List<Invitation> _listOfInvitations = new List<Invitation>();
        private static List<Game> _listOfGames = new List<Game>();
       // private string[] gameWords = { "CAT", "TABLE", "ELEPHANT", "BICYCLE", "UMBRELLA", "FONTYS" };
        private int count = 0, invitationTimeOut = 20000;

        public List<Game> ListOfGames 
        {
            get { return _listOfGames; } 
        }

        public List<Invitation> ListOfInvitations
        {
            get { return _listOfInvitations; }
        }

        public Server() 
        {
            loadDatabase();

            if(_listOfPlayers==null)
                _listOfPlayers = new List<Player>();
        }

        public void login(string username, string password) 
        {
            IHangmanCallBack context = (IHangmanCallBack)OperationContext.Current.GetCallbackChannel<IHangmanCallBack>();
            Player player=null;
            try
            {
                player = _listOfPlayers.Find(p => p.Username.ToLower() == username.ToLower() && p.Password == password);//tries to find a player whose name and password match
                player.Context = context;
                player.IsOnline = true;
                player.Game = null;
                player.Invitation = null;
                player.Context.loginConfirmation(true);
                listHasChanged += player.Context.updatePlayersList;
                updatePortalList();
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
                Player player = _listOfPlayers.Find(p => p.Username.ToLower() == username.ToLower());//tries to find a player whose name matches
                player.IsOnline = false;
                player.Context = null;
                string[] usernames = ((List<string>)getAvailablePlayersList()[0]).ToArray();
                string[] totalGuesses = getOnlinePlayersList()[1].ToArray();
                string[] correctGuesses = getOnlinePlayersList()[2].ToArray();

                if (player.Invitation != null)//if player was in a game invitation, declines invitation
                    acceptInvitation(player.Username, false, player.Invitation.Id);

                if (player.Game != null)//if player was in a game invitation, takes player out of the game
                    leaveGame(player.Username, player.Game.Id);

                listHasChanged -= player.Context.updatePlayersList;
                listHasChanged(usernames, correctGuesses, totalGuesses);

                //return new object[] { usernames, totalGuesses, correctGuesses };
            }
            catch
            {
                Console.WriteLine("Problems logging out \""+username+"\".");
            }
        }

        public void register(string username, string password)
        {
            try
            {
                IHangmanCallBack context = (IHangmanCallBack)OperationContext.Current.GetCallbackChannel<IHangmanCallBack>();
                if (_listOfPlayers.Find(p => p.Username.ToLower() == username.ToLower()) == null) //if couldnt find player whose name is "username"
                {
                    _listOfPlayers.Add(new Player(username, password));
                    context.registrationConfirmation(true);
                }
                else
                {
                    context.registrationConfirmation(false);
                }
            }
            catch
            {
                Console.WriteLine("Problems trying to register player \"" + username + "\"");
            }
        }

        public void invitePlayers(string[] invitedPlayerNames, string username) //invites players to a game
        {
            List<Player> invitedPlayers = new List<Player>();
            Player inviter = _listOfPlayers.Find(p => p.Username.ToLower() == username.ToLower());
            for (int i = 0; i < invitedPlayerNames.Count<string>(); i++)
            {
                try
                {
                    Player plr = _listOfPlayers.Find(p => p.Username.ToLower() == invitedPlayerNames[i].ToLower());
                    if(plr.IsOnline && plr.Game == null)
                        invitedPlayers.Add(plr);
                    else
                        Console.WriteLine("Player \""+invitedPlayerNames[i] + " could not be invited because he is either in another game or offline");
                }
                catch
                {
                    Console.WriteLine("Could not find \""+invitedPlayerNames[i] +"\" in the players list");
                    return;
                }
            }
            Invitation inv = new Invitation(invitedPlayers, inviter, count, invitationTimeOut, this);
            _listOfInvitations.Add(inv);
            inviter.Invitation = inv;
            updatePortalList();
            count++;
        }
        
        public void acceptInvitation(string username, bool userAccepted, int id) 
        {
            try
            {
                Invitation inv = _listOfInvitations.Find(i => i.Id == id);
                inv.acceptInvitation(username,userAccepted);
                updatePortalList();
            }
            catch
            {
                
            }
        }
            
        public void chooseGameWord(string gameWord, string username, int id) 
        {
            try
            {
                _listOfGames.Find(g => g.Id == id).setGameWord(gameWord, username);

            }
            catch
            {
                Console.WriteLine("Could not find game \"" + id + "\" when \"" + username + "\" set the gameword to \"" + gameWord + "\"");
            }
        }

        public void guessLetter(string letter, string username, int id)
        {
            try
            {
                _listOfGames.Find(g => g.Id == id).guess(letter, username);

            }
            catch 
            {
                Console.WriteLine("Could not find game \"" + id + "\" when \"" + username + "\"guessed letter \"" + letter + "\"");
            }
        }

        public void guessWord(string word, string username, int id) 
        {
            try
            {
                _listOfGames.Find(g => g.Id == id).guess(word, username);

            }
            catch
            {
                Console.WriteLine("Could not find game \"" + id + "\" when \"" + username + "\"guessed word \"" + word + "\"");
            }
        }

        public void timeUp(string username, int id) { }

        public void chat(string message, string username, int id) 
        {
            try
            {
                Game game = _listOfGames.Find(g => g.Id == id);
                foreach (Player p in game.Guessers)
                {
                    p.Context.receiveMessage(username + ":  " + message);
                }
                game.WordPicker.Context.receiveMessage(username + ":  " + message);

            }
            catch 
            {
                
                throw;
            }
        }

        public void leaveGame(string username, int id) 
        {
            try//tries to find a player whose name matches
            {
                Game game = _listOfGames.Find(g => g.Id == id);
                game.leaveGame(username);
            }
            catch
            {
                Console.WriteLine("User \""+username+"\" had problems leaving a game");
            }
        }

        public void updatePortalList()
        {

            string[] usernames = ((List<string>)getAvailablePlayersList()[0]).ToArray();
            string[] totalGuesses = getOnlinePlayersList()[1].ToArray();
            string[] correctGuesses = getOnlinePlayersList()[2].ToArray();

            listHasChanged(usernames, correctGuesses, totalGuesses);
        }
        
        public static List<List<string>> getOnlinePlayersList()
        {
            try
            {
                List<string> userNames = new List<string>();//0 = username
                List<string> totalGuesses = new List<string>();//1 = total guesses
                List<string> correctGuesses = new List<string>();//2 = correct guesses
                List<string> gameIDs = new List<string>();      //3 = ids

                List<List<string>> returnList = new List<List<string>>();

                foreach (Player p in _listOfPlayers)
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
            catch { return null; }
        }

        private List<List<string>> getAvailablePlayersList()
        {
            try
            {
                List<string> userNames = new List<string>();//0 = username
                List<string> totalGuesses = new List<string>();//1 = total guesses
                List<string> correctGuesses = new List<string>();//2 = correct guesses

                List<List<string>> returnList = new List<List<string>>();

                foreach (Player p in _listOfPlayers)
                {
                    if (p.IsOnline && p.Game == null && p.Invitation == null)
                    {
                        userNames.Add(p.Username);
                        totalGuesses.Add(p.TotalGuesses.ToString());
                        correctGuesses.Add(p.CorrectGuesses.ToString());
                    }
                }
                returnList.Add(userNames);
                returnList.Add(totalGuesses);
                returnList.Add(correctGuesses);

                return returnList;
            }
            catch
            {
                return null;
            }
        }

        public static bool saveDatabaseToFile()
        {
            List<string[]> newDataBase = new List<string[]>();

            foreach (Player pl in _listOfPlayers)
            {
                string[] str = new string[4];
                str[0] = pl.Username;
                str[1] = pl.Password;
                str[2] = pl.CorrectGuesses.ToString();
                str[3] = pl.TotalGuesses.ToString();
                newDataBase.Add(str);
            }

            try
            {

                System.IO.FileStream fileStream = new System.IO.FileStream(Properties.Resources.dataBase, System.IO.FileMode.Create);
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<string[]>));

                writer.Serialize(fileStream, newDataBase);

                fileStream.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void loadDatabase()
        {
            List<string[]> objectToLoad;

            _listOfPlayers = new List<Player>();

            try
            {
                if (System.IO.File.Exists(Properties.Resources.dataBase))
                {
                    System.IO.FileStream stream = System.IO.File.Open(Properties.Resources.dataBase, System.IO.FileMode.Open);
                    System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<string[]>));
                    objectToLoad = (List<string[]>)reader.Deserialize(stream);
                    stream.Close();

                    foreach (string[] str in objectToLoad)
                    {
                        Player pl = new Player(str[0], str[1]);

                        pl.CorrectGuesses = Int32.Parse(str[2]);
                        pl.TotalGuesses = Int32.Parse(str[3]);

                        _listOfPlayers.Add(pl);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
