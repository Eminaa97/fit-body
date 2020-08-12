using FitBody.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FitBody.Desktop
{
    public partial class FrmFitBlog : Form
    {
        private ApiService _userService = new ApiService("users");
        private ApiService _postService = new ApiService("posts");
        public FrmFitBlog()
        {
            InitializeComponent();
        }

        private async void FrmFitBlog_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            var users= await _userService.Get<List<UserFollowDto>>(null, "followers"); ;
            dgvUsers.DataSource = users;
            label3.Text = users.Count.ToString();

            var posts = await _postService.Get<List<PostLikesDto>>(null, "mostLiked"); ;
            dgvPosts.DataSource = posts;

            dgvPosts.Columns[0].Visible = false;
            dgvUsers.Columns[0].Visible = false;
        }
    }
}
