namespace Lab_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            matrixA_textBox = new TextBox();
            matrixB_textBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            rowCounter_numeric = new NumericUpDown();
            columnCounter_numeric = new NumericUpDown();
            matrixA_checkBox = new CheckBox();
            matrixB_checkBox = new CheckBox();
            generateMatrix_button = new Button();
            createCalculationProtocol_button = new CheckBox();
            matrixRank_button = new Button();
            inverseMatrix_button = new Button();
            label5 = new Label();
            matrixRank_textBox = new TextBox();
            SLAR_button = new Button();
            matrixX_textBox = new TextBox();
            label6 = new Label();
            inverseMatrix_textBox = new TextBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)rowCounter_numeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)columnCounter_numeric).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 0;
            label1.Text = "Матриця А";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(230, 9);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 1;
            label2.Text = "Матриця B";
            // 
            // matrixA_textBox
            // 
            matrixA_textBox.Location = new Point(12, 37);
            matrixA_textBox.Multiline = true;
            matrixA_textBox.Name = "matrixA_textBox";
            matrixA_textBox.ScrollBars = ScrollBars.Both;
            matrixA_textBox.Size = new Size(175, 150);
            matrixA_textBox.TabIndex = 4;
            // 
            // matrixB_textBox
            // 
            matrixB_textBox.Location = new Point(230, 37);
            matrixB_textBox.Multiline = true;
            matrixB_textBox.Name = "matrixB_textBox";
            matrixB_textBox.ScrollBars = ScrollBars.Both;
            matrixB_textBox.Size = new Size(175, 150);
            matrixB_textBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(467, 9);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 6;
            label3.Text = "Рядки";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(591, 9);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 7;
            label4.Text = "Стовпці";
            // 
            // rowCounter_numeric
            // 
            rowCounter_numeric.Location = new Point(467, 38);
            rowCounter_numeric.Name = "rowCounter_numeric";
            rowCounter_numeric.Size = new Size(73, 27);
            rowCounter_numeric.TabIndex = 8;
            rowCounter_numeric.TextAlign = HorizontalAlignment.Center;
            // 
            // columnCounter_numeric
            // 
            columnCounter_numeric.Location = new Point(591, 37);
            columnCounter_numeric.Name = "columnCounter_numeric";
            columnCounter_numeric.Size = new Size(73, 27);
            columnCounter_numeric.TabIndex = 9;
            columnCounter_numeric.TextAlign = HorizontalAlignment.Center;
            // 
            // matrixA_checkBox
            // 
            matrixA_checkBox.AutoSize = true;
            matrixA_checkBox.Location = new Point(467, 83);
            matrixA_checkBox.Name = "matrixA_checkBox";
            matrixA_checkBox.Size = new Size(105, 24);
            matrixA_checkBox.TabIndex = 10;
            matrixA_checkBox.Text = "матриця А";
            matrixA_checkBox.UseVisualStyleBackColor = true;
            matrixA_checkBox.CheckedChanged += matrixA_checkBox_CheckedChanged;
            // 
            // matrixB_checkBox
            // 
            matrixB_checkBox.AutoSize = true;
            matrixB_checkBox.Location = new Point(467, 113);
            matrixB_checkBox.Name = "matrixB_checkBox";
            matrixB_checkBox.Size = new Size(104, 24);
            matrixB_checkBox.TabIndex = 11;
            matrixB_checkBox.Text = "матриця В";
            matrixB_checkBox.UseVisualStyleBackColor = true;
            matrixB_checkBox.CheckedChanged += matrixB_checkBox_CheckedChanged;
            // 
            // generateMatrix_button
            // 
            generateMatrix_button.Location = new Point(467, 158);
            generateMatrix_button.Name = "generateMatrix_button";
            generateMatrix_button.Size = new Size(197, 29);
            generateMatrix_button.TabIndex = 12;
            generateMatrix_button.Text = "Згенерувати матрицю";
            generateMatrix_button.UseVisualStyleBackColor = true;
            generateMatrix_button.Click += generateMatrix_button_Click;
            // 
            // createCalculationProtocol_button
            // 
            createCalculationProtocol_button.AutoSize = true;
            createCalculationProtocol_button.Location = new Point(12, 214);
            createCalculationProtocol_button.Name = "createCalculationProtocol_button";
            createCalculationProtocol_button.Size = new Size(258, 24);
            createCalculationProtocol_button.TabIndex = 13;
            createCalculationProtocol_button.Text = "Формувати протокол обчислень";
            createCalculationProtocol_button.UseVisualStyleBackColor = true;
            // 
            // matrixRank_button
            // 
            matrixRank_button.Location = new Point(12, 257);
            matrixRank_button.Name = "matrixRank_button";
            matrixRank_button.Size = new Size(324, 48);
            matrixRank_button.TabIndex = 16;
            matrixRank_button.Text = "Знайти ранг матриці";
            matrixRank_button.UseVisualStyleBackColor = true;
            matrixRank_button.Click += matrixRank_button_Click;
            // 
            // inverseMatrix_button
            // 
            inverseMatrix_button.Location = new Point(342, 257);
            inverseMatrix_button.Name = "inverseMatrix_button";
            inverseMatrix_button.Size = new Size(339, 48);
            inverseMatrix_button.TabIndex = 17;
            inverseMatrix_button.Text = "Знайти обернену матрицю";
            inverseMatrix_button.UseVisualStyleBackColor = true;
            inverseMatrix_button.Click += inverseMatrix_button_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 326);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 18;
            label5.Text = "Ранг матриці";
            // 
            // matrixRank_textBox
            // 
            matrixRank_textBox.Location = new Point(118, 323);
            matrixRank_textBox.Name = "matrixRank_textBox";
            matrixRank_textBox.ReadOnly = true;
            matrixRank_textBox.Size = new Size(125, 27);
            matrixRank_textBox.TabIndex = 19;
            // 
            // SLAR_button
            // 
            SLAR_button.Location = new Point(12, 367);
            SLAR_button.Name = "SLAR_button";
            SLAR_button.Size = new Size(231, 62);
            SLAR_button.TabIndex = 20;
            SLAR_button.Text = "Обчислити СЛАР\r\n1-м методом\r\n";
            SLAR_button.UseVisualStyleBackColor = true;
            SLAR_button.Click += SLAR_button_Click;
            // 
            // matrixX_textBox
            // 
            matrixX_textBox.Location = new Point(282, 367);
            matrixX_textBox.Multiline = true;
            matrixX_textBox.Name = "matrixX_textBox";
            matrixX_textBox.ScrollBars = ScrollBars.Both;
            matrixX_textBox.Size = new Size(175, 150);
            matrixX_textBox.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(282, 326);
            label6.Name = "label6";
            label6.Size = new Size(84, 20);
            label6.TabIndex = 21;
            label6.Text = "Матриця Х";
            // 
            // inverseMatrix_textBox
            // 
            inverseMatrix_textBox.Location = new Point(489, 367);
            inverseMatrix_textBox.Multiline = true;
            inverseMatrix_textBox.Name = "inverseMatrix_textBox";
            inverseMatrix_textBox.ScrollBars = ScrollBars.Both;
            inverseMatrix_textBox.Size = new Size(175, 150);
            inverseMatrix_textBox.TabIndex = 24;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(489, 326);
            label7.Name = "label7";
            label7.Size = new Size(144, 20);
            label7.TabIndex = 23;
            label7.Text = "Обернена матриця";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(693, 547);
            Controls.Add(inverseMatrix_textBox);
            Controls.Add(label7);
            Controls.Add(matrixX_textBox);
            Controls.Add(label6);
            Controls.Add(SLAR_button);
            Controls.Add(matrixRank_textBox);
            Controls.Add(label5);
            Controls.Add(inverseMatrix_button);
            Controls.Add(matrixRank_button);
            Controls.Add(createCalculationProtocol_button);
            Controls.Add(generateMatrix_button);
            Controls.Add(matrixB_checkBox);
            Controls.Add(matrixA_checkBox);
            Controls.Add(columnCounter_numeric);
            Controls.Add(rowCounter_numeric);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(matrixB_textBox);
            Controls.Add(matrixA_textBox);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Застосування звичайних жорданових виключень";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)rowCounter_numeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)columnCounter_numeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox matrixA_textBox;
        private TextBox matrixB_textBox;
        private Label label3;
        private Label label4;
        private NumericUpDown rowCounter_numeric;
        private NumericUpDown columnCounter_numeric;
        private CheckBox matrixA_checkBox;
        private CheckBox matrixB_checkBox;
        private Button generateMatrix_button;
        private CheckBox createCalculationProtocol_button;
        private Button matrixRank_button;
        private Button inverseMatrix_button;
        private Label label5;
        private TextBox matrixRank_textBox;
        private Button SLAR_button;
        private TextBox matrixX_textBox;
        private Label label6;
        private TextBox inverseMatrix_textBox;
        private Label label7;
    }
}
