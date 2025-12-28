using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;
using _156023_155875.ProgWiz.INTERFACES;

namespace _156023_155875.ProgWiz.DAOSQL
{
    public class DAOSQL : IDataAccessObject
    {
        public DAOSQL()
        {
            using (var ctx = new KatalogContext())
            {
                ctx.Database.EnsureCreated();
            }
        }

        public void AddProducer(IProducer producer)
        {
            using (var ctx = new KatalogContext())
            {
                ctx.Producers.Add(new ProducerEntity { Name = producer.Name });
                ctx.SaveChanges();
            }
        }

        public void AddShoe(IClimbingShoe shoe)
        {
            using (var ctx = new KatalogContext())
            {
                ctx.Shoes.Add(new ShoeEntity
                {
                    ProducerId = shoe.ProducerId,
                    Name = shoe.Name,
                    ProductionYear = shoe.ProductionYear,
                    Size = shoe.Size,
                    Closure = shoe.Closure
                });
                ctx.SaveChanges();
            }
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            using (var ctx = new KatalogContext())
            {
                return ctx.Producers.ToList();
            }
        }

        public IEnumerable<IClimbingShoe> GetAllShoes()
        {
            using (var ctx = new KatalogContext())
            {
                return ctx.Shoes.ToList();
            }
        }

        public void RemoveShoe(int id)
        {
            using (var ctx = new KatalogContext())
            {
                var item = ctx.Shoes.FirstOrDefault(x => x.Id == id);
                if (item != null)
                {
                    ctx.Shoes.Remove(item);
                    ctx.SaveChanges();
                }
            }
        }
        public void UpdateShoe(IClimbingShoe shoe)
        {
            using (var ctx = new KatalogContext())
            {
                var entity = ctx.Shoes.FirstOrDefault(s => s.Id == shoe.Id);
                if (entity != null)
                {
                    entity.Name = shoe.Name;
                    entity.Size = shoe.Size;
                    entity.Closure = shoe.Closure;
                    entity.ProductionYear = shoe.ProductionYear;
                    entity.ProducerId = shoe.ProducerId;

                    ctx.SaveChanges();
                }
            }
        }
    }
}