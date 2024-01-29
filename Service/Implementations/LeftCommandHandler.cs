using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    internal class LeftCommandHandler : ICommand
    {
        private NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        bool result = false;
        public T ExecuteCommand<T>(string request, ISimulator simulator, IRobot robot)
        {
            _logger.Info("Executing LeftCommandHandler execute function");
            try
            {
                simulator.TurnLeft(request, robot);
                result = true;
                return (T)Convert.ChangeType(true, typeof(T)); ;
            }
            catch (Exception ex) { _logger.Error(ex, "Error in LeftCommandHandler handler"); result = false; }
            return (T)Convert.ChangeType(result, typeof(T));
        }
    }
}
