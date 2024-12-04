namespace AdventOfCode24;

public class Day2
{
        public static int Part1()
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
    
    public static int Part2()
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
}