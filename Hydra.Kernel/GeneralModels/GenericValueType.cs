namespace Hydra.Kernel.GeneralModels
{
    public class GenericValueType<T>
    {
        public string Name { get; set; }
        public T Value { get; set; }
    }
}
