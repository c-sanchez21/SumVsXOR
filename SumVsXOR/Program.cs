using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumVsXOR
{
    class Program
    {
        //Problem : https://www.hackerrank.com/challenges/sum-vs-xor/problem?h_r=internal-search
        //find how many times 
        //the condition n+x = n^x is satisfied 
        //for any given n and 0 <= x <= n            
        static void Main(string[] args)
        {
            //Get specified value for n or assign default value of 10k;
            ulong n = (args != null && args.Length > 0) ?
                Convert.ToUInt64(args[0]) : 1099511627776;

            //Commented out since this can take a long time for large values of n            
            //Console.WriteLine(Solution1(n));

            Console.WriteLine(Solution2(n));                                
            Console.ReadKey();
        }

        //O(n)
        static int Solution1(ulong n)
        {
            //Traverse all numbers from 0 to n 
            //and check if the condition is satisfied
            int count = 0;
            for (ulong x = 0; x <= n; x++)
                if (x + n == (x ^ n))
                    count++;
            return count;
        }

        //O(log n)
        static int Solution2(ulong n)
        {
            //Count the number of zeros
            int zeroCount = CountBinaryZeros(n);

            //Shift 1 by the number of zeros to get our result
            return 1 << zeroCount;
        }

        /// <summary>
        /// Counts the number of unset bits
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int CountBinaryZeros(ulong n)
        {
            int count = 0;
            while(n > 0)
            {
                if ((n & 1) == 0)
                    count++;
                n >>= 1;
            }
            return count;
        }
    }
}
