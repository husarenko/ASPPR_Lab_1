using System.Text;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Calculator calculator = new Calculator();

        private void Form1_Load(object sender, EventArgs e)
        {
            matrixA_checkBox.Checked = calculator.GenMatrixtA;
            matrixB_checkBox.Checked = calculator.GenMatrixtB;
        }

        private void matrixRank_button_Click(object sender, EventArgs e)
        {
            try
            {
                string matrixText = matrixA_textBox.Text.Trim();

                string[] rows = matrixText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                int n = rows.Length;
                int m = 0;

                if (n > 0)
                {
                    m = rows[0].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Length;

                    if (m == 0)
                    {
                        throw new ArgumentException("Матриця не містить даних.");
                    }
                }
                else
                {
                    throw new ArgumentException("Матриця не містить даних.");
                }


                double[,] matrix = new double[n, m];

                for (int i = 0; i < n; i++)
                {
                    string[] elements = rows[i].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (elements.Length != m)
                    {
                        throw new ArgumentException("Матриця повинна бути прямокутною.");
                    }

                    for (int j = 0; j < m; j++)
                    {
                        if (double.TryParse(elements[j], out double value))
                        {
                            matrix[i, j] = value;
                        }
                        else
                        {
                            throw new FormatException("Невірний формат числа в матриці.");
                        }
                    }
                }

                int rank = calculator.CalculateRank(matrix);

                matrixRank_textBox.Text = rank.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void inverseMatrix_button_Click(object sender, EventArgs e)
        {
            try
            {
                string matrixText = matrixA_textBox.Text.Trim();

                string[] rows = matrixText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                int n = rows.Length;
                int m = 0;

                if (n > 0)
                {
                    m = rows[0].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Length;

                    if (m == 0)
                    {
                        throw new ArgumentException("Матриця не містить даних.");
                    }
                }
                else
                {
                    throw new ArgumentException("Матриця не містить даних.");
                }

                if (n != m)
                {
                    throw new ArgumentException("Матриця повинна бути квадратною для обернення.");
                }

                double[,] matrix = new double[n, m];

                for (int i = 0; i < n; i++)
                {
                    string[] elements = rows[i].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (elements.Length != m)
                    {
                        throw new ArgumentException("Матриця повинна бути прямокутною.");
                    }

                    for (int j = 0; j < m; j++)
                    {
                        if (double.TryParse(elements[j], out double value))
                        {
                            matrix[i, j] = value;
                        }
                        else
                        {
                            throw new FormatException("Невірний формат числа в матриці.");
                        }
                    }
                }

                double[,] inverse = calculator.InverseMatrix(matrix);

                StringBuilder result = new StringBuilder();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        result.Append(inverse[i, j].ToString("F3")).Append(" ");
                    }
                    result.AppendLine();
                }

                inverseMatrix_textBox.Text = result.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generateMatrix_button_Click(object sender, EventArgs e)
        {
            int rows = (int)rowCounter_numeric.Value;
            int columns = (int)columnCounter_numeric.Value;

            calculator.GenerateMatrix(rows, columns, calculator.GenMatrixtA, calculator.GenMatrixtB, matrixA_textBox, matrixB_textBox);
        }

        private void matrixA_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            calculator.GenMatrixtA = matrixA_checkBox.Checked;
        }

        private void matrixB_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            calculator.GenMatrixtB = matrixB_checkBox.Checked;
        }

        private void SLAR_button_Click(object sender, EventArgs e)
        {
            try
            {
                double[,] matrixA = calculator.ParseMatrix(matrixA_textBox.Text);

                double[] vectorB = calculator.ParseVector(matrixB_textBox.Text);

                if (matrixA.GetLength(0) != matrixA.GetLength(1) || matrixA.GetLength(0) != vectorB.Length)
                {
                    MessageBox.Show("Некоректні розміри матриці або вектора.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                string protocol = calculator.GenerateProtocol(matrixA, vectorB);

                double[] solution = calculator.SolveSLAR(matrixA, vectorB);

                calculator.DisplaySolution(solution, matrixX_textBox);


                if (!createCalculationProtocol_button.Checked) { return; }
                ProtocolForm protocolForm = new ProtocolForm();
                protocolForm.protocol_textBox.Text = protocol;
                protocolForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}