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
    /// Logique d'interaction pour CreerCommande.xaml
    /// </summary>
    public partial class CreerCommande : Window
    {
        Commande c;
        public CreerCommande(Commande c)
        {
            this.DataContext = this;
            InitializeComponent();
            this.c = c;
        }

        private void create(object sender, RoutedEventArgs e)
        {
            c.No = Convert.ToInt32(no.Text);
            c.Heure = heure.Text;
            c.Date = Convert.ToDateTime(date.Text);
            c.NoClient = noclient.Text;
            c.NomCommis = new Commis(commis.Text);
            c.NomCommis.NbCommande = c.NomCommis.NbCommande+1;
            c.NomLivreur = new Livreur(livreur.Text);
            c.Etat = "Préparation";
            c.Solde = "";

            if ((type1.Text != null) && (taille1.Text != null) && (quantite1 != null) && (Convert.ToInt32(quantite1.Text) > 0))
            {
                Pizza p = new Pizza(type1.Text, taille1.Text);
                for (int i = 0; i < Convert.ToInt32(quantite1.Text); i++)
                {
                    c.Items.Add(p);
                }
            }
            if ((type2.Text != null) && (taille2.Text != null) && (quantite2 != null) && (Convert.ToInt32(quantite2.Text) > 0))
            {
                Pizza p = new Pizza(type2.Text, taille2.Text);
                for (int i = 0; i < Convert.ToInt32(quantite2.Text); i++)
                {
                    c.Items.Add(p);
                }
            }
            if ((nom1.Text != null) && (volume1.Text != null) && (quantite3 != null) && (Convert.ToInt32(quantite3.Text) > 0))
            {
                Boisson b = new Boisson(nom1.Text, Convert.ToInt32(volume1.Text));
                for (int i = 0; i < Convert.ToInt32(quantite3.Text); i++)
                {
                    c.Items.Add(b);
                }
            }
            if ((nom2.Text != null) && (volume2.Text != null) && (quantite4 != null) && (Convert.ToInt32(quantite4.Text) > 0))
            {
                Boisson b = new Boisson(nom2.Text, Convert.ToInt32(volume2.Text));
                for (int i = 0; i < Convert.ToInt32(quantite4.Text); i++)
                {
                    c.Items.Add(b);
                }
            }
            c.Total = c.PrixCommande();
            this.Close();
        }
    }
}
