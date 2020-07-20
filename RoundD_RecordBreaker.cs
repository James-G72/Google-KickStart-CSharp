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
                int record = input_list[0];
                if (values > 1)
                {
                    // Looking at the first value
                    if (input_list[0] > 0 && input_list[0] > input_list[1])
                    {
                        records++;
                    }
                    // Looking at all the other values
                    for (int checker = 1; checker < values - 2; checker++)
                    {
                        if (input_list[checker] > record && input_list[checker] > input_list[checker + 1])
                        {
                            records++;
                            record = input_list[checker];
                        }
                    }
                    // Looking at the last value
                    if (input_list[values - 1] > record)
                    {
                        records++;
                    }
                }
                else if (input_list[0] > 0)
                {
                    records++;
                }

                Console.WriteLine("Case #{0}: {1}", case_, records);
            }
        }
    }
}
