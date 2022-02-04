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

namespace ZombieGunner
{
    /// <summary>
    /// Interaktionslogik für Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private int _score;
        private string _name;
        public Game(string name)
        {
            InitializeComponent();
            test.Content = name;
            _name = name;
            _score = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HighscoreWerte highscore = new HighscoreWerte();
            highscore.GameOver(_name + "," + _score);
            highscore.Speichern();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
