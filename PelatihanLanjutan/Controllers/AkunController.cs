using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PelatihanLanjutan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PelatihanLanjutan.Controllers
{
    public class AkunController : Controller
    {
        private readonly AppDbContext _context;

        public AkunController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Daftar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Daftar(User datanya)
        {
            var deklarrole = _context.Tb_Roles.Where(x => x.Id == "1").FirstOrDefault();

            datanya.Roles = deklarrole;

            _context.Add(datanya); //insert to tb user
            _context.SaveChanges(); //eksekusi

            return RedirectToAction("Masuk");
            // return RedirectToAction(ControllerName:Akun ActionName:Masuk);
            //return redirect("Masuk")
        }

        public IActionResult Masuk()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Masuk(User datanya)
        {
            var cari = _context.Tb_User.Where( //proses pencarian data
                                            bebas =>
                                            bebas.Username == datanya.Username
                                            &&
                                            bebas.Password == datanya.Password
                                            ).FirstOrDefault(); //hanya dapat 1 data

            var cariusername = _context.Tb_User.Where( //proses pencarian data
                                            bebas =>
                                            bebas.Username == datanya.Username
                                            ).FirstOrDefault();
            if (cariusername != null)
            {
                var cekpassword = _context.Tb_User.Where( //proses pengecekan username
                                            bebas =>
                                            bebas.Username == datanya.Username
                                            &&
                                            bebas.Password == datanya.Password
                                            )
                    .Include(bebas2 => bebas2.Roles)
                    .FirstOrDefault();

                if (cekpassword != null)
                {
                    //proses tampungan data
                    var daftar = new List<Claim>
                    {
                        new Claim("Username", cariusername.Username),
                        new Claim("Roles", cariusername.Roles.Id),
                    };

                    //proses daftar Auth
                    await HttpContext.SignInAsync(
                        new ClaimsPrincipal(
                            new ClaimsIdentity(daftar, "Cookies", "Username", "Role")
                        )
                    );

                    if (cariusername.Roles.Id == "1")
                    {
                        return RedirectToAction(controllerName: "Blog", actionName: "Index");
                    }

                    return RedirectToAction(controllerName: "Home", actionName: "Privacy");
                }
                ViewBag.pesan = "Password salah";
                return View(datanya);
            }
            ViewBag.pesan = "Username tidak terdaftar";
            return View(datanya); 
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
