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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        IUserRepository user = new UserRepository();
        public AdminWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadUser();


        }
        public void LoadUser()
        {
           var a = user.findAllUsers();
            dgair.ItemsSource = a;
            dgair.Items.Refresh();

        }

 
            private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
           
            var selectedUser = dgair.SelectedItem as User;

            if (selectedUser != null)
            {

                var updateWindow = new UpdateUserWindow(selectedUser);
                var result = updateWindow.ShowDialog();

                if (result == true) // Người dùng nhấn "Cập nhật"
                {
                   
                    user.updateUser(selectedUser);
                    LoadUser(); // Tải lại DataGrid để hiển thị thông tin mới
                }
            }
            else
            {
                MessageBox.Show("Please choose user to update.", "Annoucement", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = dgair.SelectedItem as User;

            if (selectedUser != null)
            {
                var messageBoxResult = MessageBox.Show("Are you sure want to delete this user", "Comfirm delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    user.deleteUser(selectedUser);
                    LoadUser();
                }
            }
            else
            {
                MessageBox.Show("Please choose user to delete.", "Annoucement", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
