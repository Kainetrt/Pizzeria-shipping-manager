using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme
{
    public class Livreur:Personne
    {
        string etat;
        string moyenTransport;
        int nbCommande;

        public Livreur(string nom, string prenom="", string adresse="", string telephone="") : base(nom, prenom, adresse, telephone)
        {
            this.nbCommande = 0;
            this.etat = "libre";
        }

        public Livreur(string nom, string prenom, string adresse, string telephone, string etat,string moyenTransport):base(nom,prenom,adresse,telephone)
        {
            this.etat = etat;
            this.moyenTransport = moyenTransport;
            this.nbCommande = 0;
        }

        public string Etat
        {
            get { return this.etat; }
            set { this.etat = value; }
        }

        public string MoyenTransport
        {
            get { return this.moyenTransport; }
            set { this.moyenTransport = value; }
        }

        public int NbCommande
        {
            get { return this.nbCommande; }
            set { this.nbCommande = value; }
        }

        public void Livre()
        {
            nbCommande++;
        }
    }
}
