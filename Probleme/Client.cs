using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Probleme
{
    public class Client:Personne, INotifyPropertyChanged
    {
        DateTime premiere;
        Commande commandeno;
        int nbCommande;
        List<Commande> historique;
        string noClient;
        public event PropertyChangedEventHandler PropertyChanged;


        public Client(string nom,string prenom="",string adresse="",string telephone="") : base(nom, prenom, adresse, telephone)
        {
            this.noClient = "";
        }

        public Client(string nom, string prenom, string adresse,string telephone,DateTime premiere):base(nom,prenom,adresse,telephone)
        {
            this.premiere = premiere;
            this.nbCommande = 0;
            this.historique = new List<Commande>();
            this.total = 0f;
            this.noClient = "";
        }

        public Client(int nbCommande,string nom, string prenom, string adresse, string telephone) : base(nom, prenom, adresse, telephone)
        {
            this.nbCommande = nbCommande;
            this.historique = new List<Commande>();
            this.total = 0f;
            this.noClient = "";
        }

        public string Telephone
        {
            get { return this.telephone; }
            set { this.telephone = value; OnPropertyChanged("Telephone"); }
        }

        public string Adresse
        {
            get { return this.adresse; }
            set { this.adresse = value; OnPropertyChanged("Adresse"); }
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

        public DateTime Premiere
        {
            get { return this.premiere; }
            set { this.premiere = value; OnPropertyChanged("Premiere"); }
        }

        public Commande Commandeno
        {
            get { return this.commandeno; }
            set { this.commandeno = value; OnPropertyChanged("Commandeno"); }
        }

        public int NbCommande
        {
            get { return this.nbCommande; }
            set { this.nbCommande = value; OnPropertyChanged("NbCommande"); }
        }

        public List<Commande> Historique
        {
            get { return this.historique; }
            set { this.historique = value; OnPropertyChanged("Historique"); }
        }

        public string NoClient
        {
            get { return this.noClient; }
            set { this.noClient = value; OnPropertyChanged("NoClient"); }
        }

        

        public double MoyenneCommande(List<Commande> com)
        {
            double result = 0f;
            int compteur = 0;
            if (com != null)
            {
                foreach (Commande c in com)
                {
                    result += c.PrixCommande();
                }
                result = result / compteur;
            }
            return result;
        }

        public double PrixTotalCommande(List<Commande> com)
        {
            double result = 0f;
            if (com != null)
            {
                foreach (Commande c in com)
                {
                    result += c.PrixCommande();
                }
            }
            this.total = result;
            return result;
        }

        public void AjouterCommande(Commande c)
        {
            this.historique.Add(c);
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
