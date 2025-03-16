using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Calculator
    {
        public bool GenMatrixtA { get; set; } = false;
        public bool GenMatrixtB { get; set; } = false;

        public void GenerateMatrix(int rows, int columns, bool generateA, bool generateB, TextBox matrixATextBox, TextBox matrixBTextBox)
        {
            Random random = new Random();

            if (generateA)
            {
                double[,] matrixA = new double[rows, columns];
                StringBuilder sbA = new StringBuilder();

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        int value;
                        do
                        {
                            value = random.Next(-10, 11);
                        } while (value == 0);

                        matrixA[i, j] = value;
                        sbA.Append(matrixA[i, j]).Append(" ");
                    }
                    sbA.AppendLine();
                }

                matrixATextBox.Text = sbA.ToString();
            }

            if (generateB)
            {
                double[,] matrixB = new double[rows, columns];
                StringBuilder sbB = new StringBuilder();

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        int value;
                        do
                        {
                            value = random.Next(-10, 11);
                        } while (value == 0);

                        matrixB[i, j] = value;
                        sbB.Append(matrixB[i, j]).Append(" ");
                    }
                    sbB.AppendLine();
                }

                matrixBTextBox.Text = sbB.ToString();
            }
        }


        private void JordanElimination(double[,] a, double[] b, int row, int col)
        {
            int n = a.GetLength(0);
            double ars = a[row, col];

            if (ars == 0)
            {
                throw new InvalidOperationException("Ділення на нуль, розв'язувальний елемент не може бути нулем.");
            }

            for (int j = 0; j < n; j++)
            {
                a[row, j] /= ars;
            }
            b[row] /= ars;

            for (int k = 0; k < n; k++)
            {
                if (k != row)
                {
                    double aik = a[k, col];
                    for (int j = 0; j < n; j++)
                    {
                        a[k, j] -= aik * a[row, j];
                    }
                    b[k] -= aik * b[row];
                }
            }
        }

        public int CalculateRank(double[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);

            if (n == 0 || m == 0)
            {
                throw new ArgumentException("Матриця не може бути порожньою.");
            }

            if (a.GetLength(0) != n || a.GetLength(1) != m)
            {
                throw new ArgumentException("Матриця повинна бути прямокутною.");
            }

            int r = 0;
            int i = 0;
            double[] b = new double[Math.Max(n, m)];

            while (i < Math.Min(n, m))
            {
                if (a[i, i] != 0)
                {
                    r++;
                    JordanElimination(a, b, i, i);
                }
                i++;
            }
            return r;
        }

        public double[,] InverseMatrix(double[,] a)
        {
            int n = a.GetLength(0);
            double[,] aug = new double[n, 2 * n];
            double[,] inv = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    aug[i, j] = a[i, j];
                    aug[i, j + n] = (i == j) ? 1 : 0;
                }
            }

            for (int i = 0; i < n; i++)
            {
                double pivot = aug[i, i];
                if (pivot == 0)
                {
                    throw new InvalidOperationException("Матриця не може бути оберненою");
                }

                for (int j = 0; j < 2 * n; j++)
                {
                    aug[i, j] /= pivot;
                }

                for (int k = 0; k < n; k++)
                {
                    if (k != i)
                    {
                        double factor = aug[k, i];
                        for (int j = 0; j < 2 * n; j++)
                        {
                            aug[k, j] -= factor * aug[i, j];
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inv[i, j] = aug[i, j + n];
                }
            }

            return inv;
        }


        public double[,] ParseMatrix(string matrixText)
        {
            string[] rows = matrixText.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int n = rows.Length;
            int m = rows[0].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
            double[,] matrix = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] elements = rows[i].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = double.Parse(elements[j]);
                }
            }

            return matrix;
        }

        public double[] ParseVector(string vectorText)
        {
            string[] elements = vectorText.Trim().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            double[] vector = new double[elements.Length];



            for (int i = 0; i < elements.Length; i++)
            {
                string element = elements[i].Trim();

                if (!string.IsNullOrEmpty(element))
                {
                    vector[i] = double.Parse(element);
                }
                else
                {
                    vector[i] = 0;
                }
            }


            //for (int i = 0; i < elements.Length; i++)
            //{
            //    vector[i] = double.Parse(elements[i]);
            //}

            return vector;
        }


        public double[] SolveSLAR(double[,] a, double[] b)
        {
            int n = a.GetLength(0);
            double[] x = new double[n];
            double[,] aCopy = (double[,])a.Clone();
            double[] bCopy = (double[])b.Clone();

            for (int i = 0; i < n; i++)
            {
                JordanElimination(aCopy, bCopy, i, i);
            }

            for (int i = 0; i < n; i++)
            {
                x[i] = bCopy[i];
            }

            return x;
        }


        public void DisplaySolution(double[] solution, TextBox output)
        {
            string result = "";
            for (int i = 0; i < solution.Length; i++)
            {
                result += $"{Math.Round(solution[i], 3)}{Environment.NewLine}";
            }
            output.Text = result;
        }


        public string GenerateProtocol(double[,] a, double[] b)
        {
            StringBuilder protocol = new StringBuilder();
            protocol.AppendLine("Згенерований протокол обчислення:");
            protocol.AppendLine("Знаходження розв’язків СЛАР 1-м методом (за допомогою оберненої матриці):");
            protocol.AppendLine("Знаходження оберненої матриці:");
            protocol.AppendLine("Вхідна матриця:");
            protocol.AppendLine(MatrixToString(a));
            double[,] calcRank = (double[,])a.Clone();
            protocol.AppendLine("Ранг матриці: " + CalculateRank(calcRank).ToString());
            protocol.AppendLine("\n");

            int n = a.GetLength(0);
            double[,] aug = new double[n, 2 * n];
            double[,] originalA = (double[,])a.Clone();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    aug[i, j] = originalA[i, j];
                    aug[i, j + n] = (i == j) ? 1 : 0;
                }
            }

            for (int i = 0; i < n; i++)
            {
                protocol.AppendLine($"Крок #{i + 1}");
                protocol.AppendLine($"Розв’язувальний елемент: A[{i + 1}, {i + 1}] = {aug[i, i]:F2}");

                double pivot = aug[i, i];
                for (int j = 0; j < 2 * n; j++)
                {
                    aug[i, j] /= pivot;
                }

                for (int k = 0; k < n; k++)
                {
                    if (k != i)
                    {
                        double factor = aug[k, i];
                        for (int j = 0; j < 2 * n; j++)
                        {
                            aug[k, j] -= factor * aug[i, j];
                        }
                    }
                }

                protocol.AppendLine("Матриця після виконання ЗЖВ:");
                protocol.AppendLine(AugmentedMatrixToString(aug, n));
                //protocol.AppendLine(AugmentedMatrixToString(aug, n));
            }

            double[,] inv = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inv[i, j] = aug[i, j + n];
                }
            }

            protocol.AppendLine("Обернена матриця:");
            protocol.AppendLine(MatrixToString(inv));

            protocol.AppendLine("Вхідна матриця В:");
            protocol.AppendLine(VectorToString(b));

            protocol.AppendLine("Обчислення розв’язків:");
            double[] x = new double[n];
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += inv[i, j] * b[j];
                }
                x[i] = sum;
                protocol.AppendLine($"X[{i + 1}] = {string.Join(" + ", Enumerable.Range(0, n).Select(j => $"{b[j]:F2} * {inv[i, j]:F2}"))} = {x[i]:F2}");
            }

            return protocol.ToString();
        }


        private string MatrixToString(double[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append($"{matrix[i, j]:F2} ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }


        private string AugmentedMatrixToString(double[,] matrix, int n)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = n; j < 2 * n; j++)
                {
                    sb.Append($"{matrix[i, j]:F2} ");
                }
                for (int j = 0; j < n; j++)
                {
                    sb.Append($"{matrix[i, j]:F2} ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private string VectorToString(double[] vector)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < vector.Length; i++)
            {
                sb.AppendLine($"{vector[i]:F2}");
            }
            return sb.ToString();
        }


        //public string GenerateProtocol(double[,] a, double[] b)
        //{
        //    StringBuilder protocol = new StringBuilder();
        //    protocol.AppendLine("Згенерований протокол обчислення:");
        //    protocol.AppendLine("Знаходження розв’язків СЛАР 1-м методом (за допомогою оберненої матриці):");
        //    protocol.AppendLine("Знаходження оберненої матриці:");
        //    protocol.AppendLine("Вхідна матриця:");
        //    protocol.AppendLine(MatrixToString(a));

        //    int n = a.GetLength(0);
        //    double[,] inv = new double[n, n]; //inversed
        //    double[,] aug = new double[n, 2 * n]; //augmentation

        //    double[,] originalA = (double[,])a.Clone();
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {
        //            aug[i, j] = originalA[i, j];
        //            aug[i, j + n] = (i == j) ? 1 : 0;
        //        }
        //    }

        //    for (int i = 0; i < n; i++)
        //    {
        //        protocol.AppendLine($"Крок #{i + 1}");
        //        protocol.AppendLine($"Розв’язувальний елемент: A[{i + 1}, {i + 1}] = {aug[i, i]:F2}");

        //        JordanElimination(aug, new double[2 * n], i, i);

        //        protocol.AppendLine("Матриця після виконання ЗЖВ:");
        //        protocol.AppendLine(AugmentedMatrixToString(aug, n));
        //    }

        //    for (int i = 0; i < n; i++)
        //        for (int j = 0; j < n; j++)
        //            inv[i, j] = aug[i, j + n];

        //    protocol.AppendLine("Обернена матриця:");
        //    protocol.AppendLine(MatrixToString(inv));

        //    protocol.AppendLine("Вхідна матриця В:");
        //    protocol.AppendLine(VectorToString(b));

        //    protocol.AppendLine("Обчислення розв’язків:");
        //    double[] x = new double[n];
        //    for (int i = 0; i < n; i++)
        //    {
        //        double sum = 0;
        //        for (int j = 0; j < n; j++)
        //        {
        //            sum += inv[i, j] * b[j];
        //        }
        //        x[i] = sum;
        //        protocol.AppendLine($"X[{i + 1}] = {string.Join(" + ", Enumerable.Range(0, n).Select(j => $"{b[j]:F2} * {inv[i, j]:F2}"))} = {x[i]:F2}");
        //    }

        //    return protocol.ToString();
        //}


        //public double[] SolveSLAR(double[,] a, double[] b)
        //{
        //    int n = a.GetLength(0);
        //    double[] x = new double[n];
        //    double[,] aCopy = (double[,])a.Clone();
        //    double[] bCopy = (double[])b.Clone();

        //    for (int i = 0; i < n; i++)
        //    {
        //        double ars = aCopy[i, i];

        //        if (ars == 0)
        //        {
        //            throw new InvalidOperationException("Ділення на нуль, матриця не може бути оберненою.");
        //        }

        //        //ars замінити на "1"
        //        for (int j = 0; j < n; j++)
        //        {
        //            aCopy[i, j] /= ars;
        //        }
        //        bCopy[i] /= ars;

        //        //bij = aij*ars - ais*arj
        //        for (int k = 0; k < n; k++)
        //        {
        //            if (k != i)
        //            {
        //                double aik = aCopy[k, i];
        //                for (int j = 0; j < n; j++)
        //                {
        //                    aCopy[k, j] -= aik * aCopy[i, j];
        //                }
        //                bCopy[k] -= aik * bCopy[i];
        //            }
        //        }
        //    }

        //    //Розрахунок x[i] (в нашому випадку x[i] = b[i])
        //    for (int i = 0; i < n; i++)
        //    {
        //        x[i] = bCopy[i];
        //    }

        //    return x;
        //}


        //public double[,] InverseMatrix(double[,] a)
        //{
        //    int n = a.GetLength(0);
        //    double[,] aug = new double[n, 2 * n];
        //    double[,] inv = new double[n, n];

        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {
        //            aug[i, j] = a[i, j];
        //            aug[i, j + n] = (i == j) ? 1 : 0;
        //        }
        //    }

        //    for (int i = 0; i < n; i++)
        //    {
        //        double pivot = aug[i, i];
        //        if (pivot == 0)
        //            throw new InvalidOperationException("Матриця не може бути оберненою");

        //        for (int j = 0; j < 2 * n; j++)
        //            aug[i, j] /= pivot;

        //        for (int k = 0; k < n; k++)
        //        {
        //            if (k != i)
        //            {
        //                double factor = aug[k, i];
        //                for (int j = 0; j < 2 * n; j++)
        //                    aug[k, j] -= factor * aug[i, j];
        //            }
        //        }
        //    }

        //    for (int i = 0; i < n; i++)
        //        for (int j = 0; j < n; j++)
        //            inv[i, j] = aug[i, j + n];

        //    return inv;
        //}

        //public int CalculateRank(double[,] a)
        //{
        //    int n = a.GetLength(0);
        //    int m = a.GetLength(1);

        //    if (n == 0 || m == 0)
        //    {
        //        throw new ArgumentException("Матриця не може бути порожньою.");
        //    }

        //    if (a.GetLength(0) != n || a.GetLength(1) != m)
        //    {
        //        throw new ArgumentException("Матриця повинна бути прямокутною.");
        //    }

        //    int r = 0;
        //    int i = 0;

        //    while (i < n && i < m)
        //    {
        //        if (a[i, i] != 0)
        //        {
        //            double pivot = a[i, i];
        //            r++;

        //            for (int k = i + 1; k < n; k++)
        //            {
        //                double factor = a[k, i] / pivot;
        //                for (int j = i; j < m; j++)
        //                {
        //                    a[k, j] -= factor * a[i, j];
        //                }
        //            }
        //        }
        //        i++;
        //    }
        //    return r;
        //}
    }
}
