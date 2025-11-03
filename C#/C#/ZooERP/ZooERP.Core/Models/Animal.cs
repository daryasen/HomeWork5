using ZooERP.Core.Interfaces;

namespace ZooERP.Core.Models
{
    public abstract class Animal : IAlive, IInventory, IHealthCheckable
    {
        public int Food { get; set; }
        public string Name { get; set; }
        public bool IsHealthy { get; set; }
        public int InventoryNumber { get; set; }
        
        public abstract bool PerformHealthCheck();
        public virtual string GetInventoryInfo() => $"{GetType().Name} #{InventoryNumber}: {Name}";
    }
}