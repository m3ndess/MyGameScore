using System.ComponentModel;

namespace MyGameScore.Models.Home
{
    public class LancarPontosModel
    {
        [DisplayName("Data do jogo:")]
        public DateTime GameDate { get; set; }

        [DisplayName("Quantos pontos você fez:")]
        public int Score { get; set; }
    }
}
