using System;
using MyWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MyWebApplication.Models.ViewModels;

namespace MyWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            string text = "Asp .Net Core" ;
            ViewBag.tx = text;
            
            return View();
        }
        
        public IActionResult Blog()
        {
            User_Vm user = new User_Vm();
            user.Id = 7 ;
            user.Name = "Mohsen";
            user.Family = "Pashaei";
            user.PhoneNumber = "09227241678";
            user.Age = 24 ;
            user.DateTime = "1378/10/01";

            return View(user);
        }
        
        public IActionResult About()
        {
            User_Vm user1 = new User_Vm();
            user1.Id = 10 ;
            user1.Name = "Asma";
            user1.Family = "Ngz";
            user1.Age = 17 ;

            User_Vm user2 = new User_Vm();
            user2.Id = 15 ;
            user2.Name = "Sana";
            user2.Family = "Dsn";
            user2.Age = 16 ;

            User_Vm user3 = new User_Vm();
            user3.Id = 17 ;
            user3.Name = "Mohsen";
            user3.Family = "pse";
            user3.Age = 24 ;

            List<User_Vm> user_list = new List<User_Vm>{user1 , user2 , user3};

            // List<User_Vm> user = new List<User_Vm>();
            // user.Add(user1);
            // user.Add(user2);
            // user.Add(user3);

            ViewBag.User = user_list ;

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
