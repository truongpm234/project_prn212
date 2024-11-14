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
    /// Interaction logic for ManagerWindowxaml.xaml
    /// </summary>
    public partial class ManagerWindowxaml : Window
    {
        IPetRepository pet = new PetRepository();
        IAdoptionRepository adoption = new AdoptionRepository();
        public ManagerWindowxaml()
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

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            
                
                var createWindow = new CreatePetWindowxaml();
                var result = createWindow.ShowDialog();

                if (result == true) 
                {
                    var newPlayer = createWindow.NewPet;

   
                    pet.SavePet(newPlayer);

  
                    LoadPet();
                }
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
       
            var selectedPet = dgair.SelectedItem as Pet;

            if (selectedPet != null)
            {
                // Tạo cửa sổ UpdatePlayerWindow và truyền thông tin cầu thủ hiện tại vào
                var updateWindow = new UpdatePetWindow(selectedPet);
                var result = updateWindow.ShowDialog();

                if (result == true) // Người dùng nhấn "Cập nhật"
                {
                    // Cập nhật thông tin cầu thủ trong repository
                   pet.UpdatePet(selectedPet);
                    LoadPet(); 
                }
            }
            else
            {
                MessageBox.Show("Please choose pet to update", "Annoucement", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedPet = dgair.SelectedItem as Pet;

            if (selectedPet != null)
            {
                var messageBoxResult = MessageBox.Show("Are you sure want to delete this pet", "Comfirm delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    pet.DeletePet(selectedPet);
                    LoadPet();
                }
            }
            else
            {
                MessageBox.Show("Please choose pet to delete.", "Annoucement", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
