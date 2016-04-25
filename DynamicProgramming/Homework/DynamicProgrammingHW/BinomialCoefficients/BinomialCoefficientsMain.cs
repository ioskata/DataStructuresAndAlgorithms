namespace BinomialCoefficients
{
    using System;

    public class BinomialCoefficientsMain
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int binCoeff = GetBinomialCoefficient(n, k);
            Console.WriteLine(binCoeff);
        }

        private static int GetBinomialCoefficient(int n, int k)
        {
            if (k == 0)
            {
                return 1;
            }

            int nLength = (n + k - 1) / 2;
            var firstRow = new int[nLength];
            var secondRow = new int[nLength];

            firstRow[0] = 1;
            secondRow[0] = 1;
            secondRow[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    for (int c = 1; c < nLength; c++)
                    {
                        firstRow[c] = secondRow[c - 1] + secondRow[c];
                    }
                }
                else
                {
                    for (int c = 1; c < nLength; c++)
                    {
                        secondRow[c] = firstRow[c - 1] + firstRow[c];
                    }
                }
            }

            if (k >= nLength)
            {
                k = n - k ;
            }

            if (n % 2 == 0)
            {
                return firstRow[k];
            }
            else
            {
                return secondRow[k];
            }
        }
    }
}
