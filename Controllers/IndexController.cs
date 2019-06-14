using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace dojoGatchi.Controllers
{
    public class IndexController : Controller
    {
        public static Gatchi dojogatchi = new Gatchi();

        [HttpGet("")]
        public IActionResult Index() {
            ViewBag.message = TempData["msg"];
            ViewBag.happiness = dojogatchi.happiness;
            ViewBag.fullness = dojogatchi.fullness;
            ViewBag.energy = dojogatchi.energy;
            ViewBag.meals = dojogatchi.meals;
            return View();
        }

        [HttpGet("dojogatchi/{act}")]
        public IActionResult Action(string act) {
            if (act == "feed") {
                TempData["msg"] = dojogatchi.Feed();
            }
            else if (act == "play") {
                TempData["msg"] = dojogatchi.Play();
            }
            else if (act == "work") {
                TempData["msg"] = dojogatchi.Work();
            }
            else if (act == "sleep") {
                TempData["msg"] = dojogatchi.Sleep();
            }
            if (dojogatchi.energy <= 0)
            {
                TempData["msg"] = "Your dojogatchi died from lack of energy!";
                return RedirectToAction("Done");
            }
            else if (dojogatchi.happiness <= 0)
            {
                TempData["msg"] = "Your dojogatchi died from unhappiness!";
                return RedirectToAction("Done");
            }
            else if (dojogatchi.fullness <= 0)
            {
                TempData["msg"] = "Your dojogatchi died from starvation!";
                return RedirectToAction("Done");
            }
            else if (dojogatchi.happiness > 99 && dojogatchi.energy > 99 && dojogatchi.fullness > 99)
            {
                TempData["msg"] = "Your dojogatchi loves you. You win forever!";
                return RedirectToAction("Wingame");
            }
            return RedirectToAction("Index");
        }

        [HttpGet("done")]
        public IActionResult Done() {
            ViewBag.message = TempData["msg"];
            ViewBag.happiness = dojogatchi.happiness;
            ViewBag.fullness = dojogatchi.fullness;
            ViewBag.energy = dojogatchi.energy;
            ViewBag.meals = dojogatchi.meals;
            return View();
        }

        [HttpGet("wingame")]
        public IActionResult Wingame() {
            ViewBag.message = TempData["msg"];
            ViewBag.happiness = dojogatchi.happiness;
            ViewBag.fullness = dojogatchi.fullness;
            ViewBag.energy = dojogatchi.energy;
            ViewBag.meals = dojogatchi.meals;
            return View();
        }

        [HttpGet("reset")]
        public IActionResult Reset() {
            dojogatchi = new Gatchi();
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}