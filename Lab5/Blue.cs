using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            answer = new double[rows];

            for (int row = 0; row < rows; row++)
            {
                long sum = 0;
                int count = 0;
                for (int column = 0; column < columns; column++)
                {
                    int value = matrix[row, column];
                    if (value > 0)
                    {
                        sum += value;
                        count++;
                    }
                }

                if (count > 0)
                    answer[row] = (double)sum / count;
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int maxRow = 0;
            int maxColumn = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (matrix[row, column] > matrix[maxRow, maxColumn])
                    {
                        maxRow = row;
                        maxColumn = column;
                    }
                }
            }

            answer = new int[rows - 1, columns - 1];
            for (int row = 0; row < rows - 1; row++)
            {
                for (int column = 0; column < columns - 1; column++)
                {
                    int sourceRow = row < maxRow ? row : row + 1;
                    int sourceColumn = column < maxColumn ? column : column + 1;
                    answer[row, column] = matrix[sourceRow, sourceColumn];
                }
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                int maxColumn = 0;
                for (int column = 1; column < columns; column++)
                {
                    if (matrix[row, column] > matrix[row, maxColumn])
                        maxColumn = column;
                }

                int maximum = matrix[row, maxColumn];
                for (int column = maxColumn; column < columns - 1; column++)
                    matrix[row, column] = matrix[row, column + 1];

                matrix[row, columns - 1] = maximum;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            answer = new int[rows, columns + 1];

            for (int row = 0; row < rows; row++)
            {
                int maximum = matrix[row, columns - 1];
                for (int column = 0; column < columns - 1; column++)
                {
                    int value = matrix[row, column];
                    answer[row, column] = value;
                    maximum = Math.Max(maximum, value);
                }

                answer[row, columns - 1] = maximum;
                answer[row, columns] = matrix[row, columns - 1];
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            answer = new int[matrix.Length / 2];
            int index = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 1 - row % 2; column < columns; column += 2)
                    answer[index++] = matrix[row, column];
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            int size = matrix.GetLength(0);
            if (matrix.GetLength(1) != size || k < 0 || k >= size)
                return;

            int maxRow = 0;
            int negativeRow = -1;
            for (int row = 0; row < size; row++)
            {
                if (matrix[row, row] > matrix[maxRow, maxRow])
                    maxRow = row;

                if (negativeRow == -1 && matrix[row, k] < 0)
                    negativeRow = row;
            }

            if (negativeRow == -1 || negativeRow == maxRow)
                return;

            for (int column = 0; column < size; column++)
            {
                int value = matrix[maxRow, column];
                matrix[maxRow, column] = matrix[negativeRow, column];
                matrix[negativeRow, column] = value;
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            if (columns < 2 || array.Length != columns)
                return;

            int targetColumn = columns - 2;
            int maxRow = 0;
            for (int row = 1; row < rows; row++)
            {
                if (matrix[row, targetColumn] > matrix[maxRow, targetColumn])
                    maxRow = row;
            }

            for (int column = 0; column < columns; column++)
                matrix[maxRow, column] = array[column];
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int column = 0; column < columns; column++)
            {
                int maxRow = 0;
                for (int row = 1; row < rows; row++)
                {
                    if (matrix[row, column] > matrix[maxRow, column])
                        maxRow = row;
                }

                if (maxRow >= rows / 2)
                    continue;

                int sum = 0;
                for (int row = maxRow + 1; row < rows; row++)
                    sum += matrix[row, column];

                matrix[0, column] = sum;
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int row = 0; row + 1 < rows; row += 2)
            {
                int firstMaxColumn = 0;
                int secondMaxColumn = 0;
                for (int column = 1; column < columns; column++)
                {
                    if (matrix[row, column] > matrix[row, firstMaxColumn])
                        firstMaxColumn = column;

                    if (matrix[row + 1, column] > matrix[row + 1, secondMaxColumn])
                        secondMaxColumn = column;
                }

                int value = matrix[row, firstMaxColumn];
                matrix[row, firstMaxColumn] = matrix[row + 1, secondMaxColumn];
                matrix[row + 1, secondMaxColumn] = value;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int size = matrix.GetLength(0);
            if (matrix.GetLength(1) != size)
                return;

            int maxRow = 0;
            for (int row = 1; row < size; row++)
            {
                if (matrix[row, row] > matrix[maxRow, maxRow])
                    maxRow = row;
            }

            for (int row = 0; row < maxRow; row++)
            {
                for (int column = row + 1; column < size; column++)
                    matrix[row, column] = 0;
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int[] positiveCounts = new int[rows];
            int[] rowOrder = new int[rows];

            for (int row = 0; row < rows; row++)
            {
                rowOrder[row] = row;
                for (int column = 0; column < columns; column++)
                {
                    if (matrix[row, column] > 0)
                        positiveCounts[row]++;
                }
            }

            // Строки с равным количеством положительных элементов сохраняют порядок.
            for (int row = 1; row < rows; row++)
            {
                int sourceRow = rowOrder[row];
                int position = row;
                while (position > 0 && positiveCounts[rowOrder[position - 1]] < positiveCounts[sourceRow])
                {
                    rowOrder[position] = rowOrder[position - 1];
                    position--;
                }

                rowOrder[position] = sourceRow;
            }

            int[,] original = new int[rows, columns];
            Array.Copy(matrix, original, matrix.Length);
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                    matrix[row, column] = original[rowOrder[row], column];
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            long[] rowSums = new long[array.Length];
            long totalSum = 0;
            long totalCount = 0;

            for (int row = 0; row < array.Length; row++)
            {
                for (int column = 0; column < array[row].Length; column++)
                    rowSums[row] += array[row][column];

                totalSum += rowSums[row];
                totalCount += array[row].Length;
            }

            double average = totalCount == 0 ? 0 : (double)totalSum / totalCount;
            bool[] keepRow = new bool[array.Length];
            int keptCount = 0;

            for (int row = 0; row < array.Length; row++)
            {
                int length = array[row].Length;
                double rowAverage = length == 0 ? 0 : (double)rowSums[row] / length;
                if (rowAverage >= average)
                {
                    keepRow[row] = true;
                    keptCount++;
                }
            }

            answer = new int[keptCount][];
            int index = 0;
            for (int row = 0; row < array.Length; row++)
            {
                if (!keepRow[row])
                    continue;

                answer[index] = new int[array[row].Length];
                Array.Copy(array[row], answer[index], array[row].Length);
                index++;
            }
            // end

            return answer;
        }
    }
}