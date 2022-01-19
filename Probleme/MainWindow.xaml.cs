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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Probleme
{
    public partial class MainWindow : Window
    {
        int compteur1 = 0;
        int compteur2 = 0;
        List<Client> clients;
        List<Commis> commis;
        List<Livreur> livreurs;
        List<Commande> commandes;

        public MainWindow()
        {
            InitializeComponent();
        }

        public List<Commis> LectureCommis(string fichier = "commis.csv")
        {
            List<Commis> result = null;
            StreamReader st = null;
            try
            {
                if (fichier == "Commis.csv")
                {
                    List<Commis> commis = new List<Commis>();
                    st = new StreamReader(fichier);
                    string line = null;
                    while ((line = st.ReadLine()) != null)
                    {
                        string[] com = line.Split(';');
                        Commis ComTemp = new Commis(com[0], com[1],com[2],com[3],com[4],Convert.ToDateTime(com[5]));
                        commis.Add(ComTemp);
                    }
                    result=commis;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            { if (st != null) st.Close(); }
            return result;
        }

        public List<Client> LectureClient(string fichier="Clients.csv")
        {
            List<Client> result = null;
            StreamReader st = null;
            try
            {
                if (fichier == "Clients.csv")
                {
                    List<Client> clients = new List<Client>();
                    st = new StreamReader(fichier);
                    string line = null;
                    while ((line = st.ReadLine()) != null)
                    {
                        string[] cli = line.Split(';');
                        Client CliTemp = new Client(cli[1], cli[2], cli[3], cli[4]);
                        clients.Add(CliTemp);
                    }
                    result = clients;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            { if (st != null) st.Close(); }
            return result;
        }

        public List<Livreur> LectureLivreur(string fichier="Livreur.csv")
        {
            List<Livreur> result = null;
            StreamReader st = null;
            try
            {
                if (fichier == "Livreur.csv")
                {
                    List<Livreur> livreurs = new List<Livreur>();
                    st = new StreamReader(fichier);
                    string line = null;
                    while ((line = st.ReadLine()) != null)
                    {
                        string[] liv = line.Split(';');
                        Livreur LivTemp = new Livreur(liv[0], liv[1], liv[2], liv[3], liv[4], liv[5]);
                        livreurs.Add(LivTemp);
                    }
                    result = livreurs;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            { if (st != null) st.Close(); }
            return result;
        }

        public List<Commande> LectureCommande(string fichier="Commandes.csv")
        {
            List<Commande> result = null;
            StreamReader st = null;
            try
            {
                if (fichier == "Commandes.csv")
                {
                    List<Commande> commandes = new List<Commande>();
                    st = new StreamReader(fichier);
                    string line = null;
                    while ((line = st.ReadLine()) != null)
                    {
                        string[] com = line.Split(',');
                        Commande ComTemp = new Commande(Convert.ToInt32(com[0]), com[1], Convert.ToDateTime(com[2]), com[3], com[4], com[5], com[6], com[7]);
                        commandes.Add(ComTemp);
                    }
                    result = commandes;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            { if (st != null) st.Close(); }
            return result;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ModuleClientEffectif(object sender, RoutedEventArgs e)
        {
            if (compteur1 == 0)
            {

                clients = LectureClient("Clients.csv");
                commis = LectureCommis("Commis.csv");
                livreurs = LectureLivreur("Livreur.csv");
                compteur1++;
            }
            if (compteur2 == 0)
            {
                commandes = LectureCommande("Commandes.csv");
                compteur2++;
            }
            
            ModuleClientEffectif w = new ModuleClientEffectif(clients,commis,livreurs, commandes);
            w.Show();
        }

        private void ModuleStatistiques(object sender, RoutedEventArgs e)
        {
            if (compteur1 == 0)
            {
                clients = LectureClient("Clients.csv");
                commis = LectureCommis("Commis.csv");
                livreurs = LectureLivreur("Livreur.csv");
                compteur1++;
            }
            if (compteur2 == 0)
            {
                commandes = LectureCommande("Commandes.csv");
                compteur2++;
            }
            ModuleStatistiques w = new ModuleStatistiques(clients,commis,livreurs,commandes);
            w.Show();
        }

        private void ModuleCommandes(object sender, RoutedEventArgs e)
        {
            if (compteur2 == 0)
            {
                commandes = LectureCommande("Commandes.csv");
                compteur2++;
            }
            ModuleCommandes w = new ModuleCommandes(commandes);
            w.Show();
        }

        private void ModuleAutre(object sender, RoutedEventArgs e)
        {
            ModuleAutre w = new ModuleAutre();
            w.Show();
        }

    }
}
