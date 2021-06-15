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
        private bool isAi;
        MainWindow mw;
        bool isAgainstAI = false;
        string p1 = "";
        string p2 = "";
    
        public NewGameWindow(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
         
        }

        private void CvsP_clicked(object sender, RoutedEventArgs e)
        {
           
            isAgainstAI = true;
            HideInputPlayer();
            playBTN.Visibility = Visibility.Visible;
        }
        private void exitBTN_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Application.Current.Shutdown();
            /*
              MainWindow main = new MainWindow();
              main.Show();
              Close();
            */
        }

        private void playBTN_Click(object sender, RoutedEventArgs e)
        {
         
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void PvsP_Click(object sender, RoutedEventArgs e)
        {
            isAi = false;
            CvsP_cmp.IsEnabled = true;
            PvsP.IsEnabled = false;

            if (isAgainstAI)
            {
                mw.DataContext = new MainWindow(mw, true, p1, p2);

            }
            else
            {
                if ((p1 != "") && (p2 != ""))
                {
                    HideInputPlayer();
                    MainWindow gv = new MainWindow(mw, false, p1, p2);
                    if ((p1.Split(' ').Length > 1))
                    {
                        gv.p1_firstname = p1.Split(' ')[0];
                        gv.p1_lastname = p1.Split(' ')[1];
                    }
                    else
                    {
                        gv.p1_firstname = p1;
                        gv.p1_lastname = " ";
                    }
                    if (p2.Split(' ').Length > 1)
                    {
                        gv.p2_firstname = p2.Split(' ')[0];
                        gv.p2_lastname = p2.Split(' ')[1];
                    }
                    else
                    {
                        gv.p2_firstname = p2;
                        gv.p2_lastname = " ";
                    }
                    mw.DataContext = gv;
                }
                else MessageBox.Show("You must type a name!");
            }
        }

        private void HideInputPlayer()
        { 
            Player1.Visibility = Visibility.Hidden;
            Player1_box.Visibility = Visibility.Hidden;
            Player2_box.Visibility = Visibility.Hidden;
            Player2.Visibility = Visibility.Hidden;
        }
    }
}
