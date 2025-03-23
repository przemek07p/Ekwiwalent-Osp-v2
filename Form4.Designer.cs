namespace bazy
{
    partial class Form4
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewRatownicy;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dataGridViewRatownicy = new DataGridView();
            buttonAdd = new Button();
            buttonDelete = new Button();
            textBoxName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRatownicy).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewRatownicy
            // 
            this.dataGridViewRatownicy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRatownicy.Location = new Point(12, 12);
            dataGridViewRatownicy.Name = "dataGridViewRatownicy";
            dataGridViewRatownicy.Size = new Size(364, 243);
            dataGridViewRatownicy.TabIndex = 0;
            dataGridViewRatownicy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(12, 273);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Dodaj";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(301, 274);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Usuń";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(93, 274);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(198, 23);
            textBoxName.TabIndex = 3;
            // 
            // Form4
            // 
            ClientSize = new Size(388, 309);
            Controls.Add(textBoxName);
            Controls.Add(buttonDelete);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridViewRatownicy);
            Name = "Form4";
            Text = "Ratownicy";
            ((System.ComponentModel.ISupportInitialize)dataGridViewRatownicy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
