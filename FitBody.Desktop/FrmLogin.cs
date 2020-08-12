using FitBody.Common.Contracts;
using FitBody.Common.Requests;
using MetroFramework.Forms;
using System.Windows.Forms;

namespace FitBody.Desktop
{
    public partial class FrmLogin : MetroForm
    {
        private ApiService _usersService = new ApiService("users");

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmHome_Closing(object sender, FormClosingEventArgs e)
        {
            Show();
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            ApiService.Token = string.Empty;
            btnLogin.Enabled = true;
        }

        private async void btnLogin_Click(object sender, System.EventArgs e)
        {
            try
            {
                btnLogin.Enabled = false;

                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Username and password required!");
                    return;
                }

                var request = new UserLoginRequest
                {
                    UserName = txtUsername.Text,
                    Password = txtPassword.Text
                };

                var user = await _usersService.Post<AuthenticatedUser>(request, "login");

                ApiService.Token = user.Token;
                ApiService.Permission = user.Permission;
                ApiService.UserId = user.Id;
                FrmHome home = new FrmHome();
                home.Show();
                Hide();
                home.FormClosing += FrmHome_Closing;
            }
            catch (System.Exception ex)
            {
                btnLogin.Enabled = true;

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnRegister_Click(object sender, System.EventArgs e)
        {
            FrmRegistration frmRegistration = new FrmRegistration();
            frmRegistration.Show();
            Hide();
            frmRegistration.FormClosing += FrmHome_Closing;
        }
    }
}
