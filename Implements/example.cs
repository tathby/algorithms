using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using AlgoPortfolio.Implements;

namespace CustomSortExample
{
    public class AlgorithmInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string BestCase { get; set; }
        public string WorstCase { get; set; }
        public string Pseudocode { get; set; }

        public void Display()
        {
            Console.WriteLine($"\n=== {Name} ===");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Time Complexity:");
            Console.WriteLine($"Best Case: {BestCase}");
            Console.WriteLine($"Worst Case: {WorstCase}");
            Console.WriteLine("\nPseudocode:");
            Console.WriteLine(Pseudocode);
        }
    }

    public static class Program
    {
        public static void Main()
        {
            string filePath = "scores.txt";
            Sorter sorter = new Sorter(filePath);
            Console.WriteLine($"Data set size: {sorter.DataSetSize} elements\n");

            sorter.SortWithBubbleSort();
            sorter.SortWithHeapSort();
            sorter.SortWithInsertionSort();
            sorter.SortWithMergeSort();
            sorter.SortWithQuickSort();
        }
    }

    public class Sorter
    {
        private List<int> dataSet;
        private Dictionary<string, AlgorithmInfo> algorithmInfo { get; set; }
        public int DataSetSize => dataSet.Count;

        public Sorter(string filePath)
        {
            dataSet = LoadDataFromFile(filePath);
            InitializeAlgorithmInfo();
        }

        private void InitializeAlgorithmInfo()
        {
            algorithmInfo = new Dictionary<string, AlgorithmInfo>
            {
                {
                    "Bubble Sort",
                    new AlgorithmInfo
                    {
                        Name = "Bubble Sort",
                        Description = "A simple comparison sort that repeatedly steps through the list, compares adjacent elements and swaps them if they are in the wrong order.",
                        BestCase = "O(n) - when array is already sorted",
                        WorstCase = "O(n²) - when array is reverse sorted",
                        Pseudocode = @"
    procedure bubbleSort(A: list of sortable items)
        n = length(A)
        repeat
            swapped = false
            for i = 1 to n-1 inclusive do
                if A[i-1] > A[i] then
                    swap(A[i-1], A[i])
                    swapped = true
                end if
            end for
        until not swapped
    end procedure"
                    }
                },
                {
                    "Heap Sort",
                    new AlgorithmInfo
                    {
                        Name = "Heap Sort",
                        Description = "A comparison-based sorting algorithm that uses a binary heap data structure. It divides the input into a sorted and an unsorted region, and iteratively shrinks the unsorted region by extracting the largest element and moving it to the sorted region.",
                        BestCase = "O(n log n)",
                        WorstCase = "O(n log n)",
                        Pseudocode = @"
    procedure heapSort(A: list of sortable items)
        buildMaxHeap(A)
        for i = n to 2 do
            swap(A[1], A[i])
            heapSize = heapSize - 1
            maxHeapify(A, 1)
        end for
    end procedure"
                    }
                },
                {
                    "Insertion Sort",
                    new AlgorithmInfo
                    {
                        Name = "Insertion Sort",
                        Description = "Builds the final sorted array one item at a time by repeatedly inserting a new element into the sorted portion of the array.",
                        BestCase = "O(n) - when array is already sorted",
                        WorstCase = "O(n²) - when array is reverse sorted",
                        Pseudocode = @"
    procedure insertionSort(A: list of sortable items)
        for i = 1 to length(A) - 1 do
            key = A[i]
            j = i - 1
            while j >= 0 and A[j] > key do
                A[j+1] = A[j]
                j = j - 1
            end while
            A[j+1] = key
        end for
    end procedure"
                    }
                },
                {
                    "Merge Sort",
                    new AlgorithmInfo
                    {
                        Name = "Merge Sort",
                        Description = "A divide-and-conquer algorithm that recursively divides the input array into two halves, sorts them, and then merges the sorted halves.",
                        BestCase = "O(n log n)",
                        WorstCase = "O(n log n)",
                        Pseudocode = @"
    procedure mergeSort(A: list of sortable items)
        if length(A) <= 1 then return
        
        mid = length(A) / 2
        left = A[0...mid]
        right = A[mid...length]
        
        mergeSort(left)
        mergeSort(right)
        merge(A, left, right)
    end procedure"
                    }
                },
                {
                    "Quick Sort",
                    new AlgorithmInfo
                    {
                        Name = "Quick Sort",
                        Description = "A divide-and-conquer algorithm that picks an element as pivot and partitions the array around the pivot, placing smaller elements before it and larger elements after it.",
                        BestCase = "O(n log n)",
                        WorstCase = "O(n²) - when pivot selection consistently results in the most unbalanced partition",
                        Pseudocode = @"
    procedure quickSort(A: list of sortable items, low, high)
        if low < high then
            p = partition(A, low, high)
            quickSort(A, low, p - 1)
            quickSort(A, p + 1, high)
        end if
    end procedure"
                    }
                }
            };
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

        private void Time(Action sortAction, string algorithmName)
        {
            var info = algorithmInfo[algorithmName];
            info.Display();

            var sw = Stopwatch.StartNew();
            sortAction();
            sw.Stop();

            Console.WriteLine($"\nTime taken: {sw.ElapsedMilliseconds}ms");
            DisplaySortedData();
            Console.WriteLine("\n" + new string('=', 80) + "\n");

            // Reset data for next sort
            dataSet = LoadDataFromFile("scores.txt");
        }

        public void SortWithBubbleSort()
        {
            Time(() =>
            {
                int[] arr = dataSet.ToArray();
                arr = BubbleSort.Sort(arr);
                dataSet = arr.ToList();
            }, "Bubble Sort");
        }

        public void SortWithHeapSort()
        {
            Time(() =>
            {
                int[] arr = dataSet.ToArray();
                HeapSort.Sort(arr);
                dataSet = arr.ToList();
            }, "Heap Sort");
        }

        public void SortWithInsertionSort()
        {
            Time(() =>
            {
                int[] arr = dataSet.ToArray();
                InsertionSort.Sort(arr);
                dataSet = arr.ToList();
            }, "Insertion Sort");
        }

        public void SortWithMergeSort()
        {
            Time(() =>
            {
                int[] arr = dataSet.ToArray();
                MergeSort.Sort(arr);
                dataSet = arr.ToList();
            }, "Merge Sort");
        }

        public void SortWithQuickSort()
        {
            Time(() =>
            {
                int[] arr = dataSet.ToArray();
                var qs = new QuickSort();
                qs.Sort(arr);
                dataSet = arr.ToList();
            }, "Quick Sort");
        }

        public void DisplaySortedData()
        {
            Console.WriteLine("\nSorted Data (first 50 elements): " + 
                string.Join(", ", dataSet.Take(50)) + 
                (dataSet.Count > 50 ? "..." : ""));
        }
    }
}