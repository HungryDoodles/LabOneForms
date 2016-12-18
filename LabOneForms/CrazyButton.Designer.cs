namespace LabOneForms
{
    partial class CrazyButton
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.theButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // theButton
            // 
            this.theButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.theButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.theButton.Image = global::LabOneForms.Properties.Resources.Button;
            this.theButton.Location = new System.Drawing.Point(0, 0);
            this.theButton.Margin = new System.Windows.Forms.Padding(0);
            this.theButton.Name = "theButton";
            this.theButton.Size = new System.Drawing.Size(64, 64);
            this.theButton.TabIndex = 0;
            this.theButton.Text = "This is button";
            this.theButton.UseVisualStyleBackColor = true;
            this.theButton.Click += new System.EventHandler(this.theButton_Click);
            // 
            // CrazyButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.theButton);
            this.Name = "CrazyButton";
            this.Size = new System.Drawing.Size(64, 64);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button theButton;
    }
}
