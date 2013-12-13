using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HangmanServer
{
    public class Invitation
    {
        private int[] _accepted;
        private List<Player> _invitedPlayers = new List<Player>();
        private Player _inviter;
        private int _id;
        private Timer _timer = new Timer();
        private Server _server;

	    public int Id
	    {
		    get { return _id;}
		    set { _id = value;}
	    }

        public Player Inviter
        {
            get { return _inviter; }
            set { _inviter = value; }
        }        

        public List<Player> InvitedPlayers
        {
            get { return _invitedPlayers; }
            set { _invitedPlayers = value; }
        }

        public Invitation(List<Player> invitedPlayers, Player inviter, int id, int invitationTimeOut, Server server)
        {
            _server = server;
            _invitedPlayers = invitedPlayers;
            _inviter = inviter;
            _id = id;
            _timer.Interval = invitationTimeOut;
            _accepted = new int[invitedPlayers.Count];
            _timer.Start();
            _timer.Elapsed += timeOut;

            for (int i = 0; i < _invitedPlayers.Count; i++)
            {
                _accepted[i] = -1;
            }
            foreach (Player p in invitedPlayers)
            {
                p.Invitation = this;
                p.Context.receiveInvitation(inviter.Username, invitedPlayers.Count, id);
            }
        }

        public void acceptInvitation(string username, bool userAccepted)
        {
            try
            {                
                List<Player> playersWhoAccepted = new List<Player>();

                int idx = this._invitedPlayers.FindIndex(p => p.Username == username);
                _accepted[idx] = Convert.ToInt32(userAccepted);

                for (int i=0; i<_invitedPlayers.Count; i++)//check if all players have replied to the invitation
                {
                    if (_accepted[i] == -1)
                        return;
                    else
                        playersWhoAccepted.Add(_invitedPlayers.ElementAt(i));
                }
                _timer.Stop();
                playersWhoAccepted.Add(Inviter);
                int n = new Random().Next()%playersWhoAccepted.Count;
                Player wordPicker = playersWhoAccepted.ElementAt(n);
                playersWhoAccepted.RemoveAt(n);
                foreach (Player p in InvitedPlayers)
                    p.Invitation = null;
                Inviter.Invitation = null;
                _server.ListOfGames.Add(new Game(_id, playersWhoAccepted, wordPicker,_server));
                _server.ListOfInvitations.Remove(this);
            }
            catch
            {
                Console.WriteLine("Could not find player " + username + " in invitation id: " + _id);
                throw;
            }
        }

        private void timeOut(object sender, ElapsedEventArgs e)
        {
 	       // throw new NotImplementedException();
        }


        
    }
}
