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
        int playerSpeed = 9;
        int enemySpeed = 4;
        DispatcherTimer gameTime = new DispatcherTimer();
        List<Rectangle> itemRemover = new List<Rectangle>();

        Random rmd = new Random();
        int enemySpriteCounter = 0;
        int enemyCounter = 100;
        int limit = 50;
        private int _score;
        private int _health;
        private string _name;

        Rect playerHitBox;
        public Game(string name)
        {
            InitializeComponent();
            test.Content = name;
            _name = name;
            _score = 0;
            _health = 100;
            gameTime.Tick += TimerEvent;
            gameTime.Interval = TimeSpan.FromMilliseconds(5);
            gameTime.Start();
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            if(goUp == true && Canvas.GetTop(PlayerImage) > 5)
            {
                Canvas.SetTop(PlayerImage, Canvas.GetTop(PlayerImage) - playerSpeed);
            }
            if (goDown == true && Canvas.GetTop(PlayerImage) < 400)
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

            playerHitBox = new Rect(Canvas.GetLeft(PlayerImage), Canvas.GetTop(PlayerImage), PlayerImage.Width, PlayerImage.Height);

            enemyCounter -= 1;

            scoreTxt.Content = "Punkte: " + _score;
            lebenTxt.Content = "Leben: " + _health;

            if(enemyCounter < 0)
            {
                MakeEnemies();
                enemyCounter = limit;
            }


            foreach (var x in Canvas_Player.Children.OfType<Rectangle>())
            {
                if(x is Rectangle && (string)x.Tag == "bullet")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) - 20);
                    Rect bulletHitbox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if(Canvas.GetTop(x) < 10)
                    {
                        itemRemover.Add(x);
                    }

                    foreach (var y in Canvas_Player.Children.OfType<Rectangle>())
                    {
                        if (y is Rectangle && (string)y.Tag == "enemy")
                        {
                            Rect enemyHit = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                            if (bulletHitbox.IntersectsWith(enemyHit))
                            {
                                itemRemover.Add(x);
                                itemRemover.Add(y);
                                _score++;
                            }
                        }
                    }
                }

                if(x is Rectangle && (string)x.Tag == "enemy")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + enemySpeed);

                    if (Canvas.GetTop(x) > 550)
                    {
                        itemRemover.Add(x);
                        _health -= 10;
                    }

                    Rect enemyHitbox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (playerHitBox.IntersectsWith(enemyHitbox))
                    {
                        itemRemover.Add(x);
                        _health -= 5;
                    }
                }

            }

            foreach(Rectangle r in itemRemover)
            {
                Canvas_Player.Children.Remove(r);
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

        private void MakeEnemies()
        {
            ImageBrush enemy = new ImageBrush();

            enemySpriteCounter = rmd.Next(1, 5);

            switch (enemySpriteCounter)
            {
                case 1:
                    enemy.ImageSource = new BitmapImage(new Uri(@"Pics\zdown.png", UriKind.Relative));
                    break;
            }

            Rectangle newEnemy = new Rectangle
            {
                Tag = "enemy",
                Height = 50,
                Width = 50,
                Fill = enemy
            };

            Canvas.SetTop(newEnemy, -100);
            Canvas.SetLeft(newEnemy, rmd.Next(100, (int)Application.Current.MainWindow.Width) - 100);
            Canvas_Player.Children.Add(newEnemy);
        }
    }

    /*public class Bullet
    {
        public string direction;
        public int bulletLeft;
        public int bulletTop;

        public int bulletSpeed = 14;
        Rectangle newBullet = new Rectangle();
        DispatcherTimer bulletTime = new DispatcherTimer();

        public void MakeBullet(Canvas can)
        {
            newBullet.Tag = "bullet";
            newBullet.Height = 10;
            newBullet.Width = 10;
            newBullet.Fill = Brushes.Black;

            Canvas.SetLeft(newBullet, bulletLeft);
            Canvas.SetTop(newBullet, bulletTop);

            can.Children.Add(newBullet);

            bulletTime.Tick += BulletTimerEvent;
            bulletTime.Interval = TimeSpan.FromMilliseconds(5);
            bulletTime.Start();
        }

        private void BulletTimerEvent(object sender, KeyEventArgs e)
        {
            if (direction == "left")
            {
                bulletLeft -= bulletSpeed;
            }

            if (direction == "right")
            {
                bulletLeft += bulletSpeed;
            }

            if (direction == "up")
            {
                bulletTop -= bulletSpeed;
            }

            if (direction == "down")
            {
                bulletTop += bulletSpeed;
            }

            if (bulletLeft < 5 || bulletLeft > 1100 || bulletTop < 5 || bulletTop > 550)
            {
                bulletTime.Stop();
                newBullet = null;
                bulletTime = null;
            }
        }
    } */
}
