namespace CountryFilterAPI.Models
{
    public class Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
    public class Flags
    {
        public string Svg { get; set; }
        public string Png { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Region { get; set; }
        public Flags Flags { get; set; }
        public List<Currency> Currencies { get; set; }
    }
}
