using FitBody.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FitBody.Desktop
{
    public partial class FrmFitForum : Form
    {
        private ApiService _threadService = new ApiService("threads");
        public FrmFitForum()
        {
            InitializeComponent();
        }

        private async void FrmFitForum_Load(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            dgvThreads.DataSource = await _threadService.Get<List<ThreadDto>>();
            dgvThreads.Columns[0].Visible = false;
        }

        private async void btnFilter_Click(object sender, System.EventArgs e)
        {
           dgvThreads.DataSource = await _threadService.Post<IList<ThreadDto>>(new ThreadSearchRequest
           {
               Title = txtTitle.Text
           }, "search");

        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            FrmAddThread frm = new FrmAddThread();
            frm.FormClosing += Frm_FormClosing;
            frm.Show();
        }

        private async void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvThreads.DataSource = await _threadService.Get<List<ThreadDto>>();
        }

        private void dgvThreads_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var rowIndex = dgvThreads.SelectedCells[0].RowIndex;
                var thread = dgvThreads.Rows[rowIndex].DataBoundItem as ThreadDto;
                FrmThreadDetails frm = new FrmThreadDetails(thread.Id);
                frm.FormClosing += Frm_FormClosing;
                frm.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
