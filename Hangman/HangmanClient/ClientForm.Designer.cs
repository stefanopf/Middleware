namespace HangmanClient
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLeaveGame = new System.Windows.Forms.Button();
            this.labelAttemptsLeft = new System.Windows.Forms.Label();
            this.labelAttemptsValue = new System.Windows.Forms.Label();
            this.buttonQ = new System.Windows.Forms.Button();
            this.buttonW = new System.Windows.Forms.Button();
            this.buttonE = new System.Windows.Forms.Button();
            this.buttonR = new System.Windows.Forms.Button();
            this.buttonT = new System.Windows.Forms.Button();
            this.buttonY = new System.Windows.Forms.Button();
            this.buttonU = new System.Windows.Forms.Button();
            this.buttonJ = new System.Windows.Forms.Button();
            this.buttonH = new System.Windows.Forms.Button();
            this.buttonG = new System.Windows.Forms.Button();
            this.buttonF = new System.Windows.Forms.Button();
            this.buttonD = new System.Windows.Forms.Button();
            this.buttonS = new System.Windows.Forms.Button();
            this.buttonA = new System.Windows.Forms.Button();
            this.buttonM = new System.Windows.Forms.Button();
            this.buttonN = new System.Windows.Forms.Button();
            this.buttonB = new System.Windows.Forms.Button();
            this.buttonV = new System.Windows.Forms.Button();
            this.buttonC = new System.Windows.Forms.Button();
            this.buttonX = new System.Windows.Forms.Button();
            this.buttonZ = new System.Windows.Forms.Button();
            this.buttonI = new System.Windows.Forms.Button();
            this.buttonO = new System.Windows.Forms.Button();
            this.buttonK = new System.Windows.Forms.Button();
            this.buttonL1 = new System.Windows.Forms.Button();
            this.buttonL2 = new System.Windows.Forms.Button();
            this.buttonL3 = new System.Windows.Forms.Button();
            this.buttonL4 = new System.Windows.Forms.Button();
            this.buttonL5 = new System.Windows.Forms.Button();
            this.buttonL6 = new System.Windows.Forms.Button();
            this.buttonL7 = new System.Windows.Forms.Button();
            this.buttonL8 = new System.Windows.Forms.Button();
            this.buttonP = new System.Windows.Forms.Button();
            this.buttonL = new System.Windows.Forms.Button();
            this.buttonL9 = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.listBoxGamePlayersList = new System.Windows.Forms.ListBox();
            this.textBoxWordGuess = new System.Windows.Forms.TextBox();
            this.buttonGuessWord = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxSendMessage = new System.Windows.Forms.TextBox();
            this.labelGamePlayersList = new System.Windows.Forms.Label();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.panelGamePlay = new System.Windows.Forms.Panel();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.panelPortal = new System.Windows.Forms.Panel();
            this.buttonInvite = new System.Windows.Forms.Button();
            this.labelAvailablePlayers = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ColumnPlayer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnGuessings = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelYourStats = new System.Windows.Forms.Label();
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.panelWaiting = new System.Windows.Forms.Panel();
            this.buttonChooseGameWord = new System.Windows.Forms.Button();
            this.textBoxChooseGameWord = new System.Windows.Forms.TextBox();
            this.labelWaiting = new System.Windows.Forms.Label();
            this.panelLogin.SuspendLayout();
            this.panelGamePlay.SuspendLayout();
            this.panelPortal.SuspendLayout();
            this.panelWaiting.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLeaveGame
            // 
            this.buttonLeaveGame.AutoSize = true;
            this.buttonLeaveGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLeaveGame.Location = new System.Drawing.Point(10, 13);
            this.buttonLeaveGame.Name = "buttonLeaveGame";
            this.buttonLeaveGame.Size = new System.Drawing.Size(127, 34);
            this.buttonLeaveGame.TabIndex = 0;
            this.buttonLeaveGame.Text = "Leave Game";
            this.buttonLeaveGame.UseVisualStyleBackColor = true;
            this.buttonLeaveGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // labelAttemptsLeft
            // 
            this.labelAttemptsLeft.AutoSize = true;
            this.labelAttemptsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAttemptsLeft.Location = new System.Drawing.Point(214, 17);
            this.labelAttemptsLeft.Name = "labelAttemptsLeft";
            this.labelAttemptsLeft.Size = new System.Drawing.Size(143, 25);
            this.labelAttemptsLeft.TabIndex = 1;
            this.labelAttemptsLeft.Text = "Attempts left: ";
            // 
            // labelAttemptsValue
            // 
            this.labelAttemptsValue.AutoSize = true;
            this.labelAttemptsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAttemptsValue.Location = new System.Drawing.Point(259, 46);
            this.labelAttemptsValue.Name = "labelAttemptsValue";
            this.labelAttemptsValue.Size = new System.Drawing.Size(29, 31);
            this.labelAttemptsValue.TabIndex = 2;
            this.labelAttemptsValue.Text = "0";
            // 
            // buttonQ
            // 
            this.buttonQ.AutoSize = true;
            this.buttonQ.Enabled = false;
            this.buttonQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQ.Location = new System.Drawing.Point(10, 210);
            this.buttonQ.Name = "buttonQ";
            this.buttonQ.Size = new System.Drawing.Size(42, 35);
            this.buttonQ.TabIndex = 3;
            this.buttonQ.Text = "Q";
            this.buttonQ.UseVisualStyleBackColor = true;
            // 
            // buttonW
            // 
            this.buttonW.AutoSize = true;
            this.buttonW.Enabled = false;
            this.buttonW.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonW.Location = new System.Drawing.Point(58, 210);
            this.buttonW.Name = "buttonW";
            this.buttonW.Size = new System.Drawing.Size(42, 35);
            this.buttonW.TabIndex = 4;
            this.buttonW.Text = "W";
            this.buttonW.UseVisualStyleBackColor = true;
            // 
            // buttonE
            // 
            this.buttonE.AutoSize = true;
            this.buttonE.Enabled = false;
            this.buttonE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonE.Location = new System.Drawing.Point(106, 210);
            this.buttonE.Name = "buttonE";
            this.buttonE.Size = new System.Drawing.Size(42, 35);
            this.buttonE.TabIndex = 5;
            this.buttonE.Text = "E";
            this.buttonE.UseVisualStyleBackColor = true;
            // 
            // buttonR
            // 
            this.buttonR.AutoSize = true;
            this.buttonR.Enabled = false;
            this.buttonR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonR.Location = new System.Drawing.Point(154, 210);
            this.buttonR.Name = "buttonR";
            this.buttonR.Size = new System.Drawing.Size(42, 35);
            this.buttonR.TabIndex = 6;
            this.buttonR.Text = "R";
            this.buttonR.UseVisualStyleBackColor = true;
            // 
            // buttonT
            // 
            this.buttonT.AutoSize = true;
            this.buttonT.Enabled = false;
            this.buttonT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonT.Location = new System.Drawing.Point(202, 210);
            this.buttonT.Name = "buttonT";
            this.buttonT.Size = new System.Drawing.Size(42, 35);
            this.buttonT.TabIndex = 7;
            this.buttonT.Text = "T";
            this.buttonT.UseVisualStyleBackColor = true;
            // 
            // buttonY
            // 
            this.buttonY.AutoSize = true;
            this.buttonY.Enabled = false;
            this.buttonY.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonY.Location = new System.Drawing.Point(250, 210);
            this.buttonY.Name = "buttonY";
            this.buttonY.Size = new System.Drawing.Size(42, 35);
            this.buttonY.TabIndex = 8;
            this.buttonY.Text = "Y";
            this.buttonY.UseVisualStyleBackColor = true;
            // 
            // buttonU
            // 
            this.buttonU.AutoSize = true;
            this.buttonU.Enabled = false;
            this.buttonU.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonU.Location = new System.Drawing.Point(298, 210);
            this.buttonU.Name = "buttonU";
            this.buttonU.Size = new System.Drawing.Size(42, 35);
            this.buttonU.TabIndex = 9;
            this.buttonU.Text = "U";
            this.buttonU.UseVisualStyleBackColor = true;
            // 
            // buttonJ
            // 
            this.buttonJ.AutoSize = true;
            this.buttonJ.Enabled = false;
            this.buttonJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonJ.Location = new System.Drawing.Point(315, 251);
            this.buttonJ.Name = "buttonJ";
            this.buttonJ.Size = new System.Drawing.Size(42, 35);
            this.buttonJ.TabIndex = 16;
            this.buttonJ.Text = "J";
            this.buttonJ.UseVisualStyleBackColor = true;
            // 
            // buttonH
            // 
            this.buttonH.AutoSize = true;
            this.buttonH.Enabled = false;
            this.buttonH.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonH.Location = new System.Drawing.Point(267, 251);
            this.buttonH.Name = "buttonH";
            this.buttonH.Size = new System.Drawing.Size(42, 35);
            this.buttonH.TabIndex = 15;
            this.buttonH.Text = "H";
            this.buttonH.UseVisualStyleBackColor = true;
            // 
            // buttonG
            // 
            this.buttonG.AutoSize = true;
            this.buttonG.Enabled = false;
            this.buttonG.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonG.Location = new System.Drawing.Point(219, 251);
            this.buttonG.Name = "buttonG";
            this.buttonG.Size = new System.Drawing.Size(42, 35);
            this.buttonG.TabIndex = 14;
            this.buttonG.Text = "G";
            this.buttonG.UseVisualStyleBackColor = true;
            // 
            // buttonF
            // 
            this.buttonF.AutoSize = true;
            this.buttonF.Enabled = false;
            this.buttonF.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonF.Location = new System.Drawing.Point(171, 251);
            this.buttonF.Name = "buttonF";
            this.buttonF.Size = new System.Drawing.Size(42, 35);
            this.buttonF.TabIndex = 13;
            this.buttonF.Text = "F";
            this.buttonF.UseVisualStyleBackColor = true;
            // 
            // buttonD
            // 
            this.buttonD.AutoSize = true;
            this.buttonD.Enabled = false;
            this.buttonD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonD.Location = new System.Drawing.Point(123, 251);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(42, 35);
            this.buttonD.TabIndex = 12;
            this.buttonD.Text = "D";
            this.buttonD.UseVisualStyleBackColor = true;
            // 
            // buttonS
            // 
            this.buttonS.AutoSize = true;
            this.buttonS.Enabled = false;
            this.buttonS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonS.Location = new System.Drawing.Point(75, 251);
            this.buttonS.Name = "buttonS";
            this.buttonS.Size = new System.Drawing.Size(42, 35);
            this.buttonS.TabIndex = 11;
            this.buttonS.Text = "S";
            this.buttonS.UseVisualStyleBackColor = true;
            // 
            // buttonA
            // 
            this.buttonA.AutoSize = true;
            this.buttonA.Enabled = false;
            this.buttonA.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonA.Location = new System.Drawing.Point(27, 251);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(42, 35);
            this.buttonA.TabIndex = 10;
            this.buttonA.Text = "A";
            this.buttonA.UseVisualStyleBackColor = true;
            // 
            // buttonM
            // 
            this.buttonM.AutoSize = true;
            this.buttonM.Enabled = false;
            this.buttonM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonM.Location = new System.Drawing.Point(325, 292);
            this.buttonM.Name = "buttonM";
            this.buttonM.Size = new System.Drawing.Size(42, 35);
            this.buttonM.TabIndex = 23;
            this.buttonM.TabStop = false;
            this.buttonM.Text = "M";
            this.buttonM.UseVisualStyleBackColor = true;
            // 
            // buttonN
            // 
            this.buttonN.AutoSize = true;
            this.buttonN.Enabled = false;
            this.buttonN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonN.Location = new System.Drawing.Point(277, 292);
            this.buttonN.Name = "buttonN";
            this.buttonN.Size = new System.Drawing.Size(42, 35);
            this.buttonN.TabIndex = 22;
            this.buttonN.Text = "N";
            this.buttonN.UseVisualStyleBackColor = true;
            // 
            // buttonB
            // 
            this.buttonB.AutoSize = true;
            this.buttonB.Enabled = false;
            this.buttonB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonB.Location = new System.Drawing.Point(229, 292);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(42, 35);
            this.buttonB.TabIndex = 21;
            this.buttonB.Text = "B";
            this.buttonB.UseVisualStyleBackColor = true;
            // 
            // buttonV
            // 
            this.buttonV.AutoSize = true;
            this.buttonV.Enabled = false;
            this.buttonV.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonV.Location = new System.Drawing.Point(181, 292);
            this.buttonV.Name = "buttonV";
            this.buttonV.Size = new System.Drawing.Size(42, 35);
            this.buttonV.TabIndex = 20;
            this.buttonV.Text = "V";
            this.buttonV.UseVisualStyleBackColor = true;
            // 
            // buttonC
            // 
            this.buttonC.AutoSize = true;
            this.buttonC.Enabled = false;
            this.buttonC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonC.Location = new System.Drawing.Point(133, 292);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(42, 35);
            this.buttonC.TabIndex = 19;
            this.buttonC.Text = "C";
            this.buttonC.UseVisualStyleBackColor = true;
            // 
            // buttonX
            // 
            this.buttonX.AutoSize = true;
            this.buttonX.Enabled = false;
            this.buttonX.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX.Location = new System.Drawing.Point(85, 292);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(42, 35);
            this.buttonX.TabIndex = 18;
            this.buttonX.Text = "X";
            this.buttonX.UseVisualStyleBackColor = true;
            // 
            // buttonZ
            // 
            this.buttonZ.AutoSize = true;
            this.buttonZ.Enabled = false;
            this.buttonZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonZ.Location = new System.Drawing.Point(37, 292);
            this.buttonZ.Name = "buttonZ";
            this.buttonZ.Size = new System.Drawing.Size(42, 35);
            this.buttonZ.TabIndex = 17;
            this.buttonZ.Text = "Z";
            this.buttonZ.UseVisualStyleBackColor = true;
            // 
            // buttonI
            // 
            this.buttonI.AutoSize = true;
            this.buttonI.Enabled = false;
            this.buttonI.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonI.Location = new System.Drawing.Point(346, 210);
            this.buttonI.Name = "buttonI";
            this.buttonI.Size = new System.Drawing.Size(42, 35);
            this.buttonI.TabIndex = 24;
            this.buttonI.Text = "I";
            this.buttonI.UseVisualStyleBackColor = true;
            // 
            // buttonO
            // 
            this.buttonO.AutoSize = true;
            this.buttonO.Enabled = false;
            this.buttonO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonO.Location = new System.Drawing.Point(394, 210);
            this.buttonO.Name = "buttonO";
            this.buttonO.Size = new System.Drawing.Size(42, 35);
            this.buttonO.TabIndex = 25;
            this.buttonO.Text = "O";
            this.buttonO.UseVisualStyleBackColor = true;
            // 
            // buttonK
            // 
            this.buttonK.AutoSize = true;
            this.buttonK.Enabled = false;
            this.buttonK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonK.Location = new System.Drawing.Point(363, 251);
            this.buttonK.Name = "buttonK";
            this.buttonK.Size = new System.Drawing.Size(42, 35);
            this.buttonK.TabIndex = 26;
            this.buttonK.Text = "K";
            this.buttonK.UseVisualStyleBackColor = true;
            // 
            // buttonL1
            // 
            this.buttonL1.AutoSize = true;
            this.buttonL1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonL1.Enabled = false;
            this.buttonL1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonL1.Location = new System.Drawing.Point(16, 149);
            this.buttonL1.Name = "buttonL1";
            this.buttonL1.Size = new System.Drawing.Size(42, 35);
            this.buttonL1.TabIndex = 27;
            this.buttonL1.UseVisualStyleBackColor = false;
            this.buttonL1.Visible = false;
            // 
            // buttonL2
            // 
            this.buttonL2.AutoSize = true;
            this.buttonL2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonL2.Enabled = false;
            this.buttonL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonL2.Location = new System.Drawing.Point(64, 149);
            this.buttonL2.Name = "buttonL2";
            this.buttonL2.Size = new System.Drawing.Size(42, 35);
            this.buttonL2.TabIndex = 28;
            this.buttonL2.UseVisualStyleBackColor = false;
            this.buttonL2.Visible = false;
            // 
            // buttonL3
            // 
            this.buttonL3.AutoSize = true;
            this.buttonL3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonL3.Enabled = false;
            this.buttonL3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonL3.Location = new System.Drawing.Point(112, 149);
            this.buttonL3.Name = "buttonL3";
            this.buttonL3.Size = new System.Drawing.Size(42, 35);
            this.buttonL3.TabIndex = 29;
            this.buttonL3.UseVisualStyleBackColor = false;
            this.buttonL3.Visible = false;
            // 
            // buttonL4
            // 
            this.buttonL4.AutoSize = true;
            this.buttonL4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonL4.Enabled = false;
            this.buttonL4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonL4.Location = new System.Drawing.Point(160, 149);
            this.buttonL4.Name = "buttonL4";
            this.buttonL4.Size = new System.Drawing.Size(42, 35);
            this.buttonL4.TabIndex = 30;
            this.buttonL4.UseVisualStyleBackColor = false;
            this.buttonL4.Visible = false;
            // 
            // buttonL5
            // 
            this.buttonL5.AutoSize = true;
            this.buttonL5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonL5.Enabled = false;
            this.buttonL5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonL5.Location = new System.Drawing.Point(208, 149);
            this.buttonL5.Name = "buttonL5";
            this.buttonL5.Size = new System.Drawing.Size(42, 35);
            this.buttonL5.TabIndex = 31;
            this.buttonL5.UseVisualStyleBackColor = false;
            this.buttonL5.Visible = false;
            // 
            // buttonL6
            // 
            this.buttonL6.AutoSize = true;
            this.buttonL6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonL6.Enabled = false;
            this.buttonL6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonL6.Location = new System.Drawing.Point(256, 149);
            this.buttonL6.Name = "buttonL6";
            this.buttonL6.Size = new System.Drawing.Size(42, 35);
            this.buttonL6.TabIndex = 32;
            this.buttonL6.UseVisualStyleBackColor = false;
            this.buttonL6.Visible = false;
            // 
            // buttonL7
            // 
            this.buttonL7.AutoSize = true;
            this.buttonL7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonL7.Enabled = false;
            this.buttonL7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonL7.Location = new System.Drawing.Point(304, 149);
            this.buttonL7.Name = "buttonL7";
            this.buttonL7.Size = new System.Drawing.Size(42, 35);
            this.buttonL7.TabIndex = 33;
            this.buttonL7.UseVisualStyleBackColor = false;
            this.buttonL7.Visible = false;
            // 
            // buttonL8
            // 
            this.buttonL8.AutoSize = true;
            this.buttonL8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonL8.Enabled = false;
            this.buttonL8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonL8.Location = new System.Drawing.Point(352, 149);
            this.buttonL8.Name = "buttonL8";
            this.buttonL8.Size = new System.Drawing.Size(42, 35);
            this.buttonL8.TabIndex = 34;
            this.buttonL8.UseVisualStyleBackColor = false;
            this.buttonL8.Visible = false;
            // 
            // buttonP
            // 
            this.buttonP.AutoSize = true;
            this.buttonP.Enabled = false;
            this.buttonP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonP.Location = new System.Drawing.Point(442, 210);
            this.buttonP.Name = "buttonP";
            this.buttonP.Size = new System.Drawing.Size(42, 35);
            this.buttonP.TabIndex = 35;
            this.buttonP.Text = "P";
            this.buttonP.UseVisualStyleBackColor = true;
            // 
            // buttonL
            // 
            this.buttonL.AutoSize = true;
            this.buttonL.Enabled = false;
            this.buttonL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonL.Location = new System.Drawing.Point(411, 251);
            this.buttonL.Name = "buttonL";
            this.buttonL.Size = new System.Drawing.Size(42, 35);
            this.buttonL.TabIndex = 36;
            this.buttonL.Text = "L";
            this.buttonL.UseVisualStyleBackColor = true;
            // 
            // buttonL9
            // 
            this.buttonL9.AutoSize = true;
            this.buttonL9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonL9.Enabled = false;
            this.buttonL9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonL9.Location = new System.Drawing.Point(400, 149);
            this.buttonL9.Name = "buttonL9";
            this.buttonL9.Size = new System.Drawing.Size(42, 35);
            this.buttonL9.TabIndex = 37;
            this.buttonL9.UseVisualStyleBackColor = false;
            this.buttonL9.Visible = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(44, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(399, 55);
            this.labelTitle.TabIndex = 38;
            this.labelTitle.Text = "Hangman Online";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(158, 97);
            this.textBoxUserName.MaxLength = 20;
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(151, 20);
            this.textBoxUserName.TabIndex = 39;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(158, 131);
            this.textBoxPassword.MaxLength = 20;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(151, 20);
            this.textBoxPassword.TabIndex = 40;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(94, 100);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(58, 13);
            this.labelUserName.TabIndex = 41;
            this.labelUserName.Text = "User name";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(99, 131);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 42;
            this.labelPassword.Text = "Password";
            // 
            // buttonLogin
            // 
            this.buttonLogin.AutoSize = true;
            this.buttonLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(315, 97);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(97, 41);
            this.buttonLogin.TabIndex = 43;
            this.buttonLogin.Text = "Log in";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // listBoxGamePlayersList
            // 
            this.listBoxGamePlayersList.BackColor = System.Drawing.Color.Gainsboro;
            this.listBoxGamePlayersList.FormattingEnabled = true;
            this.listBoxGamePlayersList.Location = new System.Drawing.Point(494, 22);
            this.listBoxGamePlayersList.MultiColumn = true;
            this.listBoxGamePlayersList.Name = "listBoxGamePlayersList";
            this.listBoxGamePlayersList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxGamePlayersList.Size = new System.Drawing.Size(285, 121);
            this.listBoxGamePlayersList.TabIndex = 45;
            // 
            // textBoxWordGuess
            // 
            this.textBoxWordGuess.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWordGuess.Location = new System.Drawing.Point(37, 344);
            this.textBoxWordGuess.Name = "textBoxWordGuess";
            this.textBoxWordGuess.Size = new System.Drawing.Size(216, 31);
            this.textBoxWordGuess.TabIndex = 47;
            // 
            // buttonGuessWord
            // 
            this.buttonGuessWord.AutoSize = true;
            this.buttonGuessWord.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonGuessWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuessWord.Location = new System.Drawing.Point(259, 343);
            this.buttonGuessWord.Name = "buttonGuessWord";
            this.buttonGuessWord.Size = new System.Drawing.Size(125, 34);
            this.buttonGuessWord.TabIndex = 49;
            this.buttonGuessWord.Text = "Guess Word";
            this.buttonGuessWord.UseVisualStyleBackColor = true;
            this.buttonGuessWord.Click += new System.EventHandler(this.buttonGuessWord_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(494, 349);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(285, 23);
            this.buttonSend.TabIndex = 51;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxSendMessage
            // 
            this.textBoxSendMessage.Location = new System.Drawing.Point(494, 292);
            this.textBoxSendMessage.Multiline = true;
            this.textBoxSendMessage.Name = "textBoxSendMessage";
            this.textBoxSendMessage.Size = new System.Drawing.Size(285, 51);
            this.textBoxSendMessage.TabIndex = 50;
            // 
            // labelGamePlayersList
            // 
            this.labelGamePlayersList.AutoSize = true;
            this.labelGamePlayersList.Location = new System.Drawing.Point(495, 6);
            this.labelGamePlayersList.Name = "labelGamePlayersList";
            this.labelGamePlayersList.Size = new System.Drawing.Size(44, 13);
            this.labelGamePlayersList.TabIndex = 52;
            this.labelGamePlayersList.Text = "Players:";
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.buttonRegister);
            this.panelLogin.Controls.Add(this.labelTitle);
            this.panelLogin.Controls.Add(this.textBoxUserName);
            this.panelLogin.Controls.Add(this.textBoxPassword);
            this.panelLogin.Controls.Add(this.labelUserName);
            this.panelLogin.Controls.Add(this.labelPassword);
            this.panelLogin.Controls.Add(this.buttonLogin);
            this.panelLogin.Location = new System.Drawing.Point(7, 12);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(464, 231);
            this.panelLogin.TabIndex = 54;
            // 
            // buttonRegister
            // 
            this.buttonRegister.AutoSize = true;
            this.buttonRegister.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRegister.Location = new System.Drawing.Point(171, 180);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(56, 23);
            this.buttonRegister.TabIndex = 57;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // panelGamePlay
            // 
            this.panelGamePlay.Controls.Add(this.textBoxChat);
            this.panelGamePlay.Controls.Add(this.textBoxSendMessage);
            this.panelGamePlay.Controls.Add(this.labelGamePlayersList);
            this.panelGamePlay.Controls.Add(this.buttonLeaveGame);
            this.panelGamePlay.Controls.Add(this.buttonSend);
            this.panelGamePlay.Controls.Add(this.labelAttemptsLeft);
            this.panelGamePlay.Controls.Add(this.buttonGuessWord);
            this.panelGamePlay.Controls.Add(this.labelAttemptsValue);
            this.panelGamePlay.Controls.Add(this.textBoxWordGuess);
            this.panelGamePlay.Controls.Add(this.buttonQ);
            this.panelGamePlay.Controls.Add(this.buttonW);
            this.panelGamePlay.Controls.Add(this.listBoxGamePlayersList);
            this.panelGamePlay.Controls.Add(this.buttonE);
            this.panelGamePlay.Controls.Add(this.buttonL9);
            this.panelGamePlay.Controls.Add(this.buttonR);
            this.panelGamePlay.Controls.Add(this.buttonL);
            this.panelGamePlay.Controls.Add(this.buttonT);
            this.panelGamePlay.Controls.Add(this.buttonP);
            this.panelGamePlay.Controls.Add(this.buttonY);
            this.panelGamePlay.Controls.Add(this.buttonL8);
            this.panelGamePlay.Controls.Add(this.buttonU);
            this.panelGamePlay.Controls.Add(this.buttonL7);
            this.panelGamePlay.Controls.Add(this.buttonA);
            this.panelGamePlay.Controls.Add(this.buttonL6);
            this.panelGamePlay.Controls.Add(this.buttonS);
            this.panelGamePlay.Controls.Add(this.buttonL5);
            this.panelGamePlay.Controls.Add(this.buttonD);
            this.panelGamePlay.Controls.Add(this.buttonL4);
            this.panelGamePlay.Controls.Add(this.buttonF);
            this.panelGamePlay.Controls.Add(this.buttonL3);
            this.panelGamePlay.Controls.Add(this.buttonG);
            this.panelGamePlay.Controls.Add(this.buttonL2);
            this.panelGamePlay.Controls.Add(this.buttonH);
            this.panelGamePlay.Controls.Add(this.buttonL1);
            this.panelGamePlay.Controls.Add(this.buttonJ);
            this.panelGamePlay.Controls.Add(this.buttonK);
            this.panelGamePlay.Controls.Add(this.buttonZ);
            this.panelGamePlay.Controls.Add(this.buttonO);
            this.panelGamePlay.Controls.Add(this.buttonX);
            this.panelGamePlay.Controls.Add(this.buttonI);
            this.panelGamePlay.Controls.Add(this.buttonC);
            this.panelGamePlay.Controls.Add(this.buttonM);
            this.panelGamePlay.Controls.Add(this.buttonV);
            this.panelGamePlay.Controls.Add(this.buttonN);
            this.panelGamePlay.Controls.Add(this.buttonB);
            this.panelGamePlay.Location = new System.Drawing.Point(7, 249);
            this.panelGamePlay.Name = "panelGamePlay";
            this.panelGamePlay.Size = new System.Drawing.Size(792, 383);
            this.panelGamePlay.TabIndex = 55;
            this.panelGamePlay.Visible = false;
            // 
            // textBoxChat
            // 
            this.textBoxChat.AcceptsReturn = true;
            this.textBoxChat.Location = new System.Drawing.Point(494, 150);
            this.textBoxChat.Multiline = true;
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.ReadOnly = true;
            this.textBoxChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxChat.Size = new System.Drawing.Size(285, 136);
            this.textBoxChat.TabIndex = 53;
            // 
            // panelPortal
            // 
            this.panelPortal.Controls.Add(this.buttonInvite);
            this.panelPortal.Controls.Add(this.labelAvailablePlayers);
            this.panelPortal.Controls.Add(this.listView1);
            this.panelPortal.Controls.Add(this.labelYourStats);
            this.panelPortal.Controls.Add(this.labelPlayerName);
            this.panelPortal.Location = new System.Drawing.Point(692, 2);
            this.panelPortal.Name = "panelPortal";
            this.panelPortal.Size = new System.Drawing.Size(393, 442);
            this.panelPortal.TabIndex = 56;
            this.panelPortal.Visible = false;
            // 
            // buttonInvite
            // 
            this.buttonInvite.AutoSize = true;
            this.buttonInvite.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInvite.Location = new System.Drawing.Point(136, 397);
            this.buttonInvite.Name = "buttonInvite";
            this.buttonInvite.Size = new System.Drawing.Size(142, 34);
            this.buttonInvite.TabIndex = 4;
            this.buttonInvite.Text = "Invite for game";
            this.buttonInvite.UseVisualStyleBackColor = true;
            this.buttonInvite.Click += new System.EventHandler(this.buttonInvite_Click);
            // 
            // labelAvailablePlayers
            // 
            this.labelAvailablePlayers.AutoSize = true;
            this.labelAvailablePlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAvailablePlayers.Location = new System.Drawing.Point(18, 72);
            this.labelAvailablePlayers.Name = "labelAvailablePlayers";
            this.labelAvailablePlayers.Size = new System.Drawing.Size(131, 20);
            this.labelAvailablePlayers.TabIndex = 3;
            this.labelAvailablePlayers.Text = "Available Players:";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnPlayer,
            this.ColumnGuessings});
            this.listView1.Location = new System.Drawing.Point(41, 96);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(311, 295);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ColumnPlayer
            // 
            this.ColumnPlayer.Text = "Player";
            this.ColumnPlayer.Width = 170;
            // 
            // ColumnGuessings
            // 
            this.ColumnGuessings.Text = "Guessings (correct/total)";
            this.ColumnGuessings.Width = 137;
            // 
            // labelYourStats
            // 
            this.labelYourStats.AutoSize = true;
            this.labelYourStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYourStats.Location = new System.Drawing.Point(257, 17);
            this.labelYourStats.Name = "labelYourStats";
            this.labelYourStats.Size = new System.Drawing.Size(99, 24);
            this.labelYourStats.TabIndex = 1;
            this.labelYourStats.Text = "Your Stats:";
            this.labelYourStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerName.Location = new System.Drawing.Point(16, 10);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(181, 31);
            this.labelPlayerName.TabIndex = 0;
            this.labelPlayerName.Text = "PlayerXXXXX";
            // 
            // panelWaiting
            // 
            this.panelWaiting.Controls.Add(this.buttonChooseGameWord);
            this.panelWaiting.Controls.Add(this.textBoxChooseGameWord);
            this.panelWaiting.Controls.Add(this.labelWaiting);
            this.panelWaiting.Location = new System.Drawing.Point(477, 25);
            this.panelWaiting.Name = "panelWaiting";
            this.panelWaiting.Size = new System.Drawing.Size(193, 125);
            this.panelWaiting.TabIndex = 57;
            this.panelWaiting.Visible = false;
            // 
            // buttonChooseGameWord
            // 
            this.buttonChooseGameWord.Location = new System.Drawing.Point(62, 96);
            this.buttonChooseGameWord.Name = "buttonChooseGameWord";
            this.buttonChooseGameWord.Size = new System.Drawing.Size(75, 23);
            this.buttonChooseGameWord.TabIndex = 59;
            this.buttonChooseGameWord.Text = "Go";
            this.buttonChooseGameWord.UseVisualStyleBackColor = true;
            this.buttonChooseGameWord.Visible = false;
            this.buttonChooseGameWord.Click += new System.EventHandler(this.buttonChooseGameWord_Click);
            // 
            // textBoxChooseGameWord
            // 
            this.textBoxChooseGameWord.Location = new System.Drawing.Point(21, 73);
            this.textBoxChooseGameWord.MaxLength = 20;
            this.textBoxChooseGameWord.Name = "textBoxChooseGameWord";
            this.textBoxChooseGameWord.Size = new System.Drawing.Size(151, 20);
            this.textBoxChooseGameWord.TabIndex = 58;
            this.textBoxChooseGameWord.Visible = false;
            // 
            // labelWaiting
            // 
            this.labelWaiting.AutoSize = true;
            this.labelWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWaiting.Location = new System.Drawing.Point(12, 11);
            this.labelWaiting.Name = "labelWaiting";
            this.labelWaiting.Size = new System.Drawing.Size(161, 16);
            this.labelWaiting.TabIndex = 0;
            this.labelWaiting.Text = "Waiting for other players...";
            this.labelWaiting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1101, 638);
            this.Controls.Add(this.panelGamePlay);
            this.Controls.Add(this.panelWaiting);
            this.Controls.Add(this.panelPortal);
            this.Controls.Add(this.panelLogin);
            this.MaximizeBox = false;
            this.Name = "ClientForm";
            this.Text = "Hangman";
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelGamePlay.ResumeLayout(false);
            this.panelGamePlay.PerformLayout();
            this.panelPortal.ResumeLayout(false);
            this.panelPortal.PerformLayout();
            this.panelWaiting.ResumeLayout(false);
            this.panelWaiting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLeaveGame;
        private System.Windows.Forms.Label labelAttemptsLeft;
        private System.Windows.Forms.Label labelAttemptsValue;
        private System.Windows.Forms.Button buttonQ;
        private System.Windows.Forms.Button buttonW;
        private System.Windows.Forms.Button buttonE;
        private System.Windows.Forms.Button buttonR;
        private System.Windows.Forms.Button buttonT;
        private System.Windows.Forms.Button buttonY;
        private System.Windows.Forms.Button buttonU;
        private System.Windows.Forms.Button buttonJ;
        private System.Windows.Forms.Button buttonH;
        private System.Windows.Forms.Button buttonG;
        private System.Windows.Forms.Button buttonF;
        private System.Windows.Forms.Button buttonD;
        private System.Windows.Forms.Button buttonS;
        private System.Windows.Forms.Button buttonA;
        private System.Windows.Forms.Button buttonM;
        private System.Windows.Forms.Button buttonN;
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.Button buttonV;
        private System.Windows.Forms.Button buttonC;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Button buttonZ;
        private System.Windows.Forms.Button buttonI;
        private System.Windows.Forms.Button buttonO;
        private System.Windows.Forms.Button buttonK;
        private System.Windows.Forms.Button buttonL1;
        private System.Windows.Forms.Button buttonL2;
        private System.Windows.Forms.Button buttonL3;
        private System.Windows.Forms.Button buttonL4;
        private System.Windows.Forms.Button buttonL5;
        private System.Windows.Forms.Button buttonL6;
        private System.Windows.Forms.Button buttonL7;
        private System.Windows.Forms.Button buttonL8;
        private System.Windows.Forms.Button buttonP;
        private System.Windows.Forms.Button buttonL;
        private System.Windows.Forms.Button buttonL9;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.ListBox listBoxGamePlayersList;
        private System.Windows.Forms.TextBox textBoxWordGuess;
        private System.Windows.Forms.Button buttonGuessWord;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxSendMessage;
        private System.Windows.Forms.Label labelGamePlayersList;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Panel panelGamePlay;
        private System.Windows.Forms.Panel panelPortal;
        private System.Windows.Forms.Label labelPlayerName;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Label labelAvailablePlayers;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ColumnPlayer;
        private System.Windows.Forms.Label labelYourStats;
        private System.Windows.Forms.Button buttonInvite;
        private System.Windows.Forms.ColumnHeader ColumnGuessings;
        private System.Windows.Forms.Panel panelWaiting;
        private System.Windows.Forms.Button buttonChooseGameWord;
        private System.Windows.Forms.TextBox textBoxChooseGameWord;
        private System.Windows.Forms.Label labelWaiting;
        private System.Windows.Forms.TextBox textBoxChat;
    }
}

