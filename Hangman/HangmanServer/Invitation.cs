using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HangmanServer
{
    class Invitation
    {
        private List<bool> _accepted = new List<bool>();
        private List<Player> _invitedPlayers = new List<Player>();
        private Player _inviter;
        private decimal _id;
        private Timer _timer = new Timer();

	    public decimal Id
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

        public Invitation(List<Player> invitedPlayers, Player inviter, decimal id, int invitationTimeOut)
        {
            _invitedPlayers = invitedPlayers;
            _inviter = inviter;
            _id = id;
            _timer.Interval= invitationTimeOut;
            _timer.Start();
            _timer.Elapsed+= timeOut;

            foreach (Player p in invitedPlayers)
            {
                p.Context.receiveInvitation(inviter.Username, invitedPlayers.Count);
            }
        }

        private void timeOut(object sender, ElapsedEventArgs e)
        {



 	        throw new NotImplementedException();
        }


        
    }
}
