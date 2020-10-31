namespace Test.DAL
{
    public class AnswerDetails
    {
        public int AnswerDetailsId { get; set; }
        public Choice choice { get; set; }
        public User PickedByUser { get; set; }
    }
}
