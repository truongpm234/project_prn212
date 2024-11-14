using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Interaction logic for UpdateUserWindow.xaml
    /// </summary>
    public partial class UpdateUserWindow : Window
    {
        public User UpdatedUser { get; private set; }
        public UpdateUserWindow(User user)
        {
            InitializeComponent();
            txtUserId.Text = user.UserId.ToString();
            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            txtPhoneNumber.Text = user.PhoneNumber;
            txtAddress.Text = user.Address;
            txtPassword.Text = user.Password;
            txtRoleId.Text = user.RoleId.ToString();
            txtRoleName.Text = user.RoleName;
          


            UpdatedUser = user; 
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
           
            UpdatedUser.Username = txtUsername.Text;
            UpdatedUser.Email = txtEmail.Text;
            UpdatedUser.PhoneNumber = txtPhoneNumber.Text;
            UpdatedUser.Address = txtAddress.Text;
            UpdatedUser.Password = txtPassword.Text;
            DialogResult = true;

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
