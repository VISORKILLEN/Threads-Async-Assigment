namespace Threads___Asynx_Assigment
{
    internal class Race
    {
        private List<Car> cars = new List<Car>();
        private static bool raceFinished = false;
        private static object lockObj = new object();

        public void Start()
        {
            cars.Add(new Car { Name = "Saab 900" });
            cars.Add(new Car { Name = "Nissan Skyline R32" });
            cars.Add(new Car { Name = "Mazda 3" });
            cars.Add(new Car { Name = "Bmw M4" });

            List<Thread> threads = new List<Thread>();

            // Create a thread for each car to run
            foreach (var car in cars)
            {
                Thread t = new Thread(() => car.Drive());
                threads.Add(t);
            }

            Console.WriteLine("Race starts!\n");

            // Start all the threads
            foreach (var t in threads)
            {
                t.Start();
            }
            
            var statusThread = new Thread(StatusLoop);
            statusThread.IsBackground = true;
            statusThread.Start();
        }

        // This method is called when a car finishes
        public static void OnCarFinished(Car car)
        {
            // Lock to ensure only one thread can access this block at a time
            lock (lockObj)
            {
                if (!raceFinished)
                {
                    raceFinished = true;
                    Console.WriteLine($"{car.Name} Won the race!");
                }
            }
        }

        // This method runs in a separate thread to listen for user input and display status
        private void StatusLoop()
        {
            while (!raceFinished)
            {
                string? input = Console.ReadLine();

                // If the user presses Enter without typing anything, or types "status", display the status of all cars
                if (input == "" || input.ToLower() == "status")
                {
                    Console.WriteLine("------------");
                    Console.WriteLine("Status");
                    foreach (var car in cars)
                    {
                        Console.WriteLine($"{car.Name}: {car.Distance:F2} km, {car.Speed} km/h");
                    }
                    Console.WriteLine("------------");
                }
            }

        }
    }
}
