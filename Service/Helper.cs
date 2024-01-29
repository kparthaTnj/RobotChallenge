using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class Helper
    {
        public static bool IsValidPlacement(int a,int endIndex)
        {
            var startIndex = 0;
            return a >= startIndex && a <= endIndex;
        }
    }
}
