using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme
{
    class Pizza:Produit
    {
        string taille;

        public Pizza(string nom,string taille):base(nom)
        {
            this.nom = nom;
            this.taille = taille;
            if (nom == "Reine")
            {
                this.prix = 10f;
            }
            if (nom == "Champignon")
            {
                this.prix = 12f;
            }
        }

        public string Taille
        {
            get { return this.taille; }
            set { this.taille = value; }
        }
    }
}
