using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Spectre.Console;

namespace GESTOR_TORNEOSv4.src.Modules.Application.UI;

public class MatchUI : IMatchUI
{
    private readonly IMatchService _matchService;
    private readonly ITournamentService _tournamentService;
    private readonly ITeamService _teamService;
    private readonly ITournamentTeamService _tournamentTeamService;

    public MatchUI(IMatchService matchService, ITournamentService tournamentService, ITeamService teamService, ITournamentTeamService tournamentTeamService)
    {
        _matchService = matchService;
        _tournamentService = tournamentService;
        _teamService = teamService;
        _tournamentTeamService = tournamentTeamService;
    }

    public async Task ShowMatchMenu()
    {
        while (true)
        {
            Console.Clear();
            var rule = new Rule("[blue]MENÚ DE PARTIDOS[/]");
            rule.Justification = Justify.Left;
            AnsiConsole.Write(rule);

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Seleccione una opción:")
                    .AddChoices(new[] {
                        "1. Crear Partido",
                        "2. Finalizar Partido",
                        "0. Regresar al Menú Principal"
                    }));

            switch (choice)
            {
                case "1. Crear Partido":
                    await CreateMatch();
                    break;
                case "2. Finalizar Partido":
                    FinishMatch();
                    break;
                case "0. Regresar al Menú Principal":
                    return;
            }
        }
    }

    public async Task CreateMatch()
    {
        Console.Clear();
        var rule = new Rule("[green]CREAR PARTIDO[/]");
        rule.Justification = Justify.Left;
        AnsiConsole.Write(rule);

        try
        {
            // Mostrar torneos disponibles
            var tournaments = await _tournamentService.GetAllTournamentsAsync();
            if (!tournaments.Any())
            {
                AnsiConsole.MarkupLine("[red]❌ No hay torneos disponibles. Debe crear un torneo primero.[/]");
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            var tournamentTable = new Table()
                .Title("[yellow]TORNEOS DISPONIBLES[/]")
                .AddColumn("ID", column => column.Width(5))
                .AddColumn("Nombre", column => column.Width(30))
                .AddColumn("Fecha Inicio", column => column.Width(15))
                .AddColumn("Fecha Fin", column => column.Width(15));

            foreach (var tournament in tournaments)
            {
                tournamentTable.AddRow(
                    tournament.Id.ToString(),
                    tournament.Name,
                    tournament.StartDate.ToString("yyyy-MM-dd"),
                    tournament.EndDate.ToString("yyyy-MM-dd")
                );
            }

            AnsiConsole.Write(tournamentTable);

            var tournamentId = AnsiConsole.Prompt(
                new TextPrompt<int>("[blue]🏆 Ingrese el ID del torneo:[/]")
                    .ValidationErrorMessage("[red]ID de torneo inválido[/]")
                    .Validate(id => id > 0 ? ValidationResult.Success() : ValidationResult.Error("ID debe ser mayor a 0")));

            var selectedTournament = tournaments.FirstOrDefault(t => t.Id == tournamentId);
            if (selectedTournament == null)
            {
                AnsiConsole.MarkupLine("[red]❌ Torneo no encontrado.[/]");
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            // Mostrar equipos del torneo usando el servicio de torneos-equipos
            var teams = await _tournamentTeamService.GetTeamsByTournamentAsync(tournamentId);
            if (!teams.Any())
            {
                AnsiConsole.MarkupLine("[red]❌ No hay equipos inscritos en este torneo. Debe inscribir equipos primero.[/]");
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            var teamTable = new Table()
                .Title($"[yellow]EQUIPOS INSCRITOS EN '{selectedTournament.Name}'[/]")
                .AddColumn("ID", column => column.Width(5))
                .AddColumn("Nombre", column => column.Width(30))
                .AddColumn("Ciudad", column => column.Width(20));

            foreach (var team in teams)
            {
                teamTable.AddRow(
                    team.Id.ToString(),
                    team.Name,
                    team.City?.Name ?? "Sin ciudad"
                );
            }

            AnsiConsole.Write(teamTable);

            var homeTeamId = AnsiConsole.Prompt(
                new TextPrompt<int>("[blue]🏠 Ingrese el ID del equipo local:[/]")
                    .ValidationErrorMessage("[red]ID de equipo local inválido[/]")
                    .Validate(id => id > 0 ? ValidationResult.Success() : ValidationResult.Error("ID debe ser mayor a 0")));

            var awayTeamId = AnsiConsole.Prompt(
                new TextPrompt<int>("[blue]✈️  Ingrese el ID del equipo visitante:[/]")
                    .ValidationErrorMessage("[red]ID de equipo visitante inválido[/]")
                    .Validate(id => id > 0 ? ValidationResult.Success() : ValidationResult.Error("ID debe ser mayor a 0")));

            if (homeTeamId == awayTeamId)
            {
                AnsiConsole.MarkupLine("[red]❌ No puede ser el mismo equipo local y visitante.[/]");
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            var matchDate = AnsiConsole.Prompt(
                new TextPrompt<DateTime>("[blue]📅 Ingrese la fecha del partido (yyyy-MM-dd):[/]")
                    .ValidationErrorMessage("[red]Fecha inválida[/]")
                    .Validate(date => date >= DateTime.Today ? ValidationResult.Success() : ValidationResult.Error("La fecha debe ser hoy o futura")));

            // Crear el partido
            var createdMatch = await _matchService.CreateMatchAsync(tournamentId, homeTeamId, awayTeamId, matchDate);
            
            AnsiConsole.MarkupLine("[green]✅ Partido creado exitosamente![/]");
            AnsiConsole.MarkupLine($"[blue]📋 ID del partido:[/] {createdMatch.Id}");
            AnsiConsole.MarkupLine($"[blue]📅 Fecha:[/] {matchDate:yyyy-MM-dd}");
            
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]❌ Error: {ex.Message}[/]");
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    public void FinishMatch()
    {
        Console.Clear();
        var rule = new Rule("[green]FINALIZAR PARTIDO[/]");
        rule.Justification = Justify.Left;
        AnsiConsole.Write(rule);

        try
        {
            // Mostrar partidos sin score
            var matchesWithoutScore = _matchService.GetMatchesWithoutScoreAsync().Result;
            if (!matchesWithoutScore.Any())
            {
                AnsiConsole.MarkupLine("[green]✅ No hay partidos pendientes de finalizar.[/]");
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            var matchTable = new Table()
                .Title("[yellow]PARTIDOS PENDIENTES DE FINALIZAR[/]")
                .AddColumn("ID", column => column.Width(5))
                .AddColumn("Torneo", column => column.Width(20))
                .AddColumn("Equipos", column => column.Width(30))
                .AddColumn("Fecha", column => column.Width(15));

            foreach (var match in matchesWithoutScore)
            {
                var homeTeamName = match.HomeTeam?.Name ?? $"Equipo {match.HomeTeamId}";
                var awayTeamName = match.AwayTeam?.Name ?? $"Equipo {match.AwayTeamId}";
                var tournamentName = match.Tournament?.Name ?? $"Torneo {match.TournamentId}";
                
                matchTable.AddRow(
                    match.Id.ToString(),
                    tournamentName,
                    $"{homeTeamName} vs {awayTeamName}",
                    match.MatchDate.ToString("yyyy-MM-dd")
                );
            }

            AnsiConsole.Write(matchTable);

            var matchId = AnsiConsole.Prompt(
                new TextPrompt<int>("[blue]🎯 Ingrese el ID del partido a finalizar:[/]")
                    .ValidationErrorMessage("[red]ID de partido inválido[/]")
                    .Validate(id => id > 0 ? ValidationResult.Success() : ValidationResult.Error("ID debe ser mayor a 0")));

            var selectedMatch = matchesWithoutScore.FirstOrDefault(m => m.Id == matchId);
            if (selectedMatch == null)
            {
                AnsiConsole.MarkupLine("[red]❌ Partido no encontrado o ya finalizado.[/]");
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            var selectedHomeTeamName = selectedMatch.HomeTeam?.Name ?? $"Equipo {selectedMatch.HomeTeamId}";
            var selectedAwayTeamName = selectedMatch.AwayTeam?.Name ?? $"Equipo {selectedMatch.AwayTeamId}";

            AnsiConsole.MarkupLine($"[yellow]🏟️  FINALIZANDO PARTIDO: {selectedHomeTeamName} vs {selectedAwayTeamName}[/]");
            AnsiConsole.WriteLine();

            var homeScore = AnsiConsole.Prompt(
                new TextPrompt<int>($"[blue]⚽ Goles de {selectedHomeTeamName}:[/]")
                    .ValidationErrorMessage("[red]Número de goles inválido[/]")
                    .Validate(goals => goals >= 0 ? ValidationResult.Success() : ValidationResult.Error("Los goles no pueden ser negativos")));

            var awayScore = AnsiConsole.Prompt(
                new TextPrompt<int>($"[blue]⚽ Goles de {selectedAwayTeamName}:[/]")
                    .ValidationErrorMessage("[red]Número de goles inválido[/]")
                    .Validate(goals => goals >= 0 ? ValidationResult.Success() : ValidationResult.Error("Los goles no pueden ser negativos")));

            // Finalizar el partido
            var finishedMatch = _matchService.FinishMatchAsync(matchId, homeScore, awayScore).Result;
            
            AnsiConsole.MarkupLine("[green]✅ Partido finalizado exitosamente![/]");
            AnsiConsole.MarkupLine($"[blue]📊 Resultado:[/] {selectedHomeTeamName} {homeScore} - {awayScore} {selectedAwayTeamName}");
            
            if (homeScore > awayScore)
                AnsiConsole.MarkupLine($"[green]🏆 Ganador: {selectedHomeTeamName}[/]");
            else if (awayScore > homeScore)
                AnsiConsole.MarkupLine($"[green]🏆 Ganador: {selectedAwayTeamName}[/]");
            else
                AnsiConsole.MarkupLine("[yellow]🤝 Resultado: Empate[/]");

            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]❌ Error: {ex.Message}[/]");
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
