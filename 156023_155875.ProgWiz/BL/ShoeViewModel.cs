using System;
using System.ComponentModel;
using _156023_155875.ProgWiz.INTERFACES;
using _156023_155875.ProgWiz.CORE;

namespace _156023_155875.ProgWiz.BL
{
    public class ShoeViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IClimbingShoe _shoe;

        public ShoeViewModel(IClimbingShoe shoe)
        {
            _shoe = shoe;
        }

        public int Id => _shoe.Id;
        public int ProducerId
        {
            get => _shoe.ProducerId;
            set
            {
                _shoe.ProducerId = value;
                OnPropertyChanged();
            }
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
            set
            {
                _shoe.Size = value;
                OnPropertyChanged();
            }
        }

        public int ProductionYear
        {
            get => _shoe.ProductionYear;
            set
            {
                _shoe.ProductionYear = value;
                OnPropertyChanged();
            }
        }

        public ClosureType Closure
        {
            get => _shoe.Closure;
            set
            {
                _shoe.Closure = value;
                OnPropertyChanged();
            }
        }

        public IClimbingShoe GetModel() => _shoe;

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                string result = null;

                if (columnName == "Name")
                {
                    if (string.IsNullOrWhiteSpace(Name))
                        result = "Nazwa jest wymagana.";
                    else if (Name.Length < 3)
                        result = "Nazwa musi mieć min. 3 znaki.";
                }

                if (columnName == "ProductionYear")
                {
                    if (ProductionYear < 1900 || ProductionYear > DateTime.Now.Year + 1)
                        result = "Podaj poprawny rok produkcji.";
                }

                if (columnName == "Size")
                {
                    if (Size < 30 || Size > 50)
                        result = "Rozmiar spoza zakresu (30-50).";
                }

                return result;
            }
        }
    }
}