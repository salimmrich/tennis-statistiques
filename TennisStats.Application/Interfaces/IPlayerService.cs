using TennisStats.Domain.Entities;

namespace TennisStats.Application.Interfaces
{
    public interface IPlayerService
    {
        Task<List<Player>> GetAllPlayersAsync();
        Task<Player?> GetPlayerByIdAsync(int id);
        Task<string> GetCountryWithBestWinRatioAsync();
        Task<double> GetAverageBmiAsync();
        Task<double> GetMedianHeightAsync();
    }
}