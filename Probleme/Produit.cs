using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme
{
    public class Produit
    {
        protected string nom;
        protected double prix;

        public Produit(string nom)
        {
            this.nom = nom;
            this.prix = 0f;
        }

        public Produit(string nom, double prix)
        {
            this.nom = nom;
            this.prix = prix;
        }

        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }

        public double Prix
        {
            get { return this.prix; }
            set { this.prix = value; }
        }
    }
}
