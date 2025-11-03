namespace ZooERP.Core.Models
{
    public class Rabbit : Herbivore
    {
        public override bool PerformHealthCheck() => IsHealthy && Food > 0;
    }
}