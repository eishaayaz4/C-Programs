using System;
public class Diamond{
   public static void PrintDiamond()
    {
        Console.Write("Enter the number of lines: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Input cannot be null or empty ");
            return;
        }
        if (int.TryParse(input, out int n))
        {
            if (n <= 0)
            {
                Console.WriteLine("Please enter a positive integer.");
            }
            // For even n, print as a diamond-like pattern
            if (n % 2 == 0)
            {
                int mid = n / 2;

                // Print the top half
                for (int i = 0; i < mid; i++)
                {
                    // Print leading spaces
                    for (int j = 0; j < mid - i - 1; j++)
                    {
                        Console.Write(" ");
                    }

                    // Print the first star
                    Console.Write("*");

                    // Print spaces between stars
                    if (i > 0)
                    {
                        for (int j = 0; j < 2 * i - 1; j++)
                        {
                            Console.Write(" ");
                        }

                        // Print the second star
                        Console.Write("*");
                    }

                    Console.WriteLine();
                }

                // Print the bottom half
                for (int i = mid - 1; i >= 0; i--)
                {
                    // Print leading spaces
                    for (int j = 0; j < mid - i - 1; j++)
                    {
                        Console.Write(" ");
                    }

                    // Print the first star
                    Console.Write("*");

                    // Print spaces between stars
                    if (i > 0)
                    {
                        for (int j = 0; j < 2 * i - 1; j++)
                        {
                            Console.Write(" ");
                        }

                        // Print the second star
                        Console.Write("*");
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                // Handle the odd number case 
                int mid = n / 2;

                // Print the top half including the middle row
                for (int i = 0; i <= mid; i++)
                {
                    // Print leading spaces
                    for (int j = 0; j < mid - i; j++)
                    {
                        Console.Write(" ");
                    }

                    // Print the first star
                    Console.Write("*");

                    // Print spaces between stars
                    if (i > 0)
                    {
                        for (int j = 0; j < 2 * i - 1; j++)
                        {
                            Console.Write(" ");
                        }

                        // Print the second star
                        Console.Write("*");
                    }

                    Console.WriteLine();
                }

                // Print the bottom half
                for (int i = mid - 1; i >= 0; i--)
                {
                    // Print leading spaces
                    for (int j = 0; j < mid - i; j++)
                    {
                        Console.Write(" ");
                    }

                    // Print the first star
                    Console.Write("*");

                    // Print spaces between stars
                    if (i > 0)
                    {
                        for (int j = 0; j < 2 * i - 1; j++)
                        {
                            Console.Write(" ");
                        }

                        // Print the second star
                        Console.Write("*");
                    }

                    Console.WriteLine();
                }
            }
        }
        else
        {
            Console.WriteLine("Input must be a valid  positive integer ");
            return;

        }
    }
}
