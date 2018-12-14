using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace passcode.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("num") == null)
            {
                HttpContext.Session.SetInt32("num", 1);
            }
            else{
                int count = HttpContext.Session.GetInt32("num").GetValueOrDefault();
                HttpContext.Session.SetInt32("num", count + 1);
            }
                ViewBag.num = HttpContext.Session.GetInt32("num");
                var chars = "QWERTYUIOPLKJHGFDSAZXCVBNM1234567890";
                var stringChars = new char[14];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                var finalString = new String(stringChars);
                HttpContext.Session.SetString("word", finalString);
                ViewBag.word = HttpContext.Session.GetString("word");
                return View();
        }

        [HttpPost("generate")]
        public IActionResult generate()
        {
            return RedirectToAction("Index");
        }

        [HttpPost("reset")]
        public IActionResult reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
