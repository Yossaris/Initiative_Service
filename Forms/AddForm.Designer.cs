
namespace Initiative_Service
{
    partial class AddForm
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
            this.dataGridViewAdd = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iniBonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAdd
            // 
            this.dataGridViewAdd.AllowUserToAddRows = false;
            this.dataGridViewAdd.AllowUserToDeleteRows = false;
            this.dataGridViewAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAdd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.iniBonus});
            this.dataGridViewAdd.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewAdd.Name = "dataGridViewAdd";
            this.dataGridViewAdd.ReadOnly = true;
            this.dataGridViewAdd.RowTemplate.Height = 25;
            this.dataGridViewAdd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAdd.Size = new System.Drawing.Size(820, 420);
            this.dataGridViewAdd.TabIndex = 0;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // iniBonus
            // 
            this.iniBonus.DataPropertyName = "iniBonus";
            this.iniBonus.HeaderText = "Initiative Modifier";
            this.iniBonus.Name = "iniBonus";
            this.iniBonus.ReadOnly = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(390, 468);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(80, 40);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(180, 13);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(12, 13);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(162, 23);
            this.searchTextBox.TabIndex = 3;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 513);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridViewAdd);
            this.Name = "AddForm";
            this.Text = "Add...";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAdd;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn iniBonus;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
    }
}