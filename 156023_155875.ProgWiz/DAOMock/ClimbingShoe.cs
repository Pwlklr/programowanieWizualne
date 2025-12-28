using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _156023_155875.ProgWiz.CORE;
using _156023_155875.ProgWiz.INTERFACES;

namespace _156023_155875.ProgWiz.DAOMock
{
    public class ClimbingShoe : IClimbingShoe
    {
        public int Id { get; set; }
        public int ProducerId { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public double Size { get; set; }
        public ClosureType Closure { get; set; }
    }
}