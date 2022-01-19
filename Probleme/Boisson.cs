using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme
{
    class Boisson:Produit
    {
        int volume;

        public Boisson(string nom,int volume):base(nom)
        {
            this.volume = volume;
            if (nom == "Coca")
            {
                this.prix = 2f;
            }
            if (nom == "Fanta")
            {
                this.prix = 3f;
            }
        }

        public int Volume
        {
            get { return this.volume; }
            set { this.volume = value; }
        }
    }
}
