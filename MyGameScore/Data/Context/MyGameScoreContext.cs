using Microsoft.EntityFrameworkCore;
using MyGameScore.Data.Entity;

namespace MyGameScore.Data.Context
{
    public class MyGameScoreContext: DbContext
    {
        public MyGameScoreContext()
        {

        }
        private string connectionString = "Data Source=DESKTOP-M909G85;Initial Catalog=MyGameScore;Integrated Security=True";

        public DbSet<GameScore> GameScore { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
