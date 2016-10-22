namespace LabOneForms
{
    partial class PlayForm
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
            this.components = new System.ComponentModel.Container();
            this.wavingProgressBar = new System.Windows.Forms.ProgressBar();
            this.heartbeatTimer = new System.Windows.Forms.Timer(this.components);
            this.hardcoreButton = new System.Windows.Forms.Button();
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
            // heartbeatTimer
            // 
            this.heartbeatTimer.Enabled = true;
            this.heartbeatTimer.Interval = 16;
            this.heartbeatTimer.Tick += new System.EventHandler(this.heartbeatTimer_Tick);
            // 
            // hardcoreButton
            // 
            this.hardcoreButton.Location = new System.Drawing.Point(13, 53);
            this.hardcoreButton.Name = "hardcoreButton";
            this.hardcoreButton.Size = new System.Drawing.Size(61, 23);
            this.hardcoreButton.TabIndex = 1;
            this.hardcoreButton.TabStop = false;
            this.hardcoreButton.Text = "Press me";
            this.hardcoreButton.UseVisualStyleBackColor = true;
            // 
            // PlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.hardcoreButton);
            this.Controls.Add(this.wavingProgressBar);
            this.Name = "PlayForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Click Field";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ProgressBar wavingProgressBar;
        private System.Windows.Forms.Timer heartbeatTimer;
        public System.Windows.Forms.Button hardcoreButton;
    }
}

