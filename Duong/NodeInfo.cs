using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Duong
{
    class NodeInfo
    {
        int rowIndex = 0;
        int colIndex = 0;
        public bool isReadyToClick = false;
        public bool isChoosing = false;
        public string picName;
        public Label lable;
        /// <summary>
        /// set default contructor
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="colIndex"></param>
        public NodeInfo(int rowIndex, int colIndex)
        {
            this.rowIndex = rowIndex;
            this.colIndex = colIndex;
            isReadyToClick = false;
            isChoosing = false;
            lable = new Label();
        }

        /// <summary>
        /// lock click event
        /// </summary>
        void LockActivity()
        {
            isReadyToClick = false;
        }

        /// <summary>
        /// set click enable
        /// </summary>
        void UnlockActivity()
        {
            isReadyToClick = true;
        }

        /// <summary>
        /// call back when click 
        /// </summary>
        void ClickCallback()
        {
            if(isReadyToClick)
            {
                isChoosing = !isChoosing;
            }
        }
    }
}
