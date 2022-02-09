using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCourse.Data;
using MyCourse.Models;
using MyCourse.ViewModels;

namespace MyCourse.Controllers
{
    public class ItemController : Controller
    {

        private readonly AppDbContext mydb;
        public ItemController(AppDbContext db)
        {
            mydb = db;
        }
        public IActionResult Index(string searchphrase)
        {
            //IEnumerable<Item> brandsList = mydb.Items.Include("Category");

            List<Item> brands = new List<Item>();
            if (searchphrase == null)
            {
                brands = mydb.Items.ToList();
            }
            else
            {
                brands = mydb.Items.Where(k => k.borrower.Contains(searchphrase)).ToList();
            }
            foreach (var item in brands)
            {
                item.Category = mydb.Category.Where(u => u.id == item.categoryId).FirstOrDefault();
            }
            return View("Index" ,brands);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            ItemVM itemvm = new ItemVM();
            itemvm.item = new Item();
            ViewData["dropdown"] = mydb.Category.Select(i => new SelectListItem
            {
                Text = i.category,
                Value = i.id.ToString()
            });
            return View(itemvm);
        }

        [HttpPost]
        public ActionResult Create(ItemVM viewitm)
        {

            if (ModelState.IsValid)
            {
                mydb.Items.Add(viewitm.item);
                mydb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewitm);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var currentItem = mydb.Items.Where(x => x.id == id).FirstOrDefault();

            ViewData["dropdown"] = mydb.Category.Select(i => new SelectListItem
            {
                Text = i.category,
                Value = i.id.ToString()
            });

            return View(currentItem);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Item itm ,int id)
        {
            var todelete = mydb.Items.Where(x => x.id == id).FirstOrDefault();
            if(mydb.Items.Contains(todelete))
            {
                if(ModelState.IsValid)
                {
                    mydb.Items.Remove(todelete);
                    mydb.Items.Add(itm);
                    mydb.SaveChanges();
                } else
                {
                    return View();
                }
            }
            return RedirectToAction("Index","Item");
        }

        public ActionResult Details(Item it)
        {
            var res = mydb.Items.Where(x=>x.id == it.id).FirstOrDefault();
            if(res == null)
            {
                return View(it);
            } else
            {
                return View(res);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if(id == 0 || id == null)
            {
                return NotFound();
            } else
            {
                var item = mydb.Items.Find(id);
                if (item == null)
                { 
                    return View(null);
                }
                return View(item);
            }
        }


        [HttpPost]
        [Authorize]
        public ActionResult Delete(Item it)
        {
            if (it == null)
            {
                return RedirectToAction("Index", "Item");
            } else 
            {
                var todelete = mydb.Items.Where(x => x.id == it.id).First();
                mydb.Remove(todelete);
                mydb.SaveChanges();
                return RedirectToAction("Index", "Item");
            }
            return View();
        }

        public ActionResult Search(string searchphrase)
        {
            mydb.Items.Where(k => k.itemname == searchphrase).ToList();
            return RedirectToAction("Index", "Item");
        }
    }
}

