namespace ServiceRegister.Application
{
    public interface IOrderable
    {
        int? OrderNumber { get; }
        string Name { get; }
    }
}
