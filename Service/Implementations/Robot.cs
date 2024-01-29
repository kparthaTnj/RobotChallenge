using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class Robot : IRobot
    {
        public int _east = 0;
        public int _north = 0;
        public string _direction;
        public Robot() {         

        }
        public int East { get; set; }
        public int North { get; set; }
        public string Direction { get; set; }

        public void Left()
        {
            switch (Direction.ToLower())
            {
                case "east":
                    Direction = "north";
                    break;
                case "west":
                    Direction = "south";
                    break;
                case "north":
                    Direction = "west";
                    break;
                case "south":
                    Direction = "east";
                    break;
            }
        }

        public void Move()
        {
            switch (Direction.ToLower())
            {
                case "east":
                    East += 1;
                    break;
                case "west":
                    East -= 1;
                    break;
                case "north":
                    North += 1;
                    break;
                case "south":
                    North -= 1;
                    break;
            }
        }

        public void Place(int east, int north, string direction)
        {          
                //Toy.Place(east,north,direction);
                East = east;
                North = north;
                Direction = direction;
        }

        public string Report()
        {
            return East + "," + North + "," + Direction?.ToUpper();
        }

        public void Right()
        {
            switch (Direction.ToLower())
            {
                case "east":
                    Direction = "south";
                    break;
                case "west":
                    Direction = "north";
                    break;
                case "north":
                    Direction = "east";
                    break;
                case "south":
                    Direction = "west";
                    break;
            }
        }
    }
}
