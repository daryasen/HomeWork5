using ZooERP.Core.Interfaces;

namespace ZooERP.Core.Models
{
    public class Thing : IInventory
    {
        public int InventoryNumber { get; set; }
        public string Name { get; set; }
        
        public string GetInventoryInfo() => $"{GetType().Name} #{InventoryNumber}: {Name}";
    }
}