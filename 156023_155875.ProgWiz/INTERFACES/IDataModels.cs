using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE;

namespace INTERFACES
{
    public interface IProducer
    {
        int Id { get; set; }
        string Name { get; set; }
    }

    public interface IClimbingShoe
    {
        int Id { get; set; }
        int ProducerId { get; set; }
        string Name { get; set; }
        int ProductionYear { get; set; }
        ClosureType Closure { get; set; }
    }

    public interface IDataAccessObject
    {
        IEnumerable<IProducer> GetAllProducers();
        IEnumerable<IClimbingShoe> GetAllShoes();
    }
}