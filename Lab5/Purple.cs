using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {


            int[] answer = new int[matrix.GetLength(1)];
            int c = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {

                    if (matrix[j, i] < 0)
                    {
                        count++;

                    }

                }

                answer[c] = count;
                c++;
            }

            return answer;
        }

        public void Task2(int[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = int.MaxValue;
                int minIndex = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minIndex = j;
                    }
                }


                for (int j = minIndex; j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }

                matrix[i, 0] = min;
            }

        }

        public int[,] Task3(int[,] matrix)
        {


            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = Int32.MinValue;
                int maxIndex = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIndex = j;
                    }
                }

                for (int j = matrix.GetLength(1) - 1; j >= maxIndex; j--)
                {
                    answer[i, j + 1] = matrix[i, j];

                }

                for (int j = 0; j <= maxIndex; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
            }

            return answer;
        }

        public void Task4(int[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = Int32.MinValue;
                int maxIndex = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIndex = j;
                    }
                }

                int S = 0;
                int cnt = 0;
                for (int j = maxIndex + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        S += matrix[i, j];
                        cnt++;
                    }
                }

                int elem = 0;
                if (cnt > 0)
                {
                    elem = S / cnt;
                }
                else
                {
                    continue;
                }

                for (int j = 0; j < maxIndex; j++)
                {
                    if (matrix[i, j] < 0 & elem > 0)
                    {
                        matrix[i, j] = elem;
                    }
                }
            }


        }

        public void Task5(int[,] matrix, int k)
        {
            if (k >= 0 & k < matrix.GetLength(1))
            {
                int[] array = new int[matrix.GetLength(0)];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int max = Int32.MinValue;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > max)
                        {
                            max = matrix[i, j];
                        }
                    }

                    array[i] = max;
                }

                int l = matrix.GetLength(0) - 1;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, k] = array[l];
                    l--;
                }
            }

        }

        public void Task6(int[,] matrix, int[] array)
        {


            if (array.Length == matrix.GetLength(1))
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    int max = Int32.MinValue;
                    int maxIndex = -1;
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if (matrix[j, i] > max)
                        {
                            max = matrix[j, i];
                            maxIndex = j;
                        }
                    }

                    if (max < array[i])
                    {
                        matrix[maxIndex, i] = array[i];
                    }
                }
            }


        }

        public void Task7(int[,] matrix)
        {

            int[] mins = new int[matrix.GetLength(0)];
            int[][] jagged = new int[matrix.GetLength(0)][];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                jagged[i] = new int[matrix.GetLength(1)];
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = int.MaxValue;
                int minIndex = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                        min = matrix[i, j];
                }

                mins[i] = min;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    jagged[i][j] = matrix[i, j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; j < matrix.GetLength(0) - i - 1; j++)
                    if (mins[j] < mins[j + 1])
                    {
                        (jagged[j], jagged[j + 1]) = (jagged[j + 1], jagged[j]);
                        (mins[j], mins[j + 1]) = (mins[j + 1], mins[j]);
                    }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = jagged[i][j];
                }

            }

        }

        public int[] Task8(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return null;
            int n = matrix.GetLength(0);
            int[] answer = new int[2 * n - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    answer[j - i + n - 1] += matrix[i, j];
                }
            }

            return answer;
        }

        public void Task9(int[,] matrix, int k)
        {
            int a=matrix.GetLength(0), b=matrix.GetLength(1);
            if (a != b)
            {
                return;
            }

            if (k >= a || k<0)
            {
                return;
            }
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);


            int r = 0, c = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(matrix[r, c]))
                    {
                        r = i;
                        c = j;
                    }
                }
            }
            
            while (r != k)
            {
                int step = r > k ? -1 : 1;
                for (int j = 0; j < cols; j++) 
                {
                    int temp = matrix[r, j];
                    matrix[r, j] = matrix[r + step, j];
                    matrix[r + step, j] = temp;
                }

                r += step;
            }

            while (c != k)
            {
                int step = c > k ? -1 : 1;
                for (int i = 0; i < rows; i++) 
                {
                    int temp = matrix[i, c];
                    matrix[i, c] = matrix[i, c + step];
                    matrix[i, c + step] = temp;
                }

                c += step;
            }
            

        }



public int[,] Task10(int[,] A, int[,] B)
        {
            int m = A.GetLength(0);
            int n = A.GetLength(1);
            int p = B.GetLength(1);

            if (n != B.GetLength(0))
                return null;            

            int[,] answer = new int[m, p];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    for (int t = 0; t < n; t++)
                    {
                        answer[i, j] += A[i, t] * B[t, j];
                    }
                }
            }

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[][] answer = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                        count++;
                }

                answer[i] = new int[count];   

                int index = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][index] = matrix[i, j];
                        index++;
                    }
                }
            }

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int total = 0;
            for (int i = 0; i < array.Length; i++)
            {
                total += array[i].Length;
            }

            int n = 0;
            while (n * n < total)
            {
                n++;
            }

            int[,] answer = new int[n, n];
            
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[k / n, k % n] = array[i][j];
                    k++;
                }
            }

            return answer;
        }
    }
}
