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
using System.Windows.Shapes;

namespace Duong
{
    /// <summary>
    /// Interaction logic for FAIL.xaml
    /// </summary>
    public partial class FAIL : Window
    {
        public bool isReplay;
        public FAIL(int level)
        {
            InitializeComponent();
            isReplay = false;
        }
        
        private void Replay_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isReplay = true;
        }

        private void Exit_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
