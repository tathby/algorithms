using System;

namespace AlgoPortfolio.Implements;

public class QuickSort
{
    public void Sort(int[] arr)
    {
        if (arr == null || arr.Length == 0)
            return;
        QuickSortArray(arr, 0, arr.Length - 1);
    }

    private void QuickSortArray(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int p = Part(arr, low, high);

            QuickSortArray(arr, low, p - 1);
            QuickSortArray(arr, p + 1, high);
        }
    }

    private int Part(int[] arr, int low, int high)
    {
        int pivot = arr[high];

        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);
        return i + 1;
    }

    private void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
