using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace HangmanContract
{
    [ServiceContract(Namespace = "HangmanContract")]
    public interface IPortal
    {
        [OperationContract]
        bool login(string username, string password);
        
        [OperationContract]
        bool register(string username, string password);
        
        [OperationContract]
        void invitePlayers(string[] invitedPlayerNames, string username); //invites players to a game
        
        [OperationContract]
        void acceptInvitation(bool userAccepted);
    }
}
