using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using _156023_155875.ProgWiz.CORE;
using _156023_155875.ProgWiz.INTERFACES;

namespace _156023_155875.ProgWiz.DAOMock
{
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
        public void AddShoe(IClimbingShoe shoe)
        {
            // Symulacja auto-inkrementacji ID
            int newId = _shoes.Any() ? _shoes.Max(s => s.Id) + 1 : 1;
            shoe.Id = newId;
            _shoes.Add(shoe);
        }

        public void RemoveShoe(int id)
        {
            var shoeToRemove = _shoes.FirstOrDefault(s => s.Id == id);
            if (shoeToRemove != null)
            {
                _shoes.Remove(shoeToRemove);
            }
        }

        public void AddProducer(IProducer producer)
        {
            int newId = _producers.Any() ? _producers.Max(p => p.Id) + 1 : 1;
            producer.Id = newId;
            _producers.Add(producer);
        }
    }
}