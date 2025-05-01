using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Utilisation du logger standard
using TennisStats.Application.Interfaces;
using TennisStats.Domain.Entities;

namespace TennisStats.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly ILogger<PlayersController> _logger;

        // Injecter le service de joueurs et le logger
        public PlayersController(IPlayerService playerService, ILogger<PlayersController> logger)
        {
            _playerService = playerService;
            _logger = logger;
        }

        // Récupérer tous les joueurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            _logger.LogInformation("GetPlayers appelé"); // Log avec LogInformation
            try
            {
                var players = await _playerService.GetAllPlayersAsync();
                _logger.LogInformation("Récupération réussie de {Count} joueurs", players.Count());
                return Ok(players); // Retour des joueurs
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur survenue lors de la récupération des joueurs");
                return BadRequest($"Une erreur est survenue : {ex.Message}");
            }
        }

        // Récupérer un joueur par ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayerById(int id)
        {
            _logger.LogInformation("GetPlayerById appelé avec l'ID : {Id}", id); // Log avec LogInformation
            try
            {
                var player = await _playerService.GetPlayerByIdAsync(id);
                if (player == null)
                {
                    _logger.LogWarning("Joueur avec l'ID {Id} non trouvé", id); // Log avec LogWarning
                    return NotFound();
                }

                _logger.LogInformation("Joueur avec l'ID {Id} récupéré avec succès", id); // Log avec LogInformation
                return Ok(player);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur survenue lors de la récupération du joueur avec l'ID {Id}", id); // Log avec LogError
                return BadRequest($"Une erreur est survenue : {ex.Message}");
            }
        }

        // Récupérer le pays avec le meilleur ratio de victoires
        [HttpGet("best-win-ratio")]
        public async Task<ActionResult<string>> GetCountryWithBestWinRatio()
        {
            _logger.LogInformation("GetCountryWithBestWinRatio appelé");
            try
            {
                var country = await _playerService.GetCountryWithBestWinRatioAsync();
                _logger.LogInformation("Le pays avec le meilleur ratio de victoires est {Country}", country);
                return Ok(country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur survenue lors de la récupération du pays avec le meilleur ratio de victoires");
                return BadRequest($"Une erreur est survenue : {ex.Message}");
            }
        }

        // Récupérer l'IMC moyen des joueurs
        [HttpGet("average-bmi")]
        public async Task<ActionResult<double>> GetAverageBmi()
        {
            _logger.LogInformation("GetAverageBmi appelé");
            try
            {
                var averageBmi = await _playerService.GetAverageBmiAsync();
                _logger.LogInformation("IMC moyen des joueurs : {AverageBmi}", averageBmi);
                return Ok(averageBmi);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur survenue lors de la récupération de l'IMC moyen");
                return BadRequest($"Une erreur est survenue : {ex.Message}");
            }
        }

        // Récupérer la médiane de la taille des joueurs
        [HttpGet("median-height")]
        public async Task<ActionResult<double>> GetMedianHeight()
        {
            _logger.LogInformation("GetMedianHeight appelé");
            try
            {
                var medianHeight = await _playerService.GetMedianHeightAsync();
                _logger.LogInformation("Médiane de la taille des joueurs : {MedianHeight}", medianHeight);
                return Ok(medianHeight);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur survenue lors de la récupération de la médiane de taille");
                return BadRequest($"Une erreur est survenue : {ex.Message}");
            }
        }
    }
}
