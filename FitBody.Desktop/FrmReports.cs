using FitBody.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitBody.Desktop
{
    public partial class FrmReports : Form
    {
        private ApiService _reportsService = new ApiService("reports");
        public FrmReports()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        private async void FrmReports_Load(object sender, EventArgs e)
        {
            if (ApiService.Permission == 0)
            {
                btnPosts.Visible = false;
                btnUsers.Visible = false;
            }
            WindowState = FormWindowState.Maximized;
            await LoadUsers();
            await LoadPosts();
        }
        private async Task LoadUsers()
        {
            var data = (await _reportsService.Get<List<UserReportDto>>(null, "users"));

            usersDataGrid.DataSource = data;
        }
        private async Task LoadPosts()
        {
            var data = (await _reportsService.Get<List<PostReportDto>>(null, "posts"));

            postsDataGrid.DataSource = data;
        }
        private async void btnUsers_Click_1(object sender, EventArgs e)
        {
            await _reportsService.GetExcelFile($"Users_Report_{DateTime.UtcNow.Ticks}.xls", "users");

        }
        private async void btnPosts_Click_1(object sender, EventArgs e)
        {
            await _reportsService.GetExcelFile($"Posts_Report_{DateTime.UtcNow.Ticks}.xls", "posts");

        }
    }
}
