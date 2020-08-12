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
    public partial class FrmAddThread : Form
    {
        private ApiService _threadService = new ApiService("threads");
        public FrmAddThread()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var thred = new ThreadInsertModel
                {
                    Content = txtContent.Text,
                    Title = txtTitle.Text
                };
                await _threadService.Post<dynamic>(thred);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            Close();
        }
    }
}
