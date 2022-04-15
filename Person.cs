#pragma warning disable
namespace Sorting_Alghoritsm
{
    public enum CountryEnum
    {
        PL,
        UK,
        DE
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public CountryEnum Country { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age} {Country}";
        }
    }
}
