using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Services;

public class TournamentService : ITournamentService
{
    private readonly ITournamentRepository _tournamentRepository;

    public TournamentService(ITournamentRepository tournamentRepository)
    {
        _tournamentRepository = tournamentRepository;
    }

    public async Task<Tournament?> GetTournamentByIdAsync(int id)
    {
        try
        {
            var tournament = await _tournamentRepository.GetByIdAsync(id);
            if (tournament == null)
            {
                Console.WriteLine($"Tournament with ID {id} not found.");
                return null;
            }
            return tournament;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving tournament by ID {id}: {ex.Message}");
            return null;
        }
    }

    public async Task<IEnumerable<Tournament>> GetAllTournamentsAsync()
    {
        try
        {
            var tournaments = await _tournamentRepository.GetAllAsync();
            if (tournaments == null || !tournaments.Any())
            {
                Console.WriteLine("No tournaments found.");
                return Enumerable.Empty<Tournament>();
            }
            return tournaments;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving all tournaments: {ex.Message}");
            return Enumerable.Empty<Tournament>();
        }
    }

    public async Task AddTournamentAsync(Tournament tournament)
    {
        try
        {
            if (tournament == null)
            {
                Console.WriteLine("Tournament cannot be null.");
                return;
            }
            _tournamentRepository.Add(tournament);
            await _tournamentRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding tournament: {ex.Message}");
        }
    }

    public async Task UpdateTournamentAsync(int id, Tournament tournament)
    {
        try
        {
            var existingTournament = await _tournamentRepository.GetByIdAsync(id);
            if (existingTournament != null)
            {
                existingTournament.Name = tournament.Name;
                existingTournament.StartDate = tournament.StartDate;
                existingTournament.EndDate = tournament.EndDate;
                _tournamentRepository.Update(existingTournament);
                await _tournamentRepository.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine($"Tournament with ID {id} not found for update.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating tournament with ID {id}: {ex.Message}");
        }

    }

    public async Task DeleteTournamentAsync(int id)
    {
        try
        {
            if (await _tournamentRepository.GetByIdAsync(id) != null)
            {
                Console.WriteLine($"Failed to delete tournament with ID {id}.");
                return;
            }
            await _tournamentRepository.DeleteAsync(id);
            await _tournamentRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting tournament with ID {id}: {ex.Message}");
        }
    }

    public async Task<IEnumerable<Tournament>> GetTournamentsWhereTeamIsNotEnrolledAsync(int teamId)
    {
        try
        {
            var tournaments = await _tournamentRepository.GetTournamentsWhereTeamIsNotEnrolledAsync(teamId);
            if (tournaments == null || !tournaments.Any())
            {
                Console.WriteLine($"No tournaments found where team with ID {teamId} is not enrolled.");
                return Enumerable.Empty<Tournament>();
            }
            return tournaments;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving tournaments where team with ID {teamId} is not enrolled: {ex.Message}");
            return Enumerable.Empty<Tournament>();
        }
    }
    
    public async Task<IEnumerable<Tournament>> GetTournamentsByTeamIdAsync(int teamId)
    {
        try
        {
            var tournaments = await _tournamentRepository.GetTournamentsByTeamIdAsync(teamId);
            if (tournaments == null || !tournaments.Any())
            {
                Console.WriteLine($"No tournaments found for team with ID {teamId}.");
                return Enumerable.Empty<Tournament>();
            }
            return tournaments;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving tournaments for team with ID {teamId}: {ex.Message}");
            return Enumerable.Empty<Tournament>();
        }
    }
}