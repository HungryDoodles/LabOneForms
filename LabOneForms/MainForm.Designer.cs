namespace LabOneForms
{
    partial class MainForm
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
            this.scoreLabel = new System.Windows.Forms.Label();
            this.gameStateGroupBox = new System.Windows.Forms.GroupBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.gameOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentSpeedMultiplierLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.gameStateGroupBox.SuspendLayout();
            this.gameOptionsGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreLabel.Location = new System.Drawing.Point(6, 16);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(56, 20);
            this.scoreLabel.TabIndex = 0;
            this.scoreLabel.Text = "Score";
            // 
            // gameStateGroupBox
            // 
            this.gameStateGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameStateGroupBox.Controls.Add(this.timeLabel);
            this.gameStateGroupBox.Controls.Add(this.scoreLabel);
            this.gameStateGroupBox.Location = new System.Drawing.Point(12, 12);
            this.gameStateGroupBox.Name = "gameStateGroupBox";
            this.gameStateGroupBox.Size = new System.Drawing.Size(200, 51);
            this.gameStateGroupBox.TabIndex = 1;
            this.gameStateGroupBox.TabStop = false;
            this.gameStateGroupBox.Text = "Game State";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeLabel.Location = new System.Drawing.Point(150, 16);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timeLabel.Size = new System.Drawing.Size(47, 20);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.Text = "Time";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gameOptionsGroupBox
            // 
            this.gameOptionsGroupBox.Controls.Add(this.currentSpeedMultiplierLabel);
            this.gameOptionsGroupBox.Controls.Add(this.currentTimeLabel);
            this.gameOptionsGroupBox.Controls.Add(this.menuStrip1);
            this.gameOptionsGroupBox.Location = new System.Drawing.Point(13, 70);
            this.gameOptionsGroupBox.Name = "gameOptionsGroupBox";
            this.gameOptionsGroupBox.Size = new System.Drawing.Size(200, 74);
            this.gameOptionsGroupBox.TabIndex = 2;
            this.gameOptionsGroupBox.TabStop = false;
            this.gameOptionsGroupBox.Text = "Game Options";
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.AutoSize = true;
            this.currentTimeLabel.Location = new System.Drawing.Point(6, 40);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(30, 13);
            this.currentTimeLabel.TabIndex = 0;
            this.currentTimeLabel.Text = "Time";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 16);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(194, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem1,
            this.mediumToolStripMenuItem,
            this.hardToolStripMenuItem,
            this.insaneToolStripMenuItem});
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.easyToolStripMenuItem.Text = "Set Difficulty";
            // 
            // easyToolStripMenuItem1
            // 
            this.easyToolStripMenuItem1.Name = "easyToolStripMenuItem1";
            this.easyToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.easyToolStripMenuItem1.Text = "Easy";
            this.easyToolStripMenuItem1.Click += new System.EventHandler(this.easyToolStripMenuItem1_Click);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mediumToolStripMenuItem.Text = "Medium";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.mediumToolStripMenuItem_Click);
            // 
            // hardToolStripMenuItem
            // 
            this.hardToolStripMenuItem.Name = "hardToolStripMenuItem";
            this.hardToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hardToolStripMenuItem.Text = "Hard";
            this.hardToolStripMenuItem.Click += new System.EventHandler(this.hardToolStripMenuItem_Click);
            // 
            // insaneToolStripMenuItem
            // 
            this.insaneToolStripMenuItem.Name = "insaneToolStripMenuItem";
            this.insaneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.insaneToolStripMenuItem.Text = "Insane";
            this.insaneToolStripMenuItem.Click += new System.EventHandler(this.insaneToolStripMenuItem_Click);
            // 
            // currentSpeedMultiplierLabel
            // 
            this.currentSpeedMultiplierLabel.AutoSize = true;
            this.currentSpeedMultiplierLabel.Location = new System.Drawing.Point(6, 53);
            this.currentSpeedMultiplierLabel.Name = "currentSpeedMultiplierLabel";
            this.currentSpeedMultiplierLabel.Size = new System.Drawing.Size(81, 13);
            this.currentSpeedMultiplierLabel.TabIndex = 2;
            this.currentSpeedMultiplierLabel.Text = "Speed multiplier";
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.Location = new System.Drawing.Point(13, 151);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(200, 32);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stopButton.Enabled = false;
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stopButton.Location = new System.Drawing.Point(13, 190);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(200, 32);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop!";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 234);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.gameOptionsGroupBox);
            this.Controls.Add(this.gameStateGroupBox);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Scoreboard";
            this.gameStateGroupBox.ResumeLayout(false);
            this.gameStateGroupBox.PerformLayout();
            this.gameOptionsGroupBox.ResumeLayout(false);
            this.gameOptionsGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.GroupBox gameStateGroupBox;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.GroupBox gameOptionsGroupBox;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insaneToolStripMenuItem;
        private System.Windows.Forms.Label currentSpeedMultiplierLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
    }
}