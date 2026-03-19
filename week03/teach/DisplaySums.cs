using System;
using System.Collections.Generic;

public static class DisplaySums {
    public static void Run() {
        DisplaySumPairs(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
        // Expected:
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");

        DisplaySumPairs(new int[] {-20, -15, -10, -5, 0, 5, 10, 15, 20});
        // Expected:
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");

        DisplaySumPairs(new int[] {5, 11, 2, -4, 6, 8, -1});
        // Expected:
        // 8 2
        // -1 11
    }

    /// <summary>
    /// Display pairs of numbers that sum to 10 using a Set (O(n))
    /// </summary>
    private static void DisplaySumPairs(int[] numbers) {
        HashSet<int> seen = new HashSet<int>();

        foreach (int number in numbers) {
            int complement = 10 - number;

            if (seen.Contains(complement)) {
                Console.WriteLine($"{number} {complement}");
            }

            seen.Add(number);
        }
    }
}