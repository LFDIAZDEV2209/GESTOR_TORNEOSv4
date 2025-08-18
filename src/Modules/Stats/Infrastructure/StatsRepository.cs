using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using GESTOR_TORNEOSv4.src.Shared.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace GESTOR_TORNEOSv4.src.Modules.Infrastructure;

public class StatsRepository : IStatsRepository
{
	private readonly AppDbContext _context;

	public StatsRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<PlayerStats>> GetPlayersWithMostAssistsByTournamentAsync(int tournamentId)
	{
		return await _context.PlayerStats
			.Include(ps => ps.Player)
			.ThenInclude(p => p!.Team)
			.Include(ps => ps.Match)
			.Where(ps => ps.Match!.TournamentId == tournamentId)
			.GroupBy(ps => new { ps.PlayerId, PlayerName = ps.Player!.Name })
			.Select(g => new PlayerStats
			{
				PlayerId = g.Key.PlayerId,
				Player = g.First().Player,
				Goals = g.Sum(ps => ps.Goals),
				Assists = g.Sum(ps => ps.Assists),
				MinutesPlayed = g.Sum(ps => ps.MinutesPlayed)
			})
			.OrderByDescending(ps => ps.Assists)
			.ThenByDescending(ps => ps.Goals)
			.Take(10)
			.ToListAsync();
	}

	public async Task<IEnumerable<PlayerStats>> GetMostExpensivePlayersByTeamAsync(int teamId)
	{
		return await _context.Players
			.Where(p => p.TeamId == teamId && p.MarketValue > 0)
			.OrderByDescending(p => p.MarketValue)
			.Take(10)
			.Select(p => new PlayerStats
			{
				PlayerId = p.Id,
				Player = p,
				Goals = 0,
				Assists = 0,
				MinutesPlayed = 0
			})
			.ToListAsync();
	}

	public async Task<IEnumerable<PlayerStats>> GetPlayersBelowAverageAgeByTeamAsync(int teamId)
	{
		var averageAge = await GetAverageTeamAgeAsync(teamId);
		
		// Obtener todos los jugadores del equipo y filtrar por edad en memoria
		var players = await _context.Players
			.Where(p => p.TeamId == teamId && p.BirthDate != null)
			.ToListAsync();

		// Filtrar por edad en memoria para evitar problemas de traducción
		var youngPlayers = players
			.Where(p => CalculateAge(p.BirthDate) < averageAge)
			.OrderBy(p => p.BirthDate)
			.Take(10);

		return youngPlayers.Select(p => new PlayerStats
		{
			PlayerId = p.Id,
			Player = p,
			Goals = 0,
			Assists = 0,
			MinutesPlayed = 0
		});
	}

	private static int CalculateAge(DateTime birthDate)
	{
		var today = DateTime.Today;
		var age = today.Year - birthDate.Year;
		if (birthDate.Date > today.AddYears(-age)) age--;
		return age;
	}

	public async Task<IEnumerable<TeamStats>> GetTeamsWithMostGoalsAsync(int tournamentId)
	{
		var teamStats = await _context.PlayerStats
			.Include(ps => ps.Player)
			.ThenInclude(p => p!.Team)
			.ThenInclude(t => t!.City)
			.Include(ps => ps.Match)
			.Where(ps => ps.Match!.TournamentId == tournamentId)
			.GroupBy(ps => new { TeamId = ps.Player!.TeamId, TeamName = ps.Player.Team!.Name, CityName = ps.Player.Team.City!.Name })
			.Select(g => new TeamStats
			{
				TeamId = g.Key.TeamId ?? 0,
				TeamName = g.Key.TeamName,
				CityName = g.Key.CityName,
				TotalGoals = g.Sum(ps => ps.Goals),
				TotalAssists = g.Sum(ps => ps.Assists),
				MatchesPlayed = g.Select(ps => ps.MatchId).Distinct().Count(),
				AverageGoalsPerMatch = g.Select(ps => ps.MatchId).Distinct().Count() > 0
					? (double)g.Sum(ps => ps.Goals) / g.Select(ps => ps.MatchId).Distinct().Count()
					: 0
			})
			.OrderByDescending(ts => ts.TotalGoals)
			.ThenByDescending(ts => ts.AverageGoalsPerMatch)
			.ToListAsync();

		return teamStats;
	}

	public async Task<double> GetAverageTeamAgeAsync(int teamId)
	{
		// Obtener todos los jugadores del equipo con fecha de nacimiento
		var players = await _context.Players
			.Where(p => p.TeamId == teamId && p.BirthDate != null)
			.Select(p => p.BirthDate)
			.ToListAsync();

		if (!players.Any())
			return 0.0;

		// Calcular edad promedio en memoria
		var totalAge = players.Sum(birthDate => CalculateAge(birthDate));
		return (double)totalAge / players.Count;
	}
}
