using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _156023_155875.ProgWiz.CORE;
using _156023_155875.ProgWiz.INTERFACES;

namespace _156023_155875.ProgWiz.BL
{
    public class ShoeViewModel : ViewModelBase
    {
        private readonly IClimbingShoe _shoe;
        public int Id => _shoe.Id;

        public ShoeViewModel(IClimbingShoe shoe)
        {
            _shoe = shoe;
        }

        public string Name
        {
            get => _shoe.Name;
            set
            {
                _shoe.Name = value;
                OnPropertyChanged();
            }
        }

        public double Size
        {
            get => _shoe.Size;
            set { _shoe.Size = value; OnPropertyChanged(); }
        }

        public ClosureType Closure
        {
            get => _shoe.Closure;
            set { _shoe.Closure = value; OnPropertyChanged(); }
        }
        public IClimbingShoe GetModel()
        {
            return _shoe;
        }

        public int ProducerId => _shoe.ProducerId;
    }
}