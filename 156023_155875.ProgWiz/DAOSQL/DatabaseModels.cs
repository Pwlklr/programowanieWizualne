using _156023_155875.ProgWiz.CORE;
using _156023_155875.ProgWiz.INTERFACES;

namespace _156023_155875.ProgWiz.DAOSQL
{
    public class ProducerEntity : IProducer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ShoeEntity : IClimbingShoe
    {
        public int Id { get; set; }
        public int ProducerId { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public double Size { get; set; }
        public ClosureType Closure { get; set; }
    }
}