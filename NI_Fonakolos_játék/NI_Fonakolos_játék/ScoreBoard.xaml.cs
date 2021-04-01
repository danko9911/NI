using NI_Fonakolos_játék.Model;
using NI_Fonakolos_játék.ModelView;
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

namespace NI_Fonakolos_játék
{
    /// <summary>
    /// Interaction logic for LeaderBoard.xaml
    /// </summary>
    public partial class ScoreBoard : Window
    {
        List<Player> list = new List<Player>();
        public ScoreBoard()
        {

            InitializeComponent();
           // LoadPeopleList();
            listPoeple();
        }
        /*
        private void LoadPeopleList()
        {
            list = ScoreBoardView.LoadPeople();
            list = list.OrderByDescending(Player => Player.Score).ToList();

        }
        */
        private void listPoeple()
        {
            int k = 0;
            int i = 1;
            TextBlock[,] blocklist = new TextBlock[8, 3];

            foreach (Player item in list)
            {
                blocklist[i, k] = new TextBlock();
                blocklist[i, k].Text = item.FullName;
                Grid.SetRow(blocklist[i, k], i);
                Grid.SetColumn(blocklist[i, k], k);
                blocklist[i, k].FontSize = 28;
                grid.Children.Add(blocklist[i, k]);
                k++;
                blocklist[i, k] = new TextBlock();
                blocklist[i, k].Text = item.time;
                Grid.SetRow(blocklist[i, k], i);
                Grid.SetColumn(blocklist[i, k], k);
                blocklist[i, k].FontSize = 28;
                grid.Children.Add(blocklist[i, k]);
                k++;
                blocklist[i, k] = new TextBlock();
                blocklist[i, k].Text = item.Score.ToString();
                Grid.SetRow(blocklist[i, k], i);
                Grid.SetColumn(blocklist[i, k], k);
                blocklist[i, k].FontSize = 28;
                grid.Children.Add(blocklist[i, k]);
                k = 0;
                i++;
                if (i > 7) break;
            }

        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();

        }
    }
}
