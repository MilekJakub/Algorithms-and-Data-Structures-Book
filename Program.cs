namespace Sorting_Alghoritsm
{
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
            SortingAlgorithms.SelectionSort(stringTab);
            Console.WriteLine(string.Join(", ", stringTab));
            #endregion

            #region Insertion sort
            //Insertion sort
            Console.WriteLine("\nInsertion sort.");
            tab = new int[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            SortingAlgorithms.InsertionSort(tab);
            Console.WriteLine(string.Join(", ", tab));

            stringTab = new string[] { "z", "y", "x", "a", "c", "b", "e", "d", "f" };
            SortingAlgorithms.InsertionSort(stringTab);
            Console.WriteLine(string.Join(", ", stringTab));
            #endregion

            #region Bubble sort
            //Bubble sort
            Console.WriteLine("\nBubble sort.");
            tab = new int[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            SortingAlgorithms.BubbleSort(tab);
            Console.WriteLine(string.Join(", ", tab));

            stringTab = new string[] { "z", "y", "x", "a", "c", "b", "e", "d", "f" };
            SortingAlgorithms.OptimizedBubbleSort(stringTab);
            Console.WriteLine(string.Join(", ", stringTab));
            #endregion

            #region Quicksort
            //Quicksort
            Console.WriteLine("\nQuicksort.");
            tab = new int[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            SortingAlgorithms.QuickSort(tab);
            Console.WriteLine(string.Join(", ", tab));

            stringTab = new string[] { "z", "y", "x", "a", "c", "b", "e", "d", "f" };
            SortingAlgorithms.QuickSort(stringTab);
            Console.WriteLine(string.Join(", ", stringTab));
            #endregion

            #region List sorting
            //Sorting List<T> using LINQ
            Console.WriteLine("\nSorted List<T> using LINQ.");
            List<Person> people = new List<Person>();

            people.Add(new Person { Name = "Marcin", Age = 29, Country = CountryEnum.PL });
            people.Add(new Person { Name = "Sabina", Age = 25, Country = CountryEnum.DE });
            people.Add(new Person { Name = "Anna", Age = 31, Country = CountryEnum.PL });
            people.Add(new Person { Name = "Thomas", Age = 34, Country = CountryEnum.UK });
            people.Add(new Person { Name = "Jakub", Age = 19, Country = CountryEnum.PL });

            var result = people.OrderBy(p => p.Age).ToList();

            foreach (var person in result)
            {
                Console.WriteLine(person);
            }
            #endregion

            #region Using SortedList
            //Using SortedList
            Console.WriteLine("\nUsing SortedList [in this example the key value is age].");
            SortedList<int, Person> peopleSortedList = new SortedList<int, Person>();

            peopleSortedList.Add(29, new Person { Name = "Marcin", Age = 29, Country = CountryEnum.PL });
            peopleSortedList.Add(25, new Person { Name = "Sabina", Age = 25, Country = CountryEnum.DE });
            peopleSortedList.Add(31, new Person { Name = "Anna", Age = 31, Country = CountryEnum.PL });
            peopleSortedList.Add(34, new Person { Name = "Thomas", Age = 34, Country = CountryEnum.UK });
            peopleSortedList.Add(19, new Person { Name = "Jakub", Age = 19, Country = CountryEnum.PL });

            foreach (var person in peopleSortedList)
            {
                Console.WriteLine(person);
            }
            #endregion
        }
    }
}