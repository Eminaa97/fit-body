using FitBody.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FitBody.Desktop
{
    public partial class FrmPostDetails : Form
    {
        private ApiService _postsService = new ApiService("posts");
        private ApiService _tagsService = new ApiService("tags");
        private ApiService _commentsService = new ApiService("comments");

        private PostDto _post;
        private readonly int _postId;

        public FrmPostDetails(int postId)
        {
            InitializeComponent();
            _postId = postId;
        }

        private async void FrmEditPost_Load(object sender, EventArgs e)
        {
            var postTags = await _tagsService.Get<IList<TagDto>>(null, $"posts/{_postId}");
            _post = (PostDto)(await _postsService.GetById<PostDto>(_postId));

            txtTitle.Text = _post.Title;
            txtTitle.ReadOnly = true;
            txtContent.Text = _post.Content;
            txtContent.ReadOnly = true;
            txtTags.Text = string.Join(",", postTags.Select(x => x.Title));
            txtTags.ReadOnly = true;
            txtCategory.Text = _post.Categoryname;
            txtCategory.ReadOnly = true;
            txtSubcategory.Text = _post.Subcategoryname;
            txtSubcategory.ReadOnly = true;

            dgvComments.DataSource = await _commentsService.Get<IList<CommentDto>>(null, $"posts/{_post.Id}");
            dgvComments.Columns[0].Visible = false;
            dgvComments.Columns[3].Visible = false;
            dgvComments.Columns[4].Visible = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnLike_Click(object sender, EventArgs e)
        {
            try
            {
                var liked = await _postsService.Post<bool>(null, $"like/{_postId}");

                btnLike.Text = liked ? "Unlike" : "Like";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var saved = await _postsService.Post<bool>(null, $"save/{_postId}");

                btnSave.Text = saved ? "Unsave" : "Save";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                var apiResponse = await _commentsService.Post<CommentDto>(new CommentInsertModel
                {
                    PostId = _postId,
                    Content = comment
                });

                if (apiResponse != null)
                {
                    dgvComments.DataSource = await _commentsService.Get<IList<CommentDto>>(null, $"posts/{_post.Id}");
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
