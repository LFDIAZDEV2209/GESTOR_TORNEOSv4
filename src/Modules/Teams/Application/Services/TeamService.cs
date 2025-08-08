using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;

    public TeamService(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task AddTeamAsync(Team team)
    {
        try
        {
            if (team == null)
            {
                Console.WriteLine("The team provided is null.");
                return;
            }

            _teamRepository.Add(team);
            await _teamRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding the team: {ex.Message}");
            Console.WriteLine(ex.InnerException);
        }
    }

    public async Task DeleteTeamAsync(int id)
    {
        try
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null)
            {
                Console.WriteLine($"Failed to delete tournament with ID {id}.");
                return;
            }
            await _teamRepository.DeleteAsync(id);
            await _teamRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting tournament with ID {id}: {ex.Message}");
        }
    }

    public async Task<IEnumerable<Team>> GetAllTeamsAsync()
    {
        try
        {
            var teams = await _teamRepository.GetAllAsync();
            if (teams == null || !teams.Any())
            {
                Console.WriteLine("No teams found.");
                return Enumerable.Empty<Team>();
            }
            return teams;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving all teams: {ex.Message}");
            return Enumerable.Empty<Team>();
        }
    }

    public async Task<Team?> GetTeamByIdAsync(int id)
    {
        try
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null)
            {
                Console.WriteLine($"team with ID {id} not found.");
                return null;
            }
            return team;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving team by ID {id}: {ex.Message}");
            return null;
        }
    }

    public async Task UpdateTeamAsync(int id, Team team)
    {
        try
        {
            var existingTeam = await _teamRepository.GetByIdAsync(id);
            if (existingTeam != null)
            {
                existingTeam.Name = team.Name;

                _teamRepository.Update(existingTeam);
                await _teamRepository.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine($"team with ID {id} not found for update.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating team with ID {id}: {ex.Message}");
        }
    }
    
    public async Task<IEnumerable<Team>> GetTeamsWithAtLeastOneTournamentAsync()
    {
        try
        {
            var teams = await _teamRepository.GetTeamsWithAtLeastOneTournamentAsync();
            if (teams == null || !teams.Any())
            {
                Console.WriteLine("No teams with at least one tournament found.");
                return Enumerable.Empty<Team>();
            }
            return teams;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving teams with at least one tournament: {ex.Message}");
            return Enumerable.Empty<Team>();
        }
    }
}
