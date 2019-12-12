using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext DbContext;
        public HomeController(MyContext context){
            DbContext=context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("user/new")]
        public IActionResult registration(User newUser){
            if(ModelState.IsValid){
                if(DbContext.Users.Any(user => user.Email==newUser.Email)){
                    ModelState.AddModelError("Email","Not today");
                    return View("Index");
                }
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, newUser.Password);
                DbContext.Add(newUser);
                DbContext.SaveChanges();
                HttpContext.Session.SetInt32("userId", newUser.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }
        [HttpPost("user/login")]
        public IActionResult Login(Login userlog){
            if(ModelState.IsValid){
                var userInDb = DbContext.Users.FirstOrDefault(user => user.Email==userlog.LoginEmail);
                if(userInDb==null){
                    ModelState.AddModelError("LoginEmail","Not today");
                    return View("Index");
                }
                var hasher = new PasswordHasher<Login>();
                var result = hasher.VerifyHashedPassword(userlog, userInDb.Password, userlog.LoginPassword);
                if(result==0){
                    ModelState.AddModelError("LoginEmail","Not today");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("userId", userInDb.UserId);
                return RedirectToAction("Dashboard");
            }else{
                return View("Index");
            }
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            List<Wedding> allWeddings = DbContext.Weddings
            .Include(guest => guest.WeddingsToAttend)
            .ToList();
            ViewBag.UserId = HttpContext.Session.GetInt32("userId");
            return View(allWeddings);
        }

        [HttpPost("wedding/delete/{weddingId}")]
        public IActionResult delete(int weddingId){
            Wedding weddingToDelete = DbContext.Weddings.FirstOrDefault(wed => wed.WeddingId==weddingId);
            DbContext.Remove(weddingToDelete);
            DbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("new")]
        public IActionResult NewWedding()
        {
            return View();
        }

        [HttpPost("new/wedding")]
        public IActionResult NewWeddingCreated(Wedding newWedding){
            if(ModelState.IsValid){
                var userFromDb = DbContext.Users.FirstOrDefault(u => u.UserId==HttpContext.Session.GetInt32("userId"));
                newWedding.Creator = userFromDb;
                newWedding.UserId = userFromDb.UserId;
                DbContext.Add(newWedding);
                DbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("NewWedding");
        }

        [HttpGet("show/{weddingId}")]
        public IActionResult OneWedding(int weddingId)
        {
            var oneWedding = DbContext.Weddings
            .Include(r => r.WeddingsToAttend)
            .ThenInclude(r => r.user)
            .FirstOrDefault(wed => wed.WeddingId==weddingId);
            return View(oneWedding);
        }

        [HttpPost("wedding/rsvp/{weddingId}")]
        public IActionResult rsvp(int weddingId){
            RSVP weddingToRsvp = DbContext.RSVPs
            .Where(wed => wed.WeddingId==weddingId).FirstOrDefault(user => user.UserId == HttpContext.Session.GetInt32("userId"));
            if(weddingToRsvp==null){
                RSVP rsvp = new RSVP();
                rsvp.WeddingId = weddingId;
                rsvp.UserId = (int)HttpContext.Session.GetInt32("userId");
                DbContext.Add(rsvp);
                DbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else {
                DbContext.Remove(weddingToRsvp);
                DbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }


        [HttpGet("logout")]
        public IActionResult logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }



        // public IActionResult Privacy()
        // {
        //     return View();
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
