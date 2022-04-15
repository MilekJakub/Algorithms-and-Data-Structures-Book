namespace PriorityQueue_Call_Center
{
    class Program
    {
        static void Main()
        {
            Random random = new Random();
            CallCenter center = new CallCenter();
            center.Call(random.Next(1000,9999));
            center.Call(random.Next(1000, 9999), true);
            center.Call(random.Next(1000, 9999));
            center.Call(random.Next(1000, 9999), true);

            Console.WriteLine("- Statring queue -");
            for (int i = 0; i < center.Calls.Count; i++)
            {
                if (center.Calls.ElementAt(i).IsPriority)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                Console.WriteLine(center.Calls.ElementAt(i));
                Console.ResetColor();
            }
            Console.WriteLine();


            while (center.AreWaitingCalls())
            {
                Console.WriteLine("----------------------------------------------");
                IncomingCall call = center.Answer("Marcin");
                Log($"The call #{call.Id} from client {call.ClientId} has been anwered by { call.Consultant}. | Procedure: ");
                if (call.IsPriority)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("priority.");
                    Console.ResetColor();
                }
                else Console.WriteLine("normal.");
                Thread.Sleep(random.Next(1000, 10000));
                center.End(call);
                Log($"The call #{call.Id} with the client {call.ClientId} was terminated by { call.Consultant}.");
                
                if (center.Calls.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("\n - Queue - ");
                    for (int i = 0; i < center.Calls.Count; i++)
                    {
                        Console.ResetColor();
                        if (center.Calls.ElementAt(i).IsPriority)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        Console.WriteLine(center.Calls.ElementAt(i));
                    }
                    Console.WriteLine("");
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nThere's no more calls!");
                    Console.ResetColor();
                }
            }
        }
        private static void Log(string text)
        {
            Console.Write($"[{DateTime.Now.ToString("HH:mm:ss")}] > {text}");
        }
    }
}