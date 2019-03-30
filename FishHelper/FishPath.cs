using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishHelper
{
    //Класс, отвечающий за сохранение данных о точках рыбной ловли
    class FishPath
    {
        public String xCoord { get; set; }
        public String yCoord { get; set; }
        public String tCorner { get; set; }
        public bool holeType { get; set; }

        public FishPath(String xcoord, String ycoord, String tcorner, bool holetype)
        {
            this.xCoord = xcoord;
            this.yCoord = ycoord;
            this.tCorner = tcorner;
            this.holeType = holetype;
        }

        public FishPath()
        {
        }

    }
}
