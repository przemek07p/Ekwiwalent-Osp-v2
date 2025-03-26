namespace bazy
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonAddTable;
        private System.Windows.Forms.Button buttonDeleteTable;
        private System.Windows.Forms.TextBox textBoxTableName;
        private System.Windows.Forms.ListBox listBoxTables;

        private void InitializeComponent()
        {
            buttonAddTable = new Button();
            buttonDeleteTable = new Button();
            textBoxTableName = new TextBox();
            listBoxTables = new ListBox();
            buttonRatownicy = new Button();
            buttonNext = new Button();
            comboBoxTables = new ComboBox();
            SuspendLayout();
            // 
            // buttonAddTable
            // 
            buttonAddTable.Location = new Point(278, 56);
            buttonAddTable.Name = "buttonAddTable";
            buttonAddTable.Size = new Size(75, 23);
            buttonAddTable.TabIndex = 2;
            buttonAddTable.Text = "Dodaj";
            buttonAddTable.UseVisualStyleBackColor = true;
            buttonAddTable.Click += buttonAddTable_Click;
            // 
            // buttonDeleteTable
            // 
            buttonDeleteTable.Location = new Point(278, 85);
            buttonDeleteTable.Name = "buttonDeleteTable";
            buttonDeleteTable.Size = new Size(75, 23);
            buttonDeleteTable.TabIndex = 3;
            buttonDeleteTable.Text = "Usuń";
            buttonDeleteTable.UseVisualStyleBackColor = true;
            buttonDeleteTable.Click += buttonDeleteTable_Click;
            // 
            // textBoxTableName
            // 
            textBoxTableName.Location = new Point(12, 56);
            textBoxTableName.Name = "textBoxTableName";
            textBoxTableName.Size = new Size(260, 23);
            textBoxTableName.TabIndex = 4;
            // 
            // listBoxTables
            // 
            listBoxTables.FormattingEnabled = true;
            listBoxTables.ItemHeight = 15;
            listBoxTables.Location = new Point(12, 85);
            listBoxTables.Name = "listBoxTables";
            listBoxTables.Size = new Size(260, 139);
            listBoxTables.TabIndex = 5;
            // 
            // buttonRatownicy
            // 
            buttonRatownicy.Location = new Point(278, 201);
            buttonRatownicy.Name = "buttonRatownicy";
            buttonRatownicy.Size = new Size(75, 23);
            buttonRatownicy.TabIndex = 8;
            buttonRatownicy.Text = "Ratownicy";
            buttonRatownicy.UseVisualStyleBackColor = true;
            buttonRatownicy.Click += buttonRatownicy_Click;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(278, 10);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(75, 23);
            buttonNext.TabIndex = 7;
            buttonNext.Text = "Dalej";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // comboBoxTables
            // 
            comboBoxTables.FormattingEnabled = true;
            comboBoxTables.Location = new Point(12, 12);
            comboBoxTables.Name = "comboBoxTables";
            comboBoxTables.Size = new Size(260, 23);
            comboBoxTables.TabIndex = 6;
            // 
            // Form1
            // 
            ClientSize = new Size(363, 237);
            Controls.Add(buttonRatownicy);
            Controls.Add(buttonNext);
            Controls.Add(comboBoxTables);
            Controls.Add(listBoxTables);
            Controls.Add(textBoxTableName);
            Controls.Add(buttonDeleteTable);
            Controls.Add(buttonAddTable);
            Name = "Form1";
            Text = "Database Manager";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Button buttonRatownicy;
        private Button buttonNext;
        private ComboBox comboBoxTables;
    }
}
