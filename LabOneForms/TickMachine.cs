using System;
using System.Collections.Generic;
using System.Timers;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOneForms
{
    public class TickMachine : object
    {
        public static TickMachine lastSingleton;

        List<ITickable> tickables;
        Timer timer;

        public uint cleanupInterval = 120;
        uint cleanupCounter = 0;
        bool execInProgress = false;

        double deltatime = 0.016f;

        public TickMachine()
        {
            lastSingleton = this;
            tickables = new List<ITickable>();
            timer = new Timer();
            timer.Interval = 1;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!execInProgress) { Tick(); }
        }

        public void StartTicking()
        {
            timer.Start();
        }

        public void StopTicking()
        {
            timer.Stop();
        }

        void Tick()
        {
            System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Lowest;
            execInProgress = true;

            Stopwatch time = new Stopwatch();
            time.Start();

            List<ITickable> localTickables = new List<ITickable>(tickables);

            double currentDeltatime = Helpers.Clamp(deltatime, 0.016666666, 1.0);
            foreach (ITickable tickable in localTickables)
            {
                if(tickable != null) tickable.Tick(currentDeltatime);
            }

            time.Stop();
            deltatime = time.Elapsed.TotalSeconds;
            time = null;

            CleanCheck();
            execInProgress = false;

            System.Threading.Thread.Sleep(0);
        }

        public void AddTickable(ITickable tickable)
        {
            CleanList();
            if (!tickables.Exists(elem => elem == tickable))
                tickables.Add(tickable);
        }
        public void RemoveTickable(ITickable tickable)
        {
            tickables.RemoveAll(elem => elem == tickable);
        }

        public void CleanList() { tickables.RemoveAll(tickable => tickable == null); }
        public void CleanCheck()
        {
            if (execInProgress) return;
            if (cleanupCounter >= cleanupInterval)
            {
                cleanupCounter = 0;
                CleanList();
            }
            else ++cleanupCounter;
        }
    }

    public interface ITickable
    {
        void Tick(double deltatime);
    }
}
