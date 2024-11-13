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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IUserRepository User = new UserRepository();
        public LoginWindow()
        {
            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var ml = txtEmailAddress.Text;
            var pa = txtPass.Password;
            var us = User.checkLogin(ml, pa);
            if (us != null)
            {
                if (us.UserId == 3)
                {
                    StaffWindow staffWindow = new StaffWindow();
                    staffWindow.ShowDialog();
                    Close();
                }
                else if (us.UserId == 2)
                {
                    ManagerWindowxaml managerWindow = new ManagerWindowxaml();
                    managerWindow.Show();
                    this.Close();
                }
                else if(us.UserId == 1)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close();
                }
                else if(us.UserId == 4)
                {
                    UserWindow userWindow = new UserWindow();
                    userWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You have no permission to access this function!");
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
