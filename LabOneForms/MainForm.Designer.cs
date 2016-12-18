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
            this.ClickerGameLaunchButton = new System.Windows.Forms.Button();
            this.particlesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ClickerGameLaunchButton
            // 
            this.ClickerGameLaunchButton.Location = new System.Drawing.Point(13, 13);
            this.ClickerGameLaunchButton.Name = "ClickerGameLaunchButton";
            this.ClickerGameLaunchButton.Size = new System.Drawing.Size(90, 23);
            this.ClickerGameLaunchButton.TabIndex = 0;
            this.ClickerGameLaunchButton.Text = "Clicker Game";
            this.ClickerGameLaunchButton.UseVisualStyleBackColor = true;
            this.ClickerGameLaunchButton.Click += new System.EventHandler(this.ClickerGameLaunchBitton_Click);
            // 
            // particlesButton
            // 
            this.particlesButton.Location = new System.Drawing.Point(12, 42);
            this.particlesButton.Name = "particlesButton";
            this.particlesButton.Size = new System.Drawing.Size(90, 23);
            this.particlesButton.TabIndex = 1;
            this.particlesButton.Text = "Particles";
            this.particlesButton.UseVisualStyleBackColor = true;
            this.particlesButton.Click += new System.EventHandler(this.particlesButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.particlesButton);
            this.Controls.Add(this.ClickerGameLaunchButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ClickerGameLaunchButton;
        private System.Windows.Forms.Button particlesButton;
    }
}