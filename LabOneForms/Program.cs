using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

// alexei_kasatkin@mail.ru

namespace LabOneForms
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Controller());
        }
    }

    public class Controller : ApplicationContext
    {
        TickMachine tickMachine;

        public TickMachine GetTickMachine() { return tickMachine; }

        public Controller()
        {
            tickMachine = new TickMachine();
            MainForm = new MainForm();
            ((IControllable)MainForm).RecieveOwningController(this);
            tickMachine.StartTicking(); // To prevent form tick before it initializes
        }

        public Controller(Form mainForm) : base(mainForm)
        {
            tickMachine = new TickMachine();
            ((IControllable)MainForm).RecieveOwningController(this);
            tickMachine.StartTicking();
        }
    }

    interface IControllable
    {
        void RecieveOwningController(Controller controller);
    }

    static class Helpers
    {
        internal static double Lerp(double a, double b, double alpha)
        {
            return a * (1 - alpha) + b * alpha;
        }

        internal static double SmoothingLerp(double value, double target, double alpha, double deltatime, double targetFramerate = 60.0)
        {
            return Lerp(value, target, Math.Pow(alpha, deltatime * targetFramerate));
        }

        internal static double Clamp(double num, double min, double max)
        {
            return num >= min ? (num <= max ? num : max) : min;
        }

        internal static Color Lerp(Color a, Color b, double alpha)
        {
            alpha = Clamp(alpha, 0, 1);
            return Color.FromArgb(
                (int)Clamp(Lerp(a.A, b.A, alpha), 0, 255),
                (int)Clamp(Lerp(a.R, b.R, alpha), 0, 255),
                (int)Clamp(Lerp(a.G, b.G, alpha), 0, 255),
                (int)Clamp(Lerp(a.B, b.B, alpha), 0, 255)
                );
        }
    }
}
