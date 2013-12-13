namespace HangmanServer
{
    partial class ServerForm
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
            this.labelStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStats = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnGames = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelPos1 = new System.Windows.Forms.Label();
            this.labelPos2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(9, 12);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(111, 24);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "Server is Off";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Turn on Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(12, 43);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 16);
            this.labelMessage.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPlayers,
            this.columnStats,
            this.columnGames});
            this.listView1.Location = new System.Drawing.Point(18, 54);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(245, 195);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            // 
            // columnPlayers
            // 
            this.columnPlayers.Text = "Player";
            this.columnPlayers.Width = 126;
            // 
            // columnStats
            // 
            this.columnStats.Text = "Stats";
            this.columnStats.Width = 72;
            // 
            // columnGames
            // 
            this.columnGames.Text = "Game";
            this.columnGames.Width = 41;
            // 
            // labelPos1
            // 
            this.labelPos1.AutoSize = true;
            this.labelPos1.Location = new System.Drawing.Point(255, 24);
            this.labelPos1.Name = "labelPos1";
            this.labelPos1.Size = new System.Drawing.Size(0, 13);
            this.labelPos1.TabIndex = 5;
            // 
            // labelPos2
            // 
            this.labelPos2.AutoSize = true;
            this.labelPos2.Location = new System.Drawing.Point(271, 247);
            this.labelPos2.Name = "labelPos2";
            this.labelPos2.Size = new System.Drawing.Size(0, 13);
            this.labelPos2.TabIndex = 6;
            this.labelPos2.Visible = false;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(274, 263);
            this.Controls.Add(this.labelPos2);
            this.Controls.Add(this.labelPos1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.button1);
            this.Name = "ServerForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnPlayers;
        private System.Windows.Forms.ColumnHeader columnGames;
        private System.Windows.Forms.ColumnHeader columnStats;
        private System.Windows.Forms.Label labelPos1;
        private System.Windows.Forms.Label labelPos2;
    }
}

