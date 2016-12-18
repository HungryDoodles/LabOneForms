using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabOneForms
{
    public partial class CrazyButton : UserControl, ITickable
    {
        public string ButtonText {
            get { return theButton.Text; }
            set { theButton.Text = value; }
        }
        public event EventHandler onButtonHit;

        double blinkAlpha = 0.0;
        double blinkAlphaDropCoeff = 0.1;
        double BlinkAlphaDropCoeff {
            get { return blinkAlphaDropCoeff; }
            set { blinkAlphaDropCoeff = Helpers.Clamp(value, 0.01, 1.0); } }

        private Color neutralColor = Color.FromArgb(220, 230, 250);
        public Color NeutralColor
        {
            get{return neutralColor;}
            set{neutralColor = value;}
        }

        private Color blinkColor = Color.FromArgb(245, 128, 115);
        public Color BlinkColor
        {
            get{return blinkColor;}
            set{blinkColor = value;}
        }

        public CrazyButton()
        {
            InitializeComponent();
        }

        private void theButton_Click(object sender, EventArgs e)
        {
            onButtonHit?.Invoke(sender, e);
            TickMachine.lastSingleton.AddTickable(this);
            blinkAlpha = 1;
        }

        public void Tick(double deltatime)
        {
            theButton.BackColor = Helpers.Lerp(NeutralColor, BlinkColor, blinkAlpha);
            blinkAlpha = Helpers.Clamp(Helpers.Lerp(blinkAlpha, 0, Math.Pow(blinkAlphaDropCoeff, deltatime * 60)), 0, 1);
        }
    }
}
