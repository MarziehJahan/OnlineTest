using System.Collections.Generic;

namespace Test.DAL
{
    public class Choice
    {
        public int ChoiceId { get; set; }
        public string ChoiceText { get; set; }
        public Question question { get; set; }
    }
}
