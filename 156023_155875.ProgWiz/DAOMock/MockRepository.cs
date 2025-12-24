using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CORE;
using INTERFACES;

namespace DAOMock
{
    public class Producer : IProducer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ClimbingShoe : IClimbingShoe
    {
        public int Id { get; set; }
        public int ProducerId { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public ClosureType Closure { get; set; }
    }

    public class DAOMock : IDataAccessObject
    {
        private List<IProducer> _producers;
        private List<IClimbingShoe> _shoes;

        public DAOMock()
        {
            _producers = new List<IProducer>
            {
                new Producer { Id = 1, Name = "La Sportiva" },
                new Producer { Id = 2, Name = "Scarpa" },
                new Producer { Id = 3, Name = "Ocun" }
            };

            _shoes = new List<IClimbingShoe>
            {
                new ClimbingShoe { Id = 1, ProducerId = 1, Name = "Solution", ProductionYear = 2018, Closure = ClosureType.Velcro },
                new ClimbingShoe { Id = 2, ProducerId = 1, Name = "Miura", ProductionYear = 2015, Closure = ClosureType.LaceUp },
                new ClimbingShoe { Id = 3, ProducerId = 2, Name = "Drago", ProductionYear = 2020, Closure = ClosureType.Velcro },
                new ClimbingShoe { Id = 4, ProducerId = 2, Name = "Instinct VS", ProductionYear = 2019, Closure = ClosureType.Velcro },
                new ClimbingShoe { Id = 5, ProducerId = 3, Name = "Ozone", ProductionYear = 2017, Closure = ClosureType.Slipper }
            };
        }

        public IEnumerable<IProducer> GetAllProducers() => _producers;
        public IEnumerable<IClimbingShoe> GetAllShoes() => _shoes;
    }
}
