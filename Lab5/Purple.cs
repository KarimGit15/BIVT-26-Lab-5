using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            
            
            // code here
            int count = 0;
            
            int[] answer = new int[matrix.GetLength(1)];
            
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                count = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        count++;
                        
                    }
                }

                
                {
                    answer[i] = count;
                }
                
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int a=matrix.GetLength(0),b=matrix.GetLength(1);
            int[,] matrix2 = new int[a,b];
            int minvalue = 0,minindexJ= 0, k=0 ;
            for (int i = 0; i < a; i++)
            {
                minvalue = 1000000;
                for (int j = 0; j < b; j++)
                {
                    if (matrix[i, j] < minvalue)
                    {
                        minvalue=matrix[i, j];
                        minindexJ = j;
                    }
                }

                matrix2[i, 0] = matrix[i, minindexJ];
                k = 0;
                for (int j = 0; j < b; j++)
                {
                    if (j != minindexJ)
                    {
                        k++;
                        matrix2[i,k]=matrix[i, j];
                        

                    }
                    
                }
            }
            
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    matrix[i, j] = matrix2[i, j];
                }
            }
            

            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            // code here
            int a = matrix.GetLength(0), b = matrix.GetLength(1)+1;
            int[,] matrix2 = new int[a,b];
            int maxvalue = -10000, maxindex=0,k=0;
            for (int i = 0; i < a; i++)
            {
                maxvalue = -10000;
                for (int j = 0; j < b-1; j++)
                {
                    if (matrix[i, j] > maxvalue)
                    {
                        maxvalue = matrix[i, j];
                        maxindex = j;
                    }
                }

                k = 0;
                for (int j = 0; j < b-1; j++)
                {
                    matrix2[i, k] = matrix[i, j];
                    k++;
                    if (j == maxindex)
                    {
                        matrix2[i, k] = maxvalue;
                        k++;
                    }
                }
            }
                   
            

            
            
            // end

            return matrix2;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            
            int a = matrix.GetLength(0), b = matrix.GetLength(1);
            
            int maxindex = 0, maxvalue = 0, sred,count;
            
            for (int i = 0; i < a; i++)
            {   maxvalue = -1000000;
                
                for (int j = 0; j < b; j++)
                {
                    if (matrix[i, j] > maxvalue)
                    {
                        maxvalue = matrix[i, j];
                        maxindex = j;
                    }
                }

                sred = 0;
                count = 0;
                for (int j = maxindex + 1; j < b; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sred += matrix[i, j];
                        count++;
                        
                        
                    }
                }
                if (count != 0)
                {
                    sred = sred / count;
                }

                if (count != 0)
                {
                    
                
                    for (int j = 0; j < maxindex; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = sred;
                        }
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            if (k < 0 || k >= matrix.GetLength(1))
            {
                return;
            }
            int a = matrix.GetLength(0), b = matrix.GetLength(1);
            int[] matrix2 = new int[a];
            int maxvalue,count=0;
            for (int i = a - 1; i >= 0; i--)
            {
                maxvalue = -10000000;
               
                for (int j = b - 1; j >= 0; j--)
                {
                    if (matrix[i, j] > maxvalue)
                    {
                        maxvalue = matrix[i, j];
                    }
                }
                matrix2[count] = maxvalue;
                count++;
            }

            for (int i = 0; i < a; i++)
            {
                matrix[i, k] = matrix2[i];
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            
            int maxvalue,maxindex;
            int a=matrix.GetLength(0), b=matrix.GetLength(1);



            if (array.Length == b)
            {


                for (int i = 0; i < b; i++)
                {
                    maxvalue = matrix[0, i];
                    maxindex = 0;
                    for (int j = 0; j < a; j++)
                    {
                        if (matrix[j, i] > maxvalue)
                        {
                            maxvalue = matrix[j, i];
                            maxindex = j;
                        }
                    }

                    if (array[i] > maxvalue)
                    {
                        matrix[maxindex, i] = array[i];

                    }


                }
            }
            // end
            
            
            

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int a = matrix.GetLength(0), b = matrix.GetLength(1);
            int minvalue;
            int[,] mins= new int[a, 2];
            for (int i = 0; i < a; i++)
            {
                minvalue = 10000000;
                for (int j = 0; j <b; j++)
                {
                    if (matrix[i, j] < minvalue)
                    {
                        minvalue = matrix[i, j];
                    }
                }
                mins[i,0]=minvalue;
                mins[i, 1] = i;
            }
            int p=mins.GetLength(0),l=mins.GetLength(1);

            for (int i = 0; i < p - 1; i++)
            {
                for (int j = 0; j < p - 1 - i; j++)
                {
                    if (mins[j, 0] < mins[j + 1, 0])
                    {
                        int temp = mins[j, 0];
                        int temp1 = mins[j, 1];
                        mins[j, 0] = mins[j + 1, 0];
                        mins[j, 1] = mins[j + 1, 1];
                        mins[j+1, 0] = temp;
                        mins[j+1, 1] = temp1;
                        
                    }
                }
            }

            int[,] matrix2 = new int[a, b];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    matrix2[i, j] = matrix[i, j];
                }
            }

            for (int i = 0; i < mins.GetLength(0); i++)
            {
                for (int j = 0; j < b; j++)
                {
                    int k = mins[i, 1];
                    matrix[i, j] = matrix2[k, j];
                }
                
            }


            // end

        }
        public int[] Task8(int[,] matrix)
        {
            // code here
            
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return null;
            }
            
            int n = matrix.GetLength(0);
            
            if (n == 0)
            {
                return new int[0];
            }
            
            int[] answer =new int[2*n-1];
            


            for (int i = n - 1; i >= 0; i--)
            {
                int sum = 0;
                for (int j = 0; j + i < n; j++)
                {
                    sum += matrix[i + j, j];
                }

                answer[n-i-1] = sum;
            }
            
            for (int i = n - 1; i > 0; i--)
            {
                int sum = 0;
                for (int j = 0; j + i < n; j++)
                {
                    sum += matrix[j,i+j];
                }

                answer[n+i-1] = sum;
            }
            // {00 01 02}
            // {10 11 12}
            // {20 21 22}
            //
            // {0,1,2,3,4}
            

            
            
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int a=matrix.GetLength(0), b=matrix.GetLength(1);
            if (a != b)
            {
                return;
            }

            if (k >= a || k<0)
            {
                return;
            }

            int maxvalue = -1,maxindexi=0,maxindexj=0;
            
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (Math.Abs(matrix[i, j]) > maxvalue)
                    {
                        maxvalue=Math.Abs(matrix[i, j]);
                        maxindexi = i;
                        maxindexj = j;
                    }
                }
            }
            int[,] matrix2 = new int[a, a];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    matrix2[i,j]=matrix[i,j];
                }
            }

            while (k != maxindexi)
            {
                for (int j = 0; j < b; j++)
                {
                    
                    if (k < maxindexi)
                        
                    {
                        int temp = matrix[maxindexi - 1, j];
                        matrix[maxindexi - 1, j] = matrix[maxindexi, j];
                        matrix[maxindexi, j] = temp;
                        
                        
                    }
                    else
                    {
                        int temp = matrix[maxindexi + 1, j];
                        matrix[maxindexi + 1, j] = matrix[maxindexi, j];
                        matrix[maxindexi, j] = temp;
                        
                        
                    }
                    
                    
                }

                if (k < maxindexi)
                {
                    maxindexi -= 1;
                }
                else
                {
                    maxindexi += 1;
                }
            }
            
            while (k != maxindexj)
            {
                for (int i = 0; i < a; i++)
                {
                    
                    if (k < maxindexj)
                        
                    {
                        int temp = matrix[i,maxindexj - 1];
                        matrix[i,maxindexj - 1] = matrix[i,maxindexj];
                        matrix[i,maxindexj] = temp;
                        
                        
                    }
                    else
                    {
                        int temp = matrix[i,maxindexj + 1];
                        matrix[i,maxindexj + 1] = matrix[i,maxindexj];
                        matrix[i,maxindexj] = temp;
                        
                        
                    }
                    
                    
                }

                if (k < maxindexj)
                {
                    maxindexj -= 1;
                }
                else
                {
                    maxindexj += 1;
                }
            }
            
            
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            
            // code here
            
            int a0 = A.GetLength(0),
                a1=A.GetLength(1), 
                b0=B.GetLength(0),
                b1=B.GetLength(1);
                ;
            
            if (a1 != b0)
            {
                return null;
            }
            int GetElement(int i, int j)
            {
                int sum = 0;

                for (int k = 0; k < a1; k++)
                {
                    sum += A[i, k] * B[k, j];
                }

                return sum;
            }
            
            int[,] matrix = new int[a0, b1];

            for (int i = 0; i < a0; i++)
            {
                for (int j = 0; j < b1; j++)
                {
                    matrix[i, j] = GetElement(i, j);
                }
            }
            
            
            
            
            // end

            return matrix;
        }
        public int[][] Task11(int[,] matrix)
        {
            

            // code here
            int a=matrix.GetLength(0), b=matrix.GetLength(1);
            int[][] answer = new int[a][];
            int count,k;
            for (int i = 0; i < a; i++)
            {
                k = 0;
                count = 0;
                for (int j = 0; j < b; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                }

                answer[i] = new int[count];
                for (int j = 0; j < b; j++)
                {
                    
                    if (matrix[i, j] > 0)
                    {
                        answer[i][k] =matrix[i, j];
                        k++;
                    }
                }

            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            

            // code here
            int count=0;
            for (int i=0;i<array.GetLength(0);i++)
            {
                
                for (int j = 0; j < array[i].Length; j++)
                {
                    count++;
                }

                
            }

            double n = Math.Sqrt(count);
            if (n != Math.Floor(n))
            {
                n=Math.Ceiling(n);
            }

            int a = Convert.ToInt32(n);
            int[,] answer = new int[a,a];

            
            int[] g=new int[count];
            int k = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    g[k]=array[i][j];
                    k++;
                }
            }

            int el = 0;
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    if (el <= count - 1)
                    {
                        answer[i, j] = g[el];
                        el++;
                    }
                    
                }
            }
            
            
            // end
            

            return answer;
        }
    }
}