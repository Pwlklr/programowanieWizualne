using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _156023_155875.ProgWiz.CORE;

namespace _156023_155875.ProgWiz.INTERFACES
{
    public interface IClimbingShoe
    {
        int Id { get; set; }
        int ProducerId { get; set; }
        string Name { get; set; }
        int ProductionYear { get; set; }
        double Size { get; set; }
        ClosureType Closure { get; set; }
    }
}