using FitBody.Common.Contracts;
using FitBody.Common.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using FitBody.Desktop.Models;

namespace FitBody.Desktop
{
    public partial class FrmUsers : Form
    {
        private ApiService _usersService = new ApiService("users");

        public FrmUsers()
        {
            InitializeComponent();
        }

        private async void FrmUsers_Load(object sender, EventArgs e)
        {
            if (ApiService.Permission == 0)
            {
                btnAdmin.Visible = false;
                btnDeactivate.Visible = false;
            }
            await LoadUsers();
            WindowState = FormWindowState.Maximized;
            dataGridView1.MultiSelect = false;
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await LoadUsers();
        }

        private async Task LoadUsers()
        {
            var userSearchRequest = new UserSearchRequest
            {
                Email = txtEmail.Text,
                UserName = txtUsername.Text
            };
            var data = (await _usersService.Get<List<UserDto>>(userSearchRequest))
                .Select(a => new UsersDataGrid
                {
                    Id = a.Id,
                    Email = a.Email,
                    Firstname = a.FirstName,
                    Lastname = a.LastName,
                    Username = a.UserName,
                    Active = a.Active,
                    Permission = a.Permission
                }).ToList();

            dataGridView1.DataSource = data;
        }

        private async void btnDeactivate_Click(object sender, EventArgs e)
        {
            try
            {
                var index = dataGridView1.SelectedCells[0].RowIndex;
                var user = dataGridView1.Rows[index].DataBoundItem as UsersDataGrid;

                await _usersService.Post<bool>(null, $"changeStatus/{user.Id}");

                await LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void btnAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                var index = dataGridView1.SelectedCells[0].RowIndex;
                var user = dataGridView1.Rows[index].DataBoundItem as UsersDataGrid;

                if (user.Permission == 0) // Assign permission 1 (Trainer) to user
                {
                    await _usersService.Post<bool>(null, $"changePermission/{user.Id}");

                    await LoadUsers();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                var index = dataGridView1.SelectedCells[0].RowIndex;
                var user = dataGridView1.Rows[index].DataBoundItem as UsersDataGrid;

                if (user.Active)
                {
                    btnDeactivate.Text = "Deactivate";
                }
                else
                {
                    btnDeactivate.Text = "Activate";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var index = dataGridView1.SelectedCells[0].RowIndex;
                var user = dataGridView1.Rows[index].DataBoundItem as UsersDataGrid;

                FrmUser frm = new FrmUser(user.Id);
                frm.FormClosing += editFrm_FormClosing;
                frm.Show();
            }
        }

        private async void editFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await LoadUsers();

        }

    }
}
