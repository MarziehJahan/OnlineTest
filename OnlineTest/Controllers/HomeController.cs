using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTest.Models;
using Test.DAL;

namespace OnlineTest.Controllers
{
    public class HomeController : Controller
    {
        TestContext ctx = new TestContext();
        public IActionResult Index()
        {
            AddAnswerViewModel model = new AddAnswerViewModel();
            model.choices = ctx.choices.Include(a=>a.question).ToList();
            model.Questions = ctx.Questions.ToList();
            return View(model);
        }
        public IActionResult AddUser(UserViewModel user)
        {
            ViewBag.Data = user.Username;
            AddAnswerViewModel addModel = new AddAnswerViewModel();
            addModel.Username = user.Username;
            addModel.choices = ctx.choices.Include(a => a.question).ToList();
            addModel.Questions = ctx.Questions.ToList();
            if (ctx.Users.Any(a => a.Username == user.Username))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ctx.Users.Add(new User()
                {
                    Username = user.Username,
                    Name = user.Name,
                    Age = user.Age
                });
                ctx.SaveChanges();
                return View(addModel);
            }
            
        }
    }
}
