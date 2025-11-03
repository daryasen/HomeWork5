using Microsoft.Extensions.DependencyInjection;
using ZooERP.Core.DependencyInjection;
using ZooERP.Core.Interfaces;
using ZooERP.Core.Models;
using ZooERP.Core.Services;

class Program
{
    private static IZooService _zooService;
    private static int _inventoryCounter = 1;
    static void Main(string[] args)
    {
        var serviceProvider = ContainerConfig.Configure();
        _zooService = serviceProvider.GetRequiredService<IZooService>();
        Console.WriteLine("=== СИСТЕМА УПРАВЛЕНИЯ ЗООПАРКОМ ===");
        AddSampleData();
        while (true)
        {
            ShowMenu();
            var choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1": AddNewAnimal(); break;
                case "2": AddNewThing(); break;
                case "3": _zooService.PrintAnimalsReport(); break;
                case "4": _zooService.PrintInventoryReport(); break;
                case "5": return;
                default: Console.WriteLine("Неверный выбор!"); break;
            }
        }
    }
    
    static void ShowMenu()
    {
        Console.WriteLine("\n--- МЕНЮ ---");
        Console.WriteLine("1. Добавить животное");
        Console.WriteLine("2. Добавить вещь");
        Console.WriteLine("3. Отчет по животным");
        Console.WriteLine("4. Инвентаризация");
        Console.WriteLine("5. Выход");
        Console.Write("Выберите действие: ");
    }
    
    static void AddSampleData()
    {
        _zooService.AddAnimal(new Rabbit { 
            Name = "Банни", Food = 2, InventoryNumber = _inventoryCounter++, KindnessLevel = 7 
        });
        _zooService.AddAnimal(new Tiger { 
            Name = "Шерхан", Food = 8, InventoryNumber = _inventoryCounter++ 
        });
        _zooService.AddThing(new Table { 
            Name = "Стол администратора", InventoryNumber = _inventoryCounter++ 
        });
    }
    
    static void AddNewAnimal()
    {
        Console.WriteLine("\nВыберите тип животного:");
        Console.WriteLine("1. Кролик");
        Console.WriteLine("2. Обезьяна");
        Console.WriteLine("3. Тигр");
        Console.WriteLine("4. Волк");
        var typeChoice = Console.ReadLine();
        Console.Write("Введите имя: ");
        var name = Console.ReadLine();
        Console.Write("Введите количество еды (кг/день): ");
        int food = int.Parse(Console.ReadLine());
        Animal animal = typeChoice switch
        {
            "1" => new Rabbit { KindnessLevel = 6 },
            "2" => new Monkey { KindnessLevel = 4 },
            "3" => new Tiger(),
            "4" => new Wolf(),
            _ => throw new ArgumentException("Неверный тип")
        };
        animal.Name = name;
        animal.Food = food;
        animal.InventoryNumber = _inventoryCounter++;
        _zooService.AddAnimal(animal);
    }
    
    static void AddNewThing()
    {
        Console.WriteLine("\nВыберите тип вещи:");
        Console.WriteLine("1. Стол");
        Console.WriteLine("2. Компьютер");
        var choice = Console.ReadLine();
        Console.Write("Введите название: ");
        var name = Console.ReadLine();
        IInventory thing = choice switch
        {
            "1" => new Table(),
            "2" => new Computer(),
            _ => throw new ArgumentException("Неверный тип")
        };
        
        thing.InventoryNumber = _inventoryCounter++;
        _zooService.AddThing(thing);
        Console.WriteLine("Вещь добавлена в инвентарь!");
    }
}