using System;
using NI_Fonakolos_játék;
using NI_Fonakolos_játék.Model;
using NI_Fonakolos_játék.ModelView;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for NewGameWindow.xaml
    /// </summary>
    public partial class NewGameWindow : Window
    {
        bool isAi;

        public NewGameWindow()
        {
            InitializeComponent();
            Player1_box.IsEnabled = false;
            Player2_box.IsEnabled = false;
        }

        private void CvsP_clicked(object sender, RoutedEventArgs e)
        {
            isAi = true;
            CvsP_cmp.IsEnabled = false;
            PvsP.IsEnabled = true;

            Player1_box.IsEnabled = true;
            Player2_box.IsEnabled = false;

            playBTN.IsEnabled = true;
        }


        private void playBTN_Click(object sender, RoutedEventArgs e)
        {
            if(checkInputData()){
                MainWindow main = new MainWindow(isAi, Player1_box.Text, Player2_box.Text);
                main.Show();
                this.Close();
            }
            else{
                MessageBox.Show("Bad Input Data")
            }

        }

        private bool checkInputData(){
            if(Player1_box.Text != ""){
                if(!isAI && Player2_box.Text == ""){
                    return false;
                }

                return true;
            }

            return false;
        }

        private void PvsP_Click(object sender, RoutedEventArgs e)
        {
            isAi = false;
            CvsP_cmp.IsEnabled = true;
            PvsP.IsEnabled = false;

            Player1_box.IsEnabled = true;
            Player2_box.IsEnabled = true;

            playBTN.IsEnabled = true;
        }

        private void exitBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
