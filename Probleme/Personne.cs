using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Probleme
{
    public abstract class Personne : INotifyPropertyChanged
    {
        protected string nom;
        protected string prenom;
        protected string adresse;
        protected string telephone;
        protected double total;
        public event PropertyChangedEventHandler PropertyChanged;

        public Personne(string nom,string prenom,string adresse,string telephone)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.telephone = telephone;
            this.total = 0f;
        }

        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; OnPropertyChanged("Nom"); }
        }

        public string Prenom
        {
            get { return this.prenom; }
            set { this.prenom = value; OnPropertyChanged("Prenom"); }
        }

        public string Adresse
        {
            get { return this.adresse; }
            set { this.adresse = value; OnPropertyChanged("Adresse"); }
        }

        public string Telephone
        {
            get { return this.telephone; }
            set { this.telephone = value; OnPropertyChanged("Telephone"); }
        }

        public double Total
        {
            get { return this.total; }
            set { this.total = value; OnPropertyChanged("Total"); }
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
