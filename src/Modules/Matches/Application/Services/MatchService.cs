using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Services;

public class MatchService : IMatchService
{
    private readonly IMatchRepository _matchRepository;

    public MatchService(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    // Operaciones básicas
    public async Task<Match?> GetByIdAsync(int id)
    {
        return await _matchRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Match>> GetAllAsync()
    {
        return await _matchRepository.GetAllAsync();
    }

    public async Task<Match> CreateMatchAsync(int tournamentId, int homeTeamId, int awayTeamId, DateTime matchDate)
    {
        try
        {
            // Validaciones básicas
            if (!await CanCreateMatchAsync(tournamentId, homeTeamId, awayTeamId, matchDate))
            {
                throw new InvalidOperationException("No se puede crear el partido con los datos proporcionados");
            }

            var match = new Match(tournamentId, homeTeamId, awayTeamId, matchDate);
            return await _matchRepository.CreateAsync(match);
        }
        catch (Exception ex)
        {
            // Log del error interno para debugging
            Console.WriteLine($"Error interno en CreateMatchAsync: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            }
            throw; // Re-lanzar la excepción original
        }
    }

    public async Task<Match> FinishMatchAsync(int matchId, int homeScore, int awayScore)
    {
        var match = await _matchRepository.GetByIdAsync(matchId);
        if (match == null)
        {
            throw new InvalidOperationException("El partido no existe");
        }

        if (match.IsFinished)
        {
            throw new InvalidOperationException("El partido ya está finalizado");
        }

        match.FinishMatch(homeScore, awayScore);
        return await _matchRepository.UpdateAsync(match);
    }

    // Consultas para el menú de partidos
    public async Task<IEnumerable<Match>> GetMatchesWithoutScoreAsync()
    {
        return await _matchRepository.GetMatchesWithoutScoreAsync();
    }

    // Validaciones básicas
    public async Task<bool> CanCreateMatchAsync(int tournamentId, int homeTeamId, int awayTeamId, DateTime matchDate)
    {
        // Validar que ambos equipos estén en el torneo
        if (!await _matchRepository.HasTeamInTournamentAsync(homeTeamId, tournamentId))
        {
            throw new InvalidOperationException($"El equipo local (ID: {homeTeamId}) no está inscrito en este torneo");
        }

        if (!await _matchRepository.HasTeamInTournamentAsync(awayTeamId, tournamentId))
        {
            throw new InvalidOperationException($"El equipo visitante (ID: {awayTeamId}) no está inscrito en este torneo");
        }

        // Validar que no sean el mismo equipo
        if (homeTeamId == awayTeamId)
        {
            throw new InvalidOperationException("No puede ser el mismo equipo local y visitante");
        }

        // Validar que no haya conflicto de horarios para los equipos
        if (await _matchRepository.HasMatchOnDateAsync(tournamentId, matchDate))
        {
            throw new InvalidOperationException($"Ya existe un partido en este torneo para la fecha {matchDate:yyyy-MM-dd}");
        }

        // Validar que no haya otro partido entre los mismos equipos en la misma fecha
        if (await _matchRepository.HasMatchBetweenTeamsAsync(tournamentId, homeTeamId, awayTeamId, matchDate))
        {
            throw new InvalidOperationException($"Ya existe un partido entre estos equipos para la fecha {matchDate:yyyy-MM-dd}");
        }

        return true;
    }
}
