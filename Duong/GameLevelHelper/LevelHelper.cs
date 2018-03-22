using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duong.GameLevelHelper
{
    /// <summary>
    /// infomation of level is playing
    /// </summary>
    class LevelInfo
    {
        public int numsRow;
        public int numsCol;
        public int rowStart;
        public int colStart;
        public int MAX_TIME;
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
        public static int gameLevel;
        /*
         *  start with 0
         */
        static public LevelInfo getLevelInfo(int level)
        {
            gameLevel = level;
            switch(level)
            {
                case 0:   
                    info = new LevelInfo(2, 4, 2, 2);
                    info.MAX_TIME = 10;
                    break;
                case 1:
                    info = new LevelInfo(4, 6, 1, 1);
                    info.MAX_TIME = 20;
                    break;
                case 2:
                    info = new LevelInfo(6, 8, 0, 0);
                    info.MAX_TIME = 30;
                    break;
                default:
                    break;
            }
            return info;
        }

        static public LevelInfo getNextLevel()
        {
            gameLevel++;
            return getLevelInfo(gameLevel);
        }
        /// <summary>
        /// check win
        /// </summary>
        /// <returns></returns>
        static public bool checkWinGame()
        {
            if(gameLevel == 2)
            {
                return true;
            }
            return false;
        }
    }
}
