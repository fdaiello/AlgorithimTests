using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestFindClosestValueInBst();
        }
        /*
		 * Two Number Sum
		 * Return an array with 2 numbers that belogns to the input array, and that sum equals target sum
		 */
        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            for (int x = 0; x < array.Length; x++)
            {
                for (int y = 0; y < array.Length; y++)
                {
                    if (x != y && (array[x] + array[y] == targetSum))
                    {
                        return new int[] { array[x], array[y] };
                    }
                }
            }

            return new int[0];
        }
        // Test Two Number Sum
        public static void TestTwoNumberSum()
        {
            int[] array = { 3, 5, -4, 8, 11, 1, -1, 6 };
            int sum = 10;
            Console.WriteLine($"TwoNumberSum: [{String.Join(",", TwoNumberSum(array, sum))}]");

        }
        /*
		Is Valid Subsequence

        Given two non-empty arrays of integers, write a function that determines whether the second array is a subsequence of the first one.

        A subsequence of an array is a set of numbers that aren't necessarily adjacent
        in the array but that are in the same order as they appear in the array. For
        instance, the numbers [1, 3, 4] form a subsequence of the array
        [1, 2, 3, 4], and so do the numbers <span>[2, 4]</span>. Note
        that a single number in an array and the array itself are both valid
        subsequences of the array.

		 */
        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {
            if (array.Count == 0 || sequence.Count == 0)
                return false;

            int p = 0;

            for (int x=0; x < array.Count; x++)
			{
                if (array[x] == sequence[p])
                    p++;
                if (p == sequence.Count)
                    return true;
			}

            return false;
        }
        public static void TestIsValidSubsequence()
        {
            List<int> sequence = new List<int> { 5, 1, 22, 25, 6, -1, 8, 10 };
            List<int> subSequence = new List<int> { 25, 8, 9};

            Console.WriteLine($"Is Valid Subsequence: {IsValidSubsequence(sequence, subSequence)}");
        }

        /*
        Sorted Squared Array
         
        Write a function that takes in a non-empty array of integers that are sorted
        in ascending order and returns a new array of the same length with the squares
        of the original integers also sorted in ascending order.         

        */
        public static int[] SortedSquaredArray(int[] array)
        {
            int[] sortedArray = new int[array.Length];
            
            for (int x=0; x<array.Length; x++)
            {
                sortedArray[x] = array[x] * array[x];
            }

            Array.Sort(sortedArray);

            return sortedArray;
        }
        public static void TestSortedSquaredArray()
        {
            int[] array = {-10, -2, -1, 2, 3, 5, 6, 8, 9 };
            Console.WriteLine($"Sorted Squared Array: [{string.Join(", ", SortedSquaredArray(array))}]");
        }

        // Tournament Winner
        /*
  There's an algorithms tournament taking place in which teams of programmers
  compete against each other to solve algorithmic problems as fast as possible.
  Teams compete in a round robin, where each team faces off against all other
  teams. Only two teams compete against each other at a time, and for each
  competition, one team is designated the home team, while the other team is the
  away team. In each competition there's always one winner and one loser; there
  are no ties. A team receives 3 points if it wins and 0 points if it loses. The
  winner of the tournament is the team that receives the most amount of points.

  Given an array of pairs representing the teams that have competed against each
  other and an array containing the results of each competition, write a
  function that returns the winner of the tournament. The input arrays are named
  <span>competitions</span> and <span>results</span>, respectively. The
  <span>competitions</span> array has elements in the form of
  <span>[homeTeam, awayTeam]</span>, where each team is a string of at most 30
  characters representing the name of the team. The <span>results</span> array
  contains information about the winner of each corresponding competition in the
  <span>competitions</span> array. Specifically, <span>results[i]</span> denotes
  the winner of <span>competitions[i]</span>, where a <span>1</span> in the
  <span>results</span> array means that the home team in the corresponding
  competition won and a <span>0</span> means that the away team won.

  It's guaranteed that exactly one team will win the tournament and that each
  team will compete against all other teams exactly once. It's also guaranteed
  that the tournament will always have at least two teams.

         */
        public static string TournamentWinner(List<List<string>> competitions, List<int> results)
        {
            string cWinner;
            int score;
            var competitors = new Dictionary<string, int>();

            // Varre a lista das competições
            for ( int x=0; x<competitions.Count; x++)
            {
                // Ve quem ganhou: 1 é o primeiro, 0 é o segundo
                if (results[x] == 1)
                {
                    // Home ganhou
                    cWinner = competitions[x][0];
                }
                else
                {
                    // Visitor ganhou
                    cWinner = competitions[x][1];
                }

                // Confere se o vencedor já está no dicionario
                if (competitors.TryGetValue(cWinner, out score))
                {
                    competitors[cWinner] = score + 3;
                }
                else
                {
                    competitors.Add(cWinner, 3);
                }
            }

            var winner = competitors.OrderByDescending(key => key.Value).FirstOrDefault();
            return winner.Key;

        }
        public static void TestTournamentWinner()
        {
            List<List<string>> competitions = new List<List<string>> { new List<string> { "HTML", "C#" }, new List<string> { "C#", "Python" }, new List<string> { "Python", "HTML" } };
            List<int> results = new List<int> { 0, 0, 1 };

            Console.WriteLine($"Tournament Winner: {TournamentWinner(competitions, results)}");

        }
        /*
        Non Constructible Change

        Given an array of positive integers representing the values of coins in your
        possession, write a function that returns the minimum amount of change (the
        minimum sum of money) that you <b>cannot</b> create. The given coins can have
        any positive integer value and aren't necessarily unique (i.e., you can have
        multiple coins of the same value).

        For example, if you're given <span>coins = [1, 2, 5]</span>, the minimum
        amount of change that you can't create is <span>4</span>. If you're given no
        coins, the minimum amount of change that you can't create is <span>1</span>.

        */
        public static int NonConstructibleChange(int[] coins)
        {
            if (coins.Length == 0)
                return 1;

            // sort array
            Array.Sort(coins);

            // if first element is greater than 1, return 1
            if (coins[0] > 1)
                return 1;

            // we know whe have 1 coin, so min change starts with 1
            int minChange = 1;

            // now lets check all coins sorted, and check what is the sum, starting from the second element
            for ( int x=1; x<coins.Length; x++)
            {

                if ( minChange + coins[x] > minChange + 1 && coins[x] != minChange + 1 && coins[x] + 1 > minChange + 1)
                {
                    return minChange + 1;
                }
                else
                {
                    minChange += coins[x];
                }
            }

            // Write your code here.
            return minChange + 1;

        }
        public static void TestNonConstructibleChange()
        {
            int[] coins = { 1, 1, 1, 1, 5, 10 };

            Console.WriteLine($"Minimum non constructible change: {NonConstructibleChange(coins)}");
        }

        /*
        Find Closest Value in BST

        Write a function that takes in a Binary Search Tree (BST) and a target integer
        value and returns the closest value to that target value contained in the BST.

        You can assume that there will only be one closest value.

        Each BST node has an integer value, a
        left child node, and a right child node. A node is
        said to be a valid <span>BST</span> node if and only if it satisfies the BST
        property: its <span>value</span> is strictly greater than the values of every
        node to its left; its <span>value</span> is less than or equal to the values
        of every node to its right; and its children nodes are either valid
        <span>BST</span> nodes themselves or <span>None</span>

        Sample Input

                  10
               /     \
              5      15
            /   \   /   \
           2     5 13   22
         /           \
        1            14

        target = 12
        
        Sample Output: 13

         */
        public static int FindClosestValueInBst(BST tree, int target)
        {
            return FindClosestValueInBstNode(tree, target, tree.value);

        }
        public static int FindClosestValueInBstNode(BST tree, int target, int lastValue)
        {
            if (tree.value == target)
                return tree.value;

            int closestValue;

            if (Math.Abs(tree.value - target) < Math.Abs(lastValue - target))
                closestValue = tree.value;
            else
                closestValue = lastValue;

            if (target < tree.value)
                if (tree.left != null)
                    return FindClosestValueInBstNode(tree.left, target, closestValue);
                else
                    return closestValue;
                
            else
                if (tree.right != null && tree.right.value > tree.value)
                    return FindClosestValueInBstNode(tree.right, target, closestValue);
                else
                    return closestValue;

        }
        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
            }
        }
        public static void TestFindClosestValueInBst()
        {
            BST tree = new BST(10)
            {
                left = new BST(5)
                {
                    left = new BST(2)
                    {
                        left = new BST(1)
                    },
                    right = new BST(5)
                },
                right = new BST(15)
                {
                    left = new BST(13)
                    {
                        right = new BST(14)
                    },
                    right = new BST(22)
                }
            };

            int target = 3;

            Console.WriteLine($"Find Closes Value in BST: {FindClosestValueInBst(tree, target)}");

        }
    }
}
