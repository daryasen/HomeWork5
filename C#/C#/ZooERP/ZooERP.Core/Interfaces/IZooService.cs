using ZooERP.Core.Models;

namespace ZooERP.Core.Interfaces
{
    public interface IZooService
    {
        void AddAnimal(Animal animal);
        void AddThing(IInventory thing);
        int GetTotalFoodRequired();
        List<Herbivore> GetContactZooAnimals();
        void PrintInventoryReport();
        void PrintAnimalsReport();
    }
}