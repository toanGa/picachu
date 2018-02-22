using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duong.LevelHelper
{
    /// <summary>
    /// infomation of level is playing
    /// </summary>
    struct LevelInfo
    {
        public int numsRow;
        public int numsCol;
        public int rowStart;
        public int colStart;
        public LevelInfo(int numsRow, int numsCol, int rowStart, int colStart)
        {
            this.numsRow = numsRow;
            this.numsCol = numsCol;
            this.rowStart = rowStart;
            this.colStart = colStart;
        }
    }

    /// <summary>
    /// help total number label will be display
    /// </summary>
    class LevelHelper
    {
        static LevelInfo info;
        /*
         *  start with 0
         */
        static public LevelInfo getLevelInfo(int level)
        {
            switch(level)
            {
                case 0:   
                    info = new LevelInfo(4, 2, 2, 2);
                    break;
                case 1:
                    info = new LevelInfo(6, 4, 1, 1);
                    break;
                case 2:
                    info = new LevelInfo(8, 6, 0, 0);
                    break;
                default:
                    break;
            }
            return info;
        }
    }
}
