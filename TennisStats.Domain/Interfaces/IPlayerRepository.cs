using TennisStats.Domain.Entities;

namespace TennisStats.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAllPlayersAsync();
        Task<Player?> GetPlayerByIdAsync(int id);
    }
}
