using Microsoft.AspNetCore.Mvc;
using _156023_155875.ProgWiz.INTERFACES;
using _156023_155875.ProgWiz.CORE;
using _156023_155875.ProgWiz.DAOSQL; 

namespace _156023_155875.ProgWiz.WEB.Controllers
{
    public class ShoeController : Controller
    {
        private readonly IDataAccessObject _dao;

        public ShoeController(IDataAccessObject dao)
        {
            _dao = dao;
        }

        public IActionResult Index()
        {
            var shoes = _dao.GetAllShoes();
            ViewBag.Producers = _dao.GetAllProducers();
            return View(shoes);
        }

        public IActionResult Create()
        {
            ViewBag.Producers = _dao.GetAllProducers();
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, int size, int year, int producerId, ClosureType closure)
        {
            var newShoe = new ShoeEntity
            {
                Name = name,
                Size = size,
                ProductionYear = year,
                ProducerId = producerId,
                Closure = closure
            };

            _dao.AddShoe(newShoe);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _dao.RemoveShoe(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var shoe = _dao.GetAllShoes().FirstOrDefault(s => s.Id == id);

            if (shoe == null) return NotFound();

            ViewBag.Producers = _dao.GetAllProducers();
            return View(shoe); 
        }

        [HttpPost]
        public IActionResult Edit(int id, string name, int size, int year, int producerId, ClosureType closure)
        {
            var updatedShoe = new ShoeEntity
            {
                Id = id,
                Name = name,
                Size = size,
                ProductionYear = year,
                ProducerId = producerId,
                Closure = closure
            };

            _dao.UpdateShoe(updatedShoe);

            return RedirectToAction("Index");
        }
    }



}