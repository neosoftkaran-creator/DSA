using System;
using System.Collections.Generic;
using System.Linq;
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
                if(seqCount == sequence.Count())
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
            for(int i = 0; i<competitions.Count();i++ )
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

        //3. We are given an array of positive integers, which represent the values of coins that we have in our possession.The array could 
        //    have duplicates. We are asked to write a function that returns the minimum amount of change that we cannot create with our coins.
        //    For instance, if the input array is [1, 2, 5], the minimum amount of change that we cannot create is 4, since we can 
        //    create 1, 2, 3 (1 + 2) and 5.

        public int nonConstructibleChange(List<int> coins)
        {

        }
    }
}
