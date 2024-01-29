using Service.Interfaces;
using ICommand = Service.Interfaces.ICommand;

namespace Service.Implementations
{
    internal class MoveCommandHandler : ICommand
    {        
        private NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        bool result = false;

        public T ExecuteCommand<T>(string request, ISimulator simulator, IRobot robot)
        {
            _logger.Info("Executing MoveCommandHandler execute function");
            try
            {
                simulator.RobotMoves(request, robot);
                result = true;
            }
            catch (Exception ex) { _logger.Error(ex, "Error in MoveCommandHandler handler");}
            return (T)Convert.ChangeType(result, typeof(T));
        }
    }
}
