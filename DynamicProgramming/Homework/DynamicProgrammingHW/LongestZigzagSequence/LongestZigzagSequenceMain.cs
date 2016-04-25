namespace LongestZigzagSequence
{
    using System;
    using System.Linq;

    public class LongestZigzagSequenceMain
    {
        static void Main(string[] args)
        {
            //var sequence = new[] { 8, 3, 5, 7, 0, 8, 9, 10, 20, 20, 20, 12, 19, 11 };
            //var sequence = new[] { 1,2,3 };
            //var sequence = new[] { 1, 3, 2 };
            var sequence = new[] { 24, 5, 31, 3, 3, 342, 51, 114, 52, 55, 56, 58 };
            var longestSeq = FindLongestZigzagSubsequence(sequence);
            Console.WriteLine("  Sequence: [{0}]", string.Join(", ", longestSeq));
        }

        public static int[] FindLongestZigzagSubsequence(int[] sequence)
        {
            int[,] len = new int[sequence.Length, 2];
            int[] prev = new int[sequence.Length];

            int maxLength = 0;
            int maxIndex = -1;
            bool increased = false;
            for (int i = 0; i < sequence.Length; i++)
            {
                len[i, 0] = len[i, 1] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (sequence[i] - sequence[j] > 0)
                    {
                        len[i, 0] = Math.Max(len[j, 1] + 1, len[i, 0]);
                    }
                    else if (sequence[i] - sequence[j] < 0)
                    {
                        len[i, 1] = Math.Max(len[j, 0] + 1, len[i, 1]);
                    }
                }
                
                if (maxLength < len[i, 0])
                {
                    maxLength = len[i, 0];
                    maxIndex = i;
                    increased = false;
                }

                if (maxLength < len[i, 1])
                {
                    maxLength = len[i, 1];
                    maxIndex = i;
                    increased = true;
                }
            }

            int[] result = new int[maxLength];
            int currentLen = maxLength;

            for (int i = maxIndex; i >= 0; i--)
            {
                if((len[i, 0] == maxLength && len[i, 0] >= len[i, 1] && !increased) || (len[i, 1] == maxLength &&  len[i, 0] <= len[i, 1] && increased))
                {
                    result[maxLength - 1] = sequence[i];
                    maxLength--;
                    increased = !increased;
                }
            }

            result.Reverse();
            return result;
        }
    }
}
