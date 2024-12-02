namespace AdventOfCode24;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Day2());
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
}