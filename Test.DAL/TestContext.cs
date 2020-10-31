using Microsoft.EntityFrameworkCore;
using System;

namespace Test.DAL
{
    public class TestContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;initial catalog=Test;integrated security=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> choices { get; set; }
        public DbSet<AnswerDetails> answerDetails { get; set; }
    }
}
