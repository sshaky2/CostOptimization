using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSum
{
    class Program
    {
        //private static int totalNodes;

        //static void PrintSubset(int[] A, int size)
        //{
        //    for (int i = 0; i < size; i++)
        //    {
        //        Console.Write(A[i] + " ");
        //    }

        //    Console.WriteLine();
        //}

        //static void SubsetSum(List<int> s, int[] t,
        //        int s_size, int t_size,
        //        int sum, int ite,
        //        int target_sum)
        //{
        //    totalNodes++;
        //    if (target_sum ==  sum)
        //    {
        //        PrintSubset(t, t_size);
        //        // Exclude previously added item and consider next candidate
        //        if (ite + 1 < s_size && sum - s[ite] + s[ite + 1] <= target_sum)
        //        {
        //            SubsetSum(s, t, s_size, t_size - 1, sum - s[ite], ite + 1, target_sum);
        //        }
        //        return;
        //    }
        //    else
        //    {
        //        // generate nodes along the breadth
        //        if (ite < s_size && sum + s[ite] <= target_sum)
        //        {
        //            for (int i = ite; i < s_size; i++)
        //            {
        //                t[t_size] = s[i];
        //                // consider next level node (along depth)
        //                SubsetSum(s, t, s_size, t_size + 1, sum + s[i], i + 1, target_sum);
        //            }
        //        }
        //    }
        //}

        //static void generateSubsets(List<int> s, int size, int target_sum)
        //{
        //    //List<int> tuplet_vector = Enumerable.Repeat(0, size).ToList();
        //    int[] tuplet_vector = new int[size];
        //    int total = 0;
        //    s.Sort();
        //    for (int i = 0; i < size; i++)
        //    {
        //        total += s[i];
        //    }

        //    if (s[0] <= target_sum && total >= target_sum)
        //    {
        //        SubsetSum(s, tuplet_vector, size, 0, 0, 0, target_sum);
        //    }


        //}

        private static List<double> w = new List<double> ();
        //private static List<double> w = new List<double> { 1,4,5};
        private static int n = 137;
        static int[] x = new int[137];
        private static double m = 10;
        private static bool found = false;
        private static List<double> subset = new List<double>();
        private static int itr = 0;
        public static void SumOfSubset(double a, int k)
        {
            if (k > n) return;
            x[k] = 1;
            int count = 0;
            itr++;
            Console.WriteLine("iteration: " + itr);
            Console.WriteLine(k + " , " + a);
            for (int i = 0; i <= k; i++)
            {
                if (x[i] == 1)
                {
                    count++;
                    //Console.Write(x[i] + " ");
                }
                    
            }
           // Console.WriteLine();
            if (Math.Abs(((a * (count - 1)) + w[k]) / count - m) <= 0.01)
            {
                for (int i = 0; i <= k; i++)
                {
                    if (x[i] == 1)
                    {
                        subset.Add(w[i]);
                        //Console.Write(w[i] + ",");
                    }
                }
                //Console.WriteLine();
                found = true;
            }

            if (!found)
            {
                if ((k + 1) <= n && ((a * (count - 1)) + w[k] + w[k + 1]) / (count + 1) <= m)
                {
                    SumOfSubset(((a * (count - 1)) + w[k]) / count, k + 1);
                }
                if ((k + 1) <= n && ((a * (count - 1)) + w[k + 1]) / count <= m)
                {
                    x[k] = 0;
                    SumOfSubset(a, k + 1);
                }
            }

        }

       

        static void Main(string[] args)
        {
            //List<int> weights = new List<int>{ 10, 7, 5, 18, 12, 20, 15};
            //generateSubsets(weights, 7, 15);
            //Console.WriteLine("total nodes: " + totalNodes);

            #region backtracking approach

            //w.Clear();
            //string path = @"C:\Users\sshakya\Documents\Visual Studio 2015\Projects\SubsetSum\Data\data1.txt";
            //string[] lines = File.ReadAllLines(path);
            //foreach (var val in lines)
            //{
            //    //Console.WriteLine(val);
            //    w.Add(Convert.ToDouble(val));
            //}

            ////Random rand = new Random();
            ////w.Clear();
            ////for (var i = 1; i < n; i++)
            ////{
            ////    w.Add(rand.Next(1, 20));
            ////}
            //w.Sort();

            ////List<double> average = new List<double> {3,25,50,100,250,1024,5120,10240,20480, 30720 };//{2.5};//
            //List<double> average = new List<double> {5120};//{2.5};//
            //int lastCount = w.Count;
            //foreach (var avg in average)
            //{
            //    do
            //    {

            //        lastCount = w.Count;
            //        Console.WriteLine("For average: " + avg + " Count: " + w.Count);
            //        m = avg;
            //        n = w.Count - 1;
            //        SumOfSubset(0, 0);
            //        found = false;
            //        Console.WriteLine("count of subset:" + subset.Count);
            //        foreach (var number in subset)
            //        {
            //            Console.Write(number + ",");
            //            var item = w.FirstOrDefault(x => x == number);
            //            w.Remove(item);

            //        }
            //        w.Sort();
            //        Console.WriteLine();
            //        subset.Clear();
            //        for (int i = 0; i < x.Length; i++)
            //        {
            //            x[i] = 0;
            //        }
            //    } while (lastCount != w.Count);
            //}

            //Console.WriteLine("Remaining numbers : Count: " + w.Count);
            //foreach (var num in w)
            //{
            //    Console.WriteLine(num + " , ");
            //}

            #endregion


            #region dynamic programming approach with 3d array

            //List<int> arr = new List<int>();
            //string path = @"C:\Users\sshakya\Documents\Visual Studio 2015\Projects\SubsetSum\Data\data1.txt";
            //string[] lines = File.ReadAllLines(path);
            //foreach (var val in lines)
            //{
            //    //Console.WriteLine(val);
            //    arr.Add((int)(Math.Round(Convert.ToDouble(val) * 100, MidpointRounding.AwayFromZero)));
            //}

            ////List<int> arr = new List<int> {1,2,3,4,5,6,9,10,13,17,21,24,25,26,26,26,26,26,31,40};
            //List<double> average = new List<double> { 512000 };//{2.5};//
            //int previousCount = arr.Count;
            //foreach (var avg in average)
            //{
            //    Console.WriteLine("For average: " + avg + " : ");
            //    do
            //    {
            //        previousCount = arr.Count;
            //        for (int i = 1; i <= arr.Count; ++i)
            //        {
            //            double sum = i* avg;
            //            if (sum == (int) sum)
            //            {
            //                List<int> result = isSumPossible(arr, (int) sum, i);
            //                if (result != null)
            //                {
            //                    foreach (var number in result)
            //                    {
            //                        Console.Write(number + " , ");
            //                        var item = arr.FirstOrDefault(x => x == number);
            //                        arr.Remove(item);

            //                    }
            //                    Console.WriteLine();
            //                    break;
            //                }
            //            }
            //        }
            //    } while (previousCount != arr.Count);
            //}
            //Console.WriteLine("Remining numbers :");
            //foreach (var num in arr)
            //{
            //    Console.WriteLine(num + " , ");
            //}
            #endregion

            #region dp approach w 2d array
            int[] arr1 = { 2, 3, 7, 8, 10 };
            int breakpoint = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] > 5)
                {
                    breakpoint = i - 1;
                }

            }
            Console.WriteLine(DPSubsetSum(arr1, 5, breakpoint));
            #endregion


        }


        private static List<int> isSumPossible(List<int> arr, int sum, int count)
        {
            bool[,,] memo = new bool[arr.Count + 1, sum + 1 , count + 1];
            memo[0, 0, 0] = true;

            for (int m = 1; m <= arr.Count; ++m)
                for (int n = 1; n <= sum; ++n)
                    for (int o = 1; o <= count; ++o)
                    {
                        if (o == 1 && n == arr[m - 1])
                            memo[m, n, o] = true;
                        else if (arr[m - 1] > n)
                            memo[m, n, o] = memo[m - 1, n, o];
                        else
                            memo[m, n, o] = memo[m - 1, n, o]
                              || memo[m - 1,n - arr[m - 1],o - 1];
                    }
            if (memo[arr.Count, sum, count] == false)
                return null;
            int i = arr.Count;
            int j = sum;
            int k = count;
            List<int> list = new List<int>();
            while (i > 0 && j > 0 && k > 0)
            {
                if (memo[i, j, k] == memo[i - 1, j, k])
                {

                }
                else if (k == 1 && j == arr[i - 1])
                {
                    list.Add(arr[i - 1]);
                    break;
                }
                else if (arr[i - 1] <= j
                && memo[i, j, k] == memo[i - 1, j - arr[i - 1], k - 1])
                {
                    j = j - arr[i - 1];
                    k = k - 1;
                    list.Add(arr[i - 1]);
                }
                i--;
            }
            return list;
        }

        public static bool DPSubsetSum(int[] input, int total, int breakPoint)
        {
            bool[,] T = new bool[input.Length + 1, total + 1];
            for (int i = 0; i <= input.Length; i++)
            {
                T[i, 0] = true;
            }

            for (int i = 1; i <= input.Length; i++)
            {
                for (int j = 1; j <= total; j++)
                {
                    if (j - input[i - 1] >= 0)
                    {
                        T[i, j] = T[i - 1, j] || T[i - 1, j - input[i - 1]];
                    }
                    else
                    {
                        T[i, j] = T[i - 1, j];
                    }
                }
            }
            List<int> result = new List<int>();
            int x = breakPoint;
            int y = total;

            while (x > 0 && y > 0)
            {
                if (T[x, y] && T[x - 1, y])
                {
                    result.Add(input[x-2]);
                    x--;
                }
                else
                {
                   
                    y = y - input[x - 1];
                    x--;
                }
            }

          
            

            return T[input.Length, total];
        }
    }
}
