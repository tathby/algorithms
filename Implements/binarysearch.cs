using System;

namespace AlgoPortfolio.Implements;

public class BinarySearch
{
    public static int BinarySearchIterative(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == target)
                return mid;

            if (array[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }

    public static int BinarySearchRecursive(int[] array, int target, int left, int right)
    {
        if (left > right)
            return -1;

        int mid = left + (right - left) / 2;

        if (array[mid] == target)
            return mid;

        if (array[mid] > target)
            return BinarySearchRecursive(array, target, left, mid - 1);

        return BinarySearchRecursive(array, target, mid + 1, right);
    }
}
