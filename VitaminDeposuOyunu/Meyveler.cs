using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace VitaminDeposuOyunu
{
 
    public  class Meyveler : IMeyveler
    {
        public Meyveler( int aVitamini,int cVitamini,Image image)
        {

            AVitamini = aVitamini;
            CVitamini = cVitamini;
            Image = image;
        }

        public Image Image { get; set; }
        public int AVitamini { get; set; }
        public int CVitamini { get; set; }

    }

}
