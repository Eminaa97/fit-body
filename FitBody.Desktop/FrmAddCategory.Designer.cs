namespace FitBody.Desktop
{
    partial class FrmAddCategory
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
            this.submitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new MetroFramework.Controls.MetroTextBox();
            this.dataGridSubategories = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSubategories)).BeginInit();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(308, 230);
            this.submitButton.Margin = new System.Windows.Forms.Padding(2);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(76, 26);
            this.submitButton.TabIndex = 9;
            this.submitButton.Text = "Save";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Category name";
            // 
            // txtTitle
            // 
            this.txtTitle.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtTitle.Location = new System.Drawing.Point(36, 39);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PromptText = "Title";
            this.txtTitle.Size = new System.Drawing.Size(203, 30);
            this.txtTitle.TabIndex = 10;
            // 
            // dataGridSubategories
            // 
            this.dataGridSubategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSubategories.Location = new System.Drawing.Point(36, 75);
            this.dataGridSubategories.Name = "dataGridSubategories";
            this.dataGridSubategories.Size = new System.Drawing.Size(348, 150);
            this.dataGridSubategories.TabIndex = 11;
            // 
            // frmAddCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 293);
            this.Controls.Add(this.dataGridSubategories);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label2);
            this.Name = "frmAddCategory";
            this.Text = "frmAddCategory";
            this.Load += new System.EventHandler(this.frmAddCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSubategories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroTextBox txtTitle;
        private System.Windows.Forms.DataGridView dataGridSubategories;
    }
}