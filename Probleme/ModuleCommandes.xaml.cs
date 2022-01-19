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
    
    public partial class ModuleCommandes : Window
    {
        List<Commande> com;
        public ModuleCommandes(List<Commande> com)
        {
            this.com = com;
            this.DataContext = this;
            InitializeComponent();
            list1.ItemsSource = com;
        }

        public List<Commande> Com
        {
            get { return this.com; }
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            Commande c=new Commande();
            CreerCommande w = new CreerCommande(c);
            w.Show();
            List <Commande> com2 = new List<Commande>();
            foreach(Commande a in com)
            {
                com2.Add(a);
            }
            com2.Add(c);
            com.Add(c);
            list1.ItemsSource = com2;
            
        }

        private void Preparate(object sender, RoutedEventArgs e)
        {
            Commande commande = list1.SelectedItem as Commande;
            if ((commande.Etat==null)||(commande.Etat== "fermee"))
            {
                foreach (Commande c in com)
                {
                    if (c.No == commande.No)
                    {
                        c.NomCommis.NbCommande= c.NomCommis.NbCommande+1;
                        c.Etat = "Préparation";
                    }
                }
                List<Commande> com2 = new List<Commande>();
                foreach (Commande c in com)
                {
                    com2.Add(c);
                }
                list1.ItemsSource = com2;
            }
        }

        private void Deliver(object sender, RoutedEventArgs e)
        {
            Commande commande = list1.SelectedItem as Commande;
            if (commande.Etat== "Préparation")
            {
                foreach (Commande c in com)
                {
                    if (c.No == commande.No)
                    {
                        c.Etat = "Livraison";
                    }
                }
                List<Commande> com2 = new List<Commande>();
                foreach (Commande c in com)
                {
                    com2.Add(c);
                }
                list1.ItemsSource = com2;
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Commande commande = list1.SelectedItem as Commande;
            if (commande.Etat=="Livraison")
            {
                foreach (Commande c in com)
                {
                    if (c.No == commande.No)
                    {
                        c.NomLivreur.NbCommande = c.NomLivreur.NbCommande + 1;
                        c.Etat = "fermee";
                    }
                }
                List<Commande> com2 = new List<Commande>();
                foreach (Commande c in com)
                {
                    com2.Add(c);
                }
                list1.ItemsSource = com2;
            }
        }

        private void Affichage(object sender, RoutedEventArgs e)
        {
            Commande commande = list1.SelectedItem as Commande;
            if (commande != null)
            {
                AffichageCommande w = new AffichageCommande(commande);
                w.Show();
            } 
        }

        private void Encaisse(object sender, RoutedEventArgs e)
        {
            Commande commande = list1.SelectedItem as Commande;
            foreach (Commande c in com)
            {
                if (c.No == commande.No)
                {
                    c.Solde = "ok";
                }
            }
            List<Commande> com2 = new List<Commande>();
            foreach (Commande c in com)
            {
                com2.Add(c);
            }
            list1.ItemsSource = com2;
        }

        private void Perte(object sender, RoutedEventArgs e)
        {
            Commande commande = list1.SelectedItem as Commande;
            foreach (Commande c in com)
            {
                if (c.No == commande.No)
                {
                    c.Solde = "perdu";
                }
            }
            List<Commande> com2 = new List<Commande>();
            foreach (Commande c in com)
            {
                com2.Add(c);
            }
            list1.ItemsSource = com2;
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            List<Commande> com3 = new List<Commande>();
            int id = Convert.ToInt32(RechercheNo.Text);
            foreach (Commande c in com)
            {
                if (c.No == id)
                {
                    com3.Add(c);
                    
                }
            }
            list1.ItemsSource = com3;
        }
    }
}
