using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DSA
{
    public class ArraysAndList
    {

        //1. Two Sum

        //2. Valid Subsequence
        //Given two non - empty arrays of integers, write a function that determines whether the second array is a subsequence of the first one.A subsequence of an array is a set of numbers that aren't 
        //necessarily adjacent in the array but that are in the same order as they appear in the array. For instance, 
        //the numbers [1, 3, 4] form a subsequence of the array [1, 2, 3, 4], and so do the numbers [2, 4]. Note that a single 
        //number in an array and the array itself are both valid subsequences of the array.   
        public bool IsValidSubSequence(List<int> array, List<int> sequence)
        {
            if (sequence.Count() == 0)
            {
                return true;
            }
            if (sequence.Count() > array.Count())
            {
                return false;
            }
            int seqCount = 0;
            for (int i = 0; i < array.Count(); i++)
            {


                if (sequence[seqCount] == array[i])
                {
                    seqCount++;
                }
                else
                {
                    continue;
                }
                if (seqCount == sequence.Count())
                {
                    return true;
                }
            }
            return false;
        }

        //3. Tournament Winner
        //We're asked to imagine there is an algorithms tournament in which multiple teams compete against each other. 
        //    In each competition there will be two teams that compete. There will be one winner and one loser out of all of these 
        //        competitions and there are no ties. Each team will compete against all other teams exactly once. A team gets 3 points for 
        //        each competition it wins and 0 points for each competition it loses. It's guaranteed that the tournament always has at l
        //        east two teams and there will be only one tournament winner.

        //    We are given two inputs, the competitions array and the results array.We need to write a function that returns the winner of 
        //        the tournament, or more specifically, the name of the team that has the most number of points.The competitions array is an 
        //        array of pairs, representing all of the competitions in the tournament.Inside of these pairs, we have two strings: the first 
        //        one is the name of the home team and the second one is the name of the away team. The results array represents the winner of 
        //        each of these competitions.Inside the results array, a 1 means that the home team won and a 0 means the away team won.The results 
        //        array is the same length as the competitions array, and the indices in the results array correspond with the indices in the 
        //        competitions array.
        public string tournamentWinner(List<List<string>> competitions, List<int> results)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < competitions.Count(); i++)
            {
                if (results[i] == 0)
                {
                    if (dict.ContainsKey(competitions[i][1]))
                    {
                        int currVal = dict[competitions[i][1]];
                        dict[competitions[i][1]] = currVal + 3;
                    }
                    else
                    {
                        dict.Add(competitions[i][1], 3);
                    }

                }
                else
                {
                    if (dict.ContainsKey(competitions[i][0]))
                    {
                        int currVal = dict[competitions[i][0]];
                        dict[competitions[i][0]] = currVal + 3;
                    }
                    else
                    {
                        dict.Add(competitions[i][0], 3);
                    }
                }
            }
            var res = dict.MaxBy(entry => entry.Value);
            return res.Key;
        }

        //Optimized Code
        public string TournamentWinner(List<List<string>> competitions, List<int> results)
        {
            Dictionary<string, int> scores = new Dictionary<string, int>();
            string bestTeam = "";
            int maxScore = 0;

            // 1. Use .Count property, not .Count() LINQ method
            for (int i = 0; i < competitions.Count; i++)
            {
                // 2. Cleanly determine the winner (Assuming 1 = Home wins, 0 = Away wins)
                bool homeTeamWins = results[i] == 1;
                string winningTeam = homeTeamWins ? competitions[i][0] : competitions[i][1];

                // 3. Update dictionary efficiently in ONE lookup
                scores.TryGetValue(winningTeam, out int currentScore);
                currentScore += 3;
                scores[winningTeam] = currentScore;

                // 4. Track the best team on the fly (Eliminates the need for MaxBy at the end!)
                if (currentScore > maxScore)
                {
                    maxScore = currentScore;
                    bestTeam = winningTeam;
                }
            }

            return bestTeam;
        }

        //3. We are given an array of positive integers, which represent the values of coins that we have in our possession.The array could 
        //    have duplicates. We are asked to write a function that returns the minimum amount of change that we cannot create with our coins.
        //    For instance, if the input array is [1, 2, 5], the minimum amount of change that we cannot create is 4, since we can 
        //    create 1, 2, 3 (1 + 2) and 5.

        public int nonConstructibleChange(List<int> coins)
        {
            coins.Sort();
            int currentChange = 0;
            foreach (int coin in coins)
            {
                if (coin > currentChange + 1)
                {
                    return currentChange + 1;
                }
                currentChange += coin;
            }
            return currentChange + 1;
        }
    

        //4. Transpose Matrix
        //You're given a 2D array of integers matrix . Write a function that returns the transpose of the matrix. The transpose of a matrix is a 
        //    flipped version of the original matrix across its main diagonal (which runs from top-left to bottom-right); it switches the row and 
        //    column indices of the original matrix. You can assume the input matrix always has at least 1 value; however its width and height are 
        //    not necessarily the same.

        public List<List<int>> transposedMatrix(List<List<int>> matrix)
        {
            int currentRow = 0;
            int currentCol = 0;
            int[] transposedMatrixSize = [matrix.Count(), matrix[1].Count()];
            List<List<int>> transposedMatrix = new List<List<int>>();
            if (currentRow > matrix.Count() || currentCol > matrix[1].Count())
            {
                return transposedMatrix;
            }
            //if (matrix[0].Count)
            return transposedMatrix;
        }
        //Transpose Matrix recursive approach

        //public List<List<int>> TransposeMatrixRecursiveApproach(List<List<int>> matrix)
        //{
        //    int currentRow = 0;
        //    int currentCol = 0;
        //    int[] transposedMatrixSize = [matrix.Count(), matrix[1].Count()];
        //    List<List<int>> transposedMatrix = new List<List<int>>();
        //}

        //public List<List<int>> TransposeMatrixHelperMethod(List<int>)
        //{

        //}
        //5.Three Number Sum
        //We are given an array of distinct integers and an integer that represents a target sum.We are asked to write a function that
        //is going to find all the triplets in the array that sum to the target value and return them in a 2-dimensional array. The triplets
        //should be ordered in ascending order, and so are the numbers in each triplets. For instance, if the triplets we found are: [5, -6, 1],
        //[2, -8, 6] and [3, 5, -8], then we should return [[-8, 2, 6], [-8, 3, 5], [-6, 1, 5]]. If there is no such triplet, return an empty
        //array.

        public List<List<int>> threeNumberSum(List<int> array, int targetSum)
        {
            array.Sort();
            List<List<int>> result = new List<List<int>>();
            for(int i =0; i<array.Count(); i++)
            {
                for(int j =i+1; j<array.Count(); j++)
                {
                    for(int k =j+1; k<array.Count(); k++)
                    {
                        if (array[i] + array[j] + array[k] == targetSum)
                        {
                            result.Add(new List<int>{array[i], array[j], array[k]});
                        }
                    }
                }
            }
            return result;
        }

        public List<List<int>> threeNumberSumOptimized(List<int> array, int targetSum, int currentNumPointer=0)
        {
            if (currentNumPointer == 0)
            {
                array.Sort();
            }
            //int currentNumPointer = 0;
            int windowCapacity = 2;
            List<List<int>> result = new List<List<int>>();
           
                if (currentNumPointer >= array.Count() - 2)
                {
                    return result;
                }
                else
                {
                    for (int i = currentNumPointer + 1; i < (array.Count() - 2); i++)
                    {
                        if (array[currentNumPointer] + array[i] + array[i + 1] == targetSum)
                        {
                            result.Add(new List<int> { array[currentNumPointer], array[i], array[i + 1] });
                        }
                    }
                    currentNumPointer += 1;
                    threeNumberSumOptimized(array, targetSum, currentNumPointer);
                }
                
                return result;
        }

        //6.Smallest Difference
        //We are given two arrays of integers.Both of them contain at least one element.We are asked to write a function that is going to 
        //find two numbers, one in each array, with the smallest absolute difference, and return them in an array. In the resultant array, 
        //the number from the first array should come first.

    }

    

}
