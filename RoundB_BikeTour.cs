using System;
using System.Linq;

namespace KickStart
{
    class Solution
    {
        static void Main(string[] args)
        {
            int Cases = Int32.Parse(Console.ReadLine());
            for (int case_ = 1; case_ < Cases+1; case_++)
            {
                int checkpoints = Int32.Parse(Console.ReadLine());
                int[] checkpointArray = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
                int score = 0;
                for (int element = 1; element < checkpoints-1; element++)
                {
                    if (checkpointArray[element] > checkpointArray[element-1] && checkpointArray[element] > checkpointArray[element + 1])
                    {
                        score++;
                    }
                }
                Console.WriteLine("Case #{0}: {1}", case_, score);
            }
        }
    }
}
