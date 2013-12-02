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
        private Button[] keyboard = new Button[26];
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

            keyboard[0] = buttonQ;
            keyboard[1] = buttonW;
            keyboard[2] = buttonE;
            keyboard[3] = buttonR;
            keyboard[4] = buttonT;
            keyboard[5] = buttonY;
            keyboard[6] = buttonU;
            keyboard[7] = buttonI;
            keyboard[8] = buttonO;
            keyboard[9] = buttonP;
            keyboard[10] = buttonA;
            keyboard[11] = buttonS;
            keyboard[12] = buttonD;
            keyboard[13] = buttonF;
            keyboard[14] = buttonG;
            keyboard[15] = buttonH;
            keyboard[16] = buttonJ;
            keyboard[17] = buttonK;
            keyboard[18] = buttonL;
            keyboard[19] = buttonZ;
            keyboard[20] = buttonX;
            keyboard[21] = buttonC;
            keyboard[22] = buttonV;
            keyboard[23] = buttonB;
            keyboard[24] = buttonN;
            keyboard[25] = buttonM;

            for (int i = 0; i < keyboard.Length; i++) 
            {
                keyboard[i].Enabled = false;
                keyboard[i].Click += letter_click;
            }

            label2.Text = atteptsLeft.ToString();

        }
        
        public void startNewGame(string[] guessers, string wordPicker, int[] wordRange) 
        { 
        }

        public void setWordLength(int length) 
        {
            atteptsLeft = 10;
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
            for (int i = 0; i < keyboard.Length; i++)
            {
                keyboard[i].Enabled = false;
            }          
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

            for (int i = 0; i < keyboard.Length; i++)
            {
                keyboard[i].Enabled = true;
            }
            for (int i = 0; i < gameWordLetters.Length; i++)
            {
                gameWordLetters[i].Text = "";
            }
        }

        public void letter_click(object sender, EventArgs e) 
        {
            Button b = (Button)sender;
            b.Enabled = false;
            proxy.guessLetter(b.Text, "user");
        }
    }
}
