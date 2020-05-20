using Microsoft.Win32;
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
using Recepten.Lib.Entities;
using Recepten.Lib.Services;
using Recepten.Lib.Interfaces;

namespace Recepten.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Artikel huidigArtikel;
        ArtikelService artikelService;

        enum DataSources { EmptyData, MockData }

        public MainWindow()
        {
            InitializeComponent();

            artikelService = new ArtikelService(new MockDataArtikelen());
        }



        private void MaakGuiLeeg()
        {
            lstArtikelen.SelectedItem = null;
            ClearPanel(grdArtikel);
            cmbEenheid.SelectedIndex = 0;
            txtPrijs.Text = "0";
            txtArtikelnaam.Focus();
            tbkFeedback.Visibility = Visibility.Hidden;
        }

        Artikel GeefIngegevenArtikel()
        {
            Artikel ingegevenArtikel = null;
            string naam = txtArtikelnaam.Text;
            string eenheid = cmbEenheid.SelectedItem.ToString();
            try
            {
                decimal prijs = decimal.Parse(txtPrijs.Text);
                try
                {
                    int id = (huidigArtikel != null) ? huidigArtikel.Id : 0;
                    ingegevenArtikel = new Artikel(naam, eenheid, prijs, id);
                }
                catch (Exception ex)
                {
                    ToonMelding(ex.Message);
                }

            }
            catch (Exception)
            {
                ToonMelding("De prijs is geen geldig getal");
            }
            return ingegevenArtikel;
        }

        void ToonArtikelen()
        {
            lstArtikelen.ItemsSource = artikelService.Artikelen;
            lstArtikelen.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbDataSource.ItemsSource = Enum.GetValues(typeof(DataSources));
            cmbDataSource.SelectedIndex = 0;
        }

        void LaadBeginSituatie()
        {
            ToonArtikelen();
            cmbEenheid.ItemsSource = Artikel.Verpakkingen;
            lstArtikelen.SelectedIndex = 0;
            tbkFeedback.Visibility = Visibility.Hidden;
            txtPrijs.TextChanged += DecimalTextBox_TextChanged;
        }

        void BepaalDataSource(DataSources dataSource)
        {
            IArtikelData artikelBestand = null;
            switch(dataSource)
            {
                case DataSources.EmptyData:
                    artikelBestand = new EmptyDataArtikelen();
                    break;
                case DataSources.MockData:
                    artikelBestand = new MockDataArtikelen();
                    break;
                default:
                    break;
            }
            //nieuwe instance van ArtikelService op basis van een klasse die IArtikelData implementeert
            artikelService = new ArtikelService(artikelBestand);
        }

        private void lstArtikelen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            huidigArtikel = (Artikel)lstArtikelen.SelectedItem;
            if (huidigArtikel != null)
            {
                lblId.Content = huidigArtikel.Id;
                txtArtikelnaam.Text = huidigArtikel.Naam;
                txtPrijs.Text = huidigArtikel.Prijs.ToString();
                cmbEenheid.SelectedItem = huidigArtikel.Eenheid;
            }
            else ClearPanel(grdArtikel);
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            MaakGuiLeeg();
        }

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string artikelNaam = (huidigArtikel != null) ? huidigArtikel.Naam : "";
                artikelService.Verwijder(huidigArtikel);
                ToonArtikelen();
                MaakGuiLeeg();
                ToonMelding($"{artikelNaam} is verwijderd", true);
            }
            catch (Exception ex)
            {
                ToonMelding(ex.Message);
            }
            
        }

        private void btnSlaOp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                huidigArtikel = GeefIngegevenArtikel();
                if(huidigArtikel != null)
                {
                    string artikelNaam = (huidigArtikel != null) ? huidigArtikel.Naam : "";
                    artikelService.SlaOp(huidigArtikel);
                    ToonArtikelen();
                    MaakGuiLeeg();
                    ToonMelding($"{artikelNaam} is opgeslagen", true);
                }
            }
            catch (Exception ex)
            {
                ToonMelding(ex.Message);
            }
        }

        private void cmbDataSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataSources gekozenDataSource = (DataSources)cmbDataSource.SelectedItem;
            try
            {
                BepaalDataSource(gekozenDataSource);
                LaadBeginSituatie();
                tbkFeedback.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                ToonMelding(ex.Message);
            }

        }
    }
}
