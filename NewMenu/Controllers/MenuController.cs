using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewMenu.Models;
using Dapper.Contrib.Extensions;
using Dapper;

namespace NewMenu.Controllers
{
    public class MenuController : Controller
    {
        static MySqlConnection db = new MySqlConnection("Server=localhost;Database=newmenu;Uid=root;Password=abc123");
        public IActionResult Index()
        {
            List<Menu> item = db.GetAll<Menu>().ToList(); 
            return View(item);
        }
        
        // Create needs 2 actions: One gives back the form, the other adds them to the table. 
        public IActionResult CreateItem()
        {
            return View();
        }

        
        public IActionResult Create(Menu item)
        {
            db.Insert(item);
            return RedirectToAction("Index");
        }
        public IActionResult edititem(int id)  // Allows you to edit the people inside the list information
        {
            // return Content(id.ToString()); This returns the number on the list when you click on edit
            Menu item = db.Get<Menu>(id);
            return View(item);
        }


        public IActionResult edit(Menu item) // Once you hit save button this code runs
        {
            bool s = db.Update(item);
            // Need to Update
            return RedirectToAction("Index");
        }

        
        public IActionResult deleteitem(int id)
        {
            return View(id);
        }

        public IActionResult delete(int id)
        {
            Menu item = db.Get<Menu>(id);
            db.Delete<Menu>(item);
            return RedirectToAction("index");
        }
    }
}
