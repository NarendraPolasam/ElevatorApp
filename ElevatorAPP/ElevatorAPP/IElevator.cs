using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorAPP
{
    interface IElevator
    {
        
            void Stop(int floor);
            void Descend(int floor);
            void Ascend(int floor);
            void StayPut();
            void FloorPress(int floor);
        
    }
}
