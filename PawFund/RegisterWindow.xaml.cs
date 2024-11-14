using Microsoft.Data.SqlClient;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Server=local\\SQLEXPRESS;TrustServerCertificate=True;uid=sa;pwd=123456;database=PawFundProject;";

            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string address = txtAddress.Text;
            string password = txtPassword.Password;
            string roleName = "User";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO [dbo].[User] (Username, Email, PhoneNumber, Address, Password, IsApprovedUser, RoleId, RoleName) " +
                                   "VALUES (@Username, @Email, @PhoneNumber, @Address, @Password, 1, 4, @RoleName)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@RoleName", roleName);

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Registration successful!");
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Registration failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
