using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using TennisStats.Domain.Entities;
using TennisStats.Domain.Interfaces;

namespace TennisStats.Infrastructure.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public PlayerRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["ApiSettings:BaseUrl"] + "/resources/headtohead.json";
        }

        public async Task<List<Player>> GetAllPlayersAsync()
        {
            var response = await _httpClient.GetStringAsync(_apiUrl);
            var playerCollection = JsonConvert.DeserializeObject<PlayerCollection>(response);

            if (playerCollection == null || playerCollection.Players == null)
                throw new Exception("Impossible de récupérer les joueurs.");

            return playerCollection.Players.OrderBy(p => p.Data.Rank).ToList();
        }

        public async Task<Player?> GetPlayerByIdAsync(int id)
        {
            var players = await GetAllPlayersAsync();
            return players.FirstOrDefault(p => p.Id == id);
        }
    }
}
