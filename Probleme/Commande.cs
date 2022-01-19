using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Probleme
{
    public class Commande : INotifyPropertyChanged
    {
        int no;
        string heure;
        DateTime date;
        string nomClient;
        Commis nomCommis;
        Livreur nomLivreur;
        Client leclient;
        List<Produit> items;
        string etat;
        string noClient;
        string solde;
        double total;
        public event PropertyChangedEventHandler PropertyChanged;
        

        public Commande()
        {
            this.no = 0;
            this.heure = "00H00";
            this.date = new DateTime(2021, 2, 1);
            this.nomClient = "";
            this.items = new List<Produit>();
            this.etat = "En Préparation";
            this.solde = "";
        }

        public Commande(int no,string heure,DateTime date,string nomClient,Commis nomCommis, List<Produit> items,string etat)
        {
            this.no = no;
            this.heure = heure;
            this.date = date;
            this.nomClient = nomClient;
            this.nomCommis = nomCommis;
            this.items = items;
            this.etat = etat;
            this.leclient = new Client(nomClient);
        }

        public Commande(int no,string heure,DateTime date,string noClient,Commis nomCommis,Livreur nomLivreur,string etat,string solde)
        {
            this.no = no;
            this.heure = heure;
            this.date = date;
            this.noClient = noClient;
            this.nomCommis = nomCommis;
            this.nomLivreur = nomLivreur;
            this.etat = etat;
            this.solde = solde;
            this.items = new List<Produit>();
            this.leclient = new Client(nomClient);
        }

        public Commande(int no, string heure, DateTime date, string noClient, string nomCommis, string nomLivreur, string etat, string solde)
        {
            this.no = no;
            this.heure = heure;
            this.date = date;
            this.noClient = noClient;
            this.nomCommis = new Commis(nomCommis);
            this.nomLivreur = new Livreur(nomLivreur);
            this.etat = etat;
            this.solde = solde;
            this.items = new List<Produit>();
            this.leclient = new Client(nomClient);
        }

        public int No
        {
            get { return this.no; }
            set { this.no = value; OnPropertyChanged("No"); }
        }

        public string Heure
        {
            get { return this.heure; }
            set { this.heure = value; OnPropertyChanged("Heure"); }
        }

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; OnPropertyChanged("Date"); }
        }

        public string NomClient
        {
            get { return this.nomClient; }
            set { this.nomClient = value; OnPropertyChanged("NomClient"); }
        }

        public Client LeClient
        {
            get { return this.leclient; }
            set { this.leclient = value; OnPropertyChanged("NomClient"); }
        }

        public Livreur NomLivreur
        {
            get { return this.nomLivreur; }
            set { this.nomLivreur = value; OnPropertyChanged("NomLivreur"); }
        }

        public double Total
        {
            get { return this.total; }
            set { this.total = value; OnPropertyChanged("Total"); }
        }

        public Commis NomCommis
        {
            get { return this.nomCommis; }
            set { this.nomCommis = value; OnPropertyChanged("NomCommis"); }
        }

        public List<Produit> Items
        {
            get { return this.items; }
            set { this.items = value; OnPropertyChanged("Items"); }
        }

        public string Etat
        {
            get { return this.etat; }
            set { this.etat = value; OnPropertyChanged("Etat"); }
        }

        public string Solde
        {
            get { return this.solde; }
            set { this.solde = value; OnPropertyChanged("Solde"); }
        }

        public string NoClient
        {
            get { return this.noClient; }
            set { this.noClient = value; OnPropertyChanged("NoClient"); }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public double PrixCommande()
        {
            double total = 0f;
            foreach(Produit p in items)
            {
                total += p.Prix;
            }
            return total;
        }

        public List<Commande> CommandePeriode(DateTime a,DateTime b,List<Commande> com)
        {
            List<Commande> result = new List<Commande>();
            foreach(Commande c in com)
            {
                if ((a < c.Date)&&(c.Date < b))
                {
                    result.Add(c);
                }
            }
            return result;
        }
    }
}
