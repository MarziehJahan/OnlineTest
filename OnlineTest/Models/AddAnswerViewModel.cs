using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.DAL;

namespace OnlineTest.Models
{
    public class AddAnswerViewModel
    {
        public string Username { get; set; }
        public List<Choice> choices { get; set; }
        public List<Question> Questions { get; set; }
        public List<int> selectedAns { get; set; }
    }
}