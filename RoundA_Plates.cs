using System;
using System.Linq;
using System.Collections.Generic; // Allows lists to be used. Important!

// This doesn't actually work!
// Runtime error when used by the KickStart but unfortnately the error cannot be repeated in testing.

namespace KickStart
{
    // This first class just holds all of the permutation logic that was formed seperately
    class PermutationCalculator
    {
        public static bool checker;
        public static List<int[]> Permutations(int stacks, int height, int length)
        {
            // We can ask permute to give us the different arrangements of a set of numbers
            // We need to pass in all options that would give us enough plates
            // First we cycle through all of the possible stack numbers
            checker = true;
            int[] querey = new int[stacks];
            int remaining = length;
            int counter = 0;
            // Finding the starting possition
            while (checker)
            {
                // Checking if we can satisfy the problem within a single stack
                if (height >= remaining)
                {
                    querey[counter] = remaining;
                    checker = false;
                }
                else
                {
                    querey[counter] = height;
                    remaining -= height;
                    counter++;
                }
            }
            // We now have a starting combination and set checker back to true for the new loop
            checker = true;
            // Regardless of this input method the variable can be put into the extractor to return a list of integer arrays
            List<int[]> storage = new List<int[]>();
            // Adding the first querey to our list of options
            int indexer = 1;
            while (checker)
            {
                storage = Permute(querey,storage,0,stacks);
                // Checking if the first value is the largest
                if (querey[0] >= length - (stacks - 1))
                {
                    querey[0]--;
                    querey[indexer]++;
                    indexer++;
                    if (indexer > stacks-1)
                    {
                        // If indexer exceeds stack then we want to go back to the first stack again
                        indexer = 0;
                    }
                }
                else
                {
                    checker = false;
                }

                
                
            }
            

            return storage;
        }

        private static List<int[]> Permute(int[] input_list, List<int[]> output, int l, int r)
        {
            if (l == r)
            {
                // I don't know if I need to check this or not but 
                if (!output.Contains(input_list))
                {
                    output.Add(input_list);
                    checker = true;
                }
            }
            else
            {
                for (int i = l; i < r; i++)
                {
                    input_list = Swapper(input_list, l, i);
                    Permute(input_list, output, l + 1, r);
                    input_list = Swapper(input_list, l, i);
                }
            }
            return output;
        }

        public static int[] Swapper(int[] a, int i, int j)
        {
            char temp;
            string str = string.Join("", a);
            char[] charArray = str.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            int[] Aint = Array.ConvertAll(charArray, c => (int)Char.GetNumericValue(c));
            return Aint;
        }
    }

    // Then we handle the rest of the logic in a seperate solutions class
    class Solution
    {
        static void Main(string[] args)
        {
            int Cases = Int32.Parse(Console.ReadLine());
            for (int case_ = 1; case_ < Cases+1; case_++)
            {
                // First thing to do is to assemble the resulting lines into a single variable
                // line 1 contains 
                var line1 = Console.ReadLine().Split(' ');
                int N = Convert.ToInt32(line1[0]); // Number of rows
                int K = Convert.ToInt32(line1[1]); // Number of plates per stack
                int P = Convert.ToInt32(line1[2]); // Number of plates required
                int[,] holder = new int[N,K+1];
                // We dont need to set the first row to 0 as it is 0 by default
                for (int row = 0; row < N; row++)
                {
                    // We accept an input and convert the strings to int32 while sorting them with Linq.
                    List<int> input_list = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToList();
                    for (int col = 1; col < K+1; col++)
                    {
                        // Create a cumulative sum in that row of the array using the input
                        holder[row, col] = holder[row, col - 1] + input_list[col - 1];
                    }
                }
                // At this point we have a cumulative sum array of all our stacks
                int max_count = 0;
                if (P == 1)
                {
                    // We only care about the first row so we isolate it
                    int[] firstRow = new int[N];
                    for (int i = 0; i < N; i++)
                    {
                        // Pasting the first column values into the new array
                        firstRow[i] = holder[i, 1];
                    }
                    max_count = firstRow.Max();
                }
                // Other option is that we need to take all of the plates
                else if (P == N*K)
                {
                    for (int i = 0; i < N; i++)
                    {
                        // Summing each of the values as we cycle through them
                        max_count += holder[i, K];
                    }
                }
                // The final case is if we need to choose 2:N*K-1 plates
                else
                {
                    // We request a list of all possible plate choices
                    List<int[]> options = PermutationCalculator.Permutations(N, K, P);
                    // By using a specific permutations calculator we get a list of integer arrays
                    // Now we want to check all these options and find the largest
                    int score;
                    for (int instance = 0; instance < options.Count; instance++)
                    {
                        int[] key = options[instance];
                        score = 0;
                        for (int sum_index = 0; sum_index < N; sum_index++)
                        {
                            score += holder[sum_index, key[sum_index]];
                        }
                        if (score > max_count)
                        {
                            max_count = score;
                        }
                    }
                }
                Console.WriteLine("Case #{0}: {1}", case_, max_count);
            }
        }
    }
}
