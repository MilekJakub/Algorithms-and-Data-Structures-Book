public static class SortingAlgorithms
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

    public static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[i])
                {
                    int temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                }
            }
        }
    }
    public static void BubbleSort<T>(T[] arr) where T : IComparable
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j].CompareTo(arr[i]) < 0)
                {
                    T temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                }
            }
        }
    }
    public static void OptimizedBubbleSort<T>(T[] arr) where T : IComparable
    {
        for (int i = 0; i < arr.Length; i++)
        {
            bool isAnyChange = false;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j].CompareTo(arr[i]) < 0)
                {
                    T temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                    isAnyChange = true;
                }
            }
            if (!isAnyChange)
                break;
        }
    }

    public static void QuickSort<T> (T[] arr) where T : IComparable
    {
        QuickSort(arr, 0, arr.Length - 1);
    }
    public static void QuickSort<T> (T[] arr, int lower, int upper) where T : IComparable
    {
        if (lower < upper)
        {
            int p = Partition(arr, lower, upper);

        }
    }
    public static int Partition<T> (T[] arr, int lower, int upper) where T : IComparable
    {
        int i = lower;
        int j = upper;
        var rand = new Random();
        T pivot = arr[rand.Next(i, j)]; // Random pivot to improve performance
        do
        {
            while (arr[i].CompareTo(pivot) < 0) { i++; }
            while (arr[j].CompareTo(pivot) > 0) { j--; }
            if (i >= j) { break; }

            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        while (i <= j);
        return j;
    }
}
