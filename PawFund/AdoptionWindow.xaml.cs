using BussinessObject.Models;
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
    public partial class AdoptionWindow : Window
    {
        private Pet _selectedPet;

        public AdoptionWindow(Pet selectedPet)
        {
            InitializeComponent();
            _selectedPet = selectedPet;
            txtPetName.Text = _selectedPet.PetName;
        }

        private void btnSubmitAdoption_Click(object sender, RoutedEventArgs e)
        {
            string address = txtAddress.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string email = txtEmail.Text;
            string selfDescription = txtSelfDescription.Text;
            bool hasPetExperience = chkHasPetExperience.IsChecked ?? false;
            string reasonForAdopting = txtReasonForAdopting.Text;

            var userId = GetUserId();

            if (userId.HasValue)
            {
                SaveAdoptionRequest(userId.Value, _selectedPet.PetId, address, phoneNumber, email, selfDescription, hasPetExperience, reasonForAdopting);
            }
            else
            {
                MessageBox.Show("User not logged in.");
            }
        }

        private int? GetUserId()
        {
            return UserSession.UserId;
        }

        private void SaveAdoptionRequest(int userId, int petId, string address, string phoneNumber, string email, string selfDescription, bool hasPetExperience, string reasonForAdopting)
        {
            string connectionString = "Server=local\\SQLEXPRESS;TrustServerCertificate=True;uid=sa;pwd=123456;database=PawFundProject;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO [dbo].[Adoption] (UserId, PetId, Address, PhoneNumber, Email, SelfDescription, HasPetExperience, ReasonForAdopting, IsApproved) " +
                                   "VALUES (@UserId, @PetId, @Address, @PhoneNumber, @Email, @SelfDescription, @HasPetExperience, @ReasonForAdopting, @IsApproved)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho các trường trong bảng Adoption, bao gồm cả IsApproved
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@PetId", petId);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@SelfDescription", selfDescription);
                        command.Parameters.AddWithValue("@HasPetExperience", hasPetExperience);
                        command.Parameters.AddWithValue("@ReasonForAdopting", reasonForAdopting);

                        // Đặt IsApproved mặc định là False khi tạo yêu cầu
                        command.Parameters.AddWithValue("@IsApproved", "False");

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Adoption request submitted successfully!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to submit adoption request.");
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
