using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace bazy
{
    public partial class Form5 : Form
    {
        private string selectedTable;
        private string connectionString = "server=localhost;user=root;password=;database=Kwartalna;";
        private bool cofnijClicked = false;

        public Form5(string selectedTable)
        {
            InitializeComponent();
            this.selectedTable = selectedTable;
            LoadData();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.Dpi;  // Skalowanie w zależności od DPI
            //this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Zapytanie SQL, aby pobrać unikalne osoby z tabeli selectedTable
                    string query = $"SELECT DISTINCT `Imię i Nazwisko` FROM {selectedTable} ORDER BY `Imię i Nazwisko`";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Ustawienie źródła danych dla dataGridViewOsoby
                    dataGridViewOsoby.DataSource = dataTable;

                    int columnWidth = 200; // Ustaw szerokość kolumny na 200
                    foreach (DataGridViewColumn column in dataGridViewOsoby.Columns)
                    {
                        column.Width = columnWidth;
                    }

                    // Automatyczne dopasowanie wysokości nagłówków kolumn
                    dataGridViewOsoby.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridViewOsoby_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sprawdź, czy kliknięto na komórkę (a nie nagłówek kolumny)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewOsoby.Rows[e.RowIndex];
                string imieNazwisko = row.Cells["Imię i Nazwisko"].Value.ToString();

                // Otwórz Form6 i przekaż imię i nazwisko do konstruktora
                Form6 form6 = new Form6(selectedTable, imieNazwisko);
                form6.ShowDialog(); // ShowDialog blokuje interakcję z Form5, aż do zamknięcia Form6
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cofnijClicked = true;  // Ustaw flagę
            Form2 form2 = new Form2(selectedTable);
            form2.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Wybór miejsca zapisu pliku CSV
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            saveFileDialog.Title = "Zapisz dane do pliku CSV";

            // Jeśli użytkownik wybierze lokalizację i naciśnie "Zapisz"
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Połączenie z bazą danych
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // Zapytanie SQL, aby pobrać "Imię i Nazwisko", zsumowany "Czas", "Czas Szkolenia", oraz "Stawka"
                        string query = $@"
                    SELECT 
                        `Imię i Nazwisko`, 
                        SUM(`Czas`) AS SumaCzasu, 
                        SUM(`Czas Szkolenia`) AS SumaCzasuSzkolenia, 
                        `Stawka`
                    FROM 
                        {selectedTable}
                    GROUP BY 
                        `Imię i Nazwisko`, `Stawka`
                    ORDER BY 
                        `Imię i Nazwisko`;";

                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        // Tworzenie i zapis pliku CSV w wybranej lokalizacji
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, System.Text.Encoding.UTF8))
                        {
                            // Zapisanie nagłówków do pliku CSV (używamy średników jako separatorów)
                            writer.WriteLine("Lp;Imię i Nazwisko;Należność");

                            // Licznik do numeracji wierszy
                            int lp = 1;

                            // Zmienna do przechowywania poprzedniego imienia i nazwiska
                            string poprzednieImieNazwisko = string.Empty;
                            double sumaWynik = 0;

                            while (reader.Read())
                            {
                                string imieNazwisko = reader["Imię i Nazwisko"].ToString();
                                double sumaCzasu = reader["SumaCzasu"] != DBNull.Value ? Convert.ToDouble(reader["SumaCzasu"]) : 0;
                                double sumaCzasuSzkolenia = reader["SumaCzasuSzkolenia"] != DBNull.Value ? Convert.ToDouble(reader["SumaCzasuSzkolenia"]) : 0;
                                double stawka = reader["Stawka"] != DBNull.Value ? Convert.ToDouble(reader["Stawka"]) : 0;

                                // Obliczanie wyniku
                                double wynik = 0;

                                // Sumowanie tylko, jeśli wartości są większe od zera
                                if (sumaCzasu > 0)
                                {
                                    wynik += sumaCzasu * stawka;
                                }
                                if (sumaCzasuSzkolenia > 0)
                                {
                                    wynik += sumaCzasuSzkolenia * stawka;
                                }

                                // Sprawdzanie, czy imię i nazwisko się zmieniło
                                if (imieNazwisko != poprzednieImieNazwisko)
                                {
                                    // Zapisujemy dane tylko, jeśli to nowe imię i nazwisko
                                    if (!string.IsNullOrEmpty(poprzednieImieNazwisko))
                                    {
                                        // Zapis do CSV
                                        writer.WriteLine($"{lp};{poprzednieImieNazwisko};{sumaWynik}");
                                        lp++;
                                    }

                                    // Resetowanie sumy dla nowego imienia i nazwiska
                                    sumaWynik = wynik;
                                    poprzednieImieNazwisko = imieNazwisko;
                                }
                                else
                                {
                                    // Jeśli to samo imię, dodajemy do sumy
                                    sumaWynik += wynik;
                                }
                            }

                            // Zapis ostatniego wiersza
                            if (!string.IsNullOrEmpty(poprzednieImieNazwisko))
                            {
                                writer.WriteLine($"{lp};{poprzednieImieNazwisko};{sumaWynik}");
                            }
                        }

                        MessageBox.Show("Raport wygenerowany poprawnie.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas eksportowania danych: " + ex.Message);
                }
            }
        }






        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cofnijClicked)
            {
                Environment.Exit(0);  // Zakończ aplikację tylko, jeśli formularz jest zamykany przez krzyżyk
            }
        }
    }
}
