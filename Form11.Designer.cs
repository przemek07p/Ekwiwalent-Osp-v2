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
            btnZapiszDoPliku = new Button();
            button2 = new Button();
            txtStawka = new TextBox();
            label1 = new Label();
            comboBoxTabele = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnWybierzPlik
            // 
            btnWybierzPlik.Location = new Point(461, 12);
            btnWybierzPlik.Name = "btnWybierzPlik";
            btnWybierzPlik.Size = new Size(124, 38);
            btnWybierzPlik.TabIndex = 0;
            btnWybierzPlik.Text = "Wybierz Plik Kalkulacyjny";
            btnWybierzPlik.UseVisualStyleBackColor = true;
            btnWybierzPlik.Click += btnWybierzPlik_Click;
            // 
            // txtSciezkaPliku
            // 
            txtSciezkaPliku.Location = new Point(461, 56);
            txtSciezkaPliku.Name = "txtSciezkaPliku";
            txtSciezkaPliku.Size = new Size(124, 23);
            txtSciezkaPliku.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 183);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 255);
            dataGridView1.TabIndex = 2;
            // 
            // txtSciezkaNazwiska
            // 
            txtSciezkaNazwiska.Location = new Point(461, 129);
            txtSciezkaNazwiska.Name = "txtSciezkaNazwiska";
            txtSciezkaNazwiska.Size = new Size(124, 23);
            txtSciezkaNazwiska.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(461, 85);
            button1.Name = "button1";
            button1.Size = new Size(124, 38);
            button1.TabIndex = 4;
            button1.Text = "Wybierz Plik z Imionami";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnWybierzPlikNazwiska_Click;
            // 
            // btnPodmienNazwiska
            // 
            btnPodmienNazwiska.Location = new Point(591, 12);
            btnPodmienNazwiska.Name = "btnPodmienNazwiska";
            btnPodmienNazwiska.Size = new Size(111, 38);
            btnPodmienNazwiska.TabIndex = 5;
            btnPodmienNazwiska.Text = "Podmiana Nazwisk";
            btnPodmienNazwiska.UseVisualStyleBackColor = true;
            btnPodmienNazwiska.Click += btnPodmienNazwiska_Click;
            // 
            // btnZapiszDoPliku
            // 
            btnZapiszDoPliku.Location = new Point(708, 12);
            btnZapiszDoPliku.Name = "btnZapiszDoPliku";
            btnZapiszDoPliku.Size = new Size(80, 38);
            btnZapiszDoPliku.TabIndex = 6;
            btnZapiszDoPliku.Text = "Zapisz";
            btnZapiszDoPliku.UseVisualStyleBackColor = true;
            btnZapiszDoPliku.Click += btnZapiszDoBazy_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 12);
            button2.Name = "button2";
            button2.Size = new Size(93, 38);
            button2.TabIndex = 7;
            button2.Text = "Nowy Kwartał";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtStawka
            // 
            txtStawka.Location = new Point(350, 47);
            txtStawka.Name = "txtStawka";
            txtStawka.Size = new Size(69, 23);
            txtStawka.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(350, 12);
            label1.Name = "label1";
            label1.Size = new Size(60, 18);
            label1.TabIndex = 11;
            label1.Text = "Stawka";
            // 
            // comboBoxTabele
            // 
            comboBoxTabele.FormattingEnabled = true;
            comboBoxTabele.Location = new Point(130, 47);
            comboBoxTabele.Name = "comboBoxTabele";
            comboBoxTabele.Size = new Size(186, 23);
            comboBoxTabele.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(162, 12);
            label2.Name = "label2";
            label2.Size = new Size(120, 18);
            label2.TabIndex = 13;
            label2.Text = "Wybierz Kwartał";
            // 
            // Form11
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(comboBoxTabele);
            Controls.Add(label1);
            Controls.Add(txtStawka);
            Controls.Add(button2);
            Controls.Add(btnZapiszDoPliku);
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
        private Button btnZapiszDoPliku;
        private Button button2;
        private TextBox txtStawka;
        private Label label1;
        private ComboBox comboBoxTabele;
        private Label label2;
    }
}