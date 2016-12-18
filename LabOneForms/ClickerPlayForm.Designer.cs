namespace LabOneForms
{
    partial class ClickerGamePlayForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.wavingProgressBar = new System.Windows.Forms.ProgressBar();
            this.crazyButton = new LabOneForms.CrazyButton();
            this.SuspendLayout();
            // 
            // wavingProgressBar
            // 
            this.wavingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wavingProgressBar.Location = new System.Drawing.Point(13, 13);
            this.wavingProgressBar.Name = "wavingProgressBar";
            this.wavingProgressBar.Size = new System.Drawing.Size(259, 23);
            this.wavingProgressBar.Step = 1;
            this.wavingProgressBar.TabIndex = 0;
            // 
            // crazyButton
            // 
            this.crazyButton.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(12)))), ((int)(((byte)(8)))));
            this.crazyButton.ButtonText = "Hit me!";
            this.crazyButton.Location = new System.Drawing.Point(12, 42);
            this.crazyButton.Name = "crazyButton";
            this.crazyButton.NeutralColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.crazyButton.Size = new System.Drawing.Size(48, 48);
            this.crazyButton.TabIndex = 2;
            // 
            // ClickerGamePlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.crazyButton);
            this.Controls.Add(this.wavingProgressBar);
            this.Name = "ClickerGamePlayForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Click Field";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ProgressBar wavingProgressBar;
        public CrazyButton crazyButton;
    }
}

