namespace training
{
    public class Instrument
    {

        public string Name { get; }

        public InstrumentType Type { get; }

        public double Price { get; set; }

        public Instrument(string name, InstrumentType type)
        {
            Name = name;
            Type = type;
        }
    }
}
