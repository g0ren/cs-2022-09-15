using System;
using System.Diagnostics;

// Старый алгоритм
/* 
public class Solution
{
    public int CountNegatives(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int ret = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] < 0)
                {
                    ret += (rows - i) * (cols - j);
                    cols = j;
                    break;
                }
            }
        }
        return ret;
    }
}
*/

// Ночью во сне придумал новый алгоритм
public class Solution
{
    public int CountNegatives(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int ret = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = cols - 1; j >= 0; j--)
            {
                if (j == 0 && grid[i][j] < 0)
                {
                    ret += rows - i;
                    cols = 0;
                    break;
                }
                if (grid[i][j] >= 0)
                {
                    cols = j + 1;
                    break;
                }
                ret += rows - i;
            }
        }
        return ret;
    }
}

class Program
{
    private static int CompareSortedArray(int[] x, int[] y)
    {
        int xi = 0;
        int yi = 0;
        for (; xi < x.Length; xi++)
        {
            if (x[xi] < 0) break;
        }
        for (; yi < y.Length; yi++)
        {
            if (y[yi] < 0) break;
        }
        return yi - xi;
    }

    private static int[][] GenerateSortedMatrix(int n, int m)
    {
        int[][] ret = new int[n][];
        Random rnd = new Random();
        for (int i = 0; i < n; i++)
        {
            ret[i] = new int[n];
            for (int j = 0; j < m; j++)
            {
                ret[i][j] = rnd.Next(-1000, 1001);
            }
            Array.Sort(ret[i]);
            Array.Reverse(ret[i]);
        }
        Array.Sort(ret, CompareSortedArray);
        return ret;
    }
    private static void PrintMatrix(int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                Console.Write("{0} ", matrix[i][j]);
            }
            Console.WriteLine();
        }
    }

    private static void TestForNxN(int n)
    {
        Solution s = new Solution();

        Stopwatch sw = new Stopwatch();
        int[][] matrix = GenerateSortedMatrix(n, n);
        //PrintMatrix(matrix10);
        sw.Start();
        int ans = s.CountNegatives(matrix);
        sw.Stop();
        Console.Write("{0} × {0}: {1} negs, {2}\n", n, ans, sw.Elapsed);
    }


    public static void Main(string[] args)
    {
        /*
          int[][] grid = new int[][] { new int[] { 4, 3, 2, -1 }, new int[] { 3, 2, 1, -1 }, new int[] { 1, 1, -1, -2 }, new int[] { -1, -1, -2, -3 } };
          Solution s = new Solution();
          Console.WriteLine("{0}", s.CountNegatives(grid));
  */
        TestForNxN(10); // Первый тест игнорируем, потому что он выдаёт какое-то артефактное значение
        TestForNxN(10);
        TestForNxN(33);
        TestForNxN(100);
        TestForNxN(333);
        TestForNxN(1000);
        TestForNxN(3333);
        TestForNxN(10000);
    }
}