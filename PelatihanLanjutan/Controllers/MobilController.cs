using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PelatihanLanjutan.Models;

namespace PelatihanLanjutan.Controllers
{
    public class MobilController : Controller
    {
        public IActionResult Index()
        {
            //cara deklarasi
            //var mobils = new List<Mobil>();

            //IEnumerable<Mobil> mobils2 = new List<Mobil>();
            //List<Mobil> mobils3 = new List<Mobil>();

            //mobils.Add(new Mobil
            //{
            //    IDRegistrasi = 1,
            //    Tipe = "sedan",
            //    Merk = "Toyota",
            //    Varian = "Apple",
            //});

            //mobils.Add(new Mobil
            //{
            //    IDRegistrasi = 2,
            //    Tipe = "Bus",
            //    Merk = "Tayo",
            //    Varian = "Biru",
            //});

            //string nama = "Afida";
            //ViewBag.namaSaya = nama;
            //ViewBag.mobils = mobils;
            //ViewData["nama"] = "Afidatul";

            var banyakMobil = new Mobil[]
            {
                new Mobil{IDRegistrasi= 1, Tipe="Sedan", Merk="Toyota", Varian="Blue"},
                new Mobil{IDRegistrasi= 2, Tipe="SUV", Merk="Honda", Varian="Black"},
                new Mobil{IDRegistrasi= 3, Tipe="Sedan", Merk="BMW", Varian="red"},
                new Mobil{IDRegistrasi= 4, Tipe="SUV", Merk="Toyota", Varian="Yellow"},
                new Mobil{IDRegistrasi= 5, Tipe="Sedan", Merk="Honda", Varian="Grey"},
            };

            //var cariMobil = banyakMobil.Where(r => r.Tipe == "Sedan");
            

            ViewBag.mobils = banyakMobil.Where(r => r.Merk == "Honda").FirstOrDefault();

            return View(banyakMobil);
        }
    }
}
