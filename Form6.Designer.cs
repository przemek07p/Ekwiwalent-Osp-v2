namespace bazy
{
    partial class Form6
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewWystapienia;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Label labelPagination;
        private System.Windows.Forms.Button buttonDeleteByNrZdarzenia; // Nowy przycisk usuwania

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewWystapienia = new DataGridView();
            buttonNext = new Button();
            buttonPrevious = new Button();
            buttonPrint = new Button();
            labelPagination = new Label();
            buttonDeleteByNrZdarzenia = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewWystapienia).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewWystapienia
            // 
            dataGridViewWystapienia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewWystapienia.Location = new Point(14, 14);
            dataGridViewWystapienia.Margin = new Padding(4, 3, 4, 3);
            dataGridViewWystapienia.Name = "dataGridViewWystapienia";
            dataGridViewWystapienia.Size = new Size(905, 433);
            dataGridViewWystapienia.TabIndex = 0;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(832, 453);
            buttonNext.Margin = new Padding(4, 3, 4, 3);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(88, 27);
            buttonNext.TabIndex = 1;
            buttonNext.Text = "Następna Strona";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // buttonPrevious
            // 
            buttonPrevious.Location = new Point(737, 453);
            buttonPrevious.Margin = new Padding(4, 3, 4, 3);
            buttonPrevious.Name = "buttonPrevious";
            buttonPrevious.Size = new Size(88, 27);
            buttonPrevious.TabIndex = 2;
            buttonPrevious.Text = "Poprzednia Strona";
            buttonPrevious.UseVisualStyleBackColor = true;
            buttonPrevious.Click += buttonPrevious_Click;
            // 
            // buttonPrint
            // 
            buttonPrint.Location = new Point(643, 453);
            buttonPrint.Margin = new Padding(4, 3, 4, 3);
            buttonPrint.Name = "buttonPrint";
            buttonPrint.Size = new Size(88, 27);
            buttonPrint.TabIndex = 3;
            buttonPrint.Text = "Generuj";
            buttonPrint.UseVisualStyleBackColor = true;
            buttonPrint.Click += buttonPrint_Click;
            // 
            // labelPagination
            // 
            labelPagination.AutoSize = true;
            labelPagination.Location = new Point(14, 459);
            labelPagination.Margin = new Padding(4, 0, 4, 0);
            labelPagination.Name = "labelPagination";
            labelPagination.Size = new Size(65, 15);
            labelPagination.TabIndex = 4;
            labelPagination.Text = "Page 1 of 1";
            // 
            // buttonDeleteByNrZdarzenia
            // 
            buttonDeleteByNrZdarzenia.Location = new Point(548, 453);
            buttonDeleteByNrZdarzenia.Margin = new Padding(4, 3, 4, 3);
            buttonDeleteByNrZdarzenia.Name = "buttonDeleteByNrZdarzenia";
            buttonDeleteByNrZdarzenia.Size = new Size(88, 27);
            buttonDeleteByNrZdarzenia.TabIndex = 5;
            buttonDeleteByNrZdarzenia.Text = "Usuń";
            buttonDeleteByNrZdarzenia.UseVisualStyleBackColor = true;
            buttonDeleteByNrZdarzenia.Click += buttonDeleteByNrZdarzenia_Click;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(buttonDeleteByNrZdarzenia);
            Controls.Add(labelPagination);
            Controls.Add(buttonPrint);
            Controls.Add(buttonPrevious);
            Controls.Add(buttonNext);
            Controls.Add(dataGridViewWystapienia);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form6";
            Text = "Form6";
            ((System.ComponentModel.ISupportInitialize)dataGridViewWystapienia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
