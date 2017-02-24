using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorAPP
{
    public class Elevator : IElevator
    {

        private bool[] floorReady;
        public int CurrentFloor = 1;
        private int topfloor;
        public ElevatorStatus Status = ElevatorStatus.STOPPED;

        public Elevator(int NumberOfFloors = 10)
        {
            floorReady = new bool[NumberOfFloors + 1];
            topfloor = NumberOfFloors;
        }

        public void Stop(int floor)
        {
            Status = ElevatorStatus.STOPPED;
            CurrentFloor = floor;
            floorReady[floor] = false;
            Console.WriteLine("Stopped at floor {0}", floor);
        }

        public void Descend(int floor)
        {
            for (int i = CurrentFloor; i >= 1; i--)
            {
                if (floorReady[i])
                    Stop(floor);
                else
                    continue;
            }

            Status = ElevatorStatus.STOPPED;
            Console.WriteLine("Waiting..");
        }

        public void Ascend(int floor)
        {
            for (int i = CurrentFloor; i <= topfloor; i++)
            {
                if (floorReady[i])
                    Stop(floor);
                else
                    continue;
            }

            Status = ElevatorStatus.STOPPED;
            Console.WriteLine("Waiting..");
        }

        public void StayPut()
        {
            Console.WriteLine("That's our current floor");
        }

        public void FloorPress(int floor)
        {
            if (floor > topfloor)
            {
                Console.WriteLine("We only have {0} floors", topfloor);
                return;
            }
            if (floor == 1 && CurrentFloor <= 1)
            {
                Console.WriteLine("You have pressed an Ground floor");
                return;
            }
            if (floor <= 0)
            {
                Console.WriteLine("You have pressed an incorrect floor");
                return;
            }

            floorReady[floor] = true;

            switch (Status)
            {

                case ElevatorStatus.DOWN:
                    Descend(floor);
                    break;

                case ElevatorStatus.STOPPED:
                    if (CurrentFloor < floor)
                        Ascend(floor);
                    else if (CurrentFloor == floor)
                        StayPut();
                    else
                        Descend(floor);
                    break;

                case ElevatorStatus.UP:
                    Ascend(floor);
                    break;

                default:
                    break;
            }
        }

    }
}
