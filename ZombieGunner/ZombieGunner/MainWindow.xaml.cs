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
using System.IO;

namespace ZombieGunner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string _name;
        public int _score;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            HighscoreWerte listHighscore = new HighscoreWerte();
            List<Highscore> list = listHighscore.List;
            foreach (Highscore item in list)
            {
                High.Items.Add(item);
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            string name = nameEingabe.Text;
            Game game = new Game(name);
            game.Show();
            this.Close();

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
