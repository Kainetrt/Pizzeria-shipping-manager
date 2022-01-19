using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Probleme
{
    public class Commis:Personne, INotifyPropertyChanged
    {
        string etat;
        DateTime embauche;
        int nbCommande;
        public event PropertyChangedEventHandler PropertyChanged;

        public Commis(string nom, string prenom="", string adresse="", string telephone="") : base(nom, prenom, adresse, telephone)
        {
            this.nbCommande = 0;
            this.etat = "libre";
        }

        public Commis(string nom, string prenom, string adresse, string telephone, string etat, DateTime embauche):base(nom,prenom,adresse,telephone)
        {
            this.etat = etat;
            this.embauche = embauche;
            this.nbCommande = 0;
        }

        public string Etat
        {
            get { return this.etat; }
            set { this.etat = value; OnPropertyChanged("Etat"); }
        }

        public DateTime Embauche
        {
            get { return this.embauche; }
            set { this.embauche = value; OnPropertyChanged("Embauche"); }
        }

        public int NbCommande
        {
            get { return this.nbCommande; }
            set { this.nbCommande = value; OnPropertyChanged("NbCommande"); }
        }

        public void Decroche()
        {
            nbCommande++;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
