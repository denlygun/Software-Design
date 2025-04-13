using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Aircraft
    {
        public string Name { get; set; }
        public bool IsTakingOff { get; set; }
        public CommandCentre CommandCentre { get; set; }

        public Aircraft(string name, CommandCentre commandCentre)
        {
            this.Name = name;
            this.CommandCentre = commandCentre;
        }

        public void RequestLanding()
        {
            Console.WriteLine($"Aircraft {this.Name} requests landing.");
            CommandCentre.LandAircraft(this);
        }

        public void RequestTakeOff()
        {
            Console.WriteLine($"Aircraft {this.Name} requests takeoff.");
            CommandCentre.TakeOffAircraft(this);
        }
    }

    class Runway
    {
        public readonly Guid Id = Guid.NewGuid();
        public Aircraft IsBusyWithAircraft { get; set; }

        public void HighlightRed()
        {
            Console.WriteLine($"Runway {this.Id} is busy!");
        }

        public void HighlightGreen()
        {
            Console.WriteLine($"Runway {this.Id} is free!");
        }
    }

    class CommandCentre
    {
        private List<Runway> _runways = new List<Runway>();

        public CommandCentre(Runway[] runways)
        {
            _runways.AddRange(runways);
        }

        public void LandAircraft(Aircraft aircraft)
        {
            foreach (var runway in _runways)
            {
                if (runway.IsBusyWithAircraft == null)
                {
                    Console.WriteLine($"Aircraft {aircraft.Name} is landing on runway {runway.Id}.");
                    runway.IsBusyWithAircraft = aircraft;
                    runway.HighlightRed();
                    return;
                }
            }
            Console.WriteLine($"No available runways for aircraft {aircraft.Name} to land.");
        }

        public void TakeOffAircraft(Aircraft aircraft)
        {
            foreach (var runway in _runways)
            {
                if (runway.IsBusyWithAircraft == aircraft)
                {
                    Console.WriteLine($"Aircraft {aircraft.Name} is taking off from runway {runway.Id}.");
                    runway.IsBusyWithAircraft = null;
                    runway.HighlightGreen();
                    return;
                }
            }
            Console.WriteLine($"Aircraft {aircraft.Name} is not currently on any runway.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var runway1 = new Runway();
            var runway2 = new Runway();

            var commandCentre = new CommandCentre(new Runway[] { runway1, runway2 });

            var aircraft1 = new Aircraft("Aircraft 1", commandCentre);
            var aircraft2 = new Aircraft("Aircraft 2", commandCentre);

            aircraft1.RequestLanding();

            aircraft2.RequestLanding();

            aircraft1.RequestTakeOff();

            aircraft2.RequestLanding();

            aircraft2.RequestTakeOff();
            Console.ReadKey();
        }
    }
}
