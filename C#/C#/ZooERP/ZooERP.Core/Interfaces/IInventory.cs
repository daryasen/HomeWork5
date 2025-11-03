namespace ZooERP.Core.Interfaces
{
    public interface IInventory
    {
        int InventoryNumber { get; set; }
        string GetInventoryInfo();
    }
}