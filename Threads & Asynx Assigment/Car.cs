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

            // Simulate the car driving until it reaches 5 km
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


        // Simulate random events that can happen to the car during the
        private void HandleEvent()
        {
            int roll = random.Next(1, 51);
            
            if (roll == 1)
            {
                Console.WriteLine($"{Name} is out of fuel, 15 sec stop to fuel the car.");
                Thread.Sleep(15000);
            }
            else if (roll <= 3)
            {
                Console.WriteLine($"{Name} got a flat tire, 10 sec stop to change tire.");
                Thread.Sleep(10000);
            }
            else if (roll <= 8)
            {
                Console.WriteLine($"{Name} got hit by a bird, 5 sec stop to clean the window");
                Thread.Sleep(5000);
            }
            else if (roll <= 18)
            {
                Speed -= 1;
                Console.WriteLine($"{Name} got enginge problems! Speed got reduced to {Speed} km/h");
            }
            else if (roll <= 26)
            {
                Speed += 2;
                Console.WriteLine($"{Name} got a speed boost! Speed increased to {Speed}");
            }
        }
    }
}
