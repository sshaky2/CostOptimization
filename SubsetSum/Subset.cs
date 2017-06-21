using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSum
{
    class Subset
    {
        private List<double> w = new List<double> {1,2,3,4,5,6,9,10,13,17,21,24,25,26,26,26,26,26,31,40};
        int[] x = new int[20];
        private double m = 20;
        private int size = 19;
        private bool found = false;

        public Subset()
        {
            
        }

        //note: when dividing by k (count of item in set), we are using k + 1 because k index start from zero.
        //public void SumOfSubset(double s, int k, double r)
        //{
        //    x[k] = 1;
        //    if (((s*k) + w[k])/(k+1) ==  m)
        //    {
        //        for (int i = 0; i <= k; i++)
        //        {
        //            if (x[i] == 1)
        //            {
        //                Console.Write(w[i] + ",");
        //            }
        //        }
        //        Console.WriteLine();
        //        return;
        //    }
        //    else if(((s * k) + w[k] + w[k+1])/(k+1+1) <= m)
        //    {
        //        SumOfSubset(((s * k) + w[k])/(k+1), k+1, ((r * (w.Count - k)) - w[k])/(w.Count - k - 1));
        //    }

        //    if (((s + (((r * (w.Count - k)) - w[k]) / (w.Count - k - 1))) >= m) && (((k + 1) * s + w[k + 1])/(k+1+1) <= m))
        //    {
        //        x[k] = 0;
        //        SumOfSubset(s,k+1, ((r * (w.Count - k)) - w[k]) / (w.Count - k - 1));
        //    }

        //}


        //public void SumOfSubset(double s, int k)//, double r)
        //{
        //    if (k > 4) return;
        //    x[k] = 1;

        //    if ((s + w[k]) == m)
        //    {
        //        for (int i = 0; i <= k; i++)
        //        {
        //            if (x[i] == 1)
        //            {
        //                Console.Write(w[i] + ",");
        //            }
        //        }
        //        Console.WriteLine();

        //    }
        //     if ((k + 1) <= 4 && (s + w[k] + w[k + 1]) <= m)
        //    //if(!found)
        //     {

        //         SumOfSubset((s + w[k]), k + 1); //;, r - w[k]);
        //     }

        //     if((k + 1) <= 4 && (s + w[k+1]) <= m)
        //    //if ((s + r - w[k]) >= m && (s + w[k]) <= m)
        //    {
        //        x[k] = 0;
        //        SumOfSubset(s, k + 1);//, r - w[k]);
        //    }


        //}

        public void SumOfSubset(double a, int k)
        {
            if (k > size) return;
            x[k] = 1;
            int count = 0;
            for (int i = 0; i <= k; i++)
            {
                if (x[i] == 1)
                    count++;
            }
            if (((a * (count - 1)) + w[k]) / count == m)
            {
                for (int i = 0; i <= k; i++)
                {
                    if (x[i] == 1)
                    {
                        Console.Write(w[i] + ",");
                    }
                }
                Console.WriteLine();
                found = true;
            }

            if(!found)
            {
                if ((k + 1) <= size && ((a * (count - 1)) + w[k] + w[k + 1]) / (count + 1) <= m)
                {
                    SumOfSubset(((a * (count - 1)) + w[k]) / count, k + 1);
                }
                if ((k + 1) <= size && ((a * (count - 1)) + w[k + 1]) / count <= m)
                {
                    x[k] = 0;
                    SumOfSubset(a, k + 1);
                }
            }

        }
    }
}
