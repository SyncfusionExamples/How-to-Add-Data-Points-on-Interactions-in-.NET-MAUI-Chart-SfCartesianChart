namespace AddDataPoint
{
    public class Model
    {
        public double Value { get; set; }
        public double Size { get; set; }

        public Model(double value, double size)
        {
            Value = value;
            Size = size;
        }
    }
}
