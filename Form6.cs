using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.VisualBasic;

namespace bazy
{
    public partial class Form6 : Form
    {
        private string selectedTable;
        private string imieNazwisko;
        private string connectionString = "server=localhost;user=root;password=;database=Kwartalna;";

        private int currentPage = 1;
        private int totalPages = 1;
        private int pageSize = 7;
        private DataTable fullDataTable = new DataTable();

        // Przechowywanie danych do wyświetlenia w Wordzie
        private string[,] daneWykazane = new string[7, 6]; // Dodano pole na obliczone Razem

        public Form6(string selectedTable, string imieNazwisko)
        {
            InitializeComponent();

            this.selectedTable = selectedTable;
            this.imieNazwisko = imieNazwisko;
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

                    string query = $"SELECT `Imię i Nazwisko`, DATE_FORMAT(`Data`, '%Y-%m-%d') AS `Data`, `Nr Zdarzenia`, `Czas`, `Czas Szkolenia`, `Stawka` FROM {selectedTable} WHERE `Imię i Nazwisko` = @ImieNazwisko ORDER BY `Data`";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ImieNazwisko", imieNazwisko);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    fullDataTable.Clear();
                    adapter.Fill(fullDataTable);

                    totalPages = (int)Math.Ceiling(fullDataTable.Rows.Count / (double)pageSize);
                    DisplayPage(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DisplayPage(int pageNumber)
        {
            currentPage = pageNumber;
            DataTable pageTable = fullDataTable.Clone();

            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = startIndex + pageSize;
            if (endIndex > fullDataTable.Rows.Count)
            {
                endIndex = fullDataTable.Rows.Count;
            }

            for (int i = startIndex; i < endIndex; i++)
            {
                pageTable.ImportRow(fullDataTable.Rows[i]);
            }

            dataGridViewWystapienia.DataSource = pageTable;
            UpdatePaginationInfo();

            // Przypisanie danych do wykazania w Wordzie
            daneWykazane = new string[7, 7]; // Resetowanie danych

            for (int i = 0; i < pageSize; i++)
            {
                if (i < pageTable.Rows.Count)
                {
                    DataRow row = pageTable.Rows[i];

                    // Pobranie danych
                    daneWykazane[i, 0] = row["Imię i Nazwisko"].ToString();
                    daneWykazane[i, 1] = DateTime.ParseExact(row["Data"].ToString(), "yyyy-MM-dd", null).ToString("dd-MM-yyyy");
                    daneWykazane[i, 2] = row["Nr Zdarzenia"].ToString();
                    daneWykazane[i, 3] = row["Czas Szkolenia"].ToString();
                    daneWykazane[i, 4] = row["Czas"].ToString();
                    daneWykazane[i, 5] = row["Stawka"].ToString();

                    if (!string.IsNullOrEmpty(daneWykazane[i, 4]) && !string.IsNullOrEmpty(daneWykazane[i, 5]))
                    {
                        double czas = 0;
                        double czasSzkolenia = 0;
                        double stawka = Convert.ToDouble(daneWykazane[i, 5]);
                        double razem = 0;

                        // Sprawdź, czy "Czas" jest dostępny i prawidłowy
                        if (!string.IsNullOrEmpty(daneWykazane[i, 4]) && double.TryParse(daneWykazane[i, 4], out czas))
                        {
                            // Czas jest prawidłowy
                        }
                        else
                        {
                            czas = 0; // Jeśli brak wartości, ustaw czas na 0
                        }

                        // Sprawdź, czy "Czas Szkolenia" jest dostępny i prawidłowy
                        if (!string.IsNullOrEmpty(daneWykazane[i, 3]) && double.TryParse(daneWykazane[i, 3], out czasSzkolenia))
                        {
                            // Czas szkolenia jest prawidłowy
                        }
                        else
                        {
                            czasSzkolenia = 0; // Jeśli brak wartości, ustaw czas szkolenia na 0
                        }

                        // Jeśli czas wynosi 0, użyj czasSzkolenia, i na odwrót
                        if (czas == 0 && czasSzkolenia > 0)
                        {
                            razem = czasSzkolenia * stawka;
                        }
                        else if (czas > 0)
                        {
                            razem = czas * stawka;
                        }
                        else
                        {
                            razem = 0; // Jeśli oba są 0, razem też będzie 0
                        }

                        daneWykazane[i, 6] = razem.ToString();
                    }
                    else
                    {
                        daneWykazane[i, 6] = ""; // Jeśli brak danych, ustaw pole na puste
                    }




                    // Obliczenie Razem
                    /*  if (!string.IsNullOrEmpty(daneWykazane[i, 4]) && !string.IsNullOrEmpty(daneWykazane[i, 5]))
                      {
                          double czas = Convert.ToDouble(daneWykazane[i, 4]);
                          double stawka = Convert.ToDouble(daneWykazane[i, 5]);
                          double razem = czas * stawka;
                          daneWykazane[i, 6] = razem.ToString();
                      }
                      else
                      {
                          daneWykazane[i, 6] = "";
                      }
                  }
                  else
                  {
                      // Zerowanie danych dla pustych wierszy
                      for (int j = 0; j < 6; j++)
                      {
                          daneWykazane[i, j] = "";
                      }
                    */
                }
            }
        }

        private void UpdatePaginationInfo()
        {
            labelPagination.Text = $"Page {currentPage} of {totalPages}";
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                DisplayPage(currentPage + 1);
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                DisplayPage(currentPage - 1);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string fileName = $"{imieNazwisko.Replace(" ", "_")}_strona_{currentPage}.docx";
            string filePath = Path.Combine(userProfile, "Documents", "Kwartalna", fileName);
            string templatePath = Path.Combine(userProfile, "Documents", "Kwartalna", "szablon.docx");
            Console.WriteLine(templatePath);

            try
            {
                File.Copy(templatePath, filePath, true);

                using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(filePath, true))
                {
                    MainDocumentPart mainPart = wordDocument.MainDocumentPart;
                    string docText = null;
                    using (StreamReader sr = new StreamReader(mainPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }

                    // Zastąpienie danych w szablonie
                    for (int i = 1; i <= 7; i++)
                    {
                        docText = docText.Replace($"{{imieinazwisko{i}}}", daneWykazane[i - 1, 0]);
                        docText = docText.Replace($"{{data{i}}}", daneWykazane[i - 1, 1]);
                        docText = docText.Replace($"{{nrzdarzenia{i}}}", daneWykazane[i - 1, 2]);
                       docText = docText.Replace($"{{czasszkolenia{i}}}", daneWykazane[i - 1, 3]);
                        docText = docText.Replace($"{{czas{i}}}", daneWykazane[i - 1, 4]);
                        docText = docText.Replace($"{{stawka{i}}}", daneWykazane[i - 1, 5]);
                        docText = docText.Replace($"{{razem{i}}}", daneWykazane[i - 1, 6]);
                    }

                    using (StreamWriter sw = new StreamWriter(mainPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }

                    mainPart.Document.Save();
                }

                MessageBox.Show($"Dane z bieżącej strony zapisane do pliku {fileName}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonDeleteByNrZdarzenia_Click(object sender, EventArgs e)
        {
            // Wyświetlamy okienko dialogowe do wprowadzenia numeru zdarzenia
            string nrZdarzeniaToDelete = Interaction.InputBox("Podaj numer zdarzenia do usunięcia:", "Usuwanie danych", "");

            // Sprawdzamy, czy użytkownik podał numer zdarzenia
            if (!string.IsNullOrWhiteSpace(nrZdarzeniaToDelete))
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // Usunięcie wszystkich wpisów dla podanego numeru zdarzenia
                        string query = $"DELETE FROM {selectedTable} WHERE `Nr Zdarzenia` = @NrZdarzenia";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@NrZdarzenia", nrZdarzeniaToDelete);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Aktualizacja danych
                        LoadData();
                        MessageBox.Show($"Usunięto {rowsAffected} rekord(y) dla Nr Zdarzenia: {nrZdarzeniaToDelete}.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nie podano numeru zdarzenia do usunięcia.");
            }
        }
    }
}
