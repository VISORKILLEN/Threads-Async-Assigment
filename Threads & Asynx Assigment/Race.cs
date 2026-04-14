namespace Threads___Asynx_Assigment
{
    internal class Race
    {
        private List<Car> cars = new List<Car>();
        private bool raceFinished = false;
        private object lockObj = new object();

        public void Start()
        {
            cars.Add(new Car { Name = "Saab 900" });
            cars.Add(new Car { Name = "Nissan Skyline R32" });
            cars.Add(new Car { Name = "Mazda 3" });
            cars.Add(new Car { Name = "Bmw M4" });

            List<Thread> threads = new List<Thread>();

            foreach (var car in cars)
            {
                Thread t = new Thread(() => car.Drive(OnCarFinished));
                threads.Add(t);
            }

            Console.WriteLine("Race startss!\n");

            foreach (var t in threads)
            {
                t.Start();
            }

            new Thread(StatusLoop).Start();
        }

        private void OnCarFinished(Car car)
        {

        }

        private void StatusLoop()
        {

        }
    }
}
