using System;

class Program
{
    static void Main()
    {
        int[] nums = { 3, 4, 2, 8, 7 };

        Console.WriteLine(ExisteSuma(nums, 6));   // true
        Console.WriteLine(ExisteSuma(nums, 26));  // false
        Console.WriteLine(ExisteSuma(new int[] { 4 }, 4)); // true
    }

    static bool ExisteSuma(int[] arr, int target)
    {
        return ExisteSumaRec(arr, target, 0);
    }

    static bool ExisteSumaRec(int[] arr, int target, int index)
    {
        // Caso base
        if (target == 0)
            return true;

        if (index >= arr.Length || target < 0)
            return false;

        // Dos opciones:
        // Incluiye el número actual
        // No incluirlo
        return ExisteSumaRec(arr, target - arr[index], index + 1) ||
               ExisteSumaRec(arr, target, index + 1);
    }
}