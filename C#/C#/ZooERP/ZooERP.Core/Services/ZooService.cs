using ZooERP.Core.Interfaces;
using ZooERP.Core.Models;
namespace ZooERP.Core.Services
{
    public class ZooService : IZooService
    {
        private readonly List<Animal> _animals = new();
        private readonly List<IInventory> _inventory = new();
        private readonly IVeterinaryClinic _veterinaryClinic;
        public ZooService(IVeterinaryClinic veterinaryClinic)
        {
            _veterinaryClinic = veterinaryClinic;
        }
        public void AddAnimal(Animal animal)
        {
            if (_veterinaryClinic.CheckAnimal(animal))
            {
                _animals.Add(animal);
                _inventory.Add(animal);
                Console.WriteLine($"Животное {animal.Name} принято в зоопарк!");
            }
            else
            {
                Console.WriteLine($"Животное {animal.Name} не прошло медосмотр и не принято в зоопарк.");
            }
        }
        public void AddThing(IInventory thing) => _inventory.Add(thing);
        public int GetTotalFoodRequired() => _animals.Sum(a => a.Food);
        public List<Herbivore> GetContactZooAnimals() => 
            _animals.OfType<Herbivore>().Where(h => h.CanBeInContactZoo).ToList();
        public void PrintInventoryReport()
        {
            Console.WriteLine("\n=== ИНВЕНТАРИЗАЦИЯ ===");
            foreach (var item in _inventory)
            {
                Console.WriteLine(item.GetInventoryInfo());
            }
        }
        public void PrintAnimalsReport()
        {
            Console.WriteLine("\n=== ОТЧЕТ ПО ЖИВОТНЫМ ===");
            Console.WriteLine($"Всего животных: {_animals.Count}");
            Console.WriteLine($"Общее количество еды в день: {GetTotalFoodRequired()} кг");
            var contactAnimals = GetContactZooAnimals();
            Console.WriteLine($"Животные для контактного зоопарка: {contactAnimals.Count}");
            foreach (var animal in contactAnimals)
            {
                Console.WriteLine($"- {animal.Name} (Уровень доброты: {animal.KindnessLevel})");
            }
        }
    }
}