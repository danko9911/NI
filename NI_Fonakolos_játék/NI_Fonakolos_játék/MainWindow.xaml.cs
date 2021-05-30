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
        public int playerTurn; //white = 0 / black = 1
        Model.BoardMesh game = new Model.BoardMesh();
        
        public MainWindow()
        {
            InitializeComponent();
            drawBoard();
            playerTurn = 0;
        }

        public void drawBoard()
        {
            int id = 0;
            game_board.Children.Clear();
            foreach (Model.BoardTile tile in game.gameMesh)
            {
                Ellipse myEllipse = new Ellipse();
                myEllipse.Width = 65;
                myEllipse.Height = 65;
                Canvas.SetLeft(myEllipse, tile.pos_x);
                Canvas.SetTop(myEllipse, tile.pos_y);


                switch (tile.field_owner)
                {
                    case 1: myEllipse.Fill = System.Windows.Media.Brushes.White; break;
                    case 2: myEllipse.Fill = System.Windows.Media.Brushes.Black; break;
                    case 3: myEllipse.Fill = System.Windows.Media.Brushes.Yellow; break;
                    case 4: myEllipse.Fill = System.Windows.Media.Brushes.Orange; break;
                }

                game_board.Children.Add(myEllipse);
                id++;
            }
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

        private void game_board_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            int newID = game.calculateMousePosition(p.X, p.Y);
            if (game.gameMesh[newID].field_owner != 1 && game.gameMesh[newID].field_owner != 2)
            {
                //game.gameMesh[newID].field_owner = playerTurn + 1;
                game.calcualteNextStep(newID, playerTurn + 1);
                drawBoard();
                playerTurn = (playerTurn + 1) % 2;
                
              
            }
            
        }

        
    }
}
