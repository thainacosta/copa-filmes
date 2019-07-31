using CopaMundoFilmes.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CopaMundoFilmes.Web.Repositories
{
    public class FilmesRepository
    {
        private string copaMundoUrl; 

        public FilmesRepository(string copaMundoUrl)
        {
            this.copaMundoUrl = copaMundoUrl;
        }

        public async Task<List<Filme>> Obter()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(copaMundoUrl);

                var response = await httpClient.GetAsync("/api/filmes");

                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var filmes = JsonConvert.DeserializeObject<List<Filme>>(responseContent);
                return filmes;
            }
        }

        public async Task<List<Filme>> ObterPorIds(string[] ids)
        {
            var filmes = await Obter();
            var filmesFiltrado = filmes.Where(filme => ids.Contains(filme.Id)).ToList();

            return filmesFiltrado;
        }
    }
}
