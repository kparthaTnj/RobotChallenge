using NLog;
using Service.Implementations;
using Service.Interfaces;
using System.Text.RegularExpressions;
using ICommand = Service.Interfaces.ICommand;

namespace Service
{
    /* class which acts as aggregator to process all commands and */
    public class Invoker
    {
        Dictionary<string,ICommand> commandHandlers = new Dictionary<string, ICommand>();
        private ISimulator _simulator; private IRobot _robot;
        private NLog.Logger _logger;
        private string message;
        public Invoker(ISimulator simulator,IRobot robot)
        {
            _logger = LogManager.GetCurrentClassLogger();            
            _simulator = simulator;
            _robot = robot;
            //configurable
            commandHandlers.Add("PLACE", new PlaceCommandHandler());
            commandHandlers.Add("MOVE", new MoveCommandHandler());
            commandHandlers.Add("LEFT", new LeftCommandHandler());
            commandHandlers.Add("RIGHT", new RightCommandHandler());
            commandHandlers.Add("REPORT", new ReportCommandHandler());
        }

        public string ProcessCommand(string[] commands)
        {
            try
            {
                _logger.Info("Inside Processcommand" + string.Join("",commands));
                bool result = false;
                foreach (string command in commands)
                {
                    _logger.Info("Command  --- " + command);
                    if (string.IsNullOrEmpty(command))
                    {
                        _logger.Info("Command cannot be empty --- " + command);
                        message = "Command cannot be empty";
                        return message;
                    }
                    //can be a single line to execute all commands. need to use regex which finds all commands, rather than using if condition to check 
                    // and execute all commands
                    //commandHandlers[command.ToUpper()].ExecuteCommand<bool>(command, _simulator, _robot);

                    if (Regex.IsMatch(command, "^PLACE"))
                    {
                        result = commandHandlers["PLACE"].ExecuteCommand<bool>(command, _simulator, _robot);
                    }
                    if (Regex.IsMatch(command, "^MOVE"))
                    {
                        result = commandHandlers["MOVE"].ExecuteCommand<bool>(command, _simulator, _robot);
                    }
                    if (Regex.IsMatch(command, "^LEFT"))
                    {
                        result = commandHandlers["LEFT"].ExecuteCommand<bool>(command, _simulator, _robot);
                    }
                    if (Regex.IsMatch(command, "^RIGHT"))
                    {
                        result = commandHandlers["RIGHT"].ExecuteCommand<bool>(command, _simulator, _robot);
                    }
                    if (Regex.IsMatch(command, "^REPORT"))
                    {
                        message = commandHandlers["REPORT"].ExecuteCommand<string>(command, _simulator, _robot);
                    }

                    if(!result)
                    {
                        message = "Please verify the commands/inputs and log file for more informations";
                    }

                }
                return message;
            }
            catch (Exception ex)
            {
                message = "somethong went wrong. please see the logs for exact details";
                _logger.Error(ex);
                return message;
            }            
        }
    }
}
