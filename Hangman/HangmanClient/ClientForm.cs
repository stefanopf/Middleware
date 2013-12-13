using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel;
using System.Collections.Generic;
namespace HangmanClient
{
    public partial class ClientForm : Form, HangmanContract.IHangmanCallback

    {
        
        private HangmanContract.HangmanClient proxy;
        private int atteptsLeft = 10, gameWordLenght=0, state=0; //STATE: 0=login screen, 1=portal, 2=gameplay
        private string username;
        
        private Button[] gameWordLetters = new Button[9];
        private Button[] keyboardButtons = new Button[26];

        public ClientForm()
        {
            proxy = new HangmanContract.HangmanClient(new InstanceContext(this)); //establish connection with server
            this.Shown+=ClientForm_Shown;        

            InitializeComponent();
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

            keyboardButtons[0] = buttonQ;
            keyboardButtons[1] = buttonW;
            keyboardButtons[2] = buttonE;
            keyboardButtons[3] = buttonR;
            keyboardButtons[4] = buttonT;
            keyboardButtons[5] = buttonY;
            keyboardButtons[6] = buttonU;
            keyboardButtons[7] = buttonI;
            keyboardButtons[8] = buttonO;
            keyboardButtons[9] = buttonP;
            keyboardButtons[10] = buttonA;
            keyboardButtons[11] = buttonS;
            keyboardButtons[12] = buttonD;
            keyboardButtons[13] = buttonF;
            keyboardButtons[14] = buttonG;
            keyboardButtons[15] = buttonH;
            keyboardButtons[16] = buttonJ;
            keyboardButtons[17] = buttonK;
            keyboardButtons[18] = buttonL;
            keyboardButtons[19] = buttonZ;
            keyboardButtons[20] = buttonX;
            keyboardButtons[21] = buttonC;
            keyboardButtons[22] = buttonV;
            keyboardButtons[23] = buttonB;
            keyboardButtons[24] = buttonN;
            keyboardButtons[25] = buttonM;

            foreach(Button letter in keyboardButtons)
                letter.Click+=letterGuess_click;

            labelAttemptsValue.Text = atteptsLeft.ToString();

        }
        
        public void startNewGame(string[] guessers, string wordPicker, int[] wordRange) 
        {
            for (int i = 0; i < keyboardButtons.Length; i++)
            {
                keyboardButtons[i].Enabled = true;
            }
            for (int i = 0; i < gameWordLetters.Length; i++)
            {
                gameWordLetters[i].Text = "";
            }
        }

        public void setWordLength(int length) 
        {
            atteptsLeft = 10;
            gameWordLenght = length;
            labelAttemptsValue.Text = atteptsLeft.ToString();
            for (int i = 0; i < gameWordLetters.Length; i++)
            {
                if (i < length)
                    gameWordLetters[i].Visible = true;
                else
                    gameWordLetters[i].Visible = false;
            }
            
        }

        public void updatePlayersList(string[] players, string[] correctGuesses, string[] totalGuesses)
        {
            listView1.Items.Clear();
            for (int i = 0; i < players.Count<string>();  i++)
            {
                if (players[i].ToLower() != username.ToLower())
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
                    for (int i = 0; i < gameWordLenght; i++)
                    {
                        gameWordLetters[i].Text = guess[i].ToString();
                    }
                }
                
            }
            else
            {
                if(guess.Length > 1)//lose extra point if guess is a word
                    atteptsLeft--;
                atteptsLeft--;
                labelAttemptsValue.Text = atteptsLeft.ToString();
                MessageBox.Show("Your guess was wrong");
            }
        }

        public void endGame(string[] winners, string gameWord)
        {
            string winnersString = "";
            foreach (string s in winners)
                winnersString+=s + ", ";
            winnersString = winnersString.Remove(winnersString.Length - 1);
            winnersString = winnersString.Remove(winnersString.Length - 1);

            if(winners.Contains<string>(username))        
                MessageBox.Show("Congratulations, you won!\n\nWinners:\n" + winnersString + "\n\nThe game word is: \t" + gameWord);
            else
                MessageBox.Show("You have lost!\n\nWinners:\n" + winnersString + "\n\nThe game word is: \t" + gameWord);
        }

        public void receiveMessage(string message)
        {
        }

        public void receiveInvitation(string inviter, int invitees)
        {
            MessageBox.Show("You have received an invitation for a game with " + invitees + " other players.");
        }

        public void loginConfirmation(bool confirmation)
        {
            if (confirmation == true)
            {
                displayPortal();
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
                buttonRegister.Text = "Register";
            }
            buttonLogin.Text = "Login";
            textBoxUserName.Enabled = false;
            textBoxPassword.Enabled = false;
        }

        private void displayLogin()
        {
            panelLogin.Location = new Point(0, 0);
            panelPortal.Visible = false;
            panelGamePlay.Visible = false;
            panelLogin.Visible = true;
            state = 0;
        }

        private void displayPortal()
        {
            labelPlayerName.Text = username;
            panelLogin.Visible = false;
            panelPortal.Visible = true;
            panelGamePlay.Visible = false;
            panelPortal.Location = new Point(0, 0);
            state = 1;

            this.Invalidate();
        }

        private void displayGamePlay()
        {
            panelLogin.Visible = false;
            panelPortal.Visible = false;
            panelGamePlay.Visible = true;
            panelGamePlay.Location = new Point(0, 0);
            state = 2;

            this.Invalidate();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            proxy.invitePlayers(new string[0], "none");            
        }

        private void letterGuess_click(object sender, EventArgs e) 
        {
            Button b = (Button)sender;
            b.Enabled = false;
            proxy.guessLetter(b.Text, username);
        }
        
        private void buttonGuessWord_Click(object sender, EventArgs e)
        {
            if (textBoxWordGuess.Text.Length == gameWordLenght)
            {
                proxy.guessWord(textBoxWordGuess.Text.ToUpper(), username);
                textBoxWordGuess.Text = "";
            }
            else
            {
                MessageBox.Show("Word guess has invalid lenght");
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                buttonLogin.Text = "Logging\nin...";
                textBoxUserName.Enabled = false;
                textBoxPassword.Enabled = false;
                proxy.login(textBoxUserName.Text, textBoxPassword.Text);
                this.username = textBoxUserName.Text;
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
                string s = "";

                if (textBoxUserName.Text.Length >=3 && textBoxUserName.Text.Length <=20
                    && textBoxPassword.Text.Length >= 5 && textBoxPassword.Text.Length <=20)
                {
                    textBoxUserName.Enabled = false;
                    textBoxPassword.Enabled = false;
                    if (proxy.register(textBoxUserName.Text, textBoxPassword.Text))
                    {
                        s+="Registration successful!";
                    }
                    else 
                    {
                        s += "Username already exists";
                    }
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

                if (s == "Registration successful!")
                {
                    buttonLogin_Click(null, null);
                }

                buttonRegister.Text = "Register";
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
            var selectedItems =listView1.SelectedItems;
            List<string> usernames = new List<string>();
            foreach (ListViewItem selectedItem in selectedItems)
            {
                usernames.Add(selectedItem.Text);
            }
            proxy.invitePlayers(usernames.ToArray(), username);
        }

    }
}
