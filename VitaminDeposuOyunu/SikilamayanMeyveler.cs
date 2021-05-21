using System;
using System.Collections.Generic;
using System.Text;

namespace VitaminDeposuOyunu
{

    abstract public class SikilamayanMeyveler 
    {
        private int _verimSikilamayan;
        private int _agirlikSikilamayan;
        public int VerimYaz
        {
            get { return _verimSikilamayan; }

            set
            {
                var rand = new Random();
                _verimSikilamayan = rand.Next(80, 95);
            }
        }

        public int AgirlikYaz
        {
            get { return _agirlikSikilamayan; }

            set
            {
                var rand = new Random();
                _agirlikSikilamayan = rand.Next(70, 120);
            }
        }


    }

    class Elma : SikilamayanMeyveler
    {
        private double _pureElma;
        private double _suElma;

        public int PureHesaplaElma
        {
            get { return Convert.ToInt32(_pureElma); }
            set { _pureElma = AgirlikYaz * VerimYaz / 100; }
        }
        public int SuHesaplaElma
        {
            get { return Convert.ToInt32(_suElma); }
            set { _suElma = AgirlikYaz - _pureElma; }
        }
    }
    class Armut : SikilamayanMeyveler
    {
        private double _pureArmut;
        private double _suArmut;

        public int PureHesaplaArmut
        {

            get { return  Convert.ToInt32(_pureArmut) ; }
            set { _pureArmut = AgirlikYaz * VerimYaz / 100; }

        }
        public int SuHesaplaArmut
        {
            get { return Convert.ToInt32(_suArmut); }
            set { _suArmut = AgirlikYaz - _pureArmut; }
        }
    }
    class Cilek : SikilamayanMeyveler
    {
        private double _pureCilek;
        private double _suCilek;

        public int PureHesaplaCilek
        {
            get { return Convert.ToInt32(_pureCilek); }
            set { _pureCilek = AgirlikYaz * VerimYaz / 100; }
        }
        public int SuHesaplaCilek
        {
            get { return Convert.ToInt32(_suCilek); }
            set { _suCilek = AgirlikYaz - _pureCilek; }
        }
    }


}
