using Service.Interfaces;

namespace Service.Implementations
{
    public class PlaceCommandHandler : ICommand
    {
        private NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        bool result = false;
        public T ExecuteCommand<T>(string request, ISimulator simulator, IRobot robot)
        {
            _logger.Info("Executing placecommand handler execute function");
            try
            {
                string[] coordinates = request.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (coordinates.Length == 4)
                {
                    int east;
                    int north;
                    bool eastTest = Int32.TryParse(coordinates[1], out east);
                    bool northTest = Int32.TryParse(coordinates[2], out north);
                    if (eastTest && northTest)
                    {
                        simulator.Place(east, north, coordinates[3], robot);
                        result = true;
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.Error(ex, "Error in place command handler");
                result = false;
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }
    }
}
