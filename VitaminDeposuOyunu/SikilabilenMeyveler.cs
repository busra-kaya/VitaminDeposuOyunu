using System;
using System.Collections.Generic;
using System.Text;

namespace VitaminDeposuOyunu
{
    abstract class SikilabilenMeyveler
    {
      
        private int _verimSikilabilen;
        private int _agirlikSikilabilen;
        public int VerimYaz
        {
            get { return _verimSikilabilen; }

            set
            {
                var rand = new Random();
                _verimSikilabilen = rand.Next(30, 70);
            }
        }

        public int AgirlikYaz
        {
            get { return _agirlikSikilabilen; }

            set
            {
                var rand = new Random();
                _agirlikSikilabilen = rand.Next(70, 120);
            }
        }

    }

    class Greyfurt : SikilabilenMeyveler
    {
        private double _suGreyfurt;
        private double _pureGreyfurt;
        public int SuHesaplaGreyfurt
        {
            get { return Convert.ToInt32(_suGreyfurt); }
            set { _suGreyfurt = AgirlikYaz * VerimYaz / 100; }
        }
        public int PureHesaplaGreyfurt
        {
            get { return Convert.ToInt32(_pureGreyfurt); }
            set { _pureGreyfurt = AgirlikYaz - _suGreyfurt; }
        }

    }
    
    class Portakal : SikilabilenMeyveler
    {
        private double _suPortakal;
        private double _purePortakal;

        public int SuHesaplaPortakal
        {
            get { return Convert.ToInt32(_suPortakal); }
            set { _suPortakal = AgirlikYaz * VerimYaz / 100; }
        }
        public int PureHesaplaPortakal
        {
            get { return Convert.ToInt32(_purePortakal); }
            set { _purePortakal = AgirlikYaz - _suPortakal; }
        }

    }
    class Mandalina : SikilabilenMeyveler
    {
        private double _suMandalina;
        private double _pureMandalina;

        public int SuHesaplaMandalina
        {
            get { return Convert.ToInt32(_suMandalina); }
            set { _suMandalina = AgirlikYaz * VerimYaz / 100; }
        }
        public int PureHesaplaMandalina
        {
            get { return Convert.ToInt32(_pureMandalina); }
            set { _pureMandalina = AgirlikYaz - _suMandalina; }
        }

    }
    

}
