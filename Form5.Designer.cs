namespace bazy
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewOsoby = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOsoby).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewOsoby
            // 
            dataGridViewOsoby.AllowUserToAddRows = false;
            dataGridViewOsoby.AllowUserToDeleteRows = false;
            dataGridViewOsoby.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewOsoby.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOsoby.Dock = DockStyle.Fill;
            dataGridViewOsoby.Location = new Point(0, 0);
            dataGridViewOsoby.Name = "dataGridViewOsoby";
            dataGridViewOsoby.ReadOnly = true;
            dataGridViewOsoby.RowHeadersVisible = false;
            dataGridViewOsoby.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOsoby.Size = new Size(303, 264);
            dataGridViewOsoby.TabIndex = 0;
            dataGridViewOsoby.CellDoubleClick += dataGridViewOsoby_CellDoubleClick;
            // 
            // button1
            // 
            button1.Location = new Point(216, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Powrót";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(216, 41);
            button2.Name = "button2";
            button2.Size = new Size(75, 41);
            button2.TabIndex = 2;
            button2.Text = "Generuj Raport";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(303, 264);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridViewOsoby);
            Name = "Form5";
            Text = "Form5";
            FormClosing += Form5_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridViewOsoby).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOsoby;
        private Button button1;
        private Button button2;
    }
}
