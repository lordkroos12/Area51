using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51
{
    internal class Class1
    {

        private int currentFloor = 1;
        public List<int> requests = new List<int>();
        public List<int> requestGetPassenger = new List<int>();
        public List<Agent> agents = new List<Agent>();
        bool reachedDestination = false;
        public  bool isAvailable = true;
        bool getFirstPassenger = false;

        public void Request(Agent agent)
        {
            isAvailable = false;
            agents.Add(agent);
            requestGetPassenger.Add(agent.CurrentFloor);
            requests.Add(agent.TargetFloor);
        }
        public void MoveWithoutPassenger() 
        {
            int destination = requestGetPassenger[0];
            if (destination > currentFloor)
            {
                Thread.Sleep(1000);
                currentFloor++;
                Console.WriteLine($"Moving up to pick up passenger {agents[0].Name} from Floor {destination}...");
            }
            else if (destination < currentFloor)
            {
                Thread.Sleep(1000);
                currentFloor--;
                Console.WriteLine($"Moving down to pick up passenger {agents[0].Name} from Floor {destination}...");
            }
            else
            {
                reachedDestination = true;
                Console.WriteLine($"Elevator has reached its destination to pick up the passenger {agents[0].Name}.");
                requestGetPassenger.RemoveAt(0);
            }
        }
        public void Move()
        {
            if (!getFirstPassenger)
            {
                while (!reachedDestination)
                {
                    MoveWithoutPassenger();
                }
                reachedDestination = false;
            }
            getFirstPassenger = true;
            if (requests.Count == 0)
            {
                Console.WriteLine("Elevator is idle.");
                return;
            }

            int destination = requests[0];
            if (destination > currentFloor)
            {
                Thread.Sleep(1000);
                currentFloor++;
                Console.WriteLine($"Moving for {agents[0].Name} up to Floor {destination}...");
            }
            else if (destination < currentFloor)
            {
                Thread.Sleep(1000);
                currentFloor--;
                Console.WriteLine($"Moving for {agents[0].Name} down to Floor {destination}...");
            }
            else
            {
                if (currentFloor == 2 && agents[0].SecurityLevel == "G")
                {
                    Console.WriteLine($"Elevator reached its destination!But {agents[0].Name} doesn't have rights!Choosing new floor:");
                    int num = requests[0];
                    while (requests[0] == num)
                    {
                        requests[0] = Random.Shared.Next(1, 4);
                    }

                }
                else if ((currentFloor == 3 || currentFloor == 4) && (agents[0].SecurityLevel == "G" || agents[0].SecurityLevel == "S"))
                {
                    
                    Console.WriteLine($"Elevator reached its destination!But {agents[0].Name} doesn't have rights!Choosing new floor:");
                    int num = requests[0];
                    while (requests[0] == num)
                    {
                        requests[0] = Random.Shared.Next(1, 4);
                    }
                   

                }
                else
                {
                    Console.WriteLine($"Elevator has reached its destination for {agents[0].Name}.");
                    requests.RemoveAt(0);
                    agents.Remove(agents[0]);
                    Console.WriteLine();
                    if (agents.Count > 0)
                    {
                        while (!reachedDestination)
                        {
                            MoveWithoutPassenger();
                        }
                        reachedDestination = false;
                    }
                    
                }
            }
        }

    }
}
