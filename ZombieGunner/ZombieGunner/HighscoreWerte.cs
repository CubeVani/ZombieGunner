using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ZombieGunner
{
    public class HighscoreWerte
    {

        public List<Highscore> _list = new List<Highscore>();
        public HighscoreWerte() //liest die Text Datei ein
        {
            string[] tmp = File.ReadAllLines("../../../Highscore.txt");
            foreach (string item in tmp)
            {
                GameOver(item);
            }
        }
        public void GameOver(string item) //teilt den eingelesenen Text in Name und Score un fügt die Werte in eine Liste
        {
            if(item != "")
            {
                string[] array = item.Split(",");
                _list.Add(new Highscore(array[0], Convert.ToInt32(array[1])));
            }
        }
        public void Speichern() //Schreibt die Liste in eine Text Datei und trennt den Namen und denn Score mit einem Komma
        {
            string[] x = new string[_list.Count];
            int count = 0;

            _list = SortList(_list);
            foreach (Highscore item in _list)
            {
                x[count] = item._name + "," + Convert.ToString(item._score);
                count++;
            }
            File.WriteAllLines("../../../Highscore.txt", x);
        }

        public List<Highscore> SortList(List<Highscore> list) //soll die Liste nach dem Score absteigend sotieren
        {
            List<Highscore> _list = new List<Highscore>();

            int listCont = list.Count;
            for (int x = 0; x < listCont; x++)
            {
                int wert = 0;
                Highscore test = null;
                foreach (Highscore item2 in list)
                {
                    if (wert <= item2._score)
                    {
                        wert = item2._score;
                        test = item2;
                    }
                }
                _list.Add(test);
                if(test != null)
                    list.RemoveAt(list.IndexOf(test));
            }
            return _list;
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
