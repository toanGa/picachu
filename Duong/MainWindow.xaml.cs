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

namespace Duong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<NodeInfo> node;
        public MainWindow()
        {
            InitializeComponent();
            //((Label)FindName("lable00")).
            InitNode();

            object item = MainGrid.FindName("lable00");
            if(item is Label)
            {
                MessageBox.Show("find success!!");
                Label lbl = (Label)item;
                lbl.Opacity = 0.3;
            }
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

        private void lable00_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("label 00");
            
        }

        private void lable02_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lable01_PreviewMouseDown(object sender, MouseButtonEventArgs e)
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
    }
}
