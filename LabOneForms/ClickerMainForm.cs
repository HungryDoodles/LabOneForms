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
using System.Media;

namespace LabOneForms
{
    public partial class ClickerGameMainForm : Form, ITickable, IControllable
    {
        ClickerGamePlayForm playForm;
        DifficultySettings difficulty = new DifficultySettings();
        bool running = false;
        Stopwatch gameStopwatch = new Stopwatch();
        SoundPlayer musicPlayer;
        int score = 0;
        
        public ClickerGameMainForm()
        {
            InitializeComponent();
            easyToolStripMenuItem1_Click(null, null);
            playForm = new ClickerGamePlayForm();
            playForm.crazyButton.onButtonHit += AddScore;
            playForm.Enabled = true;
            playForm.Show(this);
            easyToolStripMenuItem1_Click(null, null);
            musicPlayer = new SoundPlayer(Environment.CurrentDirectory + "\\Music\\Clicker.wav");
            musicPlayer.Load();
        }

        private void AddScore(object sender, EventArgs e)
        {
            if (!running) return;
            score += playForm.wavingProgressBar.Value;
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
            difficulty.speedMultiplier = 0.3;
            difficulty.time = 45.0;
            UpdateGameSettingsInfo();
        }
        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty.speedMultiplier = 0.45;
            difficulty.time = 30.0;
            UpdateGameSettingsInfo();
        }
        private void insaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty.speedMultiplier = 0.75;
            difficulty.time = 20.0;
            UpdateGameSettingsInfo();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            gameStopwatch.Reset();
            gameStopwatch.Start();
            running = true;
            score = 0;
            playForm.time = 0;
            playForm.timeDilation = difficulty.speedMultiplier;
            playForm.isAnimating = true;
            startButton.Enabled = false;
            difficultyMenuStrip.Enabled = false;
            stopButton.Enabled = true;
            if(musicPlayer.IsLoadCompleted) musicPlayer.Play();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            gameStopwatch.Stop();
            running = false;
            playForm.isAnimating = false;
            startButton.Enabled = true;
            difficultyMenuStrip.Enabled = true;
            stopButton.Enabled = false;
            musicPlayer.Stop();
        }

        public void Tick(double deltatime)
        {
            if (!running) return;

            double timeElapsed = gameStopwatch.Elapsed.TotalSeconds;
            if (timeElapsed >= difficulty.time)
            {
                timeElapsed = difficulty.time;
                Invoke((Action)delegate { stopButton_Click(null, null); }); 
            }
            BeginInvoke((Action)delegate { timeLabel.Text = "Time: " + (difficulty.time - timeElapsed).ToString("0.00"); });
            BeginInvoke((Action)delegate { scoreLabel.Text = "Score: " + score.ToString(); });
        }

        public void RecieveOwningController(Controller controller)
        {
            controller.GetTickMachine().AddTickable(this);
            playForm.RecieveOwningController(controller);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            running = false;
            stopButton_Click(null, null);
            playForm.Close();
            Dispose();
        }

        struct DifficultySettings
        {
            public double time;
            public double speedMultiplier;
        }
    }
}
