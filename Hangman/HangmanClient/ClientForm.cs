using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace HangmanClient
{
    public partial class ClientForm : Form, HangmanContract.IHangmanCallback

    {
        private Button[] gameWordLetters = new Button[9];
        private HangmanContract.HangmanClient proxy;
        int atteptsLeft = 10, gameWordLenght=0;

        public ClientForm()
        {
            proxy = new HangmanContract.HangmanClient(new InstanceContext(this)); //establish connection with server
            this.Shown+=ClientForm_Shown;        

            InitializeComponent();
        }

        private void ClientForm_Shown(Object sender, EventArgs e)
        {
            gameWordLetters[0] = buttonL1;
            gameWordLetters[1] = buttonL2;
            gameWordLetters[2] = buttonL3;
            gameWordLetters[3] = buttonL4;
            gameWordLetters[4] = buttonL5;
            gameWordLetters[5] = buttonL6;
            gameWordLetters[6] = buttonL7;
            gameWordLetters[7] = buttonL8;
            gameWordLetters[8] = buttonL9;

            buttonQ.Click += letter_click;
            buttonW.Click += letter_click;
            buttonE.Click += letter_click;
            buttonR.Click += letter_click;
            buttonT.Click += letter_click;
            buttonY.Click += letter_click;
            buttonU.Click += letter_click;
            buttonI.Click += letter_click;
            buttonO.Click += letter_click;
            buttonP.Click += letter_click;
            buttonA.Click += letter_click;
            buttonS.Click += letter_click;
            buttonD.Click += letter_click;
            buttonF.Click += letter_click;
            buttonG.Click += letter_click;
            buttonH.Click += letter_click;
            buttonJ.Click += letter_click;
            buttonK.Click += letter_click;
            buttonL.Click += letter_click;
            buttonZ.Click += letter_click;
            buttonX.Click += letter_click;
            buttonC.Click += letter_click;
            buttonV.Click += letter_click;
            buttonB.Click += letter_click;
            buttonN.Click += letter_click;
            buttonM.Click += letter_click;

            label2.Text = atteptsLeft.ToString();

        }
        
        public void startNewGame(string[] guessers, string wordPicker, int[] wordRange) 
        { 
        }

        public void setWordLength(int length) 
        {
            gameWordLenght = length;
            for (int i = 0; i < length; i++)
                gameWordLetters[i].Visible = true;
            
        }

        public void updatePlayersList(string[] players, int[] stats)
        {
        }

        //this is only implemented for letter guessing
        public void getResult(string guess, bool isRight,int[] positions) //receives the result of a guess 
        {
            if (isRight)
            {
                for (int i = 0; i < positions.Length; i++)
                {
                    gameWordLetters[positions[i]].Text = guess;
                }

                
                string [] s = new string[2];

                for (int i = 0; i < gameWordLenght; i++) 
                {
                    if (gameWordLetters[i].Text == "")
                        break;

                    s[1] +=gameWordLetters[i].Text;

                    if(i==gameWordLenght-1)
                    {
                        s[0] = "Congratulations, you won!";
                        endGame(s);
                    }
                }
            }
            else
            {
                atteptsLeft--;
                label2.Text = atteptsLeft.ToString();
                MessageBox.Show("Your guess was wrong");
            }
        }


        public void endGame(string[] winners)
        {
            MessageBox.Show(winners[0]+ "\nThe game word is: " + winners[1]);
        }


        public void receiveMessage(string message)
        {
        }


        public void receiveInvitation(string inviter, int invitees)
        {
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            proxy.invitePlayers(new string[0], "none");
        }

        public void letter_click(object sender, EventArgs e) 
        {
            Button b = (Button)sender;
            b.Enabled = false;
            proxy.guessLetter(b.Text, "user");
        }
    }
}
