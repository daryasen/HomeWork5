namespace ZooERP.Core.Models
{
    public class Wolf : Predator
    {
        public override bool PerformHealthCheck() => IsHealthy && Food > 2;
    }
}