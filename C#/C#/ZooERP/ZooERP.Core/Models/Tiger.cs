namespace ZooERP.Core.Models
{
    public class Tiger : Predator
    {
        public override bool PerformHealthCheck() => IsHealthy && Food > 3;
    }
}