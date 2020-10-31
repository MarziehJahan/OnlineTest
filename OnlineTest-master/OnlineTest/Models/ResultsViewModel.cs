using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.DAL;

namespace OnlineTest.Models
{
    public class ResultsViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int ChoiceId { get; set; }
        public string ChoiceText { get; set; }
        public int numOfUsersChosen { get; set; }
    }
}
