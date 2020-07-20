using System;
using System.Linq;
using System.Collections.Generic; // Allows lists to be used. Important!


// This solution works for the first test case but failts with wrong answer for the second. I am unsure why it does this and would expect it to time out for the more challenging cases.
// I cannot think of an edge case that would cause this that is dependent on the number of notes.

namespace KickStart
{
    // Then we handle the rest of the logic in a seperate solutions class
    class Solution
    {

        static void Main(string[] args)
        {
            int Cases = Int32.Parse(Console.ReadLine());
            for (int case_ = 1; case_ < Cases + 1; case_++)
            {
                // The cases loop contains all solutions
                int values = Int32.Parse(Console.ReadLine());
                List<int> input_list = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToList();
                // Filter out values that appear more than once
                List<int> filtered = input_list.Distinct().ToList();
                int ups = 0;
                int downs = 0;
                int breaks = 0;
                for (int i = 1; i < filtered.Count(); i++)
                {
                    if (filtered[i] > filtered[i - 1])
                    {
                        ups++;
                        downs = 0;
                    }
                    else
                    {
                        downs++;
                        ups = 0;
                    }
                    if (ups > 3 || downs > 3)
                    {
                        breaks++;
                        ups = downs = 0;
                    }
                }

                Console.WriteLine("Case #{0}: {1}", case_, breaks);
            }
        }
    }
}
