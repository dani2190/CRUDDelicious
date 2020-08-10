using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDDelicious.Models;

namespace CRUDDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext {get; set;}
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            
            List<Dish> AllDishes = dbContext.Dishes.OrderByDescending(what => what.CreatedAt).ToList();
            return View(AllDishes);
        }
        [Route("new")]
        [HttpGet]
        public IActionResult NewDish()
        {
            return View();
        }
        [Route("process")]
        [HttpPost]
        public IActionResult Process(Dish NewDish)
        {
            if (!ModelState.IsValid)
            {
                return View("Newdish");
            }
            else
            {
                dbContext.Dishes.Add(NewDish);
                dbContext.SaveChanges();
                return Redirect("/");
            }
        }
        [Route("{dishId}")]
        [HttpGet]
        public IActionResult ViewDish(int dishId)
        {
            Dish ThisDish = dbContext.Dishes.FirstOrDefault(dish => dish.DiSId == dishId);
            return View(ThisDish);
        }
        [Route("delete/{dishId}")]
        [HttpGet]
        public IActionResult DeletDish(int dishId)
        {
            Dish ThisDish = dbContext.Dishes.FirstOrDefault(dish => dish.DiSId == dishId);
            dbContext.Dishes.Remove(ThisDish);
            dbContext.SaveChanges();
            return Redirect("/");
        }
        [Route("edit/{dishId}")]
        [HttpGet]
        public IActionResult EditDish(int dishId)
        {
            Dish ThisDish = dbContext.Dishes.FirstOrDefault(dish => dish. DiSId == dishId);
            return View(ThisDish);
        }


        public IActionResult Privacy()
        {
            return View();
        }
        [Route("Edit")]
        [HttpPost]
        public IActionResult Edit(Dish editdish)
        {
            if (!ModelState.IsValid)
            {
                return View("EditDish",editdish);
            }
            else
            {
                Dish ThisDish = dbContext.Dishes.FirstOrDefault(dish => dish.DiSId == editdish.DiSId);
                Console.WriteLine(editdish.DiSId);
                Console.WriteLine("editdish"+ editdish.DishName);
                Console.WriteLine("thisdish" + ThisDish.DishName);
                ThisDish.DishName = editdish.DishName;
                ThisDish.ChefName = editdish.ChefName;
                ThisDish.calories = editdish.calories;
                ThisDish.Tastiness = editdish.Tastiness;
                ThisDish.Description = editdish.Description;
                ThisDish.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return Redirect("/");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
