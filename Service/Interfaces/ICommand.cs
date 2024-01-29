using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    internal interface ICommand
    {
        public T ExecuteCommand<T>(string request, ISimulator simulator, IRobot robot);
    }
}
