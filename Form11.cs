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

namespace bazy
{
    public partial class Form11 : Form
    {
        private List<string> listaNazwisk = new List<string>();

        public Form11()
        {
            InitializeComponent();
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

        private void btnPodmienNazwiska_Click(object sender, EventArgs e)
        {
            PodmienNazwiskaWExcelu();
            UsunPrzedrostkiZJednostki();
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

        private void PodmienNazwiskaWExcelu()
        {
            if (listaNazwisk.Count == 0)
            {
                MessageBox.Show("Najpierw wczytaj plik z nazwiskami.");
                return;
            }

            string aktualneNazwisko = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Jednostka"].Value != null)
                {
                    string jednostka = row.Cells["Jednostka"].Value.ToString().Trim();

                    if (listaNazwisk.Contains(jednostka))
                    {
                        aktualneNazwisko = jednostka;
                    }
                    else if (!string.IsNullOrEmpty(aktualneNazwisko))
                    {
                        row.Cells["Jednostka"].Value = aktualneNazwisko;
                    }
                }
            }
        }

        private void UsunPrzedrostkiZJednostki()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Jednostka"].Value != null)
                {
                    string jednostka = row.Cells["Jednostka"].Value.ToString();
                    jednostka = Regex.Replace(jednostka, @"^dh\.?\s*", ""); // Usuwa "dh " i "dh. "
                    row.Cells["Jednostka"].Value = jednostka;
                }
            }

        }
    }
}