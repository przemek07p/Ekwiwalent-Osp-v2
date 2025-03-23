using System;
using System.Windows.Forms;

namespace bazy
{
    public partial class Form2 : Form
    {
        private string selectedTable;
        private bool cofnijClicked = false;

        public Form2(string selectedTable)
        {
            InitializeComponent();
            this.selectedTable = selectedTable;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.Dpi;  // Skalowanie w zależności od DPI
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Ukryj pole Czas Szkolenia na starcie
            textBoxSzkolenie.Visible = false;
        }

        private void buttonDalej_Click(object sender, EventArgs e)
        {
            int liczbaRatownikow;
            if (!int.TryParse(textBoxLiczbaRatownikow.Text, out liczbaRatownikow) || liczbaRatownikow <= 0)
            {
                MessageBox.Show("Wpisz Liczbę ratowników.");
                return;
            }

            // Pobieranie daty z DateTimePicker
            string data = dateTimePickerData.Value.ToString("dd-MM-yyyy");
            string stawka = textBoxStawka.Text;
            string czas = textBoxCzas.Text;
            string czasSzkolenia = textBoxSzkolenie.Text;
            string nrZdarzenia = textBoxNrZdarzenia.Text;

            // Przekazanie osobno czas i czas szkolenia
            Form3 form3 = new Form3(selectedTable, liczbaRatownikow, data, stawka, czasSzkolenia, czas, nrZdarzenia);
            form3.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Ukryj textBox dla Czasu, pokaż textBox dla Szkolenia
                textBoxCzas.Visible = false;
                textBoxCzas.Clear();
                textBoxSzkolenie.Visible = true;
            }
            else
            {
                // Pokaż textBox dla Czasu, ukryj textBox dla Szkolenia
                textBoxCzas.Visible = true;
                textBoxSzkolenie.Visible = false;
                textBoxSzkolenie.Clear();
            }
        }

 

  

        private void textBoxLiczbaRatownikow_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSzkolenie_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Sprawdź, czy użytkownik kliknął "Powrót"
            if (!cofnijClicked)
            {
                Environment.Exit(0);  // Zakończ aplikację tylko, jeśli formularz jest zamykany przez krzyżyk
            }
        }

        private void buttonCofnij_Click(object sender, EventArgs e)
        {
            cofnijClicked = true;  // Ustaw flagę
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();  // Zamknij Form2
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(selectedTable);
            form5.Show();
            this.Hide();
        }

    }
}
