namespace ZooERP.Core.Interfaces
{
    public interface IAlive
    {
        int Food { get; set; }
        string Name { get; set; }
        bool IsHealthy { get; set; }
    }
}