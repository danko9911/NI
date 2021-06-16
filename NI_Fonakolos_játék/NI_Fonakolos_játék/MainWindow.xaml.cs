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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace NI_Fonakolos_játék
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int playerTurn; //white = 0 / black = 1
        public bool isAI;

        bool endOfGame; 

        BoardMesh game = new BoardMesh();
        Player player1 = new Player();
        Player player2 = new Player();


        public MainWindow(bool isAi, string player1Name, string player2Name)
        {
            InitializeComponent();
            ScoreBoardView.CreatePlayer();
            Player1Text.Text = player1.firstName = player1Name;

            if (isAi) { Player2Text.Text = player2.firstName = "AI";}
            else { Player2Text.Text = player2.firstName = player2Name; }

            this.isAI = isAi;

            playerTurn = RandomizeStartingPlayer();
            playerTurnColors(playerTurn);

            if (isAI && playerTurn == 1)
            {
                int aistep = game.aiStepInd();
                game.gameStep(aistep, playerTurn + 1);
                playerTurn = (playerTurn + 1) % 2;

                playerTurnColors(playerTurn);
            }

            drawBoard();
      
        }

        private void drawBoard()
        {
            int id = 0;
            bool endGame = true;

            player1.Score = 0;
            player2.Score = 0;

            game_board.Children.Clear();
            foreach (BoardTile tile in game.gameMesh)
            {
                Ellipse myEllipse = new Ellipse();
                myEllipse.Width = 65;
                myEllipse.Height = 65;
                Canvas.SetLeft(myEllipse, tile.pos_x);
                Canvas.SetTop(myEllipse, tile.pos_y);


                switch (tile.field_owner)
                {
                    case 1: myEllipse.Fill = Brushes.White; player1.Score++;  break;
                    case 2: myEllipse.Fill = Brushes.Black; player2.Score++; break;
                    case 3: if (playerTurn == 0 && !endOfGame) { myEllipse.Fill = Brushes.Red; endGame = false; } break;
                    case 4: if (playerTurn == 1 && !endOfGame) { myEllipse.Fill = Brushes.Orange; endGame = false; } break;
                    case 5: if (playerTurn == 1 && !endOfGame) { myEllipse.Fill = Brushes.Orange; endGame = false;} else if (playerTurn == 0 && !endOfGame) { myEllipse.Fill = Brushes.Red; endGame = false; } break;
                }

                game_board.Children.Add(myEllipse);

                

                id++;
            }

            Player1Text.Text = player1.firstName + "\n" + player1.Score;
            Player2Text.Text = player2.firstName + "\n" + player2.Score;

            if (endGame && !endOfGame)
            {
                endGameTitle();
            }

            
        }


        private void rules_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("A játék szabályai: \n \n - A játékot két ember játszhatja \n - A cél minnél több pontot szerezni.\n   Ezt a saját korongjaink száma határozza meg." +
                "\n - Korongot akkor lehet lehelyezni, \n   ha közrefogja az ellenfél korongjait. \n - A játékosoknak lépéskötelezetsége van minden körben!" );
        }

        private void new_game_btn_Click(object sender, RoutedEventArgs e)
        {
            newGame();
        }

        private void newGame()
        {
            NewGameWindow new_game = new NewGameWindow();
            new_game.Show();
            this.Close();
        }
		
		private void high_score_btn_Click(object sender, RoutedEventArgs e)
        {
            ScoreBoard scoreboard = new ScoreBoard();
            scoreboard.Show();
        
        }

        private void game_board_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            try
            {
                
                int newID = game.calculateMousePosition(p.X, p.Y);               
                if ((game.gameMesh[newID].field_owner == playerTurn + 3 || game.gameMesh[newID].field_owner == 5) && !endOfGame )
                {
                    game.gameStep(newID, playerTurn + 1 );
                    playerTurn = (playerTurn + 1) % 2;
                    
                    playerTurnColors(playerTurn);

                    drawBoard();
                }
                if (isAI && playerTurn == 1)
                {
                    int aistep = game.aiStepInd();
                    game.gameStep(aistep, playerTurn + 1);
                    playerTurn = (playerTurn + 1) % 2;

                    playerTurnColors(playerTurn);

                    drawBoard();
                }
            }

            catch (ArgumentOutOfRangeException )
            {
            }
            
        }

        private void playerTurnColors(int playerTurn)
        {
            if (playerTurn == 0)
            {
                Player1Text.Foreground = System.Windows.Media.Brushes.Red;
                Player2Text.Foreground = System.Windows.Media.Brushes.Black;
            }

            else if (playerTurn == 1)
            {
                Player2Text.Foreground = System.Windows.Media.Brushes.Orange;
                Player1Text.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private int RandomizeStartingPlayer()
        {
            Random rand = new Random();
            if (rand.NextDouble() < 0.5)
            {
                return 0;
            }

            else return 1;
        }

        private void endGameTitle()
        {
            string winner = "";
            int winnerPoint = 0;

            if (player1.Score > player2.Score)
            {
                winner = player1.firstName;
                winnerPoint = player1.Score;
            }
            else {
                winner = player2.firstName;
                winnerPoint = player2.Score;
            }

            ScoreBoardView.SavePlayer(player1);
            ScoreBoardView.SavePlayer(player2);
            

            MessageBox.Show("A játék véget ért. \n A játék nyertese : " + winner + " " + winnerPoint + "Ponttal");

            endOfGame = true;
            drawBoard();
        }

        private void LastStateButton_Click(object sender, RoutedEventArgs e)
        {
            if (game.getLastState(isAI) && !endOfGame)
            {
                if (!isAI)
                {
                   playerTurn = (playerTurn + 1) % 2;
                }               
                playerTurnColors(playerTurn);
                drawBoard();
            }          
        }

        private void SurrenderButton_Click(object sender, RoutedEventArgs e)
        {
            endGameTitle();
            
        }
    }

        
}
