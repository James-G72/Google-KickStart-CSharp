using System;
using System.Linq;

namespace KickStart
{
    class Program
    {
        static void Main(string[] args)
        {
            int result;
            int counter;
            int Cases = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < Cases; i++)
            {
                // We get the first line in and set it to a  var which is automatically set to a string[]
                var line1 = Console.ReadLine().Split(' ');
                // We can extract the secont value from this line to get our budget
                int budget = Convert.ToInt32(line1[1]);
                //We now need to recieve the next line which is the array
                var housePrices = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).OrderBy(p => p).ToList();
                // We now have a sorted list so lets see how many we can buy
                result = 0;
                counter = 0;
                for (int j = 0; j < housePrices.Count; j++)
                {
                    counter += housePrices[j];
                    if (counter <= budget)
                    {
                        result++;
                    }
                }
                Console.WriteLine("Case #{0}: {1}",i+1,result);
            }
        }
    }
}
