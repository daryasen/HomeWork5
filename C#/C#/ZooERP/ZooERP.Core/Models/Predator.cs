namespace ZooERP.Core.Models
{
    public abstract class Predator : Animal
    {
        public override bool PerformHealthCheck() => IsHealthy;
    }
}