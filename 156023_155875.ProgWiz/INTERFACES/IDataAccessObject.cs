using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace _156023_155875.ProgWiz.INTERFACES
{
    public interface IDataAccessObject
    {
        IEnumerable<IProducer> GetAllProducers();
        IEnumerable<IClimbingShoe> GetAllShoes();

        void AddShoe(IClimbingShoe shoe);
        void RemoveShoe(int id);
        void AddProducer(IProducer producer);
    }
}