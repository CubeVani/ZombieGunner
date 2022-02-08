using System;
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
using System.IO;
using System.Windows.Threading;

namespace ZombieGunner
{
    /// <summary>
    /// Interaktionslogik für Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        bool goLeft, goRight, goUp, goDown;
        int playerSpeed = 8;
        DispatcherTimer gameTime = new DispatcherTimer();

        private int _score;
        private string _name;
        public Game(string name)
        {
            InitializeComponent();
            test.Content = name;
            _name = name;
            _score = 0;
            gameTime.Tick += TimerEvent;
            gameTime.Interval = TimeSpan.FromMilliseconds(20);
            gameTime.Start();
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            if(goUp == true && Canvas.GetTop(PlayerImage) > 5)
            {
                Canvas.SetTop(PlayerImage, Canvas.GetTop(PlayerImage) - playerSpeed);
            }
            if (goDown == true && Canvas.GetTop(PlayerImage) < 500)
            {
                Canvas.SetTop(PlayerImage, Canvas.GetTop(PlayerImage) + playerSpeed);
            }
            if (goLeft == true && Canvas.GetLeft(PlayerImage) > 5)
            {
                Canvas.SetLeft(PlayerImage, Canvas.GetLeft(PlayerImage) - playerSpeed);
            }
            if (goRight == true && Canvas.GetLeft(PlayerImage) < 1000)
            {
                Canvas.SetLeft(PlayerImage, Canvas.GetLeft(PlayerImage) + playerSpeed);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                Canvas.SetLeft(PlayerImage, Canvas.GetLeft(PlayerImage) - playerSpeed);
                testLeftLabel.Content = "Left: " + Canvas.GetLeft(PlayerImage);



            /*HighscoreWerte highscore = new HighscoreWerte();
            highscore.GameOver(_name + "," + _score);
            highscore.Speichern();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close(); */
        }

        private void Canvas_Player_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S)
            {
                goDown = true;
            }

            if (e.Key == Key.W)
            {
                goUp = true;
            }

            if (e.Key == Key.A)
            {
                goLeft = true;
            }

            if (e.Key == Key.D)
            {
                goRight = true;
            }
        }

        private void Canvas_Player_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S)
            {
                goDown = false;
            }

            if (e.Key == Key.W)
            {
                goUp = false;
            }

            if (e.Key == Key.A)
            {
                goLeft = false;
            }

            if (e.Key == Key.D)
            {
                goRight = false;
            }
        }
    }
}
