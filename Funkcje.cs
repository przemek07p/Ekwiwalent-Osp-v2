using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bazy
{
    public static class Funkcje
    {
        public static void PodmienNazwiskaWExcelu(DataGridView dataGridView, List<string> listaNazwisk)
        {
            if (listaNazwisk == null || listaNazwisk.Count == 0)
            {
                MessageBox.Show("Najpierw wczytaj plik z nazwiskami.");
                return;
            }

            string aktualneNazwisko = "";
            foreach (DataGridViewRow row in dataGridView.Rows)
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
        public static void UsunPrzedrostkiZJednostki(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Jednostka"].Value != null)
                {
                    string jednostka = row.Cells["Jednostka"].Value.ToString();
                    jednostka = Regex.Replace(jednostka, @"^dh\.?\s*", ""); // Usuwa "dh " i "dh. "
                    row.Cells["Jednostka"].Value = jednostka;
                }
            }
        }

        public static void ZaokraglijCzasUdzialu(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Czas udziału"].Value != null)
                {
                    string czasUdzialuRaw = row.Cells["Czas udziału"].Value.ToString();
                    row.Cells["Czas udziału"].Value = ZaokraglijDoPelnychGodzin(czasUdzialuRaw);
                }
            }
        }

        private static int ZaokraglijDoPelnychGodzin(string czas)
        {
            if (TimeSpan.TryParse(czas, out TimeSpan ts))
            {
                return (int)Math.Ceiling(ts.TotalHours); // Zaokrąglenie w górę
            }
            return 0; // Jeśli nie udało się sparsować, zwróć 0
        }













    }
}
