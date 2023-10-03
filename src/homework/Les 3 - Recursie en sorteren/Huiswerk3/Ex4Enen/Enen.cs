using System;

namespace AD
{
    public class Opgave4
    {
        public static int Enen(int n)
        {
            
            int bits = 0;
            int maxBit = 31;
            
            // Handle negative numbers
            if (n < 0)
            {
                bits++; // The sign bit is set for negative numbers
                n = -n; // Work with the absolute value
            }
            
            // Early return for base case 0
            // if (n == 0) return bits;

            // Early return for base cases 1 and 0
            if (n <= 1) return bits + n;
            
            for(int bit = maxBit; bit >= 0; bit--)
            {
                // Math.Pow(2,0) == 1, so it will also catch the least significant bit (LSB)
                int bitValue = (int) Math.Pow(2, bit);

                if (n >= bitValue)
                {
                    bits++;
                    n = (n - bitValue);
                }

                if (n == 0) break;
            };
            return bits;
        }

        public static void Run()
        {
            for (int i = 0; i < 20; i++)
            {
                System.Console.WriteLine("Enen({0,4}) = {1,2}", i, Enen(i));
            }
            System.Console.WriteLine("Enen(1024) = {0,2}", Enen(1024));
            System.Console.WriteLine();
        }
    }
}
