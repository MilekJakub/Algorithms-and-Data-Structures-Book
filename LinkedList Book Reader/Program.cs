namespace LinkedList_Book_Reader
{
    public class Program
    {
        static void Main()
        {
            var firstPage = new Page() { Title = "Title1", Content = "Content a", Credits = "Credits u" };
            var secondPage = new Page() { Title = "Title2", Content = "Content b", Credits = "Credits v" };
            var thirdPage = new Page() { Title = "Title3", Content = "Content c", Credits = "Credits w" };
            var fourthPage = new Page() { Title = "Title4", Content = "Content d", Credits = "Credits x" };
            var fifthPage = new Page() { Title = "Title5", Content = "Content e", Credits = "Credits y" };
            var sixthPage = new Page() { Title = "Title6", Content = "Content f", Credits = "Credits z" };

            LinkedList<Page> pages = new LinkedList<Page>();
            pages.AddLast(secondPage);
            LinkedListNode<Page> nodePageFourth = pages.AddLast(fourthPage);
            pages.AddLast(sixthPage);
            pages.AddFirst(firstPage);
            pages.AddBefore(nodePageFourth, thirdPage);
            pages.AddAfter(nodePageFourth, fifthPage);

            LinkedListNode<Page> current = pages.First!;
            int number = 1;
            while (current != null)
            {
                Console.Clear();
                string numberString = $"- {number} - ";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (numberString.Length / 2)) + "}", numberString));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (numberString.Length / 2)) + "}", current.Value.Title));

                string content = current.Value.Content;
                for (int i = 0; i < content.Length; i += 90)
                {
                    string line = content.Substring(i);
                    line = line.Length > 90 ? line.Substring(0, 90) : line;
                    Console.WriteLine(line);
                }

                Console.WriteLine();
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (numberString.Length / 2)) + "}", current.Value.Credits));

                Console.WriteLine();
                Console.Write(current.Previous != null ? "< PREVIOUS [P]" : "              ");
                Console.Write(current.Next != null ? "< NEXT [N]".PadLeft(Console.WindowWidth - 15) : "");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.N:
                        if (current.Next != null)
                        {
                            current = current.Next;
                            number++;
                        }
                        break;

                    case ConsoleKey.P:
                        if (current.Previous != null)
                        {
                            current = current.Previous;
                            number--;
                        }
                        break;

                    default:
                        return;
                }
            }
        }
    }
}