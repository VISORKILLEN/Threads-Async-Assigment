using System;
using System.Collections.Generic;
using System.Text;

namespace Threads___Asynx_Assigment
{
    internal class Car
    {
        public string? Name { get; set; }
        public double Speed { get; set; } = 120;
        public double Distance { get; set; } = 0;
        public bool Finished { get; set; } = false;

        private static Random random = new Random();

        public void Drive(Action<Car> onFinish)
        {
            int seconds = 0;

            Console.WriteLine($"{Name} starts!");

            while (Distance < 5)
            {
                Thread.Sleep(1000);
                seconds++;

                Distance += Speed / 3600.0;

                if (seconds % 10 == 0)
                {
                    HandleEvent();
                }
            }

            Finished = true;
            Console.WriteLine($"{Name} finished!");

            onFinish(this);
        }

        private void HandleEvent()
        {
            

        }

    }
}
