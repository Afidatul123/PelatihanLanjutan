using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PelatihanLanjutan.Helper;
using PelatihanLanjutan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PelatihanLanjutan.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var banyakdata = new BlogDashBoard();
            banyakdata.blog = _context.Tb_Blog.Include(x => x.User).ToList();
            banyakdata.user = _context.Tb_User.Include(x => x.Roles).ToList();
            return View(banyakdata);
        }
        public IActionResult Create() //menampilkan kolom inputan(view)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog parameter) //menerima inputannya
        {
            if (ModelState.IsValid)
            {
                //proses masukan ke database
                //parameter.Id = BuatPrimary.buatPrimary() //ini dari helper(error karna pake integer)
                string nama = User.GetUsername();
                    parameter.User = _context.Tb_User.FirstOrDefault(x => x.Username == nama);
             

                _context.Add(parameter);
                await _context.SaveChangesAsync();

                return Redirect("Index");
            }
            return View(parameter);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cari = _context.Tb_Blog.Where(x => x.Id == id).FirstOrDefault();
            if (cari == null)
            {
                return NotFound();
            }

            _context.Tb_Blog.Remove(cari);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            var data = await _context.Tb_Blog.FirstOrDefaultAsync(a => a.Id == id);
            if(data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cari = await _context.Tb_Blog.FirstOrDefaultAsync(x => x.Id == id);
            if (cari== null)
            {
                return NotFound();
            }
            return View(cari);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Blog data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Tb_Blog.Update(data);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    return NotFound();
                }
                return RedirectToAction("Index");
            }
            return View(data);
        }
    }
}
