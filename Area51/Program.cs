namespace Area51
{
    internal class Program
    {

        static void Main()
        {
            Class1 Elevator = new Class1();
            Thread t1 = new Thread(() =>
            {
                Agent agent = new Agent("John", "S");
                Console.WriteLine($"{agent.Name} {agent.SecurityLevel} CurrentFloor: {agent.CurrentFloor} DestinationFloor: {agent.TargetFloor}");
                Elevator.Request(agent);
            });
            t1.Start();
            t1.Join();
            new Thread(() =>
            {
                while (Elevator.requests.Count > 0)
                {
                    Elevator.Move();
                }
            }).Start();

            Thread t2 = new Thread(() =>
            {
                Agent agent = new Agent("Mike", "T1");
                Console.WriteLine($"{agent.Name} {agent.SecurityLevel} CurrentFloor: {agent.CurrentFloor} DestinationFloor: {agent.TargetFloor}");
                Elevator.Request(agent);
            });
            t2.Start();
            Thread t3 = new Thread(() =>
            {
                Agent agent = new Agent("Nick", "G");
                Console.WriteLine($"{agent.Name} {agent.SecurityLevel} CurrentFloor: {agent.CurrentFloor} DestinationFloor: {agent.TargetFloor}");
                Elevator.Request(agent);
            });
            t3.Start();

        }

    }

}