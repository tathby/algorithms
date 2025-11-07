using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlgoPortfolio.Implements;

namespace CustomSortExample
{
    public static class Program
    {
        public static void Main()
        {
            string filePath = "scores.txt";
            Sorter sorter = new Sorter(filePath);

            sorter.SortWithBubbleSort();
            sorter.DisplaySortedData();

            sorter.SortWithHeapSort();
            sorter.DisplaySortedData();

            sorter.SortWithInsertionSort();
            sorter.DisplaySortedData();

            sorter.SortWithMergeSort();
            sorter.DisplaySortedData();

            sorter.SortWithQuickSort();
            sorter.DisplaySortedData();
        }
    }

    public class Sorter
    {
        private List<int> dataSet;

        public Sorter(string filePath)
        {
            dataSet = LoadDataFromFile(filePath);
        }

        private List<int> LoadDataFromFile(string filePath)
        {
            var data = new List<int>();
            foreach (var line in File.ReadLines(filePath))
            {
                if (int.TryParse(line, out int number))
                {
                    data.Add(number);
                }
            }
            return data;
        }

        public void SortWithBubbleSort()
        {
            int[] arr = dataSet.ToArray();
            arr = BubbleSort.Sort(arr);
            dataSet = arr.ToList();
        }

        public void SortWithHeapSort()
        {
            int[] arr = dataSet.ToArray();
            HeapSort.Sort(arr);
            dataSet = arr.ToList();
        }

        public void SortWithInsertionSort()
        {
            int[] arr = dataSet.ToArray();
            InsertionSort.Sort(arr);
            dataSet = arr.ToList();
        }

        public void SortWithMergeSort()
        {
            int[] arr = dataSet.ToArray();
            MergeSort.Sort(arr);
            dataSet = arr.ToList();
        }

        public void SortWithQuickSort()
        {
            int[] arr = dataSet.ToArray();
            var qs = new QuickSort();
            qs.Sort(arr);
            dataSet = arr.ToList();
        }

        public void DisplaySortedData()
        {
            Console.WriteLine("Sorted Data: " + string.Join(", ", dataSet));
        }
    }
}