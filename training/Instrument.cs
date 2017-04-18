namespace training
{
    public class Instrument
    {
        public string Name { get; }

        public InstrumentType Type { get; }

        public Instrument(string name, InstrumentType type)
        {
            Name = name;
            Type = type;
        }
    }
}
