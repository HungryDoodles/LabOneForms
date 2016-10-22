using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabOneForms
{
    public partial class MainForm : Form
    {
        double time = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void heartbeatTimer_Tick(object sender, EventArgs e)
        {
            time += 0.03;
            wavingProgressBar.Value = (int)(((Math.Sin(time) + 1) * 0.5) * 100);
        }
    }
}
