using FitBody.Common.Contracts;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FitBody.Desktop
{
    public partial class FrmUser : Form
    {
        private ApiService _userService = new ApiService("users");
        private ApiService _topicsService = new ApiService("TopicsSuggested");
        public TopicSuggestedInsertModel Topic { get; set; } = new TopicSuggestedInsertModel();

        private UserDto _user;
        private readonly int _userId;
        public FrmUser(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }
        private async void FrmUser_Load(object sender, EventArgs e)
        {
            _user = (UserDto)(await _userService.Get<UserDto>(null, $"{_userId}"));

            txtEmail.Text = _user.Email;
            txtFirstname.Text = _user.FirstName;
            txtHeight.Text = _user.Height.ToString();
            txtWeight.Text = _user.Weight.ToString();
            txtLastname.Text = _user.LastName;
            txtMobile.Text = _user.Mobile;
            txtInfo.Text = _user.Info;
            Active.Checked = _user.Active;
            TxtBirthdate.Text = _user.BirthDate.ToString();
            txtUsername.Text = _user.UserName;

            if (!string.IsNullOrEmpty(_user.Image))
            {
                using (var ms = new MemoryStream(Convert.FromBase64String(_user.Image)))
                {
                    picUser.Image = new Bitmap(Image.FromStream(ms), picUser.Width, picUser.Height);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                Topic.Topic = txtTopicSuggested.Text;
                Topic.DateCreated = DateTime.UtcNow;
                Topic.UserId = _userId;


                if (string.IsNullOrEmpty(Topic.Topic) || string.IsNullOrWhiteSpace(Topic.Topic))
                {
                    MessageBox.Show("Please insert a text");
                    return;
                }
                _ = await _topicsService.Post<TopicSuggestedDto>(Topic);

                txtTopicSuggested.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnFollow_Click(object sender, EventArgs e)
        {
            try
            {
                var follow = await _userService.Post<bool>(null, $"follow/{_user.Id}");

                btnFollow.Text = follow ? "Unfollow" : "Follow";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
