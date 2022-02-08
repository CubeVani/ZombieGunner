using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ZombieGunner
{
    public class HighscoreWerte
    {

        public List<Highscore> _list = new List<Highscore>();
        public HighscoreWerte()
        {
            string[] tmp = File.ReadAllLines("../../../Highscore.txt");
            foreach (string item in tmp)
            {
                GameOver(item);
            }
        }
        public void GameOver(string item)
        {
            string[] array = item.Split(",");
            _list.Add(new Highscore(array[0], Convert.ToInt32(array[1])));
        }
        public void Speichern()
        {
            string[] x = new string[_list.Count];
            int count = 0;
            foreach (Highscore item in _list)
            {
                x[count] = item._name + "," + Convert.ToString(item._score);
                count++;
            }
            File.WriteAllLines("../../../Highscore.txt", x);
        }
        public List<Highscore> List
        {
            get
            {
                return _list;
            }
        }
    }
}
