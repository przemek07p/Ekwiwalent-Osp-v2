using MySql.Data.MySqlClient;

namespace bazy
{
    public partial class Form1 : Form
    {
        private string connectionString = "server=localhost;user=root;password=;database=Kwartalna;";

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.Dpi;  // Skalowanie w zale¿noœci od DPI
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void LoadTables()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("SHOW TABLES;", connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    listBoxTables.Items.Clear();
                    comboBoxTables.Items.Clear();
                    while (reader.Read())
                    {
                        listBoxTables.Items.Add(reader[0].ToString());
                        comboBoxTables.Items.Add(reader[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonAddTable_Click(object sender, EventArgs e)
        {
            string tableName = textBoxTableName.Text;

            if (string.IsNullOrWhiteSpace(tableName))
            {
                MessageBox.Show("Wpisz nazwê nowego kwarta³u .");
                return;
            }

            string createTableQuery = $@"
                CREATE TABLE `{tableName}` (                    
                    `Imiê i Nazwisko` VARCHAR(255),
                    `Nr Zdarzenia` TEXT(255),
                    `Czas` INT(255),
                    `Czas Szkolenia` INT(255),
                    `Stawka` INT(255),
                    `Data` VARCHAR(25)
                    
                );";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(createTableQuery, connection);
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show($"Table '{tableName}' created successfully.");
                    LoadTables();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonDeleteTable_Click(object sender, EventArgs e)
        {
            string tableName = listBoxTables.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(tableName))
            {
                MessageBox.Show("Please select a table to delete.");
                return;
            }

            string dropTableQuery = $"DROP TABLE `{tableName}`;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(dropTableQuery, connection);
                    cmd.ExecuteNonQuery();
                    LoadTables();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private void buttonNext_Click(object sender, EventArgs e)
        {
            string selectedTable = comboBoxTables.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(selectedTable))
            {
                MessageBox.Show("Wybierz Kwarta³.");
                return;
            }

            Form2 form2 = new Form2(selectedTable);
            form2.Show();
            this.Hide();
        }
        private void buttonRatownicy_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
            this.Hide();
        }
    }
}