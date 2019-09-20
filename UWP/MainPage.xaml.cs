using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ModelObjet;
using Windows.UI.Popups;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<string> lesCategories;
        List<string> lesEtats;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void CmdValider_Click(object sender, RoutedEventArgs e)
        {
            // Case remplie

            //On teste si l'utilisateur a saisi un prix 
            if (txtPrix.Text == "")
            {
                var dialog = new MessageDialog("Saisir le prix");
                await dialog.ShowAsync();
            }
            else
            {
                //On teste si l'utilisateur a sélectionné un statut (Membre ou pas)
                if (rbOui.IsChecked == false && rbNon.IsChecked == false)
                {
                    var dialog = new MessageDialog("Saisir si vous êtes membre");
                    await dialog.ShowAsync();
                }
                else
                {
                    bool membre = false;
                    if (rbOui.IsChecked == true)
                    {
                        membre = true;
                    }
                    if (rbNon.IsChecked == false)
                    {
                        membre = false;
                    }

                    //Maintenant, on fait le remboursement
                    lblRemboursement.Text = Condition.CalculerMontantRembourse(
                        lblNbJours.Value,
                        cboCategories.SelectedItem.ToString(),
                        rbOui.IsChecked == true,
                        cboEtats.SelectedItem.ToString(),
                        Convert.ToInt16(txtPrix)) ;

                }
            }
        }

        private void SldNbJours_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            // Case remplie
            lblNbJours.Text = Convert.ToInt16(sldNbJours.Value).ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Ne pas modifier les lignes ci-dessous
            lesCategories = new List<string>();
            lesCategories.Add("Jouet"); lesCategories.Add("Livre"); lesCategories.Add("Informatique");
            cboCategories.ItemsSource = lesCategories;

            lesEtats = new List<string>();
            lesEtats.Add("Abimé"); lesEtats.Add("Très abimé"); lesEtats.Add("Bon"); lesEtats.Add("Très bon");
            cboEtats.ItemsSource = lesEtats;
        }
    }
}
