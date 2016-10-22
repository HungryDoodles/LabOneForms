using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace LabOneForms
{
    public partial class MainForm : Form
    {
        PlayForm playForm;
        DifficultySettings difficulty = new DifficultySettings();
        Timer heartbeatTimer = new Timer();
        bool running = false;
        Stopwatch gameStopwatch = new Stopwatch();
        int score = 0;
        

        public MainForm()
        {
            InitializeComponent();
            easyToolStripMenuItem1_Click(null, null);
            heartbeatTimer.Interval = 16;
            heartbeatTimer.Tick += Tick;
            playForm = new PlayForm();
            playForm.hardcoreButton.Click += AddScore;
            playForm.Show();
            easyToolStripMenuItem1_Click(null, null);
        }

        private void AddScore(object sender, EventArgs e)
        {
            if (!running) return;
            score += playForm.wavingProgressBar.Value;
        }

        private void Tick(object sender, EventArgs e)
        {
            double timeLeft = gameStopwatch.ElapsedMilliseconds / 1000.0;
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                stopButton_Click(null, null);
            }
            timeLabel.Text = "Time: " + (difficulty.time - timeLeft).ToString("0.00");
            scoreLabel.Text = "Score: " + score.ToString();
        }

        void UpdateGameSettingsInfo()
        {
            currentTimeLabel.Text = "Time: " + difficulty.time.ToString();
            currentSpeedMultiplierLabel.Text = "Speed multiplier: " + difficulty.speedMultiplier.ToString();
        }

        private void easyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            difficulty.speedMultiplier = 0.2;
            difficulty.time = 60.0;
            UpdateGameSettingsInfo();
        }
        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty.speedMultiplier = 0.25;
            difficulty.time = 45.0;
            UpdateGameSettingsInfo();
        }
        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty.speedMultiplier = 0.5;
            difficulty.time = 30.0;
            UpdateGameSettingsInfo();
        }
        private void insaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty.speedMultiplier = 2.0;
            difficulty.time = 20.0;
            UpdateGameSettingsInfo();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            gameStopwatch.Reset();
            gameStopwatch.Start();
            heartbeatTimer.Enabled = true;
            running = true;
            score = 0;
            playForm.isAnimating = true;
            startButton.Enabled = false;
            difficultyMenuStrip.Enabled = false;
            stopButton.Enabled = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            gameStopwatch.Stop();
            heartbeatTimer.Enabled = false;
            running = false;
            playForm.isAnimating = false;
            startButton.Enabled = true;
            difficultyMenuStrip.Enabled = true;
            stopButton.Enabled = false;
        }

        
    }

    struct DifficultySettings
    {
        public double time;
        public double speedMultiplier;
    }
}
