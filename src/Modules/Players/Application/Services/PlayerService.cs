using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;

    public PlayerService(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<Player?> GetPlayerByIdAsync(int id)
    {
        try
        {
            var player = await _playerRepository.GetByIdAsync(id);
            if (player == null)
            {
                Console.WriteLine($"Player with ID {id} not found.");
                return null;
            }
            return player;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error retrieving player with ID {id}: {ex.Message}", ex);
        }
    }

    public async Task<IEnumerable<Player>> GetAllPlayersAsync()
    {
        try
        {
            var players = await _playerRepository.GetAllAsync();
            if (players == null || !players.Any())
            {
                Console.WriteLine("No players found.");
                return Enumerable.Empty<Player>();
            }
            return players;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error retrieving all players: {ex.Message}", ex);
        }
    }

    public async Task AddPlayerAsync(Player player)
    {
        try
        {
            if (player == null)
            {
                Console.WriteLine("Player cannot be null.");
                return;
            }
            _playerRepository.Add(player);
            await _playerRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error adding player: {ex.Message}", ex);
        }
    }

    public async Task UpdatePlayerAsync(int id, Player player)
    {
        try
        {
            if (player == null)
            {
                Console.WriteLine("Player cannot be null.");
                return;
            }

            var existingPlayer = await _playerRepository.GetByIdAsync(id);

            if (existingPlayer == null)
            {
                Console.WriteLine($"Player with ID {id} not found.");
                return;
            }

            player.Id = id; 
            _playerRepository.Update(player);
            await _playerRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating player with ID {id}: {ex.Message}", ex);
        }
    }

    public async Task DeletePlayerAsync(int id)
    {
        try
        {
            var player = await _playerRepository.GetByIdAsync(id);
            if (player == null)
            {
                Console.WriteLine($"Player with ID {id} not found.");
                return;
            }
            await _playerRepository.DeleteAsync(id);
            await _playerRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting player with ID {id}: {ex.Message}", ex);
        }
    }
}

