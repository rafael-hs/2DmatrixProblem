using System;

namespace ConsoleApp1
{
    public class MatrixProblem
    {
        public static int days = 0;
        public static void Main(string[] args)
        {
            int[,] test1 = new int[4, 4];
            int[,] test2 = new int[10, 10];
            int[,] test3 = new int[20, 20];


            FarmMatrix(4, 4, test1, 1);
            FarmMatrix(10, 10, test2, 2);
            FarmMatrix(20, 20, test3, 1);
            Print(4, 4, test1);
            Print(10, 10, test2);
            Print(20, 20, test3);

            var result1 = CountDays(4, 4, test1);
            Print(4, 4, test1);
            days = 0;
            var result2 = CountDays(10, 10, test2);
            days = 0;
            Print(10, 10, test2);
            var result3 = CountDays(20, 20, test3);
            Print(20, 20, test3);
            days = 0;

            Console.Write("Number of days: " + result1 + "\n");
            Console.Write("Number of days: " + result2 + "\n");
            Console.Write("Number of days: " + result3);

            Console.ReadKey();
        }

        public static void FarmMatrix(int columns, int rows, int[,] arr, int caseType)
        {
            switch (caseType)
            {
                case 1:
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            if (i == j)
                                arr[i, j] = 1;
                            else
                                arr[i, j] = 0;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            if (i == 5)
                                arr[i, j] = 1;
                            else
                                arr[i, j] = 0;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            if (i == 0)
                                arr[i, j] = 1;
                            else
                                arr[i, j] = 0;
                        }
                    }
                    break;
            }
        }

        public static void Print(int columns, int rows, int[,] arr)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.Write("\n");
            }

            Console.WriteLine();
        }

        public static bool CheckMatrixIsDone(int columns, int rows, int[,] arr)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (arr[i, j] == 0) 
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static int[,] DisseminateArchive(int rows, int columns, int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {   //if first line
                    if (row == 0 && column == 0 && matrix[row, column] == 1)
                    {
                        matrix[row + 1, column] = 1;//down
                        matrix[row, column + 1] = 1;// right
                        Print(rows, columns, matrix);
                    }
                    else if (row == 0 && column == columns-1 && matrix[row, column] == 1)
                    {
                        matrix[row + 1, column] = 1; // down
                        matrix[row, column - 1] = 1;// left
                        Print(rows, columns, matrix);
                    }
                    else if (row == 0 && column > 0 && column < columns-1 && matrix[row, column] == 1)
                    {
                        matrix[row + 1, column] = 1;// de baixo
                        matrix[row, column + 1] = 1;// right
                        matrix[row, column - 1] = 1;// left
                        Print(rows, columns, matrix);
                    }//if borders left and right
                    else if (column == 0 && row > 0 && row < rows-1 && matrix[row, column] == 1)
                    {
                        matrix[row - 1, column] = 1;// up
                        matrix[row + 1, column] = 1;// down
                        matrix[row, column + 1] = 1;// right
                        Print(rows, columns, matrix);
                    }
                    else if (column == columns-1 && row > 0 && row < rows-1 && matrix[row, column] == 1)
                    {
                        matrix[row - 1, column] = 1;// up
                        matrix[row + 1, column] = 1;// down
                        matrix[row, column - 1] = 1;// left
                        Print(rows, columns, matrix);
                    }
                    else if(row == rows-1 && columns == 0 && matrix[row, column] == 1)
                    {
                        matrix[row - 1, column] = 1;// up
                        matrix[row, column + 1] = 1;// right
                        Print(rows, columns, matrix);
                    }
                    else if(row == rows-1 && column == columns-1 && matrix[row, column] == 1)
                    {
                        matrix[row - 1, column] = 1;// up
                        matrix[row, column - 1] = 1;// left
                        Print(rows, columns, matrix);
                    }
                    else if(row == rows-1 && column > 0 && column < columns-1 && matrix[row, column] == 1)
                    {
                        matrix[row, column + 1] = 1;// right
                        matrix[row, column - 1] = 1;// left
                        matrix[row - 1, column] = 1;// up
                        Print(rows, columns, matrix);
                    }
                    else if(row > 0 && column > 0 && row < rows-1 && column < columns-1 && matrix[row, column] == 1)
                    {
                        matrix[row - 1, column] = 1;// up
                        matrix[row + 1, column] = 1;// down
                        matrix[row, column + 1] = 1;// right
                        matrix[row, column - 1] = 1;// left
                        Print(rows, columns, matrix);
                    }
                    Print(rows, columns, matrix);
                }
                Print(rows, columns, matrix);
            }

            return matrix;
        }

        public static int CountDays(int rows, int columns, int[,] matrix)
        {
            
            var ModifiedMatrix = DisseminateArchive(rows, columns, matrix);
            var result = CheckMatrixIsDone(rows, columns, ModifiedMatrix);

            if (result)
            {
                days++;
                return days;
            }
            else
            {
                days++;
                CountDays(rows, columns, ModifiedMatrix);
                return days;
            }
        }
    }
}
