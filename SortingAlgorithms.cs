﻿public static class SortingAlgorithms
{
    public static void SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int min = arr[i];
            int index = i;

            for (int j = i; j < arr.Length; j++)
            {
                if (arr[j] <= min)
                {
                    min = arr[j];
                    index = j;
                }
            }

            if (index != i)
            {
                int temp = arr[index];
                arr[index] = arr[i];
                arr[i] = temp;
                min = arr[i];
            }
        }
    }
    public static void SelectionSort<T>(T[] arr) where T : IComparable
    {
        for (int i = 0; i < arr.Length; i++)
        {
            T min = arr[i];
            int index = i;

            for (int j = i; j < arr.Length; j++)
            {
                if (min.CompareTo(arr[j]) > 0)
                {
                    min = arr[j];
                    index = j;
                }
            }

            if (index != i)
            {
                T temp = arr[index];
                arr[index] = arr[i];
                arr[i] = temp;
                min = arr[i];
            }
        }
    }
    public static void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int j = i;
            while (j > 0 && arr[j - 1] > arr[j])
            {
                int temp = arr[j - 1];
                arr[j - 1] = arr[j];
                arr[j] = temp;
                j--;
            }
        }
    }
    public static void InsertionSort<T>(T[] arr) where T : IComparable
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int j = i;
            while (j > 0 && arr[j - 1].CompareTo(arr[j]) > 0)
            {
                T temp = arr[j - 1];
                arr[j - 1] = arr[j];
                arr[j] = temp;
                j--;
            }
        }
    }
}
