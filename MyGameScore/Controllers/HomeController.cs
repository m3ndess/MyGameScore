using Microsoft.AspNetCore.Mvc;
using MyGameScore.Data.Context;
using MyGameScore.Data.Entity;
using MyGameScore.Data.Repository;
using MyGameScore.Models;
using MyGameScore.Models.Home;
using System.Diagnostics;

namespace MyGameScore.Controllers
{
    public class HomeController : Controller
    {
        private MyGameScoreContext _context;

        public HomeController()
        {
            _context = new MyGameScoreContext();
        }

        [AcceptVerbs("GET")]
        public IActionResult LancarPontos()
        {
            return View();
        }

        [AcceptVerbs("POST")]
        public IActionResult LancarPontos(LancarPontosModel model)
        {
            var gameScoreRepository = new GameScoreRepository(_context);
            var gameScore = new GameScore()
            {
                GameDate = model.GameDate,
                Score = model.Score
            };

            gameScoreRepository.Save(gameScore);

            ModelState.Clear();
            return View();
        }

        public IActionResult Resultados()
        {
            var gameScoreRepository = new GameScoreRepository(_context);
            var gamesList = gameScoreRepository.ListGameScoreOrdered();
            var resultados = MontarResultados(gamesList);

            return View(resultados);
        } 

        private ResultadosModel MontarResultados(List<GameScore> gamesScore)
        {
            var totalJogos = gamesScore.Count;
            var totalPontosTemporada = 0;
            var maiorPontuacao = 0;
            var menorPontuacao = int.MaxValue;
            var quantidadeRecordes = 0;
            var dataInicio = gamesScore.First().GameDate;
            var dataFim = gamesScore.Last().GameDate;

            for (int i = 0; i < gamesScore.Count; i++)
            {
                // Contar como recorde somente quando não for o primeiro jogo
                if (i > 0 && gamesScore[i].Score > maiorPontuacao)
                {
                    quantidadeRecordes++;
                }

                totalPontosTemporada += gamesScore[i].Score;
                maiorPontuacao = gamesScore[i].Score > maiorPontuacao ? gamesScore[i].Score : maiorPontuacao;
                menorPontuacao = gamesScore[i].Score < menorPontuacao ? gamesScore[i].Score : menorPontuacao;

            }

            var mediaPontos = totalPontosTemporada / totalJogos;

            return new ResultadosModel()
            {
                Periodo = $"{dataInicio.ToString("dd/MM/yyyy")} até {dataFim.ToString("dd/MM/yyyy")}",
                JogosDisputados = totalJogos,
                MaiorPontuacao = maiorPontuacao,
                MediaPontos = mediaPontos,
                MenorPontuacao = menorPontuacao,
                QuantidadeBateuRecorde = quantidadeRecordes,
                TotalPontosTemporada = totalPontosTemporada
            };
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}