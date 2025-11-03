namespace ZooERP.Core.Models
{
    public abstract class Herbivore : Animal
    {
        public int KindnessLevel { get; set; }
        
        public bool CanBeInContactZoo => KindnessLevel > 5;
    }
}