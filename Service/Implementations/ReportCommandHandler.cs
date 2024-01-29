using Service.Interfaces;

namespace Service.Implementations
{
    internal class ReportCommandHandler : ICommand
    {
        private NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        string result = string.Empty;
        public T ExecuteCommand<T>(string request, ISimulator simulator, IRobot robot)
        {
            _logger.Info("Executing ReportCommandHandler execute function");
            try
            {
                var r = simulator.Report(robot);
                return (T)Convert.ChangeType(r, typeof(T)); ;
            }
            catch (Exception ex) { _logger.Error(ex, "Error in ReportCommandHandler handler"); result = ex.Message; }
            return (T)Convert.ChangeType(result, typeof(T));
        }
    }
}
