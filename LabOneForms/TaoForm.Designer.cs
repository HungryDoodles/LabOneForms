namespace LabOneForms
{
    partial class TaoForm
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
            this.controlGroupBox = new System.Windows.Forms.GroupBox();
            this.debugDataGridView = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxBoundsAction = new System.Windows.Forms.ComboBox();
            this.numericTimeDilation = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericBoundsAcceleration = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericDamping = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericGravityY = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericGravityX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericParticleLifetime = new System.Windows.Forms.NumericUpDown();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericMaxVelocity = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericBurst = new System.Windows.Forms.NumericUpDown();
            this.numericSpawnRate = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericSpawnerY = new System.Windows.Forms.NumericUpDown();
            this.numericSpawnerX = new System.Windows.Forms.NumericUpDown();
            this.openglContext = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.burstButton = new LabOneForms.CrazyButton();
            this.controlGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debugDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeDilation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBoundsAcceleration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDamping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGravityY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGravityX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericParticleLifetime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxVelocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBurst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpawnRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpawnerY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpawnerX)).BeginInit();
            this.SuspendLayout();
            // 
            // controlGroupBox
            // 
            this.controlGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlGroupBox.Controls.Add(this.debugDataGridView);
            this.controlGroupBox.Controls.Add(this.label10);
            this.controlGroupBox.Controls.Add(this.comboBoxBoundsAction);
            this.controlGroupBox.Controls.Add(this.numericTimeDilation);
            this.controlGroupBox.Controls.Add(this.label9);
            this.controlGroupBox.Controls.Add(this.numericBoundsAcceleration);
            this.controlGroupBox.Controls.Add(this.label8);
            this.controlGroupBox.Controls.Add(this.numericDamping);
            this.controlGroupBox.Controls.Add(this.label7);
            this.controlGroupBox.Controls.Add(this.numericGravityY);
            this.controlGroupBox.Controls.Add(this.label6);
            this.controlGroupBox.Controls.Add(this.numericGravityX);
            this.controlGroupBox.Controls.Add(this.label5);
            this.controlGroupBox.Controls.Add(this.numericParticleLifetime);
            this.controlGroupBox.Controls.Add(this.checkBoxActive);
            this.controlGroupBox.Controls.Add(this.label4);
            this.controlGroupBox.Controls.Add(this.numericMaxVelocity);
            this.controlGroupBox.Controls.Add(this.burstButton);
            this.controlGroupBox.Controls.Add(this.label3);
            this.controlGroupBox.Controls.Add(this.numericBurst);
            this.controlGroupBox.Controls.Add(this.numericSpawnRate);
            this.controlGroupBox.Controls.Add(this.label2);
            this.controlGroupBox.Controls.Add(this.label1);
            this.controlGroupBox.Controls.Add(this.numericSpawnerY);
            this.controlGroupBox.Controls.Add(this.numericSpawnerX);
            this.controlGroupBox.Location = new System.Drawing.Point(523, 13);
            this.controlGroupBox.Name = "controlGroupBox";
            this.controlGroupBox.Size = new System.Drawing.Size(518, 539);
            this.controlGroupBox.TabIndex = 1;
            this.controlGroupBox.TabStop = false;
            this.controlGroupBox.Text = "Control group box";
            // 
            // debugDataGridView
            // 
            this.debugDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.debugDataGridView.Location = new System.Drawing.Point(148, 19);
            this.debugDataGridView.Name = "debugDataGridView";
            this.debugDataGridView.Size = new System.Drawing.Size(359, 514);
            this.debugDataGridView.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 451);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Bounds action";
            // 
            // comboBoxBoundsAction
            // 
            this.comboBoxBoundsAction.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxBoundsAction.FormattingEnabled = true;
            this.comboBoxBoundsAction.Items.AddRange(new object[] {
            "Soft Reflect",
            "Hard Reflect",
            "Acceleration",
            "Kill",
            "Stop",
            "Ingore"});
            this.comboBoxBoundsAction.Location = new System.Drawing.Point(6, 467);
            this.comboBoxBoundsAction.Name = "comboBoxBoundsAction";
            this.comboBoxBoundsAction.Size = new System.Drawing.Size(130, 21);
            this.comboBoxBoundsAction.TabIndex = 23;
            this.comboBoxBoundsAction.Text = "Acceleration";
            this.comboBoxBoundsAction.SelectionChangeCommitted += new System.EventHandler(this.comboBoxBoundsAction_SelectionChangeCommited);
            // 
            // numericTimeDilation
            // 
            this.numericTimeDilation.DecimalPlaces = 2;
            this.numericTimeDilation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericTimeDilation.Location = new System.Drawing.Point(6, 428);
            this.numericTimeDilation.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericTimeDilation.Name = "numericTimeDilation";
            this.numericTimeDilation.Size = new System.Drawing.Size(130, 20);
            this.numericTimeDilation.TabIndex = 22;
            this.numericTimeDilation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTimeDilation.ValueChanged += new System.EventHandler(this.numericTimeDilation_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 412);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Time dilation";
            // 
            // numericBoundsAcceleration
            // 
            this.numericBoundsAcceleration.DecimalPlaces = 2;
            this.numericBoundsAcceleration.Location = new System.Drawing.Point(6, 389);
            this.numericBoundsAcceleration.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericBoundsAcceleration.Name = "numericBoundsAcceleration";
            this.numericBoundsAcceleration.Size = new System.Drawing.Size(130, 20);
            this.numericBoundsAcceleration.TabIndex = 20;
            this.numericBoundsAcceleration.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericBoundsAcceleration.ValueChanged += new System.EventHandler(this.numericBoundsAcceleration_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 373);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Bounds acceleration";
            // 
            // numericDamping
            // 
            this.numericDamping.DecimalPlaces = 2;
            this.numericDamping.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericDamping.Location = new System.Drawing.Point(6, 350);
            this.numericDamping.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDamping.Name = "numericDamping";
            this.numericDamping.Size = new System.Drawing.Size(130, 20);
            this.numericDamping.TabIndex = 18;
            this.numericDamping.Value = new decimal(new int[] {
            98,
            0,
            0,
            131072});
            this.numericDamping.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 334);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Damping";
            // 
            // numericGravityY
            // 
            this.numericGravityY.DecimalPlaces = 2;
            this.numericGravityY.Location = new System.Drawing.Point(75, 311);
            this.numericGravityY.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericGravityY.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.numericGravityY.Name = "numericGravityY";
            this.numericGravityY.Size = new System.Drawing.Size(61, 20);
            this.numericGravityY.TabIndex = 16;
            this.numericGravityY.Value = new decimal(new int[] {
            981,
            0,
            0,
            -2147352576});
            this.numericGravityY.ValueChanged += new System.EventHandler(this.numericGravityY_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Gravity";
            // 
            // numericGravityX
            // 
            this.numericGravityX.DecimalPlaces = 2;
            this.numericGravityX.Location = new System.Drawing.Point(6, 311);
            this.numericGravityX.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericGravityX.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.numericGravityX.Name = "numericGravityX";
            this.numericGravityX.Size = new System.Drawing.Size(62, 20);
            this.numericGravityX.TabIndex = 14;
            this.numericGravityX.ValueChanged += new System.EventHandler(this.numericGravityX_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Particle lifetime";
            // 
            // numericParticleLifetime
            // 
            this.numericParticleLifetime.DecimalPlaces = 2;
            this.numericParticleLifetime.Location = new System.Drawing.Point(6, 271);
            this.numericParticleLifetime.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericParticleLifetime.Name = "numericParticleLifetime";
            this.numericParticleLifetime.Size = new System.Drawing.Size(130, 20);
            this.numericParticleLifetime.TabIndex = 11;
            this.numericParticleLifetime.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericParticleLifetime.ValueChanged += new System.EventHandler(this.numericParticleLifetime_ValueChanged);
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Checked = true;
            this.checkBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActive.Location = new System.Drawing.Point(6, 19);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(56, 17);
            this.checkBoxActive.TabIndex = 10;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Max velocity";
            // 
            // numericMaxVelocity
            // 
            this.numericMaxVelocity.DecimalPlaces = 2;
            this.numericMaxVelocity.Location = new System.Drawing.Point(6, 231);
            this.numericMaxVelocity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericMaxVelocity.Name = "numericMaxVelocity";
            this.numericMaxVelocity.Size = new System.Drawing.Size(130, 20);
            this.numericMaxVelocity.TabIndex = 8;
            this.numericMaxVelocity.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericMaxVelocity.ValueChanged += new System.EventHandler(this.numericMaxVelocity_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Burst amount";
            // 
            // numericBurst
            // 
            this.numericBurst.Location = new System.Drawing.Point(6, 137);
            this.numericBurst.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericBurst.Name = "numericBurst";
            this.numericBurst.Size = new System.Drawing.Size(70, 20);
            this.numericBurst.TabIndex = 5;
            this.numericBurst.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericSpawnRate
            // 
            this.numericSpawnRate.DecimalPlaces = 2;
            this.numericSpawnRate.Location = new System.Drawing.Point(6, 98);
            this.numericSpawnRate.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericSpawnRate.Name = "numericSpawnRate";
            this.numericSpawnRate.Size = new System.Drawing.Size(130, 20);
            this.numericSpawnRate.TabIndex = 4;
            this.numericSpawnRate.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericSpawnRate.ValueChanged += new System.EventHandler(this.numericSpawnRate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Spawn rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Spawner position";
            // 
            // numericSpawnerY
            // 
            this.numericSpawnerY.DecimalPlaces = 2;
            this.numericSpawnerY.Location = new System.Drawing.Point(77, 59);
            this.numericSpawnerY.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericSpawnerY.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numericSpawnerY.Name = "numericSpawnerY";
            this.numericSpawnerY.Size = new System.Drawing.Size(59, 20);
            this.numericSpawnerY.TabIndex = 1;
            this.numericSpawnerY.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericSpawnerY.ValueChanged += new System.EventHandler(this.numericSpawnerY_ValueChanged);
            // 
            // numericSpawnerX
            // 
            this.numericSpawnerX.DecimalPlaces = 2;
            this.numericSpawnerX.Location = new System.Drawing.Point(6, 59);
            this.numericSpawnerX.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericSpawnerX.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numericSpawnerX.Name = "numericSpawnerX";
            this.numericSpawnerX.Size = new System.Drawing.Size(59, 20);
            this.numericSpawnerX.TabIndex = 0;
            this.numericSpawnerX.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericSpawnerX.ValueChanged += new System.EventHandler(this.numericSpawnerX_ValueChanged);
            // 
            // openglContext
            // 
            this.openglContext.AccumBits = ((byte)(0));
            this.openglContext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openglContext.AutoCheckErrors = false;
            this.openglContext.AutoFinish = false;
            this.openglContext.AutoMakeCurrent = true;
            this.openglContext.AutoSwapBuffers = true;
            this.openglContext.BackColor = System.Drawing.Color.Black;
            this.openglContext.ColorBits = ((byte)(32));
            this.openglContext.DepthBits = ((byte)(16));
            this.openglContext.Location = new System.Drawing.Point(13, 13);
            this.openglContext.Name = "openglContext";
            this.openglContext.Size = new System.Drawing.Size(504, 538);
            this.openglContext.StencilBits = ((byte)(0));
            this.openglContext.TabIndex = 2;
            this.openglContext.SizeChanged += new System.EventHandler(this.openglContext_SizeChanged);
            // 
            // burstButton
            // 
            this.burstButton.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(128)))), ((int)(((byte)(115)))));
            this.burstButton.ButtonText = "Burst!";
            this.burstButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.burstButton.Location = new System.Drawing.Point(6, 164);
            this.burstButton.Name = "burstButton";
            this.burstButton.NeutralColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.burstButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.burstButton.Size = new System.Drawing.Size(48, 48);
            this.burstButton.TabIndex = 7;
            this.burstButton.onButtonHit += new System.EventHandler(this.burstButton_onButtonHit);
            // 
            // TaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 563);
            this.Controls.Add(this.openglContext);
            this.Controls.Add(this.controlGroupBox);
            this.DoubleBuffered = true;
            this.Name = "TaoForm";
            this.Text = "TaoForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaoForm_FormClosing);
            this.Load += new System.EventHandler(this.TaoForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TaoForm_Paint);
            this.controlGroupBox.ResumeLayout(false);
            this.controlGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debugDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeDilation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBoundsAcceleration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDamping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGravityY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGravityX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericParticleLifetime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxVelocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBurst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpawnRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpawnerY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpawnerX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox controlGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericSpawnerY;
        private System.Windows.Forms.NumericUpDown numericSpawnerX;
        private System.Windows.Forms.NumericUpDown numericSpawnRate;
        private System.Windows.Forms.Label label2;
        private CrazyButton burstButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericBurst;
        private Tao.Platform.Windows.SimpleOpenGlControl openglContext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericMaxVelocity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericParticleLifetime;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.NumericUpDown numericGravityY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericGravityX;
        private System.Windows.Forms.NumericUpDown numericDamping;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericTimeDilation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericBoundsAcceleration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxBoundsAction;
        private System.Windows.Forms.DataGridView debugDataGridView;
    }
}