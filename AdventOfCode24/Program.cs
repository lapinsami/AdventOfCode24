namespace AdventOfCode24;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Day1Part2());
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
}