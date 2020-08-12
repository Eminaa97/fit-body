using FitBody.Common.Contracts;
using FitBody.Common.Requests;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FitBody.Desktop
{
    public partial class FrmRegistration : MetroForm
    {
        private ApiService _usersService = new ApiService("users");
        string avatarLocation;
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif",
                Multiselect = false
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                avatarLocation = dialog.FileName;
                var image = Image.FromFile(dialog.FileName);
                picAvatar.Image = new Bitmap(image, picAvatar.Size);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmHome_Closing(object sender, FormClosingEventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new UserInsertRequest
                {
                    UserName = txtUsername.Text,
                    Password = txtPassword.Text,
                    FirstName = txtFirstname.Text,
                    LastName = txtLastname.Text,
                    BirthDate = txtBirthdate.Value,
                    ConfirmPassword = txtConfirmPassword.Text,
                    Email = txtEmail.Text,
                    Height = float.Parse(txtHeight.Text),
                    Info = txtInfo.Text,
                    Mobile = txtMobile.Text,
                    Weight = float.Parse(txtWeight.Text),
                    Permission = chckPermission.Checked ? 1 : 0 // Trainer : User
                };

                using (Image image = Image.FromFile(avatarLocation))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();

                        string base64String = Convert.ToBase64String(imageBytes);
                        request.Image = base64String;
                    }
                }
                var user = await _usersService.Post<UserDto>(request, "register");

                MessageBox.Show("Succesfully registered");
                Close();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
