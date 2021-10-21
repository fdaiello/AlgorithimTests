using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestTournamentWinner();
        }

        // Is Valid Subsequence
        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {
            int y = 0;
            for (int x=0; x<array.Count; x++)
            {
                if ( array[x] == sequence[y])
                {
                    y++;
                    if (y > sequence.Count - 1)
                        return true;
                }
            }

            return false;
        }
        public static void TestIsValidSubsequence()
        {
            List<int> sequence = new List<int> { 5, 1, 22, 25, 6, -1, 8, 10 };
            List<int> subSequence = new List<int> { 25, 8, 10 };

            Console.WriteLine($"Is Valid Subsequence: {IsValidSubsequence(sequence, subSequence)}");
        }

        // Sorted Squared Array
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

            // Write your code here.
            var winner = competitors.OrderByDescending(key => key.Value).FirstOrDefault();
            return winner.Key;

        }
        public static void TestTournamentWinner()
        {
            List<List<string>> competitions = new List<List<string>> { new List<string> { "HTML", "C#" }, new List<string> { "C#", "Python" }, new List<string> { "Python", "HTML" } };
            List<int> results = new List<int> { 0, 0, 1 };

            Console.WriteLine($"Tournament Winner: {TournamentWinner(competitions, results)}");

        }
    }
}
