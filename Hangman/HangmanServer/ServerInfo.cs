using HangmanContract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HangmanServer
{
    //this class will be the single instance that takes care of the "single ton" matters (portal)
    public static class ServerInfo
    {
        private static string savePath = "hangman.database";
        private static List<Player> listOfPlayers;//this is our database

        /*
        public static string saveDataBase() 
        {
            try
            {
                FileStream fileStream = new FileStream(savePath, FileMode.Append);
                BinaryFormatter binaryFormater = new BinaryFormatter();
                binaryFormater.Serialize(fileStream, listOfPlayers.ToArray<Player>());
                fileStream.Close();
                return "Database has been successfully saved";
            }
            catch (System.Runtime.Serialization.SerializationException)
            {
                return "File could not be serialized, and it was NOT saved";
            }
        }

        public static string LoadDataBase()
        {
            try
            {
                FileStream fileStream = new FileStream(savePath, FileMode.Append);
                BinaryFormatter binaryFormater = new BinaryFormatter();
                listOfPlayers = new List<Player(Player[])binaryFormater.Deserialize(fileStream);
                fileStream.Close();
                return "Database has been successfully loaded";
            }
            catch
            {
                listOfPlayers = new List<Player>();
                return "A new database has been created";
            }
            
        }
         */

        public static bool registerPlayer(string username, string password) 
        {

            if (listOfPlayers.Find(p => p.Username.ToLower() == username.ToLower()) == null) //if couldnt find player whose name is "username"
            {
                listOfPlayers.Add(new Player(username, password));
                return true;
            }
            return false;
        }

        public static bool login(string  username, string password, IHangmanCallBack context)
        {

            try
            {
                Player player = listOfPlayers.Find(p =>p.Username.ToLower() == username.ToLower() && p.Password == password);//tries to find a player whose name and password match
                player.Context = context;
                player.IsOnline = true;
                return true;
            }
            catch 
            {             
                return false;
            }

        }

        public static bool logout(string username)
        {


            try//tries to find a player whose name matches
            {
                Player player = listOfPlayers.Find(p => p.Username == username);
                player.Context = null;
                player.IsOnline = false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// accesses listOfPlayers looking for online players
        /// </summary>
        /// <returns>
        /// A list of 3 lists with information about each online player: 
        /// 1- usernames, 2- total guesses, 3- correct guesses
        /// </returns>
        public static List<List<string>> getOnlinePlayersList() 
        {
            List<string> userNames = new List<string>();
            List<string> totalGuesses = new List<string>();
            List<string> correctGuesses = new List<string>();
            List<List<string>> returnList = new List<List<string>>();

            foreach (Player p in listOfPlayers)
            {
                if (p.IsOnline)
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

        public static IHangmanCallBack getContext(string username)
        {
            try 
            { 
                return listOfPlayers.Find(p => p.Username.ToLower() == username.ToLower()).Context;//returns the context of the player whose name is "username";
            }
            catch
            {
                return null;
            }
        }
    }    
}
