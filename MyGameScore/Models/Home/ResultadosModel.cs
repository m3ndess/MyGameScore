using System.ComponentModel;

namespace MyGameScore.Models.Home
{
    public class ResultadosModel
    {
        public string Periodo { get; set; }

        [DisplayName("Jogos disputados:")]
        public int JogosDisputados { get; set; }
        
        [DisplayName("Total de pontos marcados na temporada:")]
        public int TotalPontosTemporada { get; set; }
        
        [DisplayName("Media de pontos por jogo:")]
        public int MediaPontos { get; set; }
        
        [DisplayName("Maior pontuação em um jogo:")]
        public int MaiorPontuacao { get; set; }
        
        [DisplayName("Menor pontuação em um jogo:")]
        public int MenorPontuacao { get; set; }
        
        [DisplayName("Quantidade de vezes que bateu o próprio recorde:")]
        public int QuantidadeBateuRecorde { get; set; }
    }
}
