using System.Text.RegularExpressions;

namespace AdventOfCode24;

public class Day3
{
    public static int Part1()
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
    
    public static int Part2()
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

            if (inst.StartsWith("do()"))
            {
                instructionsEnabled = true;
            }
            else if (inst.StartsWith("don't()"))
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