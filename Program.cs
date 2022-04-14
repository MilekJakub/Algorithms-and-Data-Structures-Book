public class Program
{
    static void Main()
    {
        //Selection sort
        var tab = new int[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
        SortingAlgorithms.SelectionSort(tab);
        Console.WriteLine(string.Join(", ", tab));

        var stringTab = new string[] { "z", "y", "x", "a", "c", "b", "e", "d", "f" };
        SortingAlgorithms.SelectionSort<string>(stringTab);
        Console.WriteLine(string.Join(", ", stringTab));


    }
}