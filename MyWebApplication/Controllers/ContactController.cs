using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models.Context;
using MyWebApplication.Models.Entities;
using MyWebApplication.Models.ViewModels;

namespace MyWebApplication.Controllers
{
    public class ContactController : Controller
    {
        private readonly DotNetContext _context;
        public ContactController(DotNetContext context)
        {
            _context = context;
        }
        public IActionResult Form()
        {
            return View();
        }

        public IActionResult AddToForm(User_Vm vm_user)
        {
            User tbl_user = new User();
            tbl_user.Name = vm_user.Name ;
            tbl_user.Family = vm_user.Family ;
            tbl_user.Age = vm_user.Age ;
            tbl_user.PhoneNumber = vm_user.PhoneNumber ;
            tbl_user.Address = vm_user.Address ;
            // tbl_user.Image = "ABC" ;
            tbl_user.DateTime = DateTime.Now ;

            _context.Add(tbl_user);
            _context.SaveChanges();
            
            return View();
        }

    }
}