using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// Example: MultiplesOf(7,5) -> {7,14,21,28,35}
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create an array with size 'length'
        // 2. Loop from 0 to length-1
        // 3. For each index, store number * (i + 1)
        // 4. Return the array

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the list to the right by 'amount'
    /// Example:
    /// {1,2,3,4,5,6,7,8,9} with amount 3 -> {7,8,9,1,2,3,4,5,6}
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Get the size of the list
        // 2. Normalize amount using modulo
        // 3. If shift is 0, do nothing
        // 4. Find the split position
        // 5. Take the last part and the first part
        // 6. Clear the list and rebuild it

        int n = data.Count;

        int shift = amount % n;

        if (shift == 0)
            return;

        int splitIndex = n - shift;

        List<int> firstPart = data.GetRange(0, splitIndex);
        List<int> lastPart = data.GetRange(splitIndex, shift);

        data.Clear();
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}