using CopaMundoFilmes.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace CopaMundoFilmes.Web.Services
{
    public class EliminadorDeFilmes
    {
        public (Filme Campeao, Filme ViceCampeao) ObterCampeoes(List<Filme> competidores)
        {
            var vercedoresPrimeiraFase = DisputarPrimeiraFase(competidores);
            var vencedoresSegundaFase = DisputarSegundaFase(vercedoresPrimeiraFase);
            var vencedores = Disputar(vencedoresSegundaFase[0], vencedoresSegundaFase[1]);

            return (vencedores.Ganhador, vencedores.Perdedor);
        }

        private List<Filme> DisputarPrimeiraFase(List<Filme> competidores)
        {
            var disputaUm = Disputar(competidores[0], competidores[7]);
            var disputaDois = Disputar(competidores[1], competidores[6]);
            var disputaTres = Disputar(competidores[2], competidores[5]);
            var disputaQuatro = Disputar(competidores[3], competidores[4]);

            var ganhadores = new List<Filme>
            {
                disputaUm.Ganhador,
                disputaDois.Ganhador,
                disputaTres.Ganhador,
                disputaQuatro.Ganhador
            };

            return ganhadores;
        }

        private List<Filme> DisputarSegundaFase(List<Filme> competidores)
        {
            var disputaUm = Disputar(competidores[0], competidores[1]);
            var disputaDois = Disputar(competidores[2], competidores[3]);

            var ganhadores = new List<Filme>
            {
                disputaUm.Ganhador,
                disputaDois.Ganhador                
            };

            return ganhadores;
        }

        private (Filme Ganhador, Filme Perdedor) Disputar(Filme competidorUm, Filme competidorDois)
        {
            var competidores = new Filme[] { competidorUm, competidorDois };
            var resultado = competidores
                .OrderByDescending(filme => filme.Nota)
                .ThenBy(filme => filme.Titulo)
                .ToArray();

            return (resultado[0], resultado[1]);
        }
    }
}
