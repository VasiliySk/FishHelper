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
        public float xCoord { get; set; }
        public float yCoord { get; set; }
        public float tCorner { get; set; }
        public bool holeType { get; set; }

        public FishPath(float xcoord, float ycoord, float tcorner, bool holetype)
        {
            this.xCoord = xcoord;
            this.yCoord = ycoord;
            this.tCorner = tcorner;
            this.holeType = holetype;
        }
    }
}
