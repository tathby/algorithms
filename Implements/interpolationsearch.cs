using System;

namespace AlgoPortfolio.Implements;

public class InterpolationSearch
{
    public static int Search(int[] array, int target)
    {
        int low = 0;
        int high = array.Length - 1;

        while (low <= high && target >= array[low] && target <= array[high])
        {
            if (low == high)
            {
                if (array[low] == target)
                    return low;
                return -1;
            }

            int position = low + (((high - low) * (target - array[low])) /
                (array[high] - array[low]));

            if (array[position] == target)
                return position;

            if (array[position] < target)
                low = position + 1;
            else
                high = position - 1;
        }
        return -1;
    }
}
