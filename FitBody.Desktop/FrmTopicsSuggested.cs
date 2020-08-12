using FitBody.Common.Contracts;
using FitBody.Desktop.Models;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitBody.Desktop
{
    public partial class FrmTopicsSuggested : Form
    {
        private ApiService _topicService = new ApiService("TopicsSuggested");
        public bool SuggestedPostAdded { get; set; } = false;
        public int SuggestedTopicAddedId { get; set; } = -1;

        public FrmTopicsSuggested()
        {
            InitializeComponent();
        }

        private async void FrmTopicsSuggested_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            await LoadTopics();
        }
        private async Task LoadTopics()
        {
            var data = (await _topicService.Get<List<TopicSuggestedDto>>())
                .Select(a => new TopicDataGrid
                {
                    Id = a.Id,
                    Topic=a.Topic,
                    User = a.Username,
                    UserId = a.UserId
                }).ToList();

            TopicsGridView.DataSource = data;
        }

        private async void btnDecline_Click(object sender, EventArgs e)
        {
            try
            {
                var rowindex= TopicsGridView.SelectedCells[0].RowIndex;
                var topic = TopicsGridView.Rows[rowindex].DataBoundItem as TopicDataGrid;
                var toDelete = await _topicService.Delete<dynamic>(topic.Id);
                await LoadTopics();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (TopicsGridView.SelectedCells.Count > 0)
            {
                var index = TopicsGridView.SelectedCells[0].RowIndex;
                var suggestedTopic = TopicsGridView.Rows[index].DataBoundItem as TopicDataGrid;
                
                FrmEditPost frm = new FrmEditPost(null)
                {
                    Owner = this
                };
                frm.SuggestedTopicId = suggestedTopic.Id;
                frm.FormClosing += editFrm_FormClosing;
                frm.Show();
            }
        }

        private async void editFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SuggestedPostAdded && SuggestedTopicAddedId != -1)
            {
                await _topicService.Delete<dynamic>(SuggestedTopicAddedId);
            }
            await LoadTopics();
        }
    }
}
