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
    public partial class MainForm : Form, IControllable, ITickable
    {
        const double formTargetSize = 368;
        const double formSizeLerpSpeed = 0.08;
        double formCurrentSize = 0;

        Controller myController;

        public MainForm()
        {
            InitializeComponent();
        }

        public void RecieveOwningController(Controller controller)
        {
            myController = controller;
            controller.GetTickMachine().AddTickable(this);
        }

        public void Tick(double deltatime)
        {
            BeginInvoke((Action)delegate { Size = new Size((int)formCurrentSize, (int)formCurrentSize); });
            formCurrentSize = Helpers.SmoothingLerp(formCurrentSize, formTargetSize, formSizeLerpSpeed, deltatime);
        }

        private void ClickerGameLaunchBitton_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(ClickerGameMainForm));
        }

        private void particlesButton_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(TaoForm));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            myController.GetTickMachine().RemoveTickable(this);
        }

        private void ShowForm(Type formType)
        {
            if (!formType.IsSubclassOf(typeof(Form)) || !formType.GetInterfaces().Contains(typeof(IControllable)))
                throw new Exception("Bad form type");
            Hide();
            Form form = (Form)Activator.CreateInstance(formType);
            ((IControllable)form).RecieveOwningController(myController);
            form.Show(this);
            form.FormClosed += (delegate
            {
                formCurrentSize = 0.0;
                Show();
            });
        }
    }
}
