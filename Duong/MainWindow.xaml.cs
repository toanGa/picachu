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
        public MainWindow()
        {
            InitializeComponent();
            levelInfo = LevelHelper.getLevelInfo(0);
            //((Label)FindName("lable00")).
            InitNode();
            setNodeStartLevel();

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
#endif
            string testDir = Directory.GetCurrentDirectory();
            string[] test2 = Directory.GetDirectories("E:\\Tester\\picachu\\picachu\\Duong\\image\\");


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
                    index = i * numsRow + j;
                    node[index].isReadyToClick = true;
                    node[index].isChoosing = false;
                }
            }

            refreshNodeState();
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
                    index = i * numsRow + j;
                    nodeCheck = node[index];
                    if(nodeCheck.isReadyToClick && nodeCheck.isChoosing)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

 

        private void label_ClickEvent(NodeInfo clickedNode)
        {
            if(clickedNode.isReadyToClick)
            {
                if(isExistedNodeClicked())// start compare
                {
                    if (clickedNode.isChoosing)// if is choosing, remove
                    {
                        clickedNode.lable.Opacity = OPA_CHOOSED;
                    }
                    else
                    {
                        // process match event
                    }
                    clickedNode.isChoosing = !clickedNode.isChoosing;

                }
                else
                {
                    clickedNode.lable.Opacity = OPA_CHOOSED;
                }
                
            }
        }

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
        private void lable00_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("label 00");
            if (sender is Label)
            {
                Console.WriteLine("label name:" + ((Label)sender).Name);
            }

            label_ClickEvent(node[0]);
        }


        private void lable01_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void lable02_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable03_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable04_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable05_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable06_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable07_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable10_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable11_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable12_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable13_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable14_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable15_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable16_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable17_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable20_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable21_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable22_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable23_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable24_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable25_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable26_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable27_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable30_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable31_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable32_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable33_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable34_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable35_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable36_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable37_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable40_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable41_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable42_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable43_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable44_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable45_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable46_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable47_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable50_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable51_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable52_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable53_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable54_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable55_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable56_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable57_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lableInfo_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
