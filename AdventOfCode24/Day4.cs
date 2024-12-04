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

        static int CheckForWordInDirection(int col, int row, int rowDirection, int colDirection, string wordToFind, string[] letterGrid)
        {
            int currentColumn = col;
            int currentRow = row;

            for (int i = 1; i < wordToFind.Length; i++)
            {
                currentColumn += colDirection;
                currentRow += rowDirection;

                if (OutOfBounds(currentRow, currentColumn, letterGrid))
                {
                    break;
                }

                if (letterGrid[currentRow][currentColumn] != wordToFind[i])
                {
                    break;
                }

                if (i == wordToFind.Length - 1)
                {
                    return 1;
                }
            }

            return 0;
        }

        static int FindWords(string word, string[] grid, int startingRow, int startingColumn)
        {
            int wordsFound = 0;
            
            // horizontal to the right
            wordsFound += CheckForWordInDirection(startingColumn, startingRow, 0, 1, word, grid);
            // horizontal to the left
            wordsFound += CheckForWordInDirection(startingColumn, startingRow, 0, -1, word, grid);
            // vertical down
            wordsFound += CheckForWordInDirection(startingColumn, startingRow, 1, 0, word, grid);
            // vertical up
            wordsFound += CheckForWordInDirection(startingColumn, startingRow, -1, 0, word, grid);
            // diagonal up right
            wordsFound += CheckForWordInDirection(startingColumn, startingRow, -1, 1, word, grid);
            // diagonal up left
            wordsFound += CheckForWordInDirection(startingColumn, startingRow, -1, -1, word, grid);
            // diagonal down right
            wordsFound += CheckForWordInDirection(startingColumn, startingRow, 1, 1, word, grid);
            // diagonal down left
            wordsFound += CheckForWordInDirection(startingColumn, startingRow, +1, -1, word, grid);
            
            return wordsFound;
        }
    }
    
    public static int Part2()
    {
        int totalWordsFound = 0;
        string[] input = File.ReadAllLines("../../../Day4Input.txt");
        string wordToFind = "A";

        for (int row = 0; row < input.Length; row++)
        {
            for (int column = 0; column < input[0].Length; column++)
            {
                if (input[row][column] == wordToFind[0])
                {
                    totalWordsFound += FindWords(input, row, column);
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

        static int FindWords(string[] grid, int startingRow, int startingColumn)
        {
            int currentRow = startingRow;
            int currentColumn = startingColumn;
            
            // diagonal up right
            
            currentColumn++;
            currentRow--;

            if (OutOfBounds(currentRow, currentColumn, grid))
            {
                return 0;
            }

            if (grid[currentRow][currentColumn] != 'M' && grid[currentRow][currentColumn] != 'S')
            {
                return 0;
            }
            
            char firstFoundLetter = grid[currentRow][currentColumn];
            
            currentRow = startingRow;
            currentColumn = startingColumn;
            
            // diagonal down left
            
            currentColumn--;
            currentRow++;

            if (OutOfBounds(currentRow, currentColumn, grid))
            {
                return 0;
            }

            if (grid[currentRow][currentColumn] != 'M' && grid[currentRow][currentColumn] != 'S')
            {
                return 0;
            }
            
            char secondFoundLetter = grid[currentRow][currentColumn];

            if (firstFoundLetter == secondFoundLetter)
            {
                return 0;
            }

            bool firstFound = true;
            
            currentRow = startingRow;
            currentColumn = startingColumn;
            
            // diagonal up left
            
            currentColumn--;
            currentRow--;

            if (OutOfBounds(currentRow, currentColumn, grid))
            {
                return 0;
            }

            if (grid[currentRow][currentColumn] != 'M' && grid[currentRow][currentColumn] != 'S')
            {
                return 0;
            }
            
            char thirdFoundLetter = grid[currentRow][currentColumn];
            
            currentRow = startingRow;
            currentColumn = startingColumn;
            
            // diagonal down right
            
            currentColumn++;
            currentRow++;

            if (OutOfBounds(currentRow, currentColumn, grid))
            {
                return 0;
            }

            if (grid[currentRow][currentColumn] != 'M' && grid[currentRow][currentColumn] != 'S')
            {
                return 0;
            }
            
            char fourthFoundLetter = grid[currentRow][currentColumn];

            if (thirdFoundLetter == fourthFoundLetter)
            {
                return 0;
            }

            bool secondFound = true;

            if (firstFound && secondFound)
            {
                return 1;
            }


            return 0;
        }
    }
}