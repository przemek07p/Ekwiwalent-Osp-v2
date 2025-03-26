using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace bazy
{
    public partial class Form11 : Form
    {
        private string stawka = "";
        private List<string> listaNazwisk = new List<string>();
        private string connectionString = "server=localhost;user=root;password=;database=Kwartalna;";
        public Form11()
        {
            InitializeComponent();
            PobierzTabeleDoComboBoxa();
        }
    
        private void PobierzTabeleDoComboBoxa()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("SHOW TABLES;", connection); // SQL do pobrania tabel
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Dodawanie nazw tabel do ComboBox
                        comboBoxTabele.Items.Add(reader.GetString(0));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd połączenia z bazą danych: " + ex.Message);
                }
            }
        }
        private void txtStawka_TextChanged(object sender, EventArgs e)
        {
            stawka = txtStawka.Text;
        }

        private void btnPodmienNazwiska_Click(object sender, EventArgs e)
        {
            Funkcje.PodmienNazwiskaWExcelu(dataGridView1, listaNazwisk);
            Funkcje.UsunPrzedrostkiZJednostki(dataGridView1);
            Funkcje.ZaokraglijCzasUdzialu(dataGridView1);
        }


        private void btnWybierzPlik_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Wybierz plik XLSX",
                Filter = "Pliki Excel (*.xlsx)|*.xlsx",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtSciezkaPliku.Text = openFileDialog.FileName;
                WczytajDaneZExcela(openFileDialog.FileName);
            }
        }

        private void btnWybierzPlikNazwiska_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Wybierz plik tekstowy z nazwiskami",
                Filter = "Pliki tekstowe (*.txt)|*.txt",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtSciezkaNazwiska.Text = openFileDialog.FileName;
                WczytajNazwiskaZPliku(openFileDialog.FileName);
            }
        }





        private void WczytajNazwiskaZPliku(string filePath)
        {
            listaNazwisk = File.ReadAllLines(filePath).Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
        }

        private void WczytajDaneZExcela(string filePath)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Jednostka");
            dataTable.Columns.Add("Czas rozpoczęcia zdarzenia");
            dataTable.Columns.Add("Nr meldunku");
            dataTable.Columns.Add("Czas udziału");

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(filePath, false))
            {
                WorkbookPart workbookPart = document.WorkbookPart;
                Sheet firstSheet = workbookPart.Workbook.Sheets.Elements<Sheet>().FirstOrDefault();

                if (firstSheet != null)
                {
                    WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(firstSheet.Id);
                    SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().FirstOrDefault();

                    if (sheetData != null)
                    {
                        Row headerRow = sheetData.Elements<Row>().FirstOrDefault();
                        if (headerRow == null) return;

                        var columnIndexes = FindColumnIndexes(headerRow, workbookPart);

                        foreach (Row row in sheetData.Elements<Row>().Skip(1))
                        {
                            DataRow dataRow = dataTable.NewRow();
                            dataRow["Jednostka"] = GetCellValue(row, columnIndexes.jednostka, workbookPart);

                            string rawDate = GetCellValue(row, columnIndexes.czasRozpoczecia, workbookPart);
                            dataRow["Czas rozpoczęcia zdarzenia"] = FormatExcelDate(rawDate);

                            dataRow["Nr meldunku"] = GetCellValue(row, columnIndexes.nrMeldunku, workbookPart);
                            dataRow["Czas udziału"] = GetCellValue(row, columnIndexes.czasUdzialu, workbookPart);

                            dataTable.Rows.Add(dataRow);
                        }
                    }
                }
            }

            dataGridView1.DataSource = dataTable;
        }

        private (int jednostka, int czasRozpoczecia, int nrMeldunku, int czasUdzialu) FindColumnIndexes(Row headerRow, WorkbookPart workbookPart)
        {
            int jednostkaIndex = -1, czasRozpoczeciaIndex = -1, nrMeldunkuIndex = -1, czasUdzialuIndex = -1;
            int columnIndex = 0;

            foreach (Cell cell in headerRow.Elements<Cell>())
            {
                string cellValue = GetCellValue(cell, workbookPart);

                if (cellValue == "Jednostka") jednostkaIndex = columnIndex;
                if (cellValue == "Czas rozpoczęcia zdarzenia") czasRozpoczeciaIndex = columnIndex;
                if (cellValue == "Nr meldunku") nrMeldunkuIndex = columnIndex;
                if (cellValue == "Czas udziału") czasUdzialuIndex = columnIndex;

                columnIndex++;
            }

            return (jednostkaIndex, czasRozpoczeciaIndex, nrMeldunkuIndex, czasUdzialuIndex);
        }

        private string GetCellValue(Row row, int columnIndex, WorkbookPart workbookPart)
        {
            Cell cell = row.Elements<Cell>().ElementAtOrDefault(columnIndex);
            return cell != null ? GetCellValue(cell, workbookPart) : "";
        }

        private string GetCellValue(Cell cell, WorkbookPart workbookPart)
        {
            if (cell.CellValue == null)
                return "";

            string value = cell.CellValue.InnerText;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(value)).InnerText;
            }

            return value;
        }

        private string FormatExcelDate(string excelDate)
        {
            return (!string.IsNullOrEmpty(excelDate) && excelDate.Length > 6) ? excelDate.Substring(0, excelDate.Length - 6) : excelDate;
        }


        private void btnZapiszDoPliku_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Zapisz plik tekstowy",
                Filter = "Pliki tekstowe (*.txt)|*.txt",
                DefaultExt = "txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Czas rozpoczęcia zdarzenia"].Value != null &&
                            !string.IsNullOrWhiteSpace(row.Cells["Czas rozpoczęcia zdarzenia"].Value.ToString()))
                        {
                            string jednostka = row.Cells["Jednostka"].Value?.ToString() ?? "";
                            string czasRozpoczecia = row.Cells["Czas rozpoczęcia zdarzenia"].Value?.ToString() ?? "";
                            string nrMeldunku = row.Cells["Nr meldunku"].Value?.ToString() ?? "";
                            string czasUdzialu = row.Cells["Czas udziału"].Value?.ToString() ?? "";

                            string linia = $"{jednostka};{czasRozpoczecia};{nrMeldunku};{czasUdzialu}";
                            writer.WriteLine(linia);
                        }
                    }
                }
                MessageBox.Show("Dane zostały zapisane do pliku.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }



        //____________
        private void btnZapiszDoBazy_Click(object sender, EventArgs e)
        {
            if (comboBoxTabele.SelectedItem == null)
            {
                MessageBox.Show("Wybierz tabelę do zapisania danych.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string wybranaTabela = comboBoxTabele.SelectedItem.ToString();
            string stawka = txtStawka.Text.Trim(); // Pobranie stawki wpisanej przez użytkownika

            if (string.IsNullOrWhiteSpace(stawka) || !int.TryParse(stawka, out int stawkaInt))
            {
                MessageBox.Show("Podaj poprawną stawkę jako liczbę całkowitą.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Czas rozpoczęcia zdarzenia"].Value != null &&
                            !string.IsNullOrWhiteSpace(row.Cells["Czas rozpoczęcia zdarzenia"].Value.ToString()))
                        {
                            string jednostka = row.Cells["Jednostka"].Value?.ToString() ?? "";
                            string czasRozpoczecia = row.Cells["Czas rozpoczęcia zdarzenia"].Value?.ToString() ?? "";
                            string nrMeldunku = row.Cells["Nr meldunku"].Value?.ToString() ?? "";
                            string czasUdzialu = row.Cells["Czas udziału"].Value?.ToString() ?? "0";

                            if (!int.TryParse(czasUdzialu, out int czasUdzialuInt))
                            {
                                czasUdzialuInt = 0;
                            }

                            string query = $"INSERT INTO `{wybranaTabela}` (`Imię i Nazwisko`, `Nr Zdarzenia`, `Czas`, `Czas Szkolenia`, `Stawka`, `Data`) " +
                                           "VALUES (@jednostka, @nrMeldunku, @czasUdzialu, 0, @stawka, @czasRozpoczecia)";

                            using (MySqlCommand cmd = new MySqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@jednostka", jednostka);
                                cmd.Parameters.AddWithValue("@nrMeldunku", nrMeldunku);
                                cmd.Parameters.AddWithValue("@czasUdzialu", czasUdzialuInt);
                                cmd.Parameters.AddWithValue("@stawka", stawkaInt);
                                cmd.Parameters.AddWithValue("@czasRozpoczecia", czasRozpoczecia);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Dane zostały zapisane do bazy.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd zapisu do bazy: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}