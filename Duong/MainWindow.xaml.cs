using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Duong.GameLevelHelper;
using System.IO;

namespace Duong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<NodeInfo> node;
        LevelInfo levelInfo;
        private Label labelInfo;
        private const string MASTER_PATH = "E:\\Tester\\picachu\\picachu\\Duong\\image\\";
        private const double OPA_CHOOSED = 0.5;
        private const double OPA_UNCHOOSED = 1;
        private const int MAX_COL = 8;
        private const int MAX_ROW = 6;

        private const string pic1 = "p1.jpg";
        private const string pic2 = "p2.jpg";
        private const string pic3 = "p3.jpg";
        private const string pic4 = "p4.jpg";
        private const string pic5 = "p5.jpg";
        private const string pic6 = "p6.jpg";
        private const string pic7 = "p7.jpg";
        private const string pic8 = "p8.jpg";
        private const string pic9 = "p9.jpg";
        private const string pic10 = "p10.jpg";
        private const string pic11 = "p11.jpg";
        private const string pic12 = "p12.jpg";
        private const string pic13 = "p13.jpg";
        private const string pic14 = "p14.jpg";
        private const string pic15 = "p15.jpg";
        private const string pic16 = "p16.jpg";
        private const string pic17 = "p17.jpg";
        private const string pic18 = "p18.jpg";
        private const string pic19 = "p19.jpg";
        private const string pic20 = "p20.jpg";
        private const string pic21 = "p21.jpg";
        private const string pic22 = "p22.jpg";
        private const string pic23 = "p23.jpg";
        private const string pic24 = "p24.jpg";
        private const string pic25 = "p25.jpg";

        private const int NUMS_PIC = 25;
        public MainWindow()
        {
            InitializeComponent();
            levelInfo = LevelHelper.getLevelInfo(0);
            //((Label)FindName("lable00")).
            InitNode();
            setNodeStartLevel();

            refreshNodeState();

            object item = MainGrid.FindName("lableInfo");
            if(item is Label)
            {
                labelInfo = (Label)item;
            }
#if false
            object item = MainGrid.FindName("lable00");

            if(item is Label)
            {
                MessageBox.Show("find success!!");
                Label lbl = (Label)item;
                lbl.Background = new ImageBrush(new BitmapImage(new Uri(MASTER_PATH + pic15)));
                lbl.Background = null;
                lbl.Opacity = 0.3;
            }

            ImageBrush imgBrush = new ImageBrush();
 
            imgBrush.ImageSource =
                    new BitmapImage(new Uri(@"Dock.jpg", UriKind.Relative));
#endif


            string testDir = Directory.GetCurrentDirectory();
            //string[] test2 = Directory.GetDirectories("C:\\Users\\Toan\\source\\repos\\Duong\\Duong\\image\\");

        }

        public void InitNode()
        {
            int i;
            object tmp;
            node = new List<NodeInfo>(48);
            for (i = 0; i < 48; ++i)
            {
                node.Add(null);
            }

            for (i = 0; i < 48; ++i)
            {
                node[i] = new NodeInfo(i / 8, i % 8);
                string name = "lable" + i/8 + i%8;
                tmp = MainGrid.FindName(name);
                node[i].lable = (Label)tmp;
                if (tmp is Label)
                {
                    Console.WriteLine("Node " + i + " is Label with row: " + i/8 + ", col: " + i%8);
                }
                else
                {
                    Console.WriteLine("Node " + i + " is NOT Label with row: " + i / 8 + ", col: " + i % 8);
                }
            }

            initNamePic();
        }

        /// <summary>
        /// enable node when startup
        /// </summary>
        private void setNodeStartLevel()
        {
            int rowStart = levelInfo.rowStart;
            int colStart = levelInfo.colStart;
            int numsRow = levelInfo.numsRow;
            int numsCol = levelInfo.numsCol;
            int index;
            for (int i = rowStart; i < rowStart + numsRow; ++i)
            {
                for (int j = colStart; j < colStart + numsCol; ++j)
                {
                    index = i * MAX_COL + j;
                    node[index].isReadyToClick = true;
                    node[index].isChoosing = false;
                    Console.WriteLine("set node " + index + " ,value for row: " + i + ", col:" + j);
                }
            }

            
        }


        /// <summary>
        /// check all node info has clicked
        /// </summary>
        /// <returns></returns>
        private bool isExistedNodeClicked()
        {
            int rowStart = levelInfo.rowStart;
            int colStart = levelInfo.colStart;
            int numsRow = levelInfo.numsRow;
            int numsCol = levelInfo.numsCol;
            NodeInfo nodeCheck = new NodeInfo(0, 0);// use for check node
            int index;
            for (int i = rowStart; i < rowStart + numsRow; ++i )
            {
                for(int j = colStart; j < colStart + numsCol; ++j)
                {
                    index = i * MAX_COL + j;
                    nodeCheck = node[index];
                    if(nodeCheck.isReadyToClick && nodeCheck.isChoosing)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

 
        /// <summary>
        /// all click event focus here
        /// </summary>
        /// <param name="indexNode"></param>
        private void label_ClickEvent(int indexNode)
        {
            //labelInfo.Content = "clicked node: " + clickedNode.
            //string brushText = node[indexNode].lable.;
            if (node[indexNode].isReadyToClick)
            {
                if(isExistedNodeClicked())// start compare
                {
                    if (node[indexNode].isChoosing)// if is choosing, remove
                    {
                        //node[indexNode].lable.Opacity = OPA_CHOOSED;
                        node[indexNode].isChoosing = !node[indexNode].isChoosing;
                    }
                    else
                    {
                        // process match event
                        // if same label -> delete node
                        // else wrong click -> unchoose
                        int indexClicking = getIndexNodeClickPrev();
                    }
                   

                }
                else
                {
                    //node[indexNode].lable.Opacity = OPA_CHOOSED;
                    node[indexNode].isChoosing = !node[indexNode].isChoosing;
                }               
            }
            refreshNodeState();
        }

        /// <summary>
        /// refresh opacity of node
        /// </summary>
        private void refreshNodeState()
        {
            int total = node.Count;
            for(int i = 0; i < total; ++i)
            {
                if(!node[i].isReadyToClick)
                {
                    node[i].lable.Background = null;
                }
                if(node[i].isReadyToClick)
                {
                    if(node[i].isChoosing)
                    {
                        node[i].lable.Opacity = OPA_CHOOSED;
                    }else
                    {
                        node[i].lable.Opacity = OPA_UNCHOOSED;
                    }
                }
            }
            
        }

        /// <summary>
        /// set picture for label of node
        /// </summary>
        /// <param name="nodeIndex"></param>
        /// <param name="picName"></param>
        private void setNameNode(int nodeIndex, string picName)
        {
            node[nodeIndex].lable.Background = new ImageBrush(new BitmapImage(new Uri(MASTER_PATH + picName)));
            node[nodeIndex].picName = picName;
        }

        /// <summary>
        /// inti name of node, when start game or change level or reset game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void initNamePic()
        {
            int rowStart = levelInfo.rowStart;
            int colStart = levelInfo.colStart;
            int numsRow = levelInfo.numsRow;
            int numsCol = levelInfo.numsCol;
            int totalName = numsCol * numsRow >> 1;
            List<string> listName = new List<string>();
            string namePicSet;
            for (int i = 0; i < totalName; ++i)
            {
                namePicSet = getRandomPicName();
                listName.Add(namePicSet);
                listName.Add(namePicSet);
            }
            NodeInfo nodeCheck = new NodeInfo(0, 0);// use for check node
            int index;
            int indexInListName;
            Random rnd = new Random();
            for (int i = rowStart; i < rowStart + numsRow; ++i)
            {
                for (int j = colStart; j < colStart + numsCol; ++j)
                {
                    index = i * MAX_COL + j;
                    nodeCheck = node[index];
                    indexInListName = rnd.Next(0, listName.Count);
                    setNameNode(index, listName[indexInListName]);
                    listName.RemoveAt(indexInListName);
                }
            }
        }

        /// <summary>
        /// genatator random number
        /// </summary>
        /// <returns></returns>
        string getRandomPicName()
        {
            int indexPic = (new Random()).Next(1, 26);// 1 to 25
            return "p" + indexPic + ".jpg";
        }

        /// <summary>
        /// get index node clicking
        /// </summary>
        /// <returns></returns>
        int getIndexNodeClickPrev()
        {
            int rowStart = levelInfo.rowStart;
            int colStart = levelInfo.colStart;
            int numsRow = levelInfo.numsRow;
            int numsCol = levelInfo.numsCol;
            NodeInfo nodeCheck = new NodeInfo(0, 0);// use for check node
            int index;
            for (int i = rowStart; i < rowStart + numsRow; ++i)
            {
                for (int j = colStart; j < colStart + numsCol; ++j)
                {
                    index = i * MAX_COL + j;
                    nodeCheck = node[index];
                    if (nodeCheck.isReadyToClick && nodeCheck.isChoosing)
                    {
                        return index;
                    }
                }
            }
            return -1;
        }
        private void lable00_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("label 00");
            if (sender is Label)
            {
                Console.WriteLine("label name:" + ((Label)sender).Name);
            }

            label_ClickEvent(0);
        }


        private void lable01_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(1);
        }
        private void lable02_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(2);
        }

        private void lable03_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(3);
        }

        private void lable04_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(4);
        }

        private void lable05_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(5);
        }

        private void lable06_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(6);
        }

        private void lable07_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(7);
        }

        private void lable10_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(8);
        }

        private void lable11_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(9);
        }

        private void lable12_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(10);
        }

        private void lable13_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(11);
        }

        private void lable14_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(12);
        }

        private void lable15_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(13);
        }

        private void lable16_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(14);
        }

        private void lable17_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(15);
        }

        private void lable20_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(16);
        }

        private void lable21_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(17);
        }

        private void lable22_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(18);
        }

        private void lable23_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(19);
        }

        private void lable24_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(20);
        }

        private void lable25_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(21);
        }

        private void lable26_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(22);
        }

        private void lable27_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(23);
        }

        private void lable30_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(24);
        }

        private void lable31_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(25);
        }

        private void lable32_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(26);
        }

        private void lable33_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(27);
        }

        private void lable34_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(28);
        }

        private void lable35_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(29);
        }

        private void lable36_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(30);
        }

        private void lable37_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(31);
        }

        private void lable40_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(32);
        }

        private void lable41_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(33);
        }

        private void lable42_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(34);
        }

        private void lable43_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(35);
        }

        private void lable44_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(36);
        }

        private void lable45_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(37);
        }

        private void lable46_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(38);
        }

        private void lable47_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(39);
        }

        private void lable50_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(40);
        }

        private void lable51_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(41);
        }

        private void lable52_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(42);
        }

        private void lable53_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(43);
        }

        private void lable54_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(44);
        }

        private void lable55_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(45);
        }

        private void lable56_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(46);
        }

        private void lable57_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            label_ClickEvent(47);
        }

        /// <summary>
        /// label info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lableInfo_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
