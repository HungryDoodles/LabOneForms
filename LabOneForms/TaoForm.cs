using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace LabOneForms
{
    public partial class TaoForm : Form, IControllable, ITickable
    {
        Controller myController;
        ParticleSystem ps;
        double particlesAccumulator = 0;
        double counter = 0;
        object drawLock = new object();
        double savedDeltatime = 0.016666;

        object workLock = new object();
        TaoFormSettings settings, savedSettings;

        public TaoForm()
        {
            InitializeComponent();
            openglContext.InitializeContexts();
            ps = new ParticleSystem(20000);
            ps.allowChangeSize = false;

            settings.Default();
            if (settings.LoadSettingsFromFile(Environment.CurrentDirectory + "TaoForm_settings.txt"))
                ApplySettings();
            
            savedSettings = settings;

            debugDataGridView.DataSource = new BindingList<Particle>(ps);
        }

        public void RecieveOwningController(Controller controller)
        {
            controller.GetTickMachine().AddTickable(this);
            myController = controller;
        }

        public void Tick(double deltatime)
        {
            savedDeltatime = deltatime; // Lengthen particles
            
            if (!checkBoxActive.Checked) return;

            particlesAccumulator += settings.spawnerRate * deltatime;

            int particlesToSpawn = (int)particlesAccumulator;
            particlesAccumulator -= particlesToSpawn;

            lock (workLock)
            {
                ps.SpawnRandomParticles(particlesToSpawn, settings.spawnerPos, settings.maxVelocity);

                ps.Tick(deltatime);
            }
            Invalidate();
        }

        static bool inited = false;
        private void TaoForm_Load(object sender, EventArgs e)
        {
            if (!inited) { Glut.glutInit(); inited = true; }
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_MULTISAMPLE);
            //Glut.glutSetOption(Gl.GL_SAMPLES, 16);

            Gl.glEnable(Gl.GL_MULTISAMPLE);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_DST_ALPHA);

            ResizeOpengl();
        }

        private void ResizeOpengl()
        {
            Gl.glViewport(0, 0, openglContext.Width, openglContext.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Gl.glOrtho(0, openglContext.Width, 0, openglContext.Height, -10, 10);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            ps.bounds.Size = new Vector(openglContext.Width, openglContext.Height);
        }

        private void openglContext_SizeChanged(object sender, EventArgs e)
        {
            ResizeOpengl();
        }

        private void Draw(double deltatime)
        {
            Vector[] points = ps.AsVectorArray(deltatime);

            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glBegin(Gl.GL_LINES);

            Gl.glColor3f(0.0f, 0.2f, 4.0f);
            Gl.glVertex2f(0, 0);
            Gl.glVertex2f((float)numericSpawnerX.Value, (float)((double)numericSpawnerY.Value + 10 * Math.Sin(counter += deltatime)));

            Gl.glColor3f(1.0f, 0.4f, 0.15f);
            foreach (var point in points) Gl.glVertex2d(point.X, point.Y);

            Gl.glEnd();

            openglContext.SwapBuffers();

            lock (workLock)
            {
                (debugDataGridView.DataSource as BindingList<Particle>)?.ResetBindings();
                //debugDataGridView.Update();
                debugDataGridView.Refresh();
            }
        }

        private void numericParticleLifetime_ValueChanged(object sender, EventArgs e)
        {
            ps.particleLifetime = (double)numericParticleLifetime.Value;
        }

        private void TaoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            myController.GetTickMachine().RemoveTickable(this);
            if (!settings.Equals(savedSettings))
            {
                settings.SaveSettingsToFile(Environment.CurrentDirectory + "TaoForm_settings.txt");
            }
        }

        private void ApplySettings()
        {
            numericSpawnerX.Value = (decimal)settings.spawnerPos.X;
            numericSpawnerY.Value = (decimal)settings.spawnerPos.Y;
            numericBoundsAcceleration.Value = (decimal)settings.boundsAcceleraion;
            numericDamping.Value = (decimal)settings.dampingFactor;
            numericGravityX.Value = (decimal)settings.gravity.X;
            numericGravityY.Value = (decimal)settings.gravity.Y;
            numericMaxVelocity.Value = (decimal)settings.maxVelocity;
            numericParticleLifetime.Value = (decimal)settings.particleLifetime;
            numericSpawnRate.Value = (decimal)settings.spawnerRate;
            numericTimeDilation.Value = (decimal)settings.timeDilation;
        }

        private void TaoForm_Paint(object sender, PaintEventArgs e)
        {
            Draw(savedDeltatime * 3);
            //Update();
            //System.Threading.Thread.Sleep(16);
        }
        private void burstButton_onButtonHit(object sender, EventArgs e)
        {
            particlesAccumulator += (double)numericBurst.Value;
        }
        private void numericGravityX_ValueChanged(object sender, EventArgs e)
        {
            ps.gravity.X = (double)numericGravityX.Value;
            settings.gravity.X = (double)numericGravityX.Value;
        }
        private void numericGravityY_ValueChanged(object sender, EventArgs e)
        {
            ps.gravity.Y = (double)numericGravityY.Value;
            settings.gravity.Y = (double)numericGravityY.Value;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ps.DampingFactor = (double)numericDamping.Value;
            settings.dampingFactor = (double)numericDamping.Value;
        }
        private void numericBoundsAcceleration_ValueChanged(object sender, EventArgs e)
        {
            ps.boundsAcceleraion = (double)numericBoundsAcceleration.Value;
            settings.timeDilation = (double)numericTimeDilation.Value;
        }
        private void numericTimeDilation_ValueChanged(object sender, EventArgs e)
        {
            ps.timeDilation = (double)numericTimeDilation.Value;
            settings.timeDilation = (double)numericTimeDilation.Value;
        }
        private void comboBoxBoundsAction_SelectionChangeCommited(object sender, EventArgs e)
        {
            switch (comboBoxBoundsAction.SelectedText)
            {
                case "Soft Reflect":
                    settings.boundsAction = ParticleSystemBoundActionEnum.SoftReflect;
                    ps.boundsAction = ParticleSystemBoundActionEnum.SoftReflect;
                    break;
                case "Hard Reflect":
                    settings.boundsAction = ParticleSystemBoundActionEnum.HardReflect;
                    ps.boundsAction = ParticleSystemBoundActionEnum.HardReflect;
                    break;
                case "Acceleration":
                    settings.boundsAction = ParticleSystemBoundActionEnum.Acceleration;
                    ps.boundsAction = ParticleSystemBoundActionEnum.Acceleration;
                    break;
                case "Kill":
                    settings.boundsAction = ParticleSystemBoundActionEnum.Kill;
                    ps.boundsAction = ParticleSystemBoundActionEnum.Kill;
                    break;
                case "Stop":
                    settings.boundsAction = ParticleSystemBoundActionEnum.Stop;
                    ps.boundsAction = ParticleSystemBoundActionEnum.Stop;
                    break;
                case "Ingore":
                    settings.boundsAction = ParticleSystemBoundActionEnum.Ingore;
                    ps.boundsAction = ParticleSystemBoundActionEnum.Ingore;
                    break;
            }
        }
        private void numericSpawnerX_ValueChanged(object sender, EventArgs e)
        {
            settings.spawnerPos.X = (double)numericSpawnerX.Value;
        }
        private void numericSpawnerY_ValueChanged(object sender, EventArgs e)
        {
            settings.spawnerPos.Y = (double)numericSpawnerY.Value;
        }
        private void numericSpawnRate_ValueChanged(object sender, EventArgs e)
        {
            settings.spawnerRate = (double)numericSpawnRate.Value;
        }
        private void numericMaxVelocity_ValueChanged(object sender, EventArgs e)
        {
            settings.maxVelocity = (double)numericMaxVelocity.Value;
        }
    }

    struct TaoFormSettings
    {
        public Vector spawnerPos;
        public double spawnerRate;
        public double maxVelocity;
        public Vector gravity;
        public double timeDilation;
        public double boundsAcceleraion;
        public ParticleSystemBoundActionEnum boundsAction;
        public double particleLifetime;
        public double dampingFactor;

        public TaoFormSettings Default()
        {
            spawnerPos = new Vector(50, 50);
            spawnerRate = 3.0;
            maxVelocity = 100.0;
            gravity = new Vector(0, -9.81);
            timeDilation = 1.0;
            boundsAcceleraion = 90.0;
            particleLifetime = 15.0;
            boundsAction = ParticleSystemBoundActionEnum.Acceleration;
            dampingFactor = 0.98;
            return this;
        }

        public bool LoadSettingsFromFile(string filename)
        {
            if (!System.IO.File.Exists(filename))
                return false;

            var file = new System.IO.StreamReader(filename);
            string settingsString = file.ReadToEnd();
            string errorMessage = "";

            bool success = true;
            Match spawnerPosMatch = Regex.Match(settingsString, @"(?<=[Ss]pawner [Pp]os)(((\s*)-?\d+([\.,]\d+)*)[ ]+((\s*)-?\d+([\.,]\d+)*))(?=[\s;])"); //Group 2,4; 5,7
            success &= spawnerPosMatch.Success;
            success &= double.TryParse(spawnerPosMatch.Groups[2].Value, out spawnerPos.X);
            success &= double.TryParse(spawnerPosMatch.Groups[5].Value, out spawnerPos.Y);
            if (!success) errorMessage += "spawnerPosMatch:Bad groups concat " + spawnerPosMatch.Groups[2].Value + " " + spawnerPosMatch.Groups[5].Value + " in match " + spawnerPosMatch.Value + Environment.NewLine;

            success = true;
            Match gravityMatch = Regex.Match(settingsString, @"(?<=[Gg]ravity)(((\s*)-?\d+([\.,]\d+)*)[ ]+((\s*)-?\d+([\.,]\d+)*))(?=[\s;])");
            success &= gravityMatch.Success;
            success &= double.TryParse(gravityMatch.Groups[2].Value, out gravity.X);
            success &= double.TryParse(gravityMatch.Groups[5].Value, out gravity.Y);
            if (!success) errorMessage += "gravityMatch:Bad groups concat " + gravityMatch.Groups[2].Value + " " + gravityMatch.Groups[5].Value + " in match " + gravityMatch.Value + Environment.NewLine;

            success = true;
            Match spawnerRateMatch = Regex.Match(settingsString, @"(?<=[Ss]pawner [Rr]ate)((\s*)-?\d+([\.,]\d+)*)(?=[\s;])"); // Gr 1, 3
            success &= spawnerRateMatch.Success;
            success &= double.TryParse(spawnerRateMatch.Value, out spawnerRate);
            if (!success) errorMessage += "spawnerRateMatch:Bad group " + spawnerRateMatch.Groups[1].Value + " in match " + spawnerRateMatch.Value + Environment.NewLine;

            success = true;
            Match maxVelocityMatch = Regex.Match(settingsString, @"(?<=[Mm]ax [Vv]elocity)((\s*)-?\d+([\.,]\d+)*)(?=[\s;])");
            success &= maxVelocityMatch.Success;
            success &= double.TryParse(maxVelocityMatch.Value, out maxVelocity);
            if (!success) errorMessage += "maxVelocityMatch:Bad group " + maxVelocityMatch.Groups[1].Value + " in match " + maxVelocityMatch.Value + Environment.NewLine;

            success = true;
            Match timeDilationMatch = Regex.Match(settingsString, @"(?<=[Tt]ime [Dd]ilation)((\s*)-?\d+([\.,]\d+)*)(?=[\s;])");
            success &= timeDilationMatch.Success;
            success &= double.TryParse(timeDilationMatch.Value, out timeDilation);
            if (!success) errorMessage += "timeDilationMatch:Bad group " + timeDilationMatch.Groups[1].Value + " in match " + timeDilationMatch.Value + Environment.NewLine;

            success = true;
            Match boundsAcceleraionMatch = Regex.Match(settingsString, @"(?<=[Bb]ounds [Aa]cceleration)((\s*)-?\d+([\.,]\d+)*)(?=[\s;])");
            success &= boundsAcceleraionMatch.Success;
            success &= double.TryParse(boundsAcceleraionMatch.Value, out boundsAcceleraion);
            if (!success) errorMessage += "boundsAcceleraionMatch:Bad group " + boundsAcceleraionMatch.Groups[1].Value + " in match " + boundsAcceleraionMatch.Value + Environment.NewLine;

            success = true;
            Match particleLifetimeMatch = Regex.Match(settingsString, @"(?<=[Pp]article [Ll]ifetime)((\s*)-?\d+([\.,]\d+)*)(?=[\s;])");
            success &= particleLifetimeMatch.Success;
            success &= double.TryParse(particleLifetimeMatch.Value, out particleLifetime);
            if (!success) errorMessage += "particleLifetimeMatch:Bad group " + particleLifetimeMatch.Groups[1].Value + " in match " + particleLifetimeMatch.Value + Environment.NewLine;

            success = true;
            Match dampingFactorMatch = Regex.Match(settingsString, @"(?<=[Dd]amping [Ff]actor)((\s*)-?\d+([\.,]\d+)*)(?=[\s;])");
            success &= dampingFactorMatch.Success;
            success &= double.TryParse(dampingFactorMatch.Value, out dampingFactor);
            if (!success) errorMessage += "dampingFactorMatch:Bad group " + dampingFactorMatch.Groups[1].Value + " in match " + dampingFactorMatch.Value + Environment.NewLine;

            success = true;
            Match boundsActionMatch = Regex.Match(settingsString, @"(?<=[Bb]ounds [Aa]ction )((SoftReflect)|(HardReflect)|(Acceleration)|(Kill)|(Stop)|(Ignore))(?=[\s;])");//Gr 1
            success &= dampingFactorMatch.Success;
            switch (boundsActionMatch.Groups[1].Value)
            {
                case "SoftReflect":
                    boundsAction = ParticleSystemBoundActionEnum.SoftReflect;
                    break;
                case "HardReflect":
                    boundsAction = ParticleSystemBoundActionEnum.HardReflect;
                    break;
                case "Acceleration":
                    boundsAction = ParticleSystemBoundActionEnum.Acceleration;
                    break;
                case "Kill":
                    boundsAction = ParticleSystemBoundActionEnum.Kill;
                    break;
                case "Stop":
                    boundsAction = ParticleSystemBoundActionEnum.Stop;
                    break;
                case "Ignore":
                    boundsAction = ParticleSystemBoundActionEnum.Ingore;
                    break;
                default:
                    errorMessage += "boundsActionMatch:Unknown bounds action: " + boundsActionMatch.Groups[1].Value + Environment.NewLine;
                    success = false;
                    break;
            }
            if (errorMessage != "")
            {
                file.Close();
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            file.Close();
            return true;
        }

        public bool SaveSettingsToFile(string filename)
        {
            System.IO.StreamWriter file;
            try
            {
                file = new System.IO.StreamWriter(filename);
            }
            catch { return false; }

            file.Write("Spawner Pos " + spawnerPos.X.ToString() + " " + spawnerPos.Y.ToString() + ";" + Environment.NewLine);
            file.Write("Gravity " + gravity.X.ToString() + " " + gravity.Y.ToString() + ";" + Environment.NewLine);
            file.Write("Spawner Rate " + spawnerRate.ToString() + ";" + Environment.NewLine);
            file.Write("Max Velocity " + maxVelocity.ToString() + ";" + Environment.NewLine);
            file.Write("Time Dilation " + timeDilation.ToString() + ";" + Environment.NewLine);
            file.Write("Bounds Acceleration " + boundsAcceleraion.ToString() + ";" + Environment.NewLine);
            file.Write("Particle Lifetime " + particleLifetime.ToString() + ";" + Environment.NewLine);
            file.Write("Damping Factor " + dampingFactor.ToString() + ";" + Environment.NewLine);
            file.Write("Bounds Action " + boundsAction.ToString() + ";" + Environment.NewLine);

            file.Close();

            return true;
        }
    }
}
