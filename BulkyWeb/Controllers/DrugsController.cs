using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class DrugsController : Controller
    {
        private readonly IDrugsRepository _drugsRepo;
        public DrugsController(IDrugsRepository db)
        {
            _drugsRepo = db;
        }
        public IActionResult Index()
        {
            List<Drugs> objDrugsList = _drugsRepo.GetAll().ToList();
            //List<Category> objCategoryList = _db.Categories.ToList();
            return View(objDrugsList);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Drugs obj)
        {
           
            if (ModelState.IsValid)
            {
                _drugsRepo.Add(obj);
                _drugsRepo.Save();
                //_db.SaveChanges();
                TempData["success"] = "Drug created successfully";
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Drugs? drugsFromDb = _drugsRepo.Get(u => u.Batch_Id == Id);

            // Category? categoryFromDb = _db.Categories.Find(id); // it only work with the primary key 
            // Category? categoryFromDb2 = _db.Categories.FirstOrDefault(u=>u.Id==id); // it can work with any condition

            if (drugsFromDb == null)
            {
                return NotFound();
            }
            return View(drugsFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Drugs obj)
        {


            if (ModelState.IsValid)
            {
                _drugsRepo.Update(obj);
                //_db.Categories.Update(obj);

                _drugsRepo.Save();
                TempData["success"] = "Drugs updated successfully";
                return RedirectToAction("Index");
            }

            return View();

        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Drugs? drugsFromDb = _drugsRepo.Get(u => u.Batch_Id == Id);


            if (drugsFromDb == null)
            {
                return NotFound();
            }
            return View(drugsFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? Id)
        {
            Drugs? obj = _drugsRepo.Get(u => u.Batch_Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            _drugsRepo.Remove(obj);
            _drugsRepo.Save();
            TempData["success"] = "Drugs deleted successfully";
            return RedirectToAction("Index");



        }
        public IDrugsRepository Get_drugsRepo()
        {
            return _drugsRepo;
        }

        [HttpGet]
        public IActionResult Searching(string SearchTerm)
        {
            return View(_drugsRepo.Search(SearchTerm));

        }


    }
}
