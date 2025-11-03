namespace ZooERP.Core.Models
{
    public class Monkey : Herbivore
    {
        public override bool PerformHealthCheck() => IsHealthy && Food > 1;
    }
}