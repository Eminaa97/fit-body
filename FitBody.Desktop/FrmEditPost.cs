using FitBody.Common.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FitBody.Desktop
{
    public partial class FrmEditPost : Form
    {
        private ApiService _postsService = new ApiService("posts");
        private ApiService _tagsService = new ApiService("tags");
        private ApiService _categoriesService = new ApiService("categories");
        private ApiService _subcategoriesService = new ApiService("subcategories");

        private PostDto _post;
        private IList<TagDto> _allTags;
        private readonly int? _postId;
        public int? SuggestedTopicId { get; set; }

        // add a field for all categories and subcategories

        public FrmEditPost(int? postId)
        {
            InitializeComponent();
            _postId = postId;
        }

        private async void FrmEditPost_Load(object sender, EventArgs e)
        {
            var categories = await _categoriesService.Get<IList<CategoryDto>>();
            var subcategories = await _subcategoriesService.Get<IList<SubcategoryDto>>();

            if (_postId.HasValue)
            {
                var postTags = await _tagsService.Get<IList<TagDto>>(null, $"posts/{_postId.Value}");
                _post = (PostDto)(await _postsService.GetById<PostDto>(_postId));

                txtTitle.Text = _post.Title;
                txtContent.Text = _post.Content;
                txtTags.Text = string.Join(",", postTags.Select(x => x.Title));
                slctCategory.DataSource = categories;
                slctSubcategory.DataSource = subcategories;

                var categoryIndex = categories.ToList().FindIndex(x => x.Id == _post.CategoryId);
                var subcategoryIndex = subcategories.ToList().FindIndex(x => x.Id == _post.SubcategoryId);

                slctCategory.SelectedIndex = categoryIndex;
                slctSubcategory.SelectedIndex = subcategoryIndex;

                _allTags = await _tagsService.Get<IList<TagDto>>();
            }
            else
            {
                slctCategory.DataSource = categories;
                slctSubcategory.DataSource = subcategories;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var subcategory = slctSubcategory.SelectedItem as SubcategoryDto;

                if (subcategory != null)

                {
                    var tags = txtTags.Text.Split(',');
                    PostUpdateModel model = new PostUpdateModel
                    {
                        Title = txtTitle.Text,
                        Content = txtContent.Text,
                        SubcategoryId = subcategory.Id,
                        Tags = tags
                    };

                    if (_postId.HasValue)
                    {
                        model.Id = _postId.Value;
                        await _postsService.Update<dynamic>(_postId.Value, model);
                    }
                    else
                    {
                        await _postsService.Post<dynamic>(model);
                    }

                    if (Owner is FrmTopicsSuggested owner)
                    {
                        owner.SuggestedPostAdded = true;
                        owner.SuggestedTopicAddedId = SuggestedTopicId.Value;
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("Please select a subcategory");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void slctCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                slctSubcategory.DataSource = null;

                var subcategories = await _subcategoriesService.Get<IList<SubcategoryDto>>();
                var selectedCategory = slctCategory.SelectedItem as CategoryDto;

                var selectedSubcategories = subcategories.Where(a => a.CategoryId == selectedCategory.Id).ToList();
                slctSubcategory.DataSource = selectedSubcategories;

                if (!selectedSubcategories.Any())
                    slctSubcategory.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
