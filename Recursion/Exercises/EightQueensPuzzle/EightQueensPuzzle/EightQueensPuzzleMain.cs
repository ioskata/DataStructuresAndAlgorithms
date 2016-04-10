namespace EightQueensPuzzle
{
    class EightQueensPuzzleMain
    {
        static void Main(string[] args)
        {
            EightQueens.PutQueens(0);
            EightQueensPermutations.Enumerate(new int[8], 0);
        }
    }
}