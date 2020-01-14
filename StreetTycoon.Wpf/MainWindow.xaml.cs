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
using StreetTycoon.Lib.Entities;
using StreetTycoon.Lib.Services;

namespace StreetTycoon.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SpelVerloop game;


        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartSpel();
        }

        void StartSpel()
        {
            game = new SpelVerloop();
            ToonSpelerInfo();
            lstStraten.ItemsSource = StratenBeheer.Straten;
            btnGooien.IsEnabled = true;
            btnOpnieuw.Visibility = Visibility.Hidden;
        }

        void ToonSpelerInfo()
        {
            lblSpeler.Content = "";
            lblSpeler.Content = game.HuidigeSpeler;
            lblSaldo.Content = "€ " + game.HuidigeSpeler.Saldo.ToString();
        }

        private void BtnGooien_Click(object sender, RoutedEventArgs e)
        {
            game.GooidobbelSteen();
            lstStraten.SelectedIndex = game.HuidigeSpeler.HuidigePositie;
            //SperVerloop.HuidigeStraat = stratenBeheer.Zoek(SperVerloop.HuidigeSpeler.HuidigePositie);
            ToonSpelerInfo();
            PasGuiAan();
        }

        void PasGuiAan()
        {
            grdKoopInfo.Visibility = game.IsHuidigeStraatTeKoop() ? Visibility.Visible : Visibility.Hidden;
            if (game.KanSpelerDeHuidigeStraatKopen())
            {
                btnKopen.IsEnabled = true;
                lblKoopInfo.Content = $"Je kan {game.HuidigeSpeler.HuidigeStraat} kopen.\nJouw saldo: € {game.HuidigeSpeler.Saldo}";
            }
            else
            {
                btnKopen.IsEnabled = false;
                lblKoopInfo.Content = $"Je kan {game.HuidigeSpeler.HuidigeStraat} niet kopen.\nJouw saldo van € {game.HuidigeSpeler.Saldo} is ontoereikend";
            }
            tbkFeedBack.Visibility = Visibility.Hidden;
        }

        void ToonMelding(string melding, bool isSucces = false)
        {
            tbkFeedBack.Visibility = Visibility.Visible;
            tbkFeedBack.Text = melding;
            tbkFeedBack.Background = isSucces == true ?
                Brushes.Green :
                Brushes.Red;
        }

        private void btnKopen_Click(object sender, RoutedEventArgs e)
        {
            game.KoopStraat();
            ToonSpelerInfo();
            lstStraten.Items.Refresh();
            grdKoopInfo.Visibility = Visibility.Hidden;
            if (game.IsGameOver())
            {
                lblSpeler.Content = $"{game.HuidigeSpeler.Naam} is gewonnen";
                btnGooien.IsEnabled = false;
                btnOpnieuw.Visibility = Visibility.Visible;
            }
        }

        private void btnOpnieuw_Click(object sender, RoutedEventArgs e)
        {
            StartSpel();
        }

        private void btnVoegen_Click(object sender, RoutedEventArgs e)
        {
            decimal prijs = 0;
            string naam = txtStraatNaam.Text;
            try
            {
                prijs = decimal.Parse(txtPrijs.Text);
                try
                {
                    Straat straat = new Straat(naam, prijs);
                    if (game.VoegStraatToe(straat))
                    {
                        ToonMelding($"{straat} is toegevoegd", true);
                        txtPrijs.Clear();
                        txtStraatNaam.Clear();
                        lstStraten.Items.Refresh();
                    }
                    else
                    {
                        ToonMelding("Deze straat bestaat al");
                    }
                }
                catch (Exception ex)
                {
                    ToonMelding(ex.Message);
                }
            }
            catch (Exception)
            {
                ToonMelding("Geef een geldige prijs in");
            }

        }
    }
}
