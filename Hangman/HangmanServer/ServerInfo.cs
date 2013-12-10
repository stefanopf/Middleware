using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanServer
{
    public static class ServerInfo
    {
        private static List<string> playersList = new List<string>();
        private static List<string> passwordsList = new List<string>();

        public static bool registerPlayer(string player, string password) 
        {
            if (!playersList.Contains(player))
            {
                playersList.Add(player);
                passwordsList.Add(password);
                return true;
            }

            return false;
        }
        public static bool checkLoginInfo(string player, string password)
        {
            if (playersList.Contains(player) && passwordsList[playersList.IndexOf(player)] == password)
            {
                return true;
            }

            return false;
        }

    }
}
