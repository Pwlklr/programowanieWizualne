using _156023_155875.ProgWiz.INTERFACES;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Producers = _dao.GetAllProducers();
            return View(new WebShoeDto()); 
        }

        [HttpPost]
        public IActionResult Create(WebShoeDto model)
        {
            if (ModelState.IsValid)
            {
                _dao.AddShoe(model);
                return RedirectToAction("Index");
            }

            ViewBag.Producers = _dao.GetAllProducers();

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _dao.RemoveShoe(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var shoeFromDb = _dao.GetAllShoes().FirstOrDefault(s => s.Id == id);

            if (shoeFromDb == null) return NotFound();

            var model = new WebShoeDto
            {
                Id = shoeFromDb.Id,
                Name = shoeFromDb.Name,
                Size = shoeFromDb.Size,
                ProductionYear = shoeFromDb.ProductionYear,
                ProducerId = shoeFromDb.ProducerId,
                Closure = shoeFromDb.Closure
            };

            ViewBag.Producers = _dao.GetAllProducers();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(WebShoeDto model)
        {
            if (ModelState.IsValid)
            {
                _dao.UpdateShoe(model);
                return RedirectToAction("Index");
            }

            ViewBag.Producers = _dao.GetAllProducers();
            return View(model);
        }
    }
}