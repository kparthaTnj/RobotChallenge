using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IRobot
    {
        public int East {  get; set; }
        public int North { get; set; }
        public string Direction { get; set; }
        public void Place(int east, int north, string direction);
        public void Move();
        public void Right();
        public void Left();
        public string Report();

    }
}
