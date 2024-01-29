using Service.Implementations;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service
{

    public interface ISimulator
    {
        public void Place(int east, int north, string direction,IRobot robot);
        public void RobotMoves(string movement, IRobot robot);
        public void TurnLeft(string movement, IRobot robot);
        public void TurnRight(string movement, IRobot robot);
        public string Report(IRobot robot);

    }
    public class Simulator : ISimulator
    {
        private IRobot? Toy;
        private NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        //configurable
        public Table Surface=new Table(5,5);

      
        public void Place(int east, int north, string direction,IRobot robot)
        {
            if (Surface.IsValidLocation(east, north))
            {
                robot.Place(east, north, direction);
            }
            else
            {
                _logger.Error(string.Format("Robot not placed. please check the inputs : X {0} + Y {1} + F {2}",east,north,direction));
            }
        }

        public void RobotMoves(string direction, IRobot robot)
        {
            Toy = robot;
            switch (direction)
            {
                case "MOVE":
                    Move(robot);
                    break;
                case "right":
                    Toy.Right();
                    break;
                case "left":
                    Toy.Left();
                    break;
            }
        }
        private void Move(IRobot robot)
        {
            switch (robot.Direction.ToLower())
            {
                case "north":
                    if(Helper.IsValidPlacement(robot.North + 1, Surface.length))
                    robot.Move();
                    break;
                case "south":
                    if (Helper.IsValidPlacement(robot.North -1, Surface.length))
                        robot.Move();
                    break;
                case "east":
                    if (Helper.IsValidPlacement(robot.East + 1, Surface.length))
                        robot.Move();
                    break;
                case "west":
                    if (Helper.IsValidPlacement(robot.East - 1, Surface.length))
                        robot.Move();
                    break;
                default:
                    break;
            }
        }

        public string Report(IRobot robot)
        {
            return robot.Report();
        }

        public void TurnLeft(string direction, IRobot robot)
        {
            robot.Left();
        }

        public void TurnRight(string direction, IRobot robot)
        {
            robot.Right();
        }
    }
}
