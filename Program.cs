using System; 
using System.IO;
using System.Linq;
//System.Linq is needed to push an order onto a list
using System.Collections.Generic; 
//Generic is needed for creating lists & arrays, and System.IO is needed to append text to files
namespace vscode
{
    class Program
    {
        static void AddLine()
        {
            Console.WriteLine("");
            //This is absolutely not neccesary, but it's easier for me to just write AddLine & the way C# handles console outputs is messed up
        }
        static void Main(string[] args)
        {
            var rand = new Random();
            Console.WriteLine("Testing Console Ouput");
            //This just verifies the console is working as intended
            Console.Write("Starting position is: ");
            //This line starts writing the position of the cube
            var rubik = new List<int> {1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,5,5,5,5,5,5,5,5,5,6,6,6,6,6,6,6,6,6}; 
            //This line creates the Rubik's Cube
            var testList = new List<int>{1,2,3,4};
            var order = new List<int>{2, 0, 1, 3};
            var moveF = new List<int> {1,1,1,1,1,5,5,5,2,2,2,2,2,2,2,2,2,1,3,3,1,3,3,1,3,3,1,3,3,4,4,4,4,4,4,4,4,5,5,6,5,5,6,5,5,6,6,6,3,6,6,3,6,6,3};
            var newWorks = new List<int> {1,2,3,4,5,6,7,8,9,10,11,12,13,14,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54};
            //This pushes a new order onto the list, a method I just discovered. This streamlines significant portions of my code, so I'll be rewriting everything to 
            var result = order.Select(i => testList[i]).ToList();
            //This line just verifies that a reordering of the list would work
            foreach (var number in result)
            {
                Console.Write(number);
            }
            //This function just prints the results of the list
            AddLine();
            Console.Write(rubik[1]);
            using (StreamWriter sw = File.CreateText(@"C:\vscode\outputs\sizetest.txt")){
                //This is the output.
                for (int i = 0; i < 4000000; i++){
                sw.Write("Test Output ");
                sw.WriteLine(i * 4 * i * rand.Next(500));
            }
            }
        }
    }
}