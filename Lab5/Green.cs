using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int minVal = matrix[i, 0];
                int minIndex = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < minVal)
                    {
                        minVal = matrix[i, j];
                        minIndex = j;
                    }
                }
                answer[i] = minIndex;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {
            // code here
            
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m || k < 0 || k >= m)
            {
                return;
            }

            int maxDiagVal = matrix[0, 0];
            int maxDiagCol = 0;

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > maxDiagVal)
                {
                    maxDiagVal = matrix[i, i];
                    maxDiagCol = i;
                }
            }

            if (k != maxDiagCol)
            {
                for (int i = 0; i < n; i++)
                {
                    int temp = matrix[i, k];
                    matrix[i, k] = matrix[i, maxDiagCol];
                    matrix[i, maxDiagCol] = temp;
                }
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m)
            {
                return;
            }

            int maxDiagVal = matrix[0, 0];
            int maxDiagIndex = 0;

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > maxDiagVal)
                {
                    maxDiagVal = matrix[i, i];
                    maxDiagIndex = i;
                }
            }

            for (int j = 0; j < n; j++)
            {
                int temp = matrix[maxDiagIndex, j];
                matrix[maxDiagIndex, j] = matrix[j, maxDiagIndex];
                matrix[j, maxDiagIndex] = temp;
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;
            // code here
            
            // end
            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] counts = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0) count++;
                }
                counts[i] = count;
            }

            int minRow = 0;
            int maxRow = 0;
            for (int i = 1; i < rows; i++)
            {
                if (counts[i] < counts[minRow]) minRow = i;
                if (counts[i] > counts[maxRow]) maxRow = i;
            }

            bool allEqual = true;
            for (int i = 1; i < rows; i++)
            {
                if (counts[i] != counts[0])
                {
                    allEqual = false;
                    break;
                }
            }

            if (!allEqual && minRow != maxRow)
            {
                for (int j = 0; j < cols; j++)
                {
                    int temp = matrix[minRow, j];
                    matrix[minRow, j] = matrix[maxRow, j];
                    matrix[maxRow, j] = temp;
                }
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (array == null || array.Length != rows)
            {
                answer = new int[rows, cols];
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        answer[i, j] = matrix[i, j];
                return answer;
            }

            int minVal = matrix[0, 0];
            int minCol = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < minVal)
                    {
                        minVal = matrix[i, j];
                        minCol = j;
                    }
                }
            }

            answer = new int[rows, cols + 1];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= cols; j++)
                {
                    if (j <= minCol)
                        answer[i, j] = matrix[i, j];
                    else if (j == minCol + 1)
                        answer[i, j] = array[i];
                    else
                        answer[i, j] = matrix[i, j - 1];
                }
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                int posCount = 0;
                int negCount = 0;
                int maxVal = matrix[0, j];
                int maxRowIndex = 0;

                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > 0) posCount++;
                    if (matrix[i, j] < 0) negCount++;

                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxRowIndex = i;
                    }
                }

                if (posCount > negCount)
                {
                    matrix[maxRowIndex, j] = 0;
                }
                else if (negCount > posCount)
                {
                    matrix[maxRowIndex, j] = maxRowIndex;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            int[,] answer = null;
            // code here
            
            // end
            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows - 1; i++)
                {
                    for (int k = 0; k < rows - 1 - i; k++)
                    {
                        bool swap = false;
                        if (j % 2 == 0)
                        {
                            if (matrix[k, j] < matrix[k + 1, j]) swap = true;
                        }
                        else
                        {
                            if (matrix[k, j] > matrix[k + 1, j]) swap = true;
                        }

                        if (swap)
                        {
                            int temp = matrix[k, j];
                            matrix[k, j] = matrix[k + 1, j];
                            matrix[k + 1, j] = temp;
                        }
                    }
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            
           
            // end

        }
    }
}
