#pragma warning disable
namespace Dictionary
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
            employees.Add(11, new Employee() { FirstName = "John", LastName = "Doe", PhoneNumber = "000-000-000" });
            employees.Add(210, new Employee() { FirstName = "Marie", LastName = "Roosevelt", PhoneNumber = "111-111-111" });
            employees.Add(303, new Employee() { FirstName = "Thomas", LastName = "Gnabry", PhoneNumber = "222-222-222" });

            bool isCorrect = true;
            do
            {
                Console.Write("Enter employee ID: ");
                string idString = Console.ReadLine()!;
                isCorrect = int.TryParse(idString, out int id);
                if (isCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (employees.TryGetValue(id, out Employee employee))
                    {
                        Console.WriteLine("Firstname: {1}{0}Lastname: {2}{0}Phone: {3}",
                        Environment.NewLine,
                        employee.FirstName,
                        employee.LastName,
                        employee.PhoneNumber);
                    }
                    else
                    {
                        Console.WriteLine("There's no emloyee matching the given ID.");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (isCorrect);
        }
    }
}