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
        private readonly IWebHostEnvironment _env;
        public ContactController(DotNetContext context , IWebHostEnvironment env)
        {
            _context = context;
            _env = env ;
        }

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FormAsync(User_Vm vm_user)
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
                tbl_user.Status= false;

                if (vm_user.ImageFile != null)
                {
                    string FormatImage = Path.GetExtension(vm_user.ImageFile.FileName);
                    string ImageName = String.Concat(Guid.NewGuid().ToString(), FormatImage);
                    tbl_user.Image = ImageName ;

                    string path = $"{_env.WebRootPath}\\FileUpload\\{ImageName}";

                    FileStream stream = new FileStream(path, FileMode.Create);
                    vm_user.ImageFile.CopyToAsync(stream);
                }

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
                tbl_user.Status= false;

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
                Status = user_tbl.Status,
            };


            return View(vm_user);
        }

        public IActionResult UserInfo2()
        {
            var user_tbl = _context.Tbl_User.Where(n => n.Address == "sls").ToList();

            ViewBag.user = user_tbl;

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
                    ImageName = user.Image,
                    DateTime = user.DateTime.ToString(),
                    Status = user.Status,
                };
                user_lvm.Add(user_vm);
            }

            ViewBag.user = user_lvm;

            return View();
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var user = _context.Tbl_User.SingleOrDefault(u => u.Id == id);
                _context.Tbl_User.Remove(user);
                _context.SaveChanges();

                ViewBag.Tx = "OK";
            }
            catch (System.Exception ex)
            {
                ViewBag.Tx = "Er";
            }

            return RedirectToAction("UserInfo3");
        }
        public IActionResult EditStatus(int id)
        {
            try
            {
                var user = _context.Tbl_User.SingleOrDefault(u => u.Id == id);
                if (user.Status == true)
                {
                    user.Status = false;
                }
                else
                {
                    user.Status = true;
                }

                _context.Tbl_User.Update(user);
                _context.SaveChanges();

                ViewBag.Tx = "OK";
            }
            catch (System.Exception ex)
            {
                ViewBag.Tx = "Er";
            }

            return RedirectToAction("UserInfo3");
        }

    }
}