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
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new double[n];

            for (int i = 0; i < n; i++)
            {
                int sum = 0, cnt = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        cnt++;
                    }
                }
                if (cnt == 0)
                    answer[i] = 0.0;
                else
                    answer[i] = (double)sum / cnt;
            }
            // end

            return answer;
        }

        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int r = 0, c = 0;
            int mx = matrix[0, 0];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        r = i;
                        c = j;
                    }
                }
            }

            answer = new int[n - 1, m - 1];
            int ni = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == r) continue;
                int nj = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == c) continue;
                    answer[ni, nj] = matrix[i, j];
                    nj++;
                }
                ni++;
            }
            // end

            return answer;
        }

        public void Task3(int[,] matrix)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                int p = 0;
                for (int j = 1; j < m; j++)
                    if (matrix[i, j] > matrix[i, p])
                        p = j;

                if (p < m - 1)
                {
                    int mx = matrix[i, p];
                    for (int j = p; j < m - 1; j++)
                        matrix[i, j] = matrix[i, j + 1];
                    matrix[i, m - 1] = mx;
                }
            }
            // end
        }

        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            answer = new int[n, m + 1];

            for (int i = 0; i < n; i++)
            {
                int mx = matrix[i, 0];
                for (int j = 1; j < m; j++)
                    if (matrix[i, j] > mx)
                        mx = matrix[i, j];

                for (int j = 0; j < m - 1; j++)
                    answer[i, j] = matrix[i, j];

                answer[i, m - 1] = mx;
                answer[i, m] = matrix[i, m - 1];
            }
            // end

            return answer;
        }

        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int cnt = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if ((i + j) % 2 != 0)
                        cnt++;

            answer = new int[cnt];
            int p = 0;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if ((i + j) % 2 != 0)
                        answer[p++] = matrix[i, j];
            // end

            return answer;
        }

        public void Task6(int[,] matrix, int k)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m || k < 0 || k >= m) return;

            int mr = 0;
            for (int i = 1; i < n; i++)
                if (matrix[i, i] > matrix[mr, mr])
                    mr = i;

            int nr = -1;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] < 0)
                {
                    nr = i;
                    break;
                }
            }

            if (nr == -1 || nr == mr) return;

            for (int j = 0; j < m; j++)
            {
                int t = matrix[mr, j];
                matrix[mr, j] = matrix[nr, j];
                matrix[nr, j] = t;
            }
            // end
        }

        public void Task7(int[,] matrix, int[] array)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (m < 2) return;
            if (array == null || array.Length != m) return;

            int p = m - 2;
            int r = 0;
            int mx = matrix[0, p];

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, p] > mx)
                {
                    mx = matrix[i, p];
                    r = i;
                }
            }

            for (int j = 0; j < m; j++)
                matrix[r, j] = array[j];
            // end
        }

        public void Task8(int[,] matrix)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int j = 0; j < m; j++)
            {
                int r = 0;
                for (int i = 1; i < n; i++)
                    if (matrix[i, j] > matrix[r, j])
                        r = i;

                if (r < n / 2)
                {
                    int sum = 0;
                    for (int i = r + 1; i < n; i++)
                        sum += matrix[i, j];
                    matrix[0, j] = sum;
                }
            }
            // end
        }

        public void Task9(int[,] matrix)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i + 1 < n; i += 2)
            {
                int c1 = 0;
                for (int j = 1; j < m; j++)
                    if (matrix[i, j] > matrix[i, c1])
                        c1 = j;

                int c2 = 0;
                for (int j = 1; j < m; j++)
                    if (matrix[i + 1, j] > matrix[i + 1, c2])
                        c2 = j;

                int t = matrix[i, c1];
                matrix[i, c1] = matrix[i + 1, c2];
                matrix[i + 1, c2] = t;
            }
            // end
        }

        public void Task10(int[,] matrix)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m) return;

            int mr = 0;
            for (int i = 1; i < n; i++)
                if (matrix[i, i] > matrix[mr, mr])
                    mr = i;

            for (int i = 0; i < mr; i++)
                for (int j = i + 1; j < m; j++)
                    matrix[i, j] = 0;
            // end
        }

        public void Task11(int[,] matrix)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] cnt = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > 0) cnt[i]++;
            }

            bool[] used = new bool[n];
            int[] order = new int[n];

            for (int p = 0; p < n; p++)
            {
                int best = -1;
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        if (best == -1 || cnt[i] > cnt[best])
                            best = i;
                    }
                }
                used[best] = true;
                order[p] = best;
            }

            int[,] tmp = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                int src = order[i];
                for (int j = 0; j < m; j++)
                    tmp[i, j] = matrix[src, j];
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = tmp[i, j];
            // end
        }

        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            if (array == null) return new int[0][];

            int n = array.Length;
            double total = 0;
            int cnt = 0;

            for (int i = 0; i < n; i++)
            {
                if (array[i] == null) continue;
                for (int j = 0; j < array[i].Length; j++)
                {
                    total += array[i][j];
                    cnt++;
                }
            }

            double avgAll;
            if (cnt == 0)
                avgAll = 0.0;
            else
                avgAll = total / cnt;

            double[] avg = new double[n];

            for (int i = 0; i < n; i++)
            {
                if (array[i] == null || array[i].Length == 0)
                {
                    avg[i] = 0.0;
                    continue;
                }

                double sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                    sum += array[i][j];
                avg[i] = sum / array[i].Length;
            }

            int keep = 0;
            for (int i = 0; i < n; i++)
                if (avg[i] >= avgAll) keep++;

            answer = new int[keep][];
            int p = 0;

            for (int i = 0; i < n; i++)
            {
                if (avg[i] >= avgAll)
                {
                    int len;
                    if (array[i] == null)
                        len = 0;
                    else
                        len = array[i].Length;

                    answer[p] = new int[len];

                    if (array[i] != null)
                    {
                        for (int j = 0; j < len; j++)
                            answer[p][j] = array[i][j];
                    }
                    p++;
                }
            }
            // end

            return answer;
        }
    }
}
