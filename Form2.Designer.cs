namespace bazy
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxLiczbaRatownikow;
        private DateTimePicker dateTimePickerData; // Zmieniono na DateTimePicker
        private TextBox textBoxStawka;
        private TextBox textBoxCzas;
        private TextBox textBoxNrZdarzenia;
        private Button buttonDalej;
        private Button buttonCofnij;
        private Button button1;

        private void InitializeComponent()
        {
            textBoxLiczbaRatownikow = new TextBox();
            dateTimePickerData = new DateTimePicker();
            textBoxStawka = new TextBox();
            textBoxCzas = new TextBox();
            textBoxNrZdarzenia = new TextBox();
            buttonDalej = new Button();
            buttonCofnij = new Button();
            button1 = new Button();
            checkBox1 = new CheckBox();
            textBoxSzkolenie = new TextBox();
            SuspendLayout();
            // 
            // textBoxLiczbaRatownikow
            // 
            textBoxLiczbaRatownikow.Location = new Point(12, 12);
            textBoxLiczbaRatownikow.Name = "textBoxLiczbaRatownikow";
            textBoxLiczbaRatownikow.PlaceholderText = "Liczba Ratowników";
            textBoxLiczbaRatownikow.Size = new Size(312, 23);
            textBoxLiczbaRatownikow.TabIndex = 0;
            textBoxLiczbaRatownikow.TextChanged += textBoxLiczbaRatownikow_TextChanged;
            // 
            // dateTimePickerData
            // 
            dateTimePickerData.CustomFormat = "dd-MM-yyyy";
            dateTimePickerData.Format = DateTimePickerFormat.Custom;
            dateTimePickerData.Location = new Point(12, 38);
            dateTimePickerData.Name = "dateTimePickerData";
            dateTimePickerData.Size = new Size(312, 23);
            dateTimePickerData.TabIndex = 1;
            // 
            // textBoxStawka
            // 
            textBoxStawka.Location = new Point(12, 64);
            textBoxStawka.Name = "textBoxStawka";
            textBoxStawka.PlaceholderText = "Stawka";
            textBoxStawka.Size = new Size(312, 23);
            textBoxStawka.TabIndex = 2;
            // 
            // textBoxCzas
            // 
            textBoxCzas.Location = new Point(12, 90);
            textBoxCzas.Name = "textBoxCzas";
            textBoxCzas.PlaceholderText = "Czas";
            textBoxCzas.Size = new Size(312, 23);
            textBoxCzas.TabIndex = 3;
            // 
            // textBoxNrZdarzenia
            // 
            textBoxNrZdarzenia.Location = new Point(12, 116);
            textBoxNrZdarzenia.Name = "textBoxNrZdarzenia";
            textBoxNrZdarzenia.PlaceholderText = "Nr Zdarzenia";
            textBoxNrZdarzenia.Size = new Size(312, 23);
            textBoxNrZdarzenia.TabIndex = 4;
            // 
            // buttonDalej
            // 
            buttonDalej.Location = new Point(172, 145);
            buttonDalej.Name = "buttonDalej";
            buttonDalej.Size = new Size(75, 23);
            buttonDalej.TabIndex = 5;
            buttonDalej.Text = "Dalej";
            buttonDalej.UseVisualStyleBackColor = true;
            buttonDalej.Click += buttonDalej_Click;
            // 
            // buttonCofnij
            // 
            buttonCofnij.Location = new Point(12, 145);
            buttonCofnij.Name = "buttonCofnij";
            buttonCofnij.Size = new Size(75, 23);
            buttonCofnij.TabIndex = 6;
            buttonCofnij.Text = "Powrót";
            buttonCofnij.UseVisualStyleBackColor = true;
            buttonCofnij.Click += buttonCofnij_Click;
            // 
            // button1
            // 
            button1.Location = new Point(92, 145);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "Lista Akcji";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(252, 145);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(75, 19);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Szkolenie";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // textBoxSzkolenie
            // 
            textBoxSzkolenie.Location = new Point(12, 90);
            textBoxSzkolenie.Name = "textBoxSzkolenie";
            textBoxSzkolenie.PlaceholderText = "Czas Szkolenia";
            textBoxSzkolenie.Size = new Size(312, 23);
            textBoxSzkolenie.TabIndex = 12;
            textBoxSzkolenie.TextChanged += textBoxSzkolenie_TextChanged;
            // 
            // Form2
            // 
            ClientSize = new Size(331, 175);
            Controls.Add(textBoxSzkolenie);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(buttonCofnij);
            Controls.Add(buttonDalej);
            Controls.Add(textBoxNrZdarzenia);
            Controls.Add(textBoxCzas);
            Controls.Add(textBoxStawka);
            Controls.Add(dateTimePickerData);
            Controls.Add(textBoxLiczbaRatownikow);
            Name = "Form2";
            Text = "Form2";
            FormClosing += Form2_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        private CheckBox checkBox1;
        private TextBox textBoxSzkolenie;
    }
}
