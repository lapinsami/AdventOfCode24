using System.Text.RegularExpressions;

namespace AdventOfCode24;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Day3Part2());
    }

    static int Day1()
    {
        string[] input = File.ReadAllLines("../../../Day1Input.txt");

        int[] leftValues = new int[input.Length];
        int[] rightValues = new int[input.Length];
        
        for (int i = 0; i < input.Length; i++)
        {
            leftValues[i] = int.Parse(input[i].Split()[0]);
            rightValues[i] = int.Parse(input[i].Split()[^1]);
        }
        
        Array.Sort(leftValues);
        Array.Sort(rightValues);

        int sumOfDistances = 0;

        for (int i = 0; i < input.Length; i++)
        {
            sumOfDistances += Math.Abs(leftValues[i] - rightValues[i]);
        }

        return sumOfDistances;
    }

    static int Day1Part2()
    {
        string[] input = File.ReadAllLines("../../../Day1Input.txt");

        int[] leftValues = new int[input.Length];
        int[] rightValues = new int[input.Length];
        
        for (int i = 0; i < input.Length; i++)
        {
            leftValues[i] = int.Parse(input[i].Split()[0]);
            rightValues[i] = int.Parse(input[i].Split()[^1]);
        }
        
        Array.Sort(leftValues);
        Array.Sort(rightValues);

        int similarityScore = 0;

        for (int i = 0; i < input.Length; i++)
        {
            int n = leftValues[i];
            similarityScore += n * rightValues.Count(j => j == n);
        }

        return similarityScore;
    }

    static int Day2()
    {
        string[] input = File.ReadAllLines("../../../Day2Input.txt");
        int numberOfSafeLines = 0;
        
        foreach (string line in input)
        {
            string[] dataAsStr = line.Split();
            int[] data = new int[dataAsStr.Length];
            
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = int.Parse(dataAsStr[i]);
            }

            bool safe = true;
            int firstDiff = data[1] - data[0];
            
            for (int i = 1; i < data.Length; i++)
            {
                int diff = data[i] - data[i - 1];

                if (Math.Abs(diff) > 3)
                {
                    safe = false;
                }
                
                if (firstDiff * diff <= 0)
                {
                    safe = false;
                }
            }
            
            if (safe)
            {
                numberOfSafeLines++;
            }
        }
        
        return numberOfSafeLines;
    }
    
    static int Day2Part2()
    {
        string[] input = File.ReadAllLines("../../../Day2Input.txt");
        int numberOfSafeLines = 0;
        
        foreach (string line in input)
        {
            string[] dataAsStr = line.Split();
            int[] data = new int[dataAsStr.Length];
            
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = int.Parse(dataAsStr[i]);
            }

            bool safe = true;
            int firstDiff = data[1] - data[0];
            
            for (int i = 1; i < data.Length; i++)
            {
                int diff = data[i] - data[i - 1];

                if (Math.Abs(diff) > 3)
                {
                    safe = false;
                }
                
                if (firstDiff * diff <= 0)
                {
                    safe = false;
                }
            }
            
            if (safe)
            {
                numberOfSafeLines++;
            }
            else if (ProblemDampenerSafe(data))
            {
                numberOfSafeLines++;
            }
        }
        
        return numberOfSafeLines;

        bool ProblemDampenerSafe(int[] data)
        {
            List<List<int>> variations = [];

            for (int i = 0; i < data.Length; i++)
            {
                variations.Add(data.ToList());
                variations[i].RemoveAt(i);
            }

            bool globalSafe = false;
            
            foreach (var l in variations)
            {
                bool safe = true;
                int firstDiff = l[1] - l[0];
            
                for (int i = 1; i < l.Count; i++)
                {
                    int diff = l[i] - l[i - 1];

                    if (Math.Abs(diff) > 3)
                    {
                        safe = false;
                    }
                
                    if (firstDiff * diff <= 0)
                    {
                        safe = false;
                    }
                }

                if (safe)
                {
                    globalSafe = true;
                }
            }

            return globalSafe;
        }
    }

    private static int Day3()
    {
        string input = File.ReadAllText("../../../Day3Input.txt");
        string regexPattern = "[m][u][l][(]([0-9]|[1-9][0-9]|[1-9][0-9][0-9])[,]([0-9]|[1-9][0-9]|[1-9][0-9][0-9])[)]";
        Regex rex = new(regexPattern);
        
        MatchCollection matchedInstructions = rex.Matches(input);
        
        int sumOfInstructions = 0;

        for (int i = 0; i < matchedInstructions.Count; i++)
        {
            string aStr = "";
            string bStr = "";
            
            string inst = matchedInstructions[i].Value;

            for (int j = 4; j < 7; j++)
            {
                if (char.IsNumber(inst[j]))
                {
                    aStr += inst[j];
                }
                else
                {
                    break;
                }
            }
            
            string[] splitInst = inst.Split(',');
            
            for (int j = 0; j < 3; j++)
            {
                if (char.IsNumber(splitInst[1][j]))
                {
                    bStr += splitInst[1][j];
                }
                else
                {
                    break;
                }
            }

            int a = int.Parse(aStr);
            int b = int.Parse(bStr);
            
            sumOfInstructions += a * b;

        }

        return sumOfInstructions;
    }
    
    private static int Day3Part2()
    {
        string input = File.ReadAllText("../../../Day3Input.txt");
        string regexPattern = "([m][u][l][(]([0-9]|[1-9][0-9]|[1-9][0-9][0-9])[,]([0-9]|[1-9][0-9]|[1-9][0-9][0-9])[)])|([d][o][(][)])|([d][o][n]['][t][(][)])";
        Regex rex = new(regexPattern);
        
        MatchCollection matchedInstructions = rex.Matches(input);
        
        int sumOfInstructions = 0;
        bool instructionsEnabled = true;

        for (int i = 0; i < matchedInstructions.Count; i++)
        {
            string inst = matchedInstructions[i].Value;

            if (inst.StartsWith("do("))
            {
                instructionsEnabled = true;
            }
            else if (inst.StartsWith("don't("))
            {
                instructionsEnabled = false;
            }
            else
            {
                if (!instructionsEnabled)
                {
                    continue;
                }
                
                string aStr = "";
                string bStr = "";
                
                for (int j = 4; j < 7; j++)
                {
                    if (char.IsNumber(inst[j]))
                    {
                        aStr += inst[j];
                    }
                    else
                    {
                        break;
                    }
                }
            
                string[] splitInst = inst.Split(',');
            
                for (int j = 0; j < 3; j++)
                {
                    if (char.IsNumber(splitInst[1][j]))
                    {
                        bStr += splitInst[1][j];
                    }
                    else
                    {
                        break;
                    }
                }

                int a = int.Parse(aStr);
                int b = int.Parse(bStr);
            
                sumOfInstructions += a * b;
            }

        }

        return sumOfInstructions;
    }
}