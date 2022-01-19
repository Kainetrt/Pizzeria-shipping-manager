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
    /// Logique d'interaction pour AffichageCommande.xaml
    /// </summary>
    public partial class AffichageCommande : Window
    {
        List<Pizza> plist;
        List<Boisson> blist;
        public AffichageCommande(Commande c)
        {
            this.DataContext = this;
            InitializeComponent();
            plist = new List<Pizza>();
            blist = new List<Boisson>();
            if (c.Items != null)
            {
                foreach (Produit p in c.Items)
                {
                    if(p is Boisson)
                    {
                        blist.Add(p as Boisson);
                    }
                    else
                    {
                        plist.Add(p as Pizza);
                    }
                }
            }
            pizzalist.ItemsSource = plist;
            boissonlist.ItemsSource = blist;
        }
    }
}
