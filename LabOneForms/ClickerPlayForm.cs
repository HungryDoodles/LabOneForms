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
    public partial class ClickerGamePlayForm : Form, ITickable, IControllable
    {
        const double buttonPathMargin = 50.0;
        const double minFormSize = 100.0;
        const double maxFormSize = 350.0;
        public double time = 0;
        public double timeDilation = 1.0;
        public bool isAnimating = false;
        
        public ClickerGamePlayForm()
        {
            InitializeComponent();
        }

        void AnimateForm(double time)
        {
            double alpha = (Math.Sin(time) + 1) * 0.5;
            //animate Slider and Form size
            BeginInvoke((Action) delegate { wavingProgressBar.Value = (int)(alpha * 100); });
            double formScale = Helpers.Lerp(minFormSize, maxFormSize, alpha);
            BeginInvoke((Action) delegate { Size = new Size((int)formScale, (int)formScale); });
            //animate button path
            Point newButtonPoint = 
                new Point(
                    (int)Helpers.Lerp(
                        buttonPathMargin,
                        Size.Width - buttonPathMargin*2, 
                        Math.Cos(time * 1.70) * 0.5 + 0.5),
                    (int)Helpers.Lerp(
                        buttonPathMargin, 
                        Size.Height - buttonPathMargin*2, 
                        Math.Sin(time * 1.53) * 0.5 + 0.5)
                        );
            BeginInvoke((Action)delegate { crazyButton.Location = newButtonPoint; });
        }

        public void Tick(double deltaTime)
        {
            time += 0.06 * timeDilation;
            if (isAnimating) AnimateForm(time);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            isAnimating = false;
        }

        public void RecieveOwningController(Controller controller)
        {
            controller.GetTickMachine().AddTickable(this);
        }
    }
}
