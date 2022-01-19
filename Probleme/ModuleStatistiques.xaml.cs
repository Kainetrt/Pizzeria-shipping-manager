using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Probleme
{
    /// <summary>
    /// Logique d'interaction pour ModuleStatistiques.xaml
    /// </summary>
    public partial class ModuleStatistiques : Window
    {
        List<Client> client;
        List<Commis> commis;
        List<Livreur> livreur;
        List<Commande> commande;
        public ModuleStatistiques(List<Client> client,List<Commis> commis,List<Livreur> livreur,List<Commande> commande)
        {
            this.client = client;
            this.commis = commis;
            this.livreur = livreur;
            this.commande = commande;
            this.DataContext = this;
            InitializeComponent();
            listclient.ItemsSource = client;
            listcommis.ItemsSource = commis;
            listlivreur.ItemsSource = livreur;
            listcommande.ItemsSource = commande;
            listperiode.ItemsSource = commande;
            foreach(Commande c in commande)
            {
                bool trouve = false;
                foreach (Commis co in commis)
                {
                    if (co.Nom == c.NomCommis.Nom)
                    {
                        trouve = true;
                    }
                }
                if (!trouve)
                {
                    commis.Add(c.NomCommis);
                }
            }

            foreach (Commande c in commande)
            {
                bool trouve = false;
                foreach (Livreur li in livreur)
                {
                    if (li.Nom == c.NomLivreur.Nom)
                    {
                        trouve = true;
                    }
                }
                if (!trouve)
                {
                    livreur.Add(c.NomLivreur);
                }
            }

            int compteur = 0;
            double moy = 0;
            foreach (Client c in client)
            {
                moy = moy+c.MoyenneCommande(c.Historique);
                compteur++;
            }
            MoyenneCompteClient.Text = Convert.ToString(moy / compteur);
            compteur = 0;
            moy = 0;
            foreach (Commande c in commande)
            {
                moy = moy+c.PrixCommande();
                compteur++;
            }
            MoyennePrixCommande.Text = Convert.ToString(moy/compteur);
            compteur = 0;
            moy = 0;
            foreach(Commande c in commande)
            {

            }
        }

        public List<Commande> Commande
        {
            get { return this.commande; }
            set { this.commande = value; }
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            DateTime a;
            DateTime b;
            if ((date1.Text =="__/__/____")&&(date2.Text=="__/__/____"))
            {
            }
            else
            {
                if (date1.Text == "__/__/____")
                {
                    b = Convert.ToDateTime(date2.Text);
                    List<Commande> result = new List<Commande>();
                    foreach (Commande c in commande)
                    {
                        if (c.Date < b)
                        {
                            result.Add(c);
                        }
                    }
                    listperiode.ItemsSource = result;
                }
                else
                {
                    if (date2.Text == "__/__/____")
                    {
                        a = Convert.ToDateTime(date1.Text);
                        List<Commande> result = new List<Commande>();
                        foreach (Commande c in commande)
                        {
                            if (a < c.Date)
                            {
                                result.Add(c);
                            }
                        }
                        listperiode.ItemsSource = result;
                    }
                    else
                    {
                        a = Convert.ToDateTime(date1.Text);
                        b = Convert.ToDateTime(date2.Text);
                        List<Commande> result = new List<Commande>();
                        foreach (Commande c in commande)
                        {
                            if ((a < c.Date) && (c.Date < b))
                            {
                                result.Add(c);
                            }
                        }
                        listperiode.ItemsSource = result;
                    }
                }
            }  
        }

    }
}
