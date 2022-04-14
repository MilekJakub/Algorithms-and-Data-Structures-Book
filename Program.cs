public class Program
{
    static void Main()
    {
        #region Selection sort
        //Selection sort
        Console.WriteLine("Selection sort.");
        var tab = new int[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
        SortingAlgorithms.SelectionSort(tab);
        Console.WriteLine(string.Join(", ", tab));

        var stringTab = new string[] { "z", "y", "x", "a", "c", "b", "e", "d", "f" };
        SortingAlgorithms.SelectionSort<string>(stringTab);
        Console.WriteLine(string.Join(", ", stringTab));
        #endregion

        #region Insertion sort
        //Insertion sort
        Console.WriteLine("\nInsertion sort.");
        tab = new int[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
        SortingAlgorithms.InsertionSort(tab);
        Console.WriteLine(string.Join(", ", tab));

        stringTab = new string[] { "z", "y", "x", "a", "c", "b", "e", "d", "f" };
        SortingAlgorithms.InsertionSort<string>(stringTab);
        Console.WriteLine(string.Join(", ", stringTab));
        #endregion

        #region Bubble sort
        //Bubble sort
        Console.WriteLine("\nBubble sort.");
        tab = new int[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
        SortingAlgorithms.BubbleSort(tab);
        Console.WriteLine(string.Join(", ", tab));

        stringTab = new string[] { "z", "y", "x", "a", "c", "b", "e", "d", "f" };
        SortingAlgorithms.OptimizedBubbleSort<string>(stringTab);
        Console.WriteLine(string.Join(", ", stringTab));
        #endregion


    }
}