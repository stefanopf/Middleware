﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel;
using System.Collections.Generic;
using System.Diagnostics;

namespace HangmanClient
{
    public partial class ClientForm : Form, HangmanContract.IHangmanCallback
    {
        
        private HangmanContract.HangmanClient proxy;
        private int _atteptsLeft = 10, _gameWordLenght = 0, _gameId = -1, _state = 0; //STATE: 0=login screen, 1=portal, 2=waiting, 3=gameplay
        private string _username;
        
        private Button[] gameWordLetters = new Button[9];
        private Button[] keyboardButtons = new Button[26];

        public ClientForm()
        {
            proxy = new HangmanContract.HangmanClient(new InstanceContext(this)); //creates instance of the server
            this.Shown+=ClientForm_Shown;
            this.FormClosing += OnFormClosing;
            InitializeComponent();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_state != 0)
                    proxy.logout(_username);
            }
            catch { }
        }

        private void ClientForm_Shown(Object sender, EventArgs e)
        {
           
            displayLogin();

            gameWordLetters[0] = buttonL1;
            gameWordLetters[1] = buttonL2;
            gameWordLetters[2] = buttonL3;
            gameWordLetters[3] = buttonL4;
            gameWordLetters[4] = buttonL5;
            gameWordLetters[5] = buttonL6;
            gameWordLetters[6] = buttonL7;
            gameWordLetters[7] = buttonL8;
            gameWordLetters[8] = buttonL9;

            keyboardButtons[0] = buttonA;
            keyboardButtons[1] = buttonB;
            keyboardButtons[2] = buttonC;
            keyboardButtons[3] = buttonD;
            keyboardButtons[4] = buttonE;
            keyboardButtons[5] = buttonF;
            keyboardButtons[6] = buttonG;
            keyboardButtons[7] = buttonH;
            keyboardButtons[8] = buttonI;
            keyboardButtons[9] = buttonJ;
            keyboardButtons[10] = buttonK;
            keyboardButtons[11] = buttonL;
            keyboardButtons[12] = buttonM;
            keyboardButtons[13] = buttonN;
            keyboardButtons[14] = buttonO;
            keyboardButtons[15] = buttonP;
            keyboardButtons[16] = buttonQ;
            keyboardButtons[17] = buttonR;
            keyboardButtons[18] = buttonS;
            keyboardButtons[19] = buttonT;
            keyboardButtons[20] = buttonU;
            keyboardButtons[21] = buttonV;
            keyboardButtons[22] = buttonW;
            keyboardButtons[23] = buttonX;
            keyboardButtons[24] = buttonY;
            keyboardButtons[25] = buttonZ;

            //keyboardButtons[0] = buttonQ;
            //keyboardButtons[1] = buttonW;
            //keyboardButtons[2] = buttonE;
            //keyboardButtons[3] = buttonR;
            //keyboardButtons[4] = buttonT;
            //keyboardButtons[5] = buttonY;
            //keyboardButtons[6] = buttonU;
            //keyboardButtons[7] = buttonI;
            //keyboardButtons[8] = buttonO;
            //keyboardButtons[9] = buttonP;
            //keyboardButtons[10] = buttonA;
            //keyboardButtons[11] = buttonS;
            //keyboardButtons[12] = buttonD;
            //keyboardButtons[13] = buttonF;
            //keyboardButtons[14] = buttonG;
            //keyboardButtons[15] = buttonH;
            //keyboardButtons[16] = buttonJ;
            //keyboardButtons[17] = buttonK;
            //keyboardButtons[18] = buttonL;
            //keyboardButtons[19] = buttonZ;
            //keyboardButtons[20] = buttonX;
            //keyboardButtons[21] = buttonC;
            //keyboardButtons[22] = buttonV;
            //keyboardButtons[23] = buttonB;
            //keyboardButtons[24] = buttonN;
            //keyboardButtons[25] = buttonM;

            labelAttemptsValue.Text = _atteptsLeft.ToString();

        }
        
        public void startNewGame(string[] guessers, string wordPicker, int[] wordRange, int id) 
        {
            listBoxGamePlayersList.Items.Clear();
            listBoxGamePlayersList.Items.Add(wordPicker + "* - Word Chooser");//insert player names in the list
            for (int i = 0; i < guessers.Length; i++)
            {
                listBoxGamePlayersList.Items.Add(guessers[i]);
            }

            _gameId = id;

            for (int i = 0; i < keyboardButtons.Length; i++)//enable virtual keyboard buttons
            {
                keyboardButtons[i].Enabled = true;
            }
            for (int i = 0; i < gameWordLetters.Length; i++)//clears game word
            {
                gameWordLetters[i].Text = "";
            }
            if (wordPicker == _username)//if user is the word picker
            {                
                try
                {
                    labelWaiting.Text = "Your are the Word Picker!\nChoose a word beetween:\n " + wordRange[0] + " and " + wordRange[1] + " letters:";
                    textBoxChooseGameWord.Visible = true;
                    buttonChooseGameWord.Visible = true;
                    textBoxWordGuess.Text = "     WORD PICKER";
                }
                catch { }
            }
            else //if user is a guesser
            {
                textBoxWordGuess.Text = "   NOT YOUR TURN";
            }

            //disables word guessing
            textBoxWordGuess.Enabled = false;
            buttonGuessWord.Enabled = false;

            foreach (Button letter in keyboardButtons)//disables letter guessing
                letter.Click -= letterGuess_click;

        }

        public void setWordLength(int length) 
        {
            _atteptsLeft = 10;
            _gameWordLenght = length;
            labelAttemptsValue.Text = _atteptsLeft.ToString();
            for (int i = 0; i < gameWordLetters.Length; i++)
            {
                if (i < length)
                    gameWordLetters[i].Visible = true;
                else
                    gameWordLetters[i].Visible = false;
            }
            displayGamePlay();
            
        }

        public void updatePlayersList(string[] players, string[] correctGuesses, string[] totalGuesses)
        {
            listView1.Items.Clear();
            for (int i = 0; i < players.Count<string>();  i++)
            {
                if (players[i].ToLower() != _username.ToLower())
                {
                    string[] items = new string[2];
                    items[0] = players[i];
                    items[1] = correctGuesses[i] + "\\" + totalGuesses[i];

                    ListViewItem lstItem = new ListViewItem(items);
                    listView1.Items.Add(lstItem);
                }
                else
                { 
                    labelYourStats.Text = "Your stats:" + "\n"+ correctGuesses[i]+ "\\"+ totalGuesses[i];
                }
            }         
        }

        public void receiveResult(string guess, bool isRight,int[] positions) //receives the result of a guess 
        {
            if (isRight)
            {
                if (guess.Length == 1)//if guess is a letter
                {
                    for (int i = 0; i < positions.Length; i++)
                    {
                        gameWordLetters[positions[i]].Text = guess;
                    }                    
                }
                if (guess.Length > 1)//if guess is a word
                {
                    for (int i = 0; i < _gameWordLenght; i++)
                    {
                        gameWordLetters[i].Text = guess[i].ToString();
                    }
                }
                
            }
            else
            {
                if(guess.Length > 1)//lose extra point if guess is a word
                    _atteptsLeft--;
                _atteptsLeft--;
                labelAttemptsValue.Text = _atteptsLeft.ToString();
            }
            int idx = ((int)(guess.ToUpper().ToCharArray()[0]) - 'A');
            keyboardButtons[idx].Enabled = false;
        }

        public void endGame(string[] winners, string gameWord)
        {
            string winnersString = "";
            foreach (string s in winners)
                winnersString+=s + ", ";
            winnersString = winnersString.Remove(winnersString.Length - 1);
            winnersString = winnersString.Remove(winnersString.Length - 1);

            if(winners.Contains<string>(_username))        
                MessageBox.Show("Congratulations, you won!\n\nWinners:\n" + winnersString + "\n\nThe game word is: \t" + gameWord);
            else
                MessageBox.Show("You have lost!\n\nWinners:\n" + winnersString + "\n\nThe game word is: \t" + gameWord);

            try
            {
                foreach (Button letter in keyboardButtons)
                    letter.Click -= letterGuess_click;
                buttonGuessWord.Click -= buttonGuessWord_Click;
            }
            catch { }

            displayPortal();
        }

        public void receiveMessage(string message)
        {
            if (message != null && message != "")
            {

                if (textBoxChat.Text == "")
                    textBoxChat.Text = textBoxChat.Text + message;
                else
                    textBoxChat.Text = textBoxChat.Text + "\r\n" + message;
            }
            if(message== null)
            {
                MessageBox.Show("Nobody accepted your invitation");
                displayPortal();
            }
        }

        public void receiveInvitation(string inviter, int invitees, int id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            

            if (
                MessageBox.Show(inviter + " has invited you to start a game with him\nand other " + (invitees-1) + " players", "New game invitation (ID = "+id+")", MessageBoxButtons.YesNo) 
                == System.Windows.Forms.DialogResult.Yes)
            {
                stopwatch.Stop();
                if (stopwatch.Elapsed.TotalSeconds > 18)//if user waited more than 18 sec after receiving invitation
                {
                    MessageBox.Show("Invitation timed out");
                    displayPortal();
                }
                else//if user responded before 18 seconds
                {
                    displayWaiting();
                    proxy.acceptInvitation(_username, true, id);
                }
            }
            else
            {
                stopwatch.Stop();
                proxy.acceptInvitation(_username, false,id);
            } 
        }

        public void loginConfirmation(bool confirmation)
        {
            if (confirmation == true)
            {
                this._username = textBoxUserName.Text;
                displayPortal();
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
                buttonRegister.Text = "Register";
                displayLogin();
            }
            buttonLogin.Text = "Login";
            textBoxUserName.Enabled = true;
            textBoxPassword.Enabled = true;
        }

        public void registrationConfirmation(bool confirmation)
        {
            if (confirmation)
            {
                MessageBox.Show("Registration successful!");
                buttonLogin_Click(null, null);
            }
            else
            {
                MessageBox.Show("Username already exists");
            }

            textBoxUserName.Enabled = true;
            textBoxPassword.Enabled = true;
            buttonRegister.Text = "Register";
        }

        public void startTurn(int time) 
        { 
            textBoxWordGuess.Text = "";
           
            //disables word guessing
            textBoxWordGuess.Enabled = true;
            buttonGuessWord.Enabled = true;

            foreach (Button letter in keyboardButtons)//disables letter guessing
                letter.Click += letterGuess_click;            
        }

        private void displayLogin()
        {
            panelLogin.Location = new Point(0, 0);
            panelPortal.Visible = false;
            panelGamePlay.Visible = false;
            panelWaiting.Visible = false;
            panelLogin.Visible = true;
            _gameId = -1;
            _state = 0;
        }

        private void displayPortal()
        {
            labelPlayerName.Text = _username;
            panelLogin.Visible = false;
            panelPortal.Visible = true;
            panelGamePlay.Visible = false;
            panelWaiting.Visible = false;
            panelPortal.Location = new Point(0, 0);
            _state = 1;
            _gameId = -1;

            this.Invalidate();
        }

        private void displayWaiting()
        {
            panelLogin.Visible = false;
            panelPortal.Visible = false;
            panelGamePlay.Visible = false;
            panelWaiting.Visible = true;
            panelWaiting.Location = new Point(0, 0);

            labelWaiting.Text = "Waiting for other players...";
            textBoxChooseGameWord.Visible = false;
            buttonChooseGameWord.Visible = false;

            _state = 2;

            this.Invalidate();
        }

        private void displayGamePlay()
        {
            panelLogin.Visible = false;
            panelPortal.Visible = false;
            panelGamePlay.Visible = true;
            panelWaiting.Visible = false;
            panelGamePlay.Location = new Point(0, 0);
            _state = 3;

            this.Invalidate();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            try
            {
                proxy.leaveGame(this._username, this._gameId);
                displayPortal();
            }
            catch
            {
                connectionErrorMessage();
            }
        }

        private void connectionErrorMessage()
        {
            MessageBox.Show("Could not connect to server.\nIf problem persists, restart application.", "Connection error");
        }

        private void letterGuess_click(object sender, EventArgs e) 
        {

            Button b = (Button)sender;
            bool sent = false;
            try
            {
                b.Enabled = false;
                proxy.guessLetter(b.Text, _username, _gameId);
                sent = true;
            }
            catch
            {
                sent = false;
                b.Enabled = true;
                connectionErrorMessage();
            }
            finally
            {
                if (sent)
                {
                    //disables word guessing
                    textBoxWordGuess.MaxLength = 20;
                    textBoxWordGuess.Enabled = false;
                    buttonGuessWord.Enabled = false;

                    foreach (Button letter in keyboardButtons)//disables letter guessing
                        letter.Click -= letterGuess_click;
                }
            }
        }
        
        private void buttonGuessWord_Click(object sender, EventArgs e)
        {

            bool sent = false;
            try
            {
                proxy.guessWord(textBoxWordGuess.Text, _username, _gameId);
                sent = true;
                textBoxWordGuess.Text = "";
            }
            catch
            {
                sent = false;
                connectionErrorMessage();
            }
            finally
            {
                if (sent)
                {
                    //disables word guessing
                    textBoxWordGuess.MaxLength = 20;
                    textBoxWordGuess.Text = "   NOT YOUR TURN";
                    textBoxWordGuess.Enabled = false;
                    buttonGuessWord.Enabled = false;

                    foreach (Button letter in keyboardButtons)//disables letter guessing
                        letter.Click -= letterGuess_click;
                }
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                buttonLogin.Text = "Logging\r\nin...";
                textBoxUserName.Enabled = false;
                textBoxPassword.Enabled = false;
                Refresh();
                proxy.login(textBoxUserName.Text, textBoxPassword.Text);
            }
            catch
            {
                MessageBox.Show("Could not connect to server");
                buttonLogin.Text = "Login";
                textBoxUserName.Enabled = true;
                textBoxPassword.Enabled = true;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                buttonRegister.Text = "Registering...";
                textBoxUserName.Enabled = false;
                textBoxPassword.Enabled = false;
                Refresh();
                string s = "";

                if (textBoxUserName.Text.Length >=3 && textBoxUserName.Text.Length <=20
                    && textBoxPassword.Text.Length >= 5 && textBoxPassword.Text.Length <=20)
                {
                    proxy.register(textBoxUserName.Text, textBoxPassword.Text);
                }
                else
                {
                    
                    if (textBoxUserName.Text.Length < 3)
                    {
                        s += "Username too short (3-19 characters)\n";
                    }
                    if (textBoxUserName.Text.Length > 20)
                    {
                        s += "Username too long(3-19 characters)\n";
                    }
                    if (textBoxPassword.Text.Length < 5)
                    {
                        s += "Password too short(5-19 characters)\n";
                    }
                    if (textBoxPassword.Text.Length >20)
                    {
                        s += "Password too long(5-19 characters)\n";
                    }
                }
                if(s!="")
                    MessageBox.Show(s, "Registration");
                
            }
            catch 
            {
                MessageBox.Show("Could not connect to the server");
                textBoxUserName.Enabled = true;
                textBoxPassword.Enabled = true;
                buttonRegister.Text = "Register";
            }
        }

        private void buttonInvite_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedItems =listView1.SelectedItems;
                List<string> usernames = new List<string>();
                foreach (ListViewItem selectedItem in selectedItems)
                {
                    usernames.Add(selectedItem.Text);
                }
                if (usernames.Count != 0)
                {
                    proxy.invitePlayers(usernames.ToArray(), _username);
                    displayWaiting();
                }
            }
            catch
            {
                connectionErrorMessage();
            }
        }

        private void buttonChooseGameWord_Click(object sender, EventArgs e)
        {
            try
            {
                proxy.chooseGameWord(textBoxChooseGameWord.Text, _username, _gameId);
            }
            catch
            {
                connectionErrorMessage();
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string temp = "";
            try
            {
                temp = textBoxSendMessage.Text;
                proxy.chat(textBoxSendMessage.Text, _username, _gameId);
                textBoxSendMessage.Text = "";
            }
            catch
            {
                connectionErrorMessage();
                textBoxSendMessage.Text = temp;//in case fails sending message, puts it back into the text box
            }
        }

    }
}
