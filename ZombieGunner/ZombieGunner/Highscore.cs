using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ZombieGunner
{
    public class Highscore
    {
        public string _name;
        public int _score;

        public Highscore(string name, int score)
        {
            _name = name;
            _score = score;

        }
        public override string ToString()
        {
            return String.Format("{0} {1}", _name, _score);
        }
    }
}
