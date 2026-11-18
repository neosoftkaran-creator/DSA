// See https://aka.ms/new-console-template for more information
using DSA;




public class Program
{
    
    public static void Main(string[] args)
    {
        List<int> array = [1, 2, 3, 4];
        List<int> sequence = [1, 3, 4];

        List<List<string>> competitions = [["HTML", "C#"], ["C#", "Python"], ["Python", "HTML"]];
        List<int> results = [0, 0, 1];
        List<int> coins = [1, 1, 2, 3, 5, 7, 22];
        List<int> threeSumArray = [12,3,1,2,-6,5,-8,6];
        int threeSumTarget = 0;

        ArraysAndList arr = new ArraysAndList();
        bool res = arr.IsValidSubSequence(array, sequence);
        string winner = arr.tournamentWinner(competitions,results);
        int changeNotPossible = arr.nonConstructibleChange(coins);
        List<List<int>> threeSumNumber = arr.threeNumberSum(threeSumArray,threeSumTarget);
        List<List<int>> threeSumNumberOtimized = arr.threeNumberSumOptimized(threeSumArray,threeSumTarget);
    }
}
