using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTest.Models;
using Test.DAL;

namespace OnlineTest.Controllers
{
    public class TestController : Controller
    {
        TestContext ctx = new TestContext();
        [HttpPost]
        public IActionResult SaveAnswers(AddAnswerViewModel test)
        {
            User user = ctx.Users.SingleOrDefault(a => a.Username == test.Username);
            List<Choice> choices = new List<Choice>();
            foreach (var item in test.selectedAns)
            {
                choices.Add(new Choice()
                {
                    ChoiceId = item,
                    ChoiceText = ctx.choices.Find(item).ChoiceText,
                    question = ctx.choices.Find(item).question
                });
            }
            foreach (var item in choices)
            {
                AnswerDetails details = new AnswerDetails()
                {
                    choice = item,
                    PickedByUser = user
                };
                ctx.answerDetails.Add(details);
                ctx.SaveChanges();
            }
            return RedirectToAction("Results");
        }
        public IActionResult Results()
        {
            List<ResultsViewModel> resultsView = new List<ResultsViewModel>();
            Dictionary<int, int> num = new Dictionary<int, int>();
            foreach (var item in ctx.choices.OrderBy(a=>a.question.QuestionId))
            {
                num.Add(item.ChoiceId, Convert.ToInt32(ctx.answerDetails
                    .OrderBy(b=>b.choice.question.QuestionId)
                    .Where(a => a.choice.ChoiceId == item.ChoiceId)
                    .GroupBy(k => k.choice.ChoiceId)
                    .Select(m => m.Count()).FirstOrDefault()));
            }
            foreach (var item in num)
            {
                resultsView.Add(new ResultsViewModel()
                {
                    ChoiceId = item.Key,
                    numOfUsersChosen = item.Value,
                    QuestionId = ctx.choices.Include(a=>a.question).SingleOrDefault(a=>a.ChoiceId==item.Key).question.QuestionId,
                    QuestionText = ctx.choices.Include(a => a.question).SingleOrDefault(a => a.ChoiceId == item.Key).question.QuestionText,
                    ChoiceText = ctx.choices.Find(item.Key).ChoiceText
                });
            }
            return View(resultsView);
        }
    }
}
