namespace FitBody.Desktop
{
    partial class FrmTopicsSuggested
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TopicsGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDecline = new MetroFramework.Controls.MetroButton();
            this.btnAccept = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.TopicsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TopicsGridView
            // 
            this.TopicsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TopicsGridView.Location = new System.Drawing.Point(53, 63);
            this.TopicsGridView.Name = "TopicsGridView";
            this.TopicsGridView.Size = new System.Drawing.Size(410, 150);
            this.TopicsGridView.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Menu;
            this.label4.Location = new System.Drawing.Point(38, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 18;
            // 
            // btnDecline
            // 
            this.btnDecline.Location = new System.Drawing.Point(308, 219);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(75, 23);
            this.btnDecline.TabIndex = 19;
            this.btnDecline.Text = "Decline";
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(389, 219);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 20;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // FrmTopicsSuggested
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 269);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnDecline);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TopicsGridView);
            this.Name = "FrmTopicsSuggested";
            this.Text = "Form1FrmTopicsSuggested";
            this.Load += new System.EventHandler(this.FrmTopicsSuggested_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TopicsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TopicsGridView;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroButton btnDecline;
        private MetroFramework.Controls.MetroButton btnAccept;
    }
}