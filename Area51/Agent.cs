using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51
{
    internal class Agent
    {
        public string Name { get; set; }
        private string securityLevel;

        public Agent(string name, string securityLevel)
        {
            Name = name;
            this.securityLevel = securityLevel;
            currentFloor = Random.Shared.Next(1, 4);
            targetFloor = Random.Shared.Next(1, 4);
        }

        public string SecurityLevel
        {
            get { return securityLevel; }
            set
            {
                if (value == "G" || value == "S" || value == "T1" || value == "T2")
                {
                    securityLevel = value;

                }
                else
                {
                    throw new ArgumentException("Invalid security level");
                }


            }
        }
        private int targetFloor;

        public int TargetFloor
        {
            get { return targetFloor; }
            set
            {
                if (targetFloor > 4 || targetFloor < 1)
                {
                    throw new ArgumentException("Invalid floor destination!");
                }
                targetFloor = value;
            }
        }
        private int currentFloor;

        public int CurrentFloor
        {
            get { return currentFloor; }
            set
            {
                if (currentFloor > 4 || currentFloor < 1)
                {
                    throw new ArgumentException("Invalid floor destination!");
                }
                currentFloor = value;
            }
        }

    }
}
