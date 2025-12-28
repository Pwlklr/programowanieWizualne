using Microsoft.AspNetCore.Mvc;
using _156023_155875.ProgWiz.INTERFACES;
using _156023_155875.ProgWiz.DAOSQL; 

namespace _156023_155875.ProgWiz.WEB.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IDataAccessObject _dao;

        public ProducerController(IDataAccessObject dao)
        {
            _dao = dao;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var newProducer = new ProducerEntity
                {
                    Name = name
                };

                _dao.AddProducer(newProducer);
            }

            return RedirectToAction("Index", "Shoe");
        }
    }
}