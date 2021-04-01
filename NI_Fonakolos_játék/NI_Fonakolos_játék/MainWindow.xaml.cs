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
            MessageBox.Show("A játék szabályai: \n \n - A játékot két ember játszhatja \n - A cél minnél több pontot szerezni.\n   Ezt a saját korongjaink száma határozza meg." +
                "\n - Korongot akkor lehet lehelyezni, \n   ha közrefogja az ellenfél korongjait. \n - A játékosoknak lépéskötelezetsége van minden körben!" );
        }

        private void new_game_btn_Click(object sender, RoutedEventArgs e)
        {
            NewGameWindow new_game = new NewGameWindow();
            new_game.Show();
            this.Close();
        }

        private void high_score_btn_Click(object sender, RoutedEventArgs e)
        {
            ScoreBoard scoreboard = new ScoreBoard();
            scoreboard.Show();
            this.Close();
        
        }
    }
}
