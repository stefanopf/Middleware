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
            _timer.Elapsed += timeOut;
            _timer.Start();

            for (int i = 0; i < _invitedPlayers.Count; i++)
            {
                _accepted[i] = -1;
            }
            foreach (Player p in invitedPlayers)
            {
                p.Invitation = this;
                p.Context.receiveInvitation(inviter.Username, invitedPlayers.Count, id);
                server.updatePortalList();
            }
        }

        public void acceptInvitation(string username, bool userAccepted)
        {
            try
            {                
                List<Player> playersWhoAccepted = new List<Player>();

                int idx = this._invitedPlayers.FindIndex(p => p.Username == username);
                _accepted[idx] = Convert.ToInt32(userAccepted);
                if (!userAccepted)
                {
                    _invitedPlayers[idx].Invitation = null;
                }

                for (int i=0; i<_invitedPlayers.Count; i++)//check if all players have replied to the invitation
                {
                    if (_accepted[i] == -1)//if there is a player who hasnt replied yet, finish method
                    {
                        return;
                    }
                    else
                        if (_accepted[i] == 1)
                            playersWhoAccepted.Add(_invitedPlayers.ElementAt(i));
                }
                _timer.Stop();
                if (playersWhoAccepted.Count > 0)
                {
                    playersWhoAccepted.Add(Inviter);
                    int n = new Random().Next() % playersWhoAccepted.Count;
                    Player wordPicker = playersWhoAccepted.ElementAt(n);
                    playersWhoAccepted.RemoveAt(n);
                    foreach (Player p in InvitedPlayers)
                        p.Invitation = null;
                    Inviter.Invitation = null;
                    _server.ListOfGames.Add(new Game(_id, playersWhoAccepted, wordPicker, _server));
                    _server.ListOfInvitations.Remove(this);
                }
                else
                {
                    _inviter.Invitation = null;
                    _inviter.Context.receiveMessage(null);//notifies that no one accepted the game
                    _server.updatePortalList();
                }
            }
            catch
            {
                Console.WriteLine("Could not find player " + username + " in invitation id: " + _id);
                throw;
            }
        }

        private void timeOut(object sender, ElapsedEventArgs e)
        {
            try
            {       
                _timer.Stop();
                List<Player> playersWhoAccepted = new List<Player>();
                for(int i=0;i<_invitedPlayers.Count;i++)//check which players accepted invitation
                {
                    if (_accepted[i] == -1)
                        _invitedPlayers[i].Invitation = null;
                    if (_accepted[i] == 1)
                        playersWhoAccepted.Add(_invitedPlayers[i]);
                }

                if (playersWhoAccepted.Count > 0) //if someone accepted the invitation
                {
                    playersWhoAccepted.Add(Inviter);
                    int n = new Random().Next() % playersWhoAccepted.Count;
                    Player wordPicker = playersWhoAccepted.ElementAt(n);
                    playersWhoAccepted.RemoveAt(n);
                    foreach (Player p in InvitedPlayers)
                        p.Invitation = null;
                    Inviter.Invitation = null;
                    _server.ListOfGames.Add(new Game(_id, playersWhoAccepted, wordPicker, _server));
                    _server.ListOfInvitations.Remove(this);
                }
                else
                {
                    _inviter.Invitation = null;
                    _inviter.Context.receiveMessage(null);//notifies that no one accepted the game
                    _server.updatePortalList();
                }
            }
            catch
            {
                Console.WriteLine("Invitation timed out and had problems starting game id= "+_id);
                throw;
            }
        }


        
    }
}
