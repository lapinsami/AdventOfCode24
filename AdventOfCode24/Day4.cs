namespace AdventOfCode24;

public class Day4
{
    public static int Part1()
    {
        int totalWordsFound = 0;
        string[] input = File.ReadAllLines("../../../Day4Input.txt");
        string wordToFind = "XMAS";

        for (int row = 0; row < input.Length; row++)
        {
            for (int column = 0; column < input[0].Length; column++)
            {
                if (input[row][column] == wordToFind[0])
                {
                    totalWordsFound += FindWords(wordToFind, input, row, column);
                }
            }
        }
        
        return totalWordsFound;

        static bool OutOfBounds(int row, int column, string[] grid)
        {
            if (row < 0 || row >= grid.Length)
            {
                return true;
            }

            if (column < 0 || column >= grid[0].Length)
            {
                return true;
            }
            
            return false;
        }

        static int FindWords(string word, string[] grid, int startingRow, int startingColumn)
        {
            int wordsFound = 0;
            int currentRow = startingRow;
            int currentColumn = startingColumn;
            
            // horizontal to the right
            for (int i = 1; i < word.Length; i++)
            {
                currentColumn++;

                if (OutOfBounds(currentRow, currentColumn, grid))
                {
                    break;
                }

                if (grid[currentRow][currentColumn] != word[i])
                {
                    break;
                }

                if (i == 3)
                {
                    wordsFound++;
                }
            }

            currentColumn = startingColumn;
            
            // horizontal to the left
            for (int i = 1; i < word.Length; i++)
            {
                currentColumn--;

                if (OutOfBounds(currentRow, currentColumn, grid))
                {
                    break;
                }

                if (grid[currentRow][currentColumn] != word[i])
                {
                    break;
                }

                if (i == 3)
                {
                    wordsFound++;
                    break;
                }
            }
            
            currentColumn = startingColumn;
            
            // vertical down
            for (int i = 1; i < word.Length; i++)
            {
                currentRow++;

                if (OutOfBounds(currentRow, currentColumn, grid))
                {
                    break;
                }

                if (grid[currentRow][currentColumn] != word[i])
                {
                    break;
                }

                if (i == 3)
                {
                    wordsFound++;
                }
            }

            currentRow = startingRow;
            
            // vertical up
            for (int i = 1; i < word.Length; i++)
            {
                currentRow--;

                if (OutOfBounds(currentRow, currentColumn, grid))
                {
                    break;
                }

                if (grid[currentRow][currentColumn] != word[i])
                {
                    break;
                }

                if (i == 3)
                {
                    wordsFound++;
                }
            }

            currentRow = startingRow;
            
            // diagonal up right
            for (int i = 1; i < word.Length; i++)
            {
                currentColumn++;
                currentRow--;

                if (OutOfBounds(currentRow, currentColumn, grid))
                {
                    break;
                }

                if (grid[currentRow][currentColumn] != word[i])
                {
                    break;
                }

                if (i == 3)
                {
                    wordsFound++;
                }
            }

            currentColumn = startingColumn;
            currentRow = startingRow;
            
            // diagonal up left
            for (int i = 1; i < word.Length; i++)
            {
                currentColumn--;
                currentRow--;

                if (OutOfBounds(currentRow, currentColumn, grid))
                {
                    break;
                }

                if (grid[currentRow][currentColumn] != word[i])
                {
                    break;
                }

                if (i == 3)
                {
                    wordsFound++;
                }
            }

            currentColumn = startingColumn;
            currentRow = startingRow;
            
            // diagonal down right
            for (int i = 1; i < word.Length; i++)
            {
                currentColumn++;
                currentRow++;

                if (OutOfBounds(currentRow, currentColumn, grid))
                {
                    break;
                }

                if (grid[currentRow][currentColumn] != word[i])
                {
                    break;
                }

                if (i == 3)
                {
                    wordsFound++;
                }
            }

            currentColumn = startingColumn;
            currentRow = startingRow;
            
            // diagonal down left
            for (int i = 1; i < word.Length; i++)
            {
                currentColumn--;
                currentRow++;

                if (OutOfBounds(currentRow, currentColumn, grid))
                {
                    break;
                }

                if (grid[currentRow][currentColumn] != word[i])
                {
                    break;
                }

                if (i == 3)
                {
                    wordsFound++;
                }
            }
            
            return wordsFound;
        }
    }
}