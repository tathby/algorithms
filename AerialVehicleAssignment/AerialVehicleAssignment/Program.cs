namespace AerialVehicleAssignment
{
    //airplabe shtit

    public class AerialVehicle
    {
        public int CurrentAltitude { get; set; }
        public Engine engine { get; set; }
        public bool isFlying { get; set; } //default set to false
        public int MaxAltitude { get; set; }

        public AerialVehicle()
        {
            CurrentAltitude = 0;
            engine = new Engine();
            isFlying = false;
        }
        public string About()
        {
            return $"This {GetType().Name} has a max altitude of {MaxAltitude} ft.\n" +
                   $"It's current altitude is {CurrentAltitude} ft.\n" +
                   engine.About();
        }
        public void FlyDown() => FlyDown(1000);
        public void FlyDown(int feet)
        {
            if (isFlying)
            {
                CurrentAltitude -= feet;
                if (CurrentAltitude < 0)
                {
                    Console.WriteLine($"{GetType().Name} has crashed!");
                }
            }
        }
        public void FlyUp() => FlyUp(1000);
        public void FlyUp(int feet)
        {
            if (isFlying)
            {
                CurrentAltitude += feet;
                if (CurrentAltitude > MaxAltitude)
                {
                    CurrentAltitude = MaxAltitude;
                }
            }
        }
        public string StartEngine()
        {
            engine.Start();
            return $"{GetType().Name} engine started.";
        }
        public void StopEngine() => engine.Stop();
        public string TakeOff() //will not take off unless engine is started
        {
            if (!engine.isStarted)
            {
                return $"{GetType().Name} can't fly it's engine is not started.";
            }
            isFlying = true;
            return $"{GetType().Name} is flying";
        }
    }

    public class Engine
    {
        public bool isStarted { get; set; }
        public Engine() => isStarted = false;
        public string About() => $"Engine is {(isStarted ? "started" : "not started")}";
        public void Start() => isStarted = true;
        public void Stop() => isStarted = false;
    }

    class Airplane : AerialVehicle
    {
        public Airplane() => MaxAltitude = 41000;
    }

    class ToyPlane : Airplane
    {
        public bool isWoundUp { get; set; }
        public ToyPlane()
        {
            isWoundUp = false;
            MaxAltitude = 50;
        }
        public string About()
        {
            return $"This {GetType().Name} has a max altitude of {MaxAltitude} ft.\n" +
                   $"It's current altitude is {CurrentAltitude} ft.\n" +
                   engine.About() +
                   getWindUpString();
        }
        public string getWindUpString() => $"{GetType().Name} is {(isWoundUp ? "wound up" : "not wound up")}";
        public void StartEngine()
        {
            if (isWoundUp)
            {
                engine.Start();
            }
        }
        public string TakeOff()
        {
            if (!engine.isStarted)
            {
                return $"{GetType().Name} can't fly it's engine is not started.";
            }
            isFlying = true;
            return $"{GetType().Name} is flying";
        }
        public void UnWind()
        {
            isWoundUp = false;
            engine.Stop();
        }
        public void WindUp() => isWoundUp = true;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tester t = new Tester();
            t.Test();
        }

        class Tester
        {
            public void Test()
            {
                Console.WriteLine("Flying Vehicle Tester......................................................");
                Console.WriteLine("\nAirlplane.cs...............................................................");

                /*
                 * Airplane class tests
                 * many of the airplane class methods return a string we will write these to the console for testing
                 */
                Airplane ap = new Airplane();
                //Air plane should inherit from AerialVehicle
                Console.WriteLine(ap.About());
                /* Output AirplaneAbout:
                 * This OOPFlyingVehicle.Airplane has a max altitude of 41000 ft.
                 * It's current altitude is 0 ft.
                 * OOPFlyingVehicleMidterm.Airplane engine is not started
                 */

                Console.WriteLine("\nAireplaneTakeOffTests...............................................................");
                Console.WriteLine("\nCall ap.TakeOff():");
                //Test take off should fail engine isn't started
                Console.WriteLine(ap.TakeOff());  //Don't take off engine isn't started
                /* Output:
                 * OOPFlyingVehicleMidterm.Airplane can't fly it's engine is not started.
                 */
                Console.WriteLine("\nCall ap.StartEngine():");
                ap.StartEngine();
                Console.WriteLine(ap.TakeOff());  //take off engine is started
                /* Output:
                 * OOPFlyingVehicleMidterm.Airplane is flying
                 */

                //Fly up
                Console.WriteLine("\nFly up Tests...................................................................");
                Console.WriteLine("Call ap.FlyUp() fly to 1,000ft default");
                ap.FlyUp();    //Fly up tp 1,000 ft
                Console.WriteLine(ap.About());
                Console.WriteLine("\nCall ap.FlyUp(44000) Fly up to 45,000ft:");
                ap.FlyUp(44000);    //Fly up tp 45,000 ft shouldn't work
                Console.WriteLine(ap.About());
                Console.WriteLine("\nCall ap.FlyUp(44000) Fly up another 40,000ft shouldn't work");
                ap.FlyUp(40000);    //Fly up tp 41,000 ft shouldn't work
                Console.WriteLine(ap.About());
                /*
                 * Output:
                 */

                //Land
                Console.WriteLine("\nFly Down.................................................................");
                Console.WriteLine("Call ap.FlyDown(50000) Fly Down 50,000 ft");
                ap.FlyDown(50000);   //Land by floying down 50,000 ft = Crash and shouldn't work
                Console.WriteLine(ap.About());
                Console.WriteLine("Call ap.FlyDown(ap.CurrentAltitude) this should land");
                ap.FlyDown(ap.CurrentAltitude); //Land by flying down current altitiute
                Console.WriteLine(ap.About());

            }
        }
    }

}
