using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;
using TennisStats.Application.Interfaces;
using TennisStats.Domain.Entities;
using TennisStats.Infrastructure.Data.Repositories;
using TennisStats.Domain.Interfaces;

namespace TennisStats.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<List<Player>> GetAllPlayersAsync()
        {
            return await _playerRepository.GetAllPlayersAsync();
        }

        public async Task<Player?> GetPlayerByIdAsync(int id)
        {
            return await _playerRepository.GetPlayerByIdAsync(id);
        }

        public async Task<string> GetCountryWithBestWinRatioAsync()
        {
            var players = await GetAllPlayersAsync();

            var countryStats = players
                .GroupBy(p => p.Country.Code)
                .Select(g => new
                {
                    Country = g.Key,
                    Wins = g.Sum(p => p.Data.Last.Count(r => r == 1)),
                    Matches = g.Sum(p => p.Data.Last.Count)
                })
                .Where(x => x.Matches > 0)
                .Select(x => new
                {
                    x.Country,
                    WinRatio = (double)x.Wins / x.Matches
                })
                .OrderByDescending(x => x.WinRatio)
                .FirstOrDefault();

            return countryStats?.Country ?? "Unknown";
        }

        public async Task<double> GetAverageBmiAsync()
        {
            var players = await GetAllPlayersAsync();

            var bmis = players
                .Select(p =>
                {
                    var heightInMeters = p.Data.Height / 100.0;
                    return p.Data.Weight / (heightInMeters * heightInMeters);
                });

            return bmis.Any() ? Math.Round(bmis.Average(), 2) : 0;
        }

        public async Task<double> GetMedianHeightAsync()
        {
            var players = await GetAllPlayersAsync();

            var heights = players
                .Select(p => p.Data.Height)
                .OrderBy(h => h)
                .ToList();

            if (!heights.Any())
                return 0;

            int count = heights.Count;
            if (count % 2 == 1)
                return heights[count / 2];
            else
                return (heights[(count / 2) - 1] + heights[count / 2]) / 2.0;
        }
    }
}
