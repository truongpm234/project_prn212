using BussinessObject.Models;
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
    /// Interaction logic for CreatePetWindowxaml.xaml
    /// </summary>
    public partial class CreatePetWindowxaml : Window
    {
        public Pet NewPet { get; private set; }  

        public CreatePetWindowxaml()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
         
            NewPet = new Pet
            {
                PetName = txtPetName.Text,
                PetType = txtPetType.Text,
                Age = txtAge.Text,
                Gender = (cmbGender.SelectedItem as ComboBoxItem)?.Content.ToString(),
                Address = txtAddress.Text,
                MedicalCondition = txtMedicalCondition.Text,
                IsAdopted = chkIsAdopted.IsChecked.GetValueOrDefault(false), 
                Description = txtDescription.Text,
                Color = txtColor.Text,
                Size = txtSize.Text,
                UserId = int.TryParse(txtUserId.Text, out int userId) ? userId : (int?)null 
            };

            DialogResult = true; 
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; 
        }
    }
}
