﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HangmanClient.HangmanContract {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="HangmanContract", ConfigurationName="HangmanContract.IHangman", CallbackContract=typeof(HangmanContract.IHangmanCallback))]
    public interface IHangman {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/login")]
        void login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/login")]
        System.Threading.Tasks.Task loginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="HangmanContract/IHangman/register", ReplyAction="HangmanContract/IHangman/registerResponse")]
        bool register(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="HangmanContract/IHangman/register", ReplyAction="HangmanContract/IHangman/registerResponse")]
        System.Threading.Tasks.Task<bool> registerAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/invitePlayers")]
        void invitePlayers(string[] invitedPlayerNames, string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/invitePlayers")]
        System.Threading.Tasks.Task invitePlayersAsync(string[] invitedPlayerNames, string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/acceptInvitation")]
        void acceptInvitation(bool userAccepted);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/acceptInvitation")]
        System.Threading.Tasks.Task acceptInvitationAsync(bool userAccepted);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/chooseGameWord")]
        void chooseGameWord(string gameWord, string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/chooseGameWord")]
        System.Threading.Tasks.Task chooseGameWordAsync(string gameWord, string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/guessLetter")]
        void guessLetter(string letter, string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/guessLetter")]
        System.Threading.Tasks.Task guessLetterAsync(string letter, string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/guessWord")]
        void guessWord(string word, string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/guessWord")]
        System.Threading.Tasks.Task guessWordAsync(string word, string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/timeUp")]
        void timeUp(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/timeUp")]
        System.Threading.Tasks.Task timeUpAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/chat")]
        void chat(string message, string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/chat")]
        System.Threading.Tasks.Task chatAsync(string message, string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/leaveGame")]
        void leaveGame(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/leaveGame")]
        System.Threading.Tasks.Task leaveGameAsync(string username);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHangmanCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/startNewGame")]
        void startNewGame(string[] guessers, string wordPicker, int[] wordRange);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/setWordLength")]
        void setWordLength(int length);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/updatePlayersList")]
        void updatePlayersList(string[] players, string[] correctGuesses, string[] totalGuesses);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/receiveResult")]
        void receiveResult(string guess, bool isRight, int[] positions);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/endGame")]
        void endGame(string[] winners, string gameWord);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/receiveMessage")]
        void receiveMessage(string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/receiveInvitation")]
        void receiveInvitation(string inviter, int invitees);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="HangmanContract/IHangman/loginConfirmation")]
        void loginConfirmation(bool confirmation);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHangmanChannel : HangmanContract.IHangman, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HangmanClient : System.ServiceModel.DuplexClientBase<HangmanContract.IHangman>, HangmanContract.IHangman {
        
        public HangmanClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public HangmanClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public HangmanClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public HangmanClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public HangmanClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void login(string username, string password) {
            base.Channel.login(username, password);
        }
        
        public System.Threading.Tasks.Task loginAsync(string username, string password) {
            return base.Channel.loginAsync(username, password);
        }
        
        public bool register(string username, string password) {
            return base.Channel.register(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> registerAsync(string username, string password) {
            return base.Channel.registerAsync(username, password);
        }
        
        public void invitePlayers(string[] invitedPlayerNames, string username) {
            base.Channel.invitePlayers(invitedPlayerNames, username);
        }
        
        public System.Threading.Tasks.Task invitePlayersAsync(string[] invitedPlayerNames, string username) {
            return base.Channel.invitePlayersAsync(invitedPlayerNames, username);
        }
        
        public void acceptInvitation(bool userAccepted) {
            base.Channel.acceptInvitation(userAccepted);
        }
        
        public System.Threading.Tasks.Task acceptInvitationAsync(bool userAccepted) {
            return base.Channel.acceptInvitationAsync(userAccepted);
        }
        
        public void chooseGameWord(string gameWord, string username) {
            base.Channel.chooseGameWord(gameWord, username);
        }
        
        public System.Threading.Tasks.Task chooseGameWordAsync(string gameWord, string username) {
            return base.Channel.chooseGameWordAsync(gameWord, username);
        }
        
        public void guessLetter(string letter, string username) {
            base.Channel.guessLetter(letter, username);
        }
        
        public System.Threading.Tasks.Task guessLetterAsync(string letter, string username) {
            return base.Channel.guessLetterAsync(letter, username);
        }
        
        public void guessWord(string word, string username) {
            base.Channel.guessWord(word, username);
        }
        
        public System.Threading.Tasks.Task guessWordAsync(string word, string username) {
            return base.Channel.guessWordAsync(word, username);
        }
        
        public void timeUp(string username) {
            base.Channel.timeUp(username);
        }
        
        public System.Threading.Tasks.Task timeUpAsync(string username) {
            return base.Channel.timeUpAsync(username);
        }
        
        public void chat(string message, string username) {
            base.Channel.chat(message, username);
        }
        
        public System.Threading.Tasks.Task chatAsync(string message, string username) {
            return base.Channel.chatAsync(message, username);
        }
        
        public void leaveGame(string username) {
            base.Channel.leaveGame(username);
        }
        
        public System.Threading.Tasks.Task leaveGameAsync(string username) {
            return base.Channel.leaveGameAsync(username);
        }
    }
}
