namespace bazy
{
    partial class Form11
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
            btnWybierzPlik = new Button();
            txtSciezkaPliku = new TextBox();
            dataGridView1 = new DataGridView();
            txtSciezkaNazwiska = new TextBox();
            button1 = new Button();
            btnPodmienNazwiska = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnWybierzPlik
            // 
            btnWybierzPlik.Location = new Point(83, 51);
            btnWybierzPlik.Name = "btnWybierzPlik";
            btnWybierzPlik.Size = new Size(75, 23);
            btnWybierzPlik.TabIndex = 0;
            btnWybierzPlik.Text = "exel";
            btnWybierzPlik.UseVisualStyleBackColor = true;
            btnWybierzPlik.Click += btnWybierzPlik_Click;
            // 
            // txtSciezkaPliku
            // 
            txtSciezkaPliku.Location = new Point(83, 104);
            txtSciezkaPliku.Name = "txtSciezkaPliku";
            txtSciezkaPliku.Size = new Size(100, 23);
            txtSciezkaPliku.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 150);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 288);
            dataGridView1.TabIndex = 2;
            // 
            // txtSciezkaNazwiska
            // 
            txtSciezkaNazwiska.Location = new Point(343, 104);
            txtSciezkaNazwiska.Name = "txtSciezkaNazwiska";
            txtSciezkaNazwiska.Size = new Size(100, 23);
            txtSciezkaNazwiska.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(355, 51);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Nazwiska";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnWybierzPlikNazwiska_Click;
            // 
            // btnPodmienNazwiska
            // 
            btnPodmienNazwiska.Location = new Point(581, 51);
            btnPodmienNazwiska.Name = "btnPodmienNazwiska";
            btnPodmienNazwiska.Size = new Size(75, 23);
            btnPodmienNazwiska.TabIndex = 5;
            btnPodmienNazwiska.Text = "Nazwiska podmiana";
            btnPodmienNazwiska.UseVisualStyleBackColor = true;
            btnPodmienNazwiska.Click += btnPodmienNazwiska_Click;
            // 
            // Form11
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPodmienNazwiska);
            Controls.Add(button1);
            Controls.Add(txtSciezkaNazwiska);
            Controls.Add(dataGridView1);
            Controls.Add(txtSciezkaPliku);
            Controls.Add(btnWybierzPlik);
            Name = "Form11";
            Text = "Form11";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnWybierzPlik;
        private TextBox txtSciezkaPliku;
        private DataGridView dataGridView1;
        private TextBox txtSciezkaNazwiska;
        private Button button1;
        private Button btnPodmienNazwiska;
    }
}