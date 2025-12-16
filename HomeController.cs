using DemoProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    public class HomeController : Controller
    {
        InventoryViewModel ivm = new InventoryViewModel();
        public IActionResult Index()
        {
            List<Inventory> inventory = ivm.GetInventory();
            return View(inventory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                ivm.AddInventory(inventory);
                return Redirect("/Home/Index");
            }
            else
            {
                ViewBag.Message = "Something is not right with data";
                return View(inventory);
            }
        }
        public IActionResult Edit(int id)
        {
            Inventory inventory = ivm.GetInventory(id);
            return View(inventory);
        }

        [HttpPost]
        public IActionResult Edit(Inventory updateInventory)
        {
            if (ModelState.IsValid)
            {
                int rowsAffected = ivm.UpdateInventory(updateInventory);
                if(rowsAffected > 0)
                {
                    return Redirect("/Home/Index");
                }
                else
                {
                    ViewBag.Message = "Data Not Updated";
                    return View(updateInventory);

                }
            }
            else
            {
                ViewBag.Message = "Something is not right about data";
                return View(updateInventory);
            }
        }

        public IActionResult Delete(int id)
        {
            ivm.RemoveInventory(id);
            return Redirect("/Home/Index");
        }

    }
}
