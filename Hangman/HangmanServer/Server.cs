﻿using HangmanContract;
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

        private static List<Player> listOfPlayers;//this is our database
        private static List<Invitation> listOfInvitations = new List<Invitation>();
        private static List<Game> listOfGames = new List<Game>();
       // private string[] gameWords = { "CAT", "TABLE", "ELEPHANT", "BICYCLE", "UMBRELLA", "FONTYS" };
        private int count = 0;

        public List<Game> ListOfGames 
        {
            get { return listOfGames; } 
        }

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
                    Player plr = listOfPlayers.Find(p => p.Username.ToLower() == invitedPlayerNames[i].ToLower());
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
            Server s = this;
            Invitation inv = new Invitation(invitedPlayers, inviter, count, 15000, s);
            listOfInvitations.Add(inv);
            count++;
        }
        
        public void acceptInvitation(string username, bool userAccepted, int id) 
        {
            try
            {
                Invitation inv = listOfInvitations.Find(i => i.Id == id);
                inv.acceptInvitation(username,userAccepted);
            }
            catch
            {
                
            }
        }

        public void chooseGameWord(string gameWord, string username, int id) 
        {
            try
            {
                listOfGames.Find(g => g.Id == id).setGameWord(gameWord, username);

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
                listOfGames.Find(g => g.Id == id).guess(letter, username);

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
                listOfGames.Find(g => g.Id == id).guess(word, username);

            }
            catch
            {
                Console.WriteLine("Could not find game \"" + id + "\" when \"" + username + "\"guessed word \"" + word + "\"");
            }
        }

        public void timeUp(string username, int id) { }

        public void chat(string message, string username, int id) { }

        public void leaveGame(string username, int id) 
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
