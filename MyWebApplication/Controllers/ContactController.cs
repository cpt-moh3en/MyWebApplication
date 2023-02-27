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

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Form(User_Vm vm_user)
        {
            try
            {
                User tbl_user = new User();
                tbl_user.Name = vm_user.Name;
                tbl_user.Family = vm_user.Family;
                tbl_user.Age = vm_user.Age;
                tbl_user.PhoneNumber = vm_user.PhoneNumber;
                tbl_user.Address = vm_user.Address;
                tbl_user.DateTime = DateTime.Now;

                _context.Tbl_User.Add(tbl_user);

                _context.SaveChanges();

                ViewBag.tx = "Ok";

            }
            catch (System.Exception ex)
            {
                ViewBag.tx = "Error";
            }

            return View();
        }

        public IActionResult Add(User_Vm vm_user)
        {
            try
            {
                User tbl_user = new User();
                tbl_user.Name = vm_user.Name;
                tbl_user.Family = vm_user.Family;
                tbl_user.Age = vm_user.Age;
                tbl_user.PhoneNumber = vm_user.PhoneNumber;
                tbl_user.Address = vm_user.Address;
                tbl_user.DateTime = DateTime.Now;

                _context.Tbl_User.Add(tbl_user);

                _context.SaveChanges();

                ViewBag.tx = "Ok";

            }
            catch (System.Exception ex)
            {
                ViewBag.tx = "Error";
            }

            return View();

            // return RedirectToAction("Index");
            // return View("Index");
        }

        public IActionResult UserInfo()
        {
            var user_tbl = _context.Tbl_User.SingleOrDefault(i => i.Age == 16 && i.Name == "sana");
            
            User_Vm vm_user = new User_Vm
            {
                Id = user_tbl.Id,
                Name = user_tbl.Name,
                Family = user_tbl.Family,
                Age = user_tbl.Age,
                PhoneNumber = user_tbl.PhoneNumber,
                Address = user_tbl.Address,
                DateTime = user_tbl.DateTime.ToString(),
            };


            return View(vm_user);
        }

        public IActionResult UserInfo2()
        {
            var user_tbl = _context.Tbl_User.Where(n => n.Address == "sls").ToList();

            ViewBag.user = user_tbl ;

            return View();
        }

        public IActionResult UserInfo3()
        {
            var user_tbl = _context.Tbl_User.OrderBy(i => i.Id).Skip(2).Take(4).ToList();

            List<User_Vm> user_lvm = new List<User_Vm>();

            foreach (var user in user_tbl)
            {
                User_Vm user_vm = new User_Vm
                {
                    Id = user.Id,
                    Name = user.Name,
                    Family = user.Family,
                    Age = user.Age,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    DateTime = user.DateTime.ToString(),
                };
                user_lvm.Add(user_vm);
            }

            ViewBag.user = user_lvm ;

            return View();
        }

    }
}