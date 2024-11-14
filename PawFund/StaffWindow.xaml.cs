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
    /// Interaction logic for StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        IPetRepository pet = new PetRepository();
        IAdoptionRepository adoption = new AdoptionRepository();
        public StaffWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadAdoption();
            dgair.Items.Refresh();


        }
        public void LoadAdoption()
        {
            var a = adoption.GetAll();
            dgair.ItemsSource = a;
            dgair.Items.Refresh();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAcceptAdopt_Click(object sender, RoutedEventArgs e)
        {
            var selectedAdoption = dgair.SelectedItem as Adoption;

            if (selectedAdoption != null)
            {
                var messageBoxResult = MessageBox.Show("Are you sure you want to accept this adoption?", "Confirm accept", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    using (var context = new PawFundProjectContext())
                    {
                        var adoptionToUpdate = context.Adoptions
                            .SingleOrDefault(a => a.AdoptionId == selectedAdoption.AdoptionId);

                        if (adoptionToUpdate != null)
                        {
                            adoptionToUpdate.IsApproved = true;

                            context.SaveChanges();

                            selectedAdoption.IsApproved = true;
                            dgair.Items.Refresh();

                            MessageBox.Show("Adoption request has been accepted successfully.",
                                            "Confirmation",
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Could not find the selected adoption in the database.",
                                            "Error",
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose an adoption to accept.", "Announcement", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void dgair_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
