using Service.Interfaces;

namespace Service.Implementations
{
    internal class RightCommandHandler : ICommand
    {
        private NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        bool result = false;
        public T ExecuteCommand<T>(string request, ISimulator simulator, IRobot robot)
        {
            _logger.Info("Executing RightCommandHandler execute function");
            try
            {
                simulator.TurnLeft(request, robot);
                result = true;
            }
            catch (Exception ex) { _logger.Error(ex, "Error in RightCommandHandler handler");}
            return (T)Convert.ChangeType(result, typeof(T));
        }
    }
}
