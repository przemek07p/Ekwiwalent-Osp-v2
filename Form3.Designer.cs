namespace bazy
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private Button buttonZapisz;

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            buttonZapisz = new Button();
            buttonCofnij = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(622, 350);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // buttonZapisz
            // 
            buttonZapisz.Location = new Point(559, 368);
            buttonZapisz.Name = "buttonZapisz";
            buttonZapisz.Size = new Size(75, 23);
            buttonZapisz.TabIndex = 1;
            buttonZapisz.Text = "Zapisz";
            buttonZapisz.UseVisualStyleBackColor = true;
            buttonZapisz.Click += buttonZapisz_Click;
            // 
            // buttonCofnij
            // 
            buttonCofnij.Location = new Point(478, 368);
            buttonCofnij.Name = "buttonCofnij";
            buttonCofnij.Size = new Size(75, 23);
            buttonCofnij.TabIndex = 2;
            buttonCofnij.Text = "Powrót";
            buttonCofnij.UseVisualStyleBackColor = true;
            buttonCofnij.Click += buttonCofnij_Click;
            // 
            // Form3
            // 
            ClientSize = new Size(639, 400);
            Controls.Add(buttonCofnij);
            Controls.Add(buttonZapisz);
            Controls.Add(dataGridView1);
            Name = "Form3";
            Text = "Form3";
            FormClosing += Form3_FormClosing_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        private Button buttonCofnij;
    }
}