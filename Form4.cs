using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace bazy
{
    public partial class Form4 : Form
    {
        private string connectionString = "server=localhost;user=root;password=;database=ratownicy;";

        public Form4()
        {
            InitializeComponent();
            LoadData();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.Dpi;  // Skalowanie w zależności od DPI
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT `Imie i Nazwisko` FROM Ratownicy";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewRatownicy.DataSource = dataTable;

                    // Ustawienia szerokości kolumn
                    int columnWidth = 200; // Ustaw szerokość kolumny na 200
                    foreach (DataGridViewColumn column in dataGridViewRatownicy.Columns)
                    {
                        column.Width = columnWidth;
                    }

                    // Automatyczne dopasowanie wysokości nagłówków kolumn
                    dataGridViewRatownicy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string imieNazwisko = textBoxName.Text;

            if (string.IsNullOrEmpty(imieNazwisko))
            {
                MessageBox.Show("Proszę wpisać imię i nazwisko.");
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO Ratownicy (`Imie i Nazwisko`) VALUES (@ImieNazwisko)";
                    MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@ImieNazwisko", imieNazwisko);
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Osoba została dodana.");
                    LoadData();
                    textBoxName.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewRatownicy.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewRatownicy.SelectedRows[0];
                string imieNazwisko = selectedRow.Cells["Imie i Nazwisko"].Value.ToString();
                Console.WriteLine("Usuwanie osoby: " + imieNazwisko); // Dodaj komunikat do debugowania

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string deleteQuery = "DELETE FROM Ratownicy WHERE `Imie i Nazwisko` = @ImieNazwisko";
                        MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                        cmd.Parameters.AddWithValue("@ImieNazwisko", imieNazwisko);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine("Liczba usuniętych wierszy: " + rowsAffected); // Dodaj komunikat do debugowania
                        MessageBox.Show("Osoba została usunięta.");
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć osobę do usunięcia.");
            }
        }





    }
}
