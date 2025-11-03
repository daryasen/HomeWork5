using ZooERP.Core.Interfaces;
using ZooERP.Core.Models;
namespace ZooERP.Core.Services
{
    public class VeterinaryClinic : IVeterinaryClinic
    {
        public bool CheckAnimal(Animal animal)
        {
            var random = new Random();
            animal.IsHealthy = random.Next(0, 100) > 20;
            return animal.IsHealthy && animal.PerformHealthCheck();
        }
    }
}