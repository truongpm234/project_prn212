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
    /// Interaction logic for UpdatePetWindow.xaml
    /// </summary>
    public partial class UpdatePetWindow : Window
    {
        public Pet UpdatedPet { get; private set; }
        public UpdatePetWindow(Pet pet)
        {
            InitializeComponent();

            
            txtPetId.Text = pet.PetId.ToString();
            txtPetName.Text = pet.PetName;
            txtPetType.Text = pet.PetType;
            txtAge.Text = pet.Age;
            cmbGender.SelectedItem = pet.Gender;  
            txtAddress.Text = pet.Address;
            txtMedicalCondition.Text = pet.MedicalCondition;
            txtDescription.Text = pet.Description;
            txtColor.Text = pet.Color;
            txtSize.Text = pet.Size;
            txtUserId.Text = pet.UserId.ToString();  

       
            UpdatedPet = pet;
        }

       
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            
            UpdatedPet.PetName = txtPetName.Text;
            UpdatedPet.PetType = txtPetType.Text;
            UpdatedPet.Age = txtAge.Text;
            UpdatedPet.Address = txtAddress.Text;
            UpdatedPet.MedicalCondition = txtMedicalCondition.Text;
            UpdatedPet.Description = txtDescription.Text;
            UpdatedPet.Color = txtColor.Text;
            UpdatedPet.Size = txtSize.Text;      
            DialogResult = true;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    }
