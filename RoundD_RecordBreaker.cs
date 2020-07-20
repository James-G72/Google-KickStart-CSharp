using System;
using System.Linq;
using System.Collections.Generic; // Allows lists to be used. Important!

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
                int records = 0;
                int record = 0;
                for (int checker = 0; checker < values-1; checker++)
                {
                    bool test1 = input_list[checker] > record;
                    bool test2 = input_list[checker] > input_list[checker + 1];
                    if (test1 && test2)
                    {
                        records++;
                    }
                    record = Math.Max(record, input_list[checker]);
                }
                // Looking at the last value
                if (input_list[values - 1] > record)
                {
                    records++;
                }

                Console.WriteLine("Case #{0}: {1}", case_, records);
            }
        }
    }
}
