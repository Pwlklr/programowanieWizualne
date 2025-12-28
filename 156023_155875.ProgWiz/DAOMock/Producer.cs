using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _156023_155875.ProgWiz.INTERFACES;

namespace _156023_155875.ProgWiz.DAOMock
{
    public class Producer : IProducer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}