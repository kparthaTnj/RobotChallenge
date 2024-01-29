using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{    
    public class Table
    {
        public int width;
        public int length;
        public bool IsValidLocation(int east, int north)
        {
            // needs more attention here.
            if(east == 0 && north == 0) return true;
            if(east >= 0 && east < width && north >= 0 && north < length) return true;
            return false;
        }
        public Table(int width, int length)
        {
            this.width = width;
            this.length = length;
        }
    }
}
