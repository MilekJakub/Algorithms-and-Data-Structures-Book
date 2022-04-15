namespace Queue_Call_Center
{
    class Program
    {
        static void Main()
        {
            Random random = new Random();
            CallCenter center = new CallCenter();
            center.Call(1234);
            center.Call(2345);
            center.Call(3456);
            center.Call(4567);
            while (center.AreWaitingCalls())
            {
                IncomingCall call = center.Answer("Mark");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Log($"The call #{call.Id} from client {call.ClientId} has been anwered by { call.Consultant}.");
                Console.ResetColor();
            Thread.Sleep(random.Next(1000, 10000));
                center.End(call);
                Log($"The call #{call.Id} with the client {call.ClientId} was terminated by { call.Consultant}.");
                if (center.Calls.Count > 0)
                {
                    Console.Write("People waiting in the queue: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{center.Calls.Count}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("There are no more incoming calls!");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        private static void Log(string text)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] > {text}");
        }
    }
}