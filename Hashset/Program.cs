HashSet<int> usedCoupons = new HashSet<int>();
do
{
    Console.Write("Enter coupon number: ");
    string couponString = Console.ReadLine()!;
    if (int.TryParse(couponString, out int coupon))
    {
        if (usedCoupons.Contains(coupon))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This coupon has already been used.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else
        {
            usedCoupons.Add(coupon);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thanks!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
    else
    {
        break;
    }
}
while (true);