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

namespace NI_Fonakolos_játék
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void rules_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("A játék szabályai: \n \n - A játékot két ember játszhatja \n - A cél minnél több pontot szerezni.\n   Ezt a saját korongjaink száma határozza meg.");
        }
    }
}
