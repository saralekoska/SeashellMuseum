using Microsoft.AspNetCore.Mvc;
using SeashellMuseumWeb.Data;
using SeashellMuseumWeb.Models;

namespace SeashellMuseumWeb.Controllers
{
    public class SeashellController : Controller
    {
        private readonly AppDbContext _db;
        public SeashellController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Seashell> objSeashellList = _db.Seashells;
            return View(objSeashellList);
        }
        //get
        public IActionResult Add()
        {
         
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Seashell obj)
        {
            if(obj.Name == obj.CommonName)
            {
                ModelState.AddModelError("name", "The Name cannot exactly match the Common Name");
            }
            if (ModelState.IsValid)
            {
                _db.Seashells.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Seashell added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var SeashellFromDb = _db.Seashells.Find(id);
            //var SeashellFromDbFirst = _db.Seashells.FirstOrDefault(u => u.Id == id);
            //var SeashellFromDbSingle = _db.Seashells.SingleOrDefault(u => u.Id == id);

            if(SeashellFromDb == null) { 
                return NotFound(); 
            }
            return View(SeashellFromDb);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Seashell obj)
        {
            if (obj.Name == obj.CommonName)
            {
                ModelState.AddModelError("name", "The Name cannot exactly match the Common Name");
            }
            if (ModelState.IsValid)
            {
                _db.Seashells.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Seashell updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //get
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SeashellFromDb = _db.Seashells.Find(id);

            if (SeashellFromDb == null)
            {
                return NotFound();
            }
            return View(SeashellFromDb);

        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Seashells.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Seashells.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Seashell deleted successfully";
            return RedirectToAction("Index");
            
            
        }
    }
}
