using MyGameScore.Data.Context;
using MyGameScore.Data.Entity;

namespace MyGameScore.Data.Repository
{
    public class GameScoreRepository
    {
        private MyGameScoreContext _context;

        public GameScoreRepository(MyGameScoreContext context)
        {
            _context = context;
        }

        public void Save(GameScore gameScore)
        {
            ValidateGameScore(gameScore);

            _context.GameScore.Add(gameScore);
            _context.SaveChanges();
        }

        public List<GameScore> ListGameScoreOrdered() 
        {
            return _context.GameScore.OrderBy(game => game.GameDate).ToList();
        }


        private void ValidateGameScore(GameScore gameScore)
        {
            if (gameScore.GameDate == DateTime.MinValue || gameScore.GameDate > DateTime.Now || gameScore.Score < 0)
            {
                throw new Exception("Data do jogo ou pontuação inválida");
            }
        }

        
    }
}
