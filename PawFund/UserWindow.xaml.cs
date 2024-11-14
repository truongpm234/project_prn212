using BussinessObject.Models;
using Repositories;
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

namespace PawFund
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        IPetRepository pet = new PetRepository();
        IAdoptionRepository adoption = new AdoptionRepository();
        public UserWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadPet();


        }
        public void LoadPet()
        {
            var a = pet.GetAllPets();
            dgair.ItemsSource = a;
            dgair.Items.Refresh();

        }

        private void btnAdopt_Click(object sender, RoutedEventArgs e)
        {
            var selectedPet = dgair.SelectedItem as Pet;

            if (selectedPet != null)
            {
                AdoptionWindow adoptionWindow = new AdoptionWindow(selectedPet);
                adoptionWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a pet to adopt.");
            }
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
