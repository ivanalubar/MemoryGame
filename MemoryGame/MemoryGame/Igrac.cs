using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoryGame
{
    public abstract class Igrac
    {
        private string _ime;
        public string Ime
        {
            get { return _ime; }
            set { _ime = value; }
        }
        private string _razina;
        public string Razina
        {
            get { return _razina; }
            set { _razina = value; }
        }
        private bool _rezultat;
        public bool Rezultat
        {
            get { return _rezultat; }
            set { _rezultat = value; }
        }
        public Igrac(string i,string r,bool rez)
        {
            Ime = i;
            Razina = r;
            Rezultat = rez;
        }
    }
    class Pocetnik : Igrac
    {
        public Pocetnik(string ime,string razina,bool rez)
            : base(ime,razina,rez)
        { }
    }
    class Napredni : Igrac
    {
        public Napredni(string ime,string razina,bool rez)
            : base(ime,razina,rez)
        { }
    }
   
}
