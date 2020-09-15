using FitBody.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FitBody.Desktop
{
    public partial class FrmThreadDetails : Form
    {
        private ApiService _threadService = new ApiService("threads");
        private ApiService _commentService = new ApiService("comments");
        private int _threadId;

        public FrmThreadDetails(int id)
        {
            InitializeComponent();
            _threadId = id;
        }

        private async void FrmThreadDetails_Load(object sender, EventArgs e)
        {
            if (ApiService.Permission != 2)
            {
                btnDelete.Visible = false;
            }
            var thread = await _threadService.GetById<ThreadDto>(_threadId);

            txtContent.Text = thread.Content;
            txtContent.ReadOnly = true;
            txtTitle.Text = thread.Title;
            txtTitle.ReadOnly = true;
            txtDateCreated.Text = thread.DateCreated.ToString();
            txtDateCreated.ReadOnly = true;

            dgvComments.DataSource = await _commentService.Get<IList<CommentDto>>(null, $"threads/{thread.Id}");

            try
            {
                dgvComments.Columns[0].Visible = false;
                dgvComments.Columns[3].Visible = false;
                dgvComments.Columns[4].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await _threadService.Post<dynamic>(null, $"{_threadId}");
            Close();
        }

        private async void btnComment_Click(object sender, EventArgs e)
        {
            try
            {
                var comment = txtComment.Text;

                if (string.IsNullOrEmpty(comment) || string.IsNullOrWhiteSpace(comment))
                {
                    MessageBox.Show("Please insert a comment first");
                    return;
                }

                var apiResponse = await _commentService.Post<CommentDto>(new CommentInsertModel
                {
                    ThreadId = _threadId,
                    Content = comment
                });

                if (apiResponse != null)
                {
                    dgvComments.DataSource = await _commentService.Get<IList<CommentDto>>(null, $"threads/{_threadId}");
                    dgvComments.Columns[0].Visible = false;
                    dgvComments.Columns[3].Visible = false;
                    dgvComments.Columns[4].Visible = false;
                }
                txtComment.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
