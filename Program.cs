using System; 
using System.IO;
//System.IO is required to append text to files
using System.Linq;
//System.Linq is needed to push an order onto a list
using System.Collections.Generic; 
//Generic is needed for creating lists & arrays
namespace vscode
{
    class Program {
        static void Main(string[] args)
        {
            var rubik = new List<int> {1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,5,5,5,5,5,5,5,5,5,6,6,6,6,6,6,6,6,6}; 
            //This line creates the Rubik's Cube
            //This is the code used to write the current position of the cube. 
            //It goes through every number of the list, and prints them out on a single line, forming a large number which represents the cube's current state
            List<int>[] move = new List<int>[12];
            //This line creates a list that references other lists, (kinda trippy) which is required for the later nested loops of moves
            move[0] = new List<int> {0,1,2,3,4,5,44,41,38,15,12,9,16,13,10,17,14,11,6,19,20,7,22,23,8,25,26,27,28,29,30,31,32,33,34,35,36,37,47,39,40,50,42,43,53,45,46,24,48,49,21,51,52,18}; 
            move[1] = new List<int> {0,1,2,3,4,5,18,21,24,11,14,17,10,13,16,9,12,15,53,19,20,50,22,23,47,25,26,27,28,29,30,31,32,33,34,35,36,37,8,39,40,7,42,43,6,45,46,38,48,49,41,51,52,44};
            move[2] = new List<int> {0,1,11,3,4,14,6,7,17,9,10,53,12,13,52,15,16,51,24,21,18,25,22,19,26,23,20,8,28,29,5,31,32,2,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,27,30,33};
            move[3] = new List<int> {0,1,33,3,4,30,6,7,27,9,10,2,12,13,5,15,16,8,20,23,26,19,22,25,18,21,24,51,28,29,52,31,32,53,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,17,14,11};
            move[4] = new List<int> {6,3,0,7,4,1,8,5,2,18,19,20,12,13,14,15,16,17,27,28,29,21,22,23,24,25,26,36,37,38,30,31,32,33,34,35,9,10,11,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53};
            move[5] = new List<int> {2,5,8,1,4,7,0,3,6,36,37,38,12,13,14,15,16,17,9,10,11,21,22,23,24,25,26,18,19,20,30,31,32,33,34,35,27,28,29,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53};
            move[6] = new List<int> {20,23,26,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,51,21,22,48,24,25,45,33,30,27,34,31,28,35,32,29,2,37,38,1,40,41,0,43,44,36,46,47,39,49,50,42,52,53};
            move[7] = new List<int> {42,39,36,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,0,21,22,1,24,25,2,29,32,35,38,31,34,27,30,33,45,37,38,48,40,41,51,43,44,26,46,47,23,49,50,20,52,53};
            move[8] = new List<int> {35,1,2,32,4,5,29,7,8,0,10,11,3,13,14,6,16,17,18,19,20,21,22,23,24,25,26,27,28,45,30,31,46,33,34,47,42,39,36,43,40,37,44,41,38,15,12,9,48,49,50,51,52,53};
            move[9] = new List<int> {9,1,2,12,4,5,15,7,8,47,10,11,16,13,14,45,16,17,18,19,20,21,22,23,24,25,26,27,28,6,30,31,3,33,34,0,38,41,44,37,40,43,36,39,42,29,32,35,48,49,50,51,52,53};
            move[10] = new List<int> {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,42,43,44,18,19,20,21,22,23,15,16,17,27,28,29,30,31,32,24,25,26,36,37,38,39,40,41,33,34,35,51,48,45,52,49,46,53,50,47};
            move[11] = new List<int> {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,24,25,26,18,19,20,21,22,23,33,34,35,27,28,29,30,31,32,42,43,44,36,37,38,39,40,41,15,16,17,47,50,53,46,49,52,45,48,51};
            //These lines are the result of hours of work turning each individual move of the Rubik's cube into a sort of algorithm that can be applied to the base Rubik's cube
            //The underscores represent a counterclockwise movement
            var moveIndex = new List<String> {"F","F'","R","R'","U","U'","B","B'","L","L'","D","D'"};
            using (StreamWriter sw = File.CreateText(@"C:\vscode\outputs\7 Moves.txt")){
            //This is the output. Streamwriter is a function used in C# that allows a creation and 'streaming' of text to a file. 
                for (int p = 0; p < 11; p++){
                    //This section is pretty complicated, too much to explain in comments, but a detailed explanation of how I got here is in the paper.
                    var move1Result = move[p].Select(i => rubik[i]).ToList();
                    for (int u = 0; u < 11; u++){
                        var move2Result = move[u].Select(i => move1Result[i]).ToList();
                        for (int w = 0; w < 11; w++){
                            var move3Result = move[w].Select(i => move2Result[i]).ToList();
                            for (int q = 0; q < 11; q++){
                                var move4Result = move[q].Select(i => move3Result[i]).ToList();
                                for (int f = 0; f < 11; f++){
                                    var move5Result = move[f].Select(i => move4Result[i]).ToList();
                                    for (int t = 0; t < 11; t++){
                                        var move6Result = move[t].Select(i => move5Result[i]).ToList();
                                        for (int k = 0; k < 11; k++){
                                            var move7Result = move[k].Select(i => move6Result[i]).ToList();
                                            foreach (var number in move7Result) {
                                                sw.Write(number);
                                            }
                                            sw.WriteLine(" " + moveIndex[p] + " + " +moveIndex[u] + " + " + moveIndex[w] + " + " + moveIndex[q] + " + " + moveIndex[f] + " + " + moveIndex[t] + " + " + moveIndex[k]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        Console.WriteLine("Enter the current state of your Rubik's cube: ");
        String lookingFor = Console.ReadLine();
        Console.WriteLine("Here is every possible way to get there: ");
        foreach (string line in File.ReadLines(@"C:\vscode\outputs\6 Moves.txt")){
            if (line.Contains(lookingFor)){
                Console.WriteLine(line);
            }
        }
    }
}
}