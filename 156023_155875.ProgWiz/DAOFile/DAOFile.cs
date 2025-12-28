using System.Text.Json;
using _156023_155875.ProgWiz.CORE;
using _156023_155875.ProgWiz.INTERFACES;

namespace _156023_155875.ProgWiz.DAOFile
{
    public class FileProducer : IProducer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FileShoe : IClimbingShoe
    {
        public int Id { get; set; }
        public int ProducerId { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public ClosureType Closure { get; set; }
        public int Size { get; set; }
    }

    internal class DataStore
    {
        public List<FileProducer> Producers { get; set; } = new();
        public List<FileShoe> Shoes { get; set; } = new();
    }

    public class DAOFile : IDataAccessObject
    {
        private const string FilePath = "katalog_data.json";
        private DataStore _store;

        public DAOFile()
        {
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                _store = JsonSerializer.Deserialize<DataStore>(json) ?? new DataStore();
            }
            else
            {
                _store = new DataStore();
                _store.Producers.Add(new FileProducer { Id = 1, Name = "La Sportiva (File)" });
            }
        }

        private void SaveData()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(_store, options);
            File.WriteAllText(FilePath, json);
        }

        public void AddProducer(IProducer producer)
        {
            int newId = _store.Producers.Any() ? _store.Producers.Max(p => p.Id) + 1 : 1;
            _store.Producers.Add(new FileProducer { Id = newId, Name = producer.Name });
            SaveData();
        }

        public void AddShoe(IClimbingShoe shoe)
        {
            int newId = _store.Shoes.Any() ? _store.Shoes.Max(s => s.Id) + 1 : 1;
            _store.Shoes.Add(new FileShoe
            {
                Id = newId,
                ProducerId = shoe.ProducerId,
                Name = shoe.Name,
                ProductionYear = shoe.ProductionYear,
                Closure = shoe.Closure,
                Size = shoe.Size
            });
            SaveData();
        }

        public IEnumerable<IProducer> GetAllProducers() => _store.Producers;

        public IEnumerable<IClimbingShoe> GetAllShoes() => _store.Shoes;

        public void RemoveShoe(int id)
        {
            var item = _store.Shoes.FirstOrDefault(s => s.Id == id);
            if (item != null)
            {
                _store.Shoes.Remove(item);
                SaveData();
            }
        }

        public void UpdateShoe(IClimbingShoe shoe)
        {
            var existing = _store.Shoes.FirstOrDefault(s => s.Id == shoe.Id);
            if (existing != null)
            {
                existing.Name = shoe.Name;
                existing.Size = shoe.Size;
                existing.ProductionYear = shoe.ProductionYear;
                existing.Closure = shoe.Closure;
                existing.ProducerId = shoe.ProducerId;
                SaveData();
            }
        }
    }
}