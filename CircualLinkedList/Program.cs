namespace CircuralLinkedList_Wheel_of_Fortune
{
    public class Program
    {
        static void Main()
        {
            //Using CircuralLinkedList to build the wheel of fortune.
            //Implementation in CircularLinkedList.cs
            CircularLinkedList<string> categories = new CircularLinkedList<string>();
            categories.AddLast("C");
            categories.AddLast("Java");
            categories.AddLast("Python");
            categories.AddLast("C++");
            categories.AddLast("C#");
            categories.AddLast("Visual Basic");
            categories.AddLast("JavaScript");
            categories.AddLast("PHP");
            categories.AddLast("Groovy");
            categories.AddLast("SQL");
            categories.AddLast("Swift");
            categories.AddLast("GO");
            categories.AddLast("Ruby");

            Console.WriteLine("If you don't know which language to learn yet, this program should help you.");
            Random random = new Random();
            int totalTime = 0;
            int remainingTime = 0;
            foreach (string category in categories)
            {
                if (remainingTime <= 0)
                {
                    Console.WriteLine("Press [Enter] to begin or any other key to leave.");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            totalTime = random.Next(1000, 5000);
                            remainingTime = totalTime;
                            break;
                        default:
                            return;
                    }
                }

                int categoryTime = (-450 * remainingTime) / (totalTime - 50) + 500 + (22500 / (totalTime - 50));
                remainingTime -= categoryTime;
                Thread.Sleep(categoryTime);
                Console.ForegroundColor = remainingTime <= 0 ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.WriteLine(category);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

        }
    }
}
