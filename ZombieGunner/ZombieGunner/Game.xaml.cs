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
using System.Linq;

namespace ZombieGunner
{
    /// <summary>
    /// Interaktionslogik für Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        bool goLeft, goRight, goUp, goDown;
        int playerSpeed = 4;
        DispatcherTimer gameTime = new DispatcherTimer();

        private int _score;
        private int _health;
        private string _name;
        public Game(string name)
        {
            InitializeComponent();
            test.Content = name;
            _name = name;
            _score = 0;
            gameTime.Tick += TimerEvent;
            gameTime.Interval = TimeSpan.FromMilliseconds(5);
            gameTime.Start();
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            if(goUp == true && Canvas.GetTop(PlayerImage) > 5)
            {
                Canvas.SetTop(PlayerImage, Canvas.GetTop(PlayerImage) - playerSpeed);
                PlayerImage.Source = new BitmapImage(new Uri(@"C:\Users\bib\Desktop\Fächer\PRG\ZombieGunner\GitHub\ZombieGunner\Pics\up.png"));
            }
            if (goDown == true && Canvas.GetTop(PlayerImage) < 500)
            {
                Canvas.SetTop(PlayerImage, Canvas.GetTop(PlayerImage) + playerSpeed);
                PlayerImage.Source = new BitmapImage(new Uri(@"C:\Users\bib\Desktop\Fächer\PRG\ZombieGunner\GitHub\ZombieGunner\Pics\down.png"));
            }
            if (goLeft == true && Canvas.GetLeft(PlayerImage) > 5)
            {
                Canvas.SetLeft(PlayerImage, Canvas.GetLeft(PlayerImage) - playerSpeed);
                PlayerImage.Source = new BitmapImage(new Uri(@"C:\Users\bib\Desktop\Fächer\PRG\ZombieGunner\GitHub\ZombieGunner\Pics\left.png"));
            }
            if (goRight == true && Canvas.GetLeft(PlayerImage) < 1000)
            {
                Canvas.SetLeft(PlayerImage, Canvas.GetLeft(PlayerImage) + playerSpeed);
                PlayerImage.Source = new BitmapImage(new Uri(@"C:\Users\bib\Desktop\Fächer\PRG\ZombieGunner\GitHub\ZombieGunner\Pics\right.png"));
            }

            foreach(var x in Canvas_Player.Children.OfType<Rectangle>())
            {
                if(x is Rectangle && (string)x.Tag == "bullet")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) - 20);
                }
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

            if(e.Key == Key.Space)
            {
                Rectangle newBullet = new Rectangle
                {
                    Tag = "bullet",
                    Height = 10,
                    Width = 10,
                    Fill = Brushes.Black
                };

                Canvas.SetTop(newBullet, Canvas.GetTop(PlayerImage) + PlayerImage.Height / 2);
                Canvas.SetLeft(newBullet, Canvas.GetLeft(PlayerImage) + PlayerImage.Width / 2);

                Canvas_Player.Children.Add(newBullet);
            }
        }
    }
}
