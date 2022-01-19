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
    /// Logique d'interaction pour ModuleClientEffectif.xaml
    /// </summary>
    public partial class ModuleClientEffectif : Window
    {
        List<Client> clients;
        List<Commis> commis;
        List<Livreur> livreurs;
        public delegate List<Personne> TypeTri(List<Personne> liste);
        public ModuleClientEffectif(List<Client> clients, List<Commis> commis, List<Livreur> livreurs,List<Commande> commande)
        {
            this.clients = clients;
            this.commis = commis;
            this.livreurs = livreurs;
            this.DataContext = this;
            InitializeComponent();

            foreach (Commande c in commande)
            {
                bool trouve = false;
                foreach (Commis co in commis)
                {
                    if (c.NomCommis != null)
                    {
                        if (co.Nom == c.NomCommis.Nom)
                        {
                            trouve = true;
                        }
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
                foreach (Livreur li in livreurs)
                {
                    if (c.NomLivreur != null)
                    {
                        if (li.Nom == c.NomLivreur.Nom)
                        {
                            trouve = true;
                        }
                    }
                }
                if (!trouve)
                {
                    livreurs.Add(c.NomLivreur);
                }
            }

            ButtonClients.IsEnabled = false;
            ButtonLivreurs.IsEnabled = true;
            ButtonCommis.IsEnabled = true;
            list1.ItemsSource = clients;
        }


        private void TriVille(object sender, RoutedEventArgs e)
        {
            Alph.IsEnabled = true;
            Ville.IsEnabled = false;
            Montant.IsEnabled = true;

            List<Personne> listville = new List<Personne>();
            foreach (Personne p in list1.ItemsSource)
            {
                listville.Add(p);
            }
            list1.ItemsSource = AppliqueFonction(TriVille, listville); ;
        }

        private void TriMontant(object sender, RoutedEventArgs e)
        {
            Alph.IsEnabled = true;
            Ville.IsEnabled = true;
            Montant.IsEnabled = false;

            List<Personne> listmont=new List<Personne>();
            foreach (Personne p in list1.ItemsSource)
            {
                listmont.Add(p);
            }
            list1.ItemsSource = AppliqueFonction(TriMontant, listmont);
        }

        private void TriAlph(object sender, RoutedEventArgs e)
        {
            Alph.IsEnabled = false;
            Ville.IsEnabled = true;
            Montant.IsEnabled = true;
            List<Personne> listalph = new List<Personne>();
            foreach (Personne p in list1.ItemsSource)
            {
                listalph.Add(p);
            }
            list1.ItemsSource = AppliqueFonction(TriAlphabetique,listalph);
        }

        public static List<Personne> AppliqueFonction(TypeTri t,List<Personne> liste)
        {
            return t(liste);
        }

        public static List<Personne> TriAlphabetique(List<Personne> liste)
        {
            int n = liste.Count() - 1;
            for (int i = n; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (liste[j - 1].Nom.CompareTo(liste[j].Nom) == 1)
                    {
                        Personne temp = liste[j - 1];
                        liste[j - 1] = liste[j];
                        liste[j] = temp;
                    }
                }
            }
            return liste;
        }

        public static List<Personne> TriMontant(List<Personne> liste)
        {
            int n = liste.Count() - 1;
            for (int i = n; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (liste[j - 1].Total > liste[j].Total)
                    {
                        Personne temp = liste[j - 1];
                        liste[j - 1] = liste[j];
                        liste[j] = temp;
                    }
                }
            }
            return liste;
        }

        public static List<Personne> TriVille(List<Personne> liste)
        {
            int n = liste.Count() - 1;
            for (int i = n; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (liste[j - 1].Adresse.CompareTo(liste[j].Adresse) == 1)
                    {
                        Personne temp = liste[j - 1];
                        liste[j - 1] = liste[j];
                        liste[j] = temp;
                    }
                }
            }
            return liste;
        }

        public List<Client> Clients
        {
            get { return this.clients; }
        }

        public List<Commis> Commis
        {
            get { return this.commis; }
        }

        public List<Livreur> Livreurs
        {
            get { return this.livreurs; }
        }

        private void AfficheCommis(object sender, RoutedEventArgs e)
        {
            ButtonClients.IsEnabled = true;
            ButtonLivreurs.IsEnabled = true;
            ButtonCommis.IsEnabled = false;
            Alph.IsEnabled = true;
            Ville.IsEnabled = true;
            Montant.IsEnabled = true;
            list1.ItemsSource = commis;
        }

        private void AffichageLivreurs(object sender, RoutedEventArgs e)
        {
            ButtonClients.IsEnabled = true;
            ButtonLivreurs.IsEnabled = false;
            ButtonCommis.IsEnabled = true;
            Alph.IsEnabled = true;
            Ville.IsEnabled = true;
            Montant.IsEnabled = true;
            list1.ItemsSource = livreurs;
        }

        private void AffichageClients(object sender, RoutedEventArgs e)
        {
            ButtonClients.IsEnabled = false;
            ButtonLivreurs.IsEnabled = true;
            ButtonCommis.IsEnabled = true;
            Alph.IsEnabled = true;
            Ville.IsEnabled = true;
            Montant.IsEnabled = true;
            list1.ItemsSource = clients;
        }
    }
}
