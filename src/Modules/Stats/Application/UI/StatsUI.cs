using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Spectre.Console;

namespace GESTOR_TORNEOSv4.src.Modules.Application.UI;

public class StatsUI : IStatsUI
{
	private readonly IStatsService _statsService;

	public StatsUI(IStatsService statsService)
	{
		_statsService = statsService;
	}

	public async Task ShowStatsMenu()
	{
		while (true)
		{
			Console.Clear();

			AnsiConsole.Write(
				new FigletText("ESTADÍSTICAS")
					.Centered()
					.Color(Color.Blue)
			);

			var choice = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title("[bold green]Seleccione una opción:[/]")
					.PageSize(10)
					.AddChoices(new[]
					{
						"4.1. Jugadores Con Más Asistencias Torneo",
						"4.2. Equipos Con Más Goles",
						"4.3. Jugadores Más Caros Por Equipo",
						"4.4. Jugadores Menor Al Promedio De Edad Por Equipo",
						"4.5. Regresar Al Menú Principal"
					}));

			switch (choice)
			{
				case "4.1. Jugadores Con Más Asistencias Torneo":
					await ShowPlayersWithMostAssists();
					break;
				case "4.2. Equipos Con Más Goles":
					await ShowTeamsWithMostGoals();
					break;
				case "4.3. Jugadores Más Caros Por Equipo":
					await ShowMostExpensivePlayers();
					break;
				case "4.4. Jugadores Menor Al Promedio De Edad Por Equipo":
					await ShowPlayersBelowAverageAge();
					break;
				case "4.5. Regresar Al Menú Principal":
					return;
			}
		}
	}

	public async Task ShowPlayersWithMostAssists()
	{
		Console.Clear();

		AnsiConsole.Write(
			new FigletText("MÁS ASISTENCIAS")
				.Centered()
				.Color(Color.Green)
		);

		try
		{
			var tournaments = await _statsService.GetAllTournamentsAsync();
			if (!tournaments.Any())
			{
				AnsiConsole.MarkupLine("[red]❌ No hay torneos disponibles.[/]");
				AnsiConsole.WriteLine();
				AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
				Console.ReadKey();
				return;
			}

			var tournamentChoice = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title("[bold yellow]Seleccione un torneo:[/]")
					.PageSize(10)
					.AddChoices(tournaments.Select(t => $"{t.Id}. {t.Name}")));

			var tournamentId = int.Parse(tournamentChoice.Split('.')[0]);
			var selectedTournament = tournaments.First(t => t.Id == tournamentId);

			AnsiConsole.MarkupLine($"[bold blue]📊 Estadísticas de asistencias para: {selectedTournament.Name}[/]");
			AnsiConsole.WriteLine();

			var players = await _statsService.GetPlayersWithMostAssistsByTournamentAsync(tournamentId);
			if (!players.Any())
			{
				AnsiConsole.MarkupLine("[yellow]⚠️  No hay estadísticas disponibles para este torneo.[/]");
				AnsiConsole.WriteLine();
				AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
				Console.ReadKey();
				return;
			}

			var table = new Table()
				.Title("[bold yellow]TOP 10 JUGADORES CON MÁS ASISTENCIAS[/]")
				.AddColumn("Pos", column => column.Width(5).Alignment(Justify.Center))
				.AddColumn("Jugador", column => column.Width(30))
				.AddColumn("Equipo", column => column.Width(25))
				.AddColumn("Asistencias", column => column.Width(12).Alignment(Justify.Center))
				.AddColumn("Goles", column => column.Width(8).Alignment(Justify.Center))
				.AddColumn("Minutos", column => column.Width(10).Alignment(Justify.Center));

			int position = 1;
			foreach (var ps in players)
			{
				var teamName = ps.Player?.Team?.Name ?? "Sin equipo";
				table.AddRow(
					position++.ToString(),
					ps.Player?.Name ?? "N/A",
					teamName,
					ps.Assists.ToString(),
					ps.Goals.ToString(),
					ps.MinutesPlayed.ToString()
				);
			}

			AnsiConsole.Write(table);
		}
		catch (Exception ex)
		{
			AnsiConsole.MarkupLine($"[red]❌ Error: {ex.Message}[/]");
		}

		AnsiConsole.WriteLine();
		AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
		Console.ReadKey();
	}

	public async Task ShowTeamsWithMostGoals()
	{
		Console.Clear();

		AnsiConsole.Write(
			new FigletText("EQUIPOS + GOLES")
				.Centered()
				.Color(Color.Green)
		);

		try
		{
			var tournaments = await _statsService.GetAllTournamentsAsync();
			if (!tournaments.Any())
			{
				AnsiConsole.MarkupLine("[red]❌ No hay torneos disponibles.[/]");
				AnsiConsole.WriteLine();
				AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
				Console.ReadKey();
				return;
			}

			var tournamentChoice = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title("[bold yellow]Seleccione un torneo:[/]")
					.PageSize(10)
					.AddChoices(tournaments.Select(t => $"{t.Id}. {t.Name}")));

			var tournamentId = int.Parse(tournamentChoice.Split('.')[0]);
			var selectedTournament = tournaments.First(t => t.Id == tournamentId);

			AnsiConsole.MarkupLine($"[bold blue]📊 Estadísticas de goles para: {selectedTournament.Name}[/]");
			AnsiConsole.WriteLine();

			var teams = await _statsService.GetTeamsWithMostGoalsAsync(tournamentId);
			if (!teams.Any())
			{
				AnsiConsole.MarkupLine("[yellow]⚠️  No hay estadísticas disponibles para este torneo.[/]");
				AnsiConsole.WriteLine();
				AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
				Console.ReadKey();
				return;
			}

			var table = new Table()
				.Title("[bold yellow]RANKING DE EQUIPOS POR GOLES[/]")
				.AddColumn("Pos", column => column.Width(5).Alignment(Justify.Center))
				.AddColumn("Equipo", column => column.Width(30))
				.AddColumn("Ciudad", column => column.Width(20))
				.AddColumn("Goles", column => column.Width(8).Alignment(Justify.Center))
				.AddColumn("Asistencias", column => column.Width(12).Alignment(Justify.Center))
				.AddColumn("Partidos", column => column.Width(10).Alignment(Justify.Center))
				.AddColumn("Promedio", column => column.Width(10).Alignment(Justify.Center));

			int position = 1;
			foreach (var team in teams)
			{
				table.AddRow(
					position++.ToString(),
					team.TeamName,
					team.CityName,
					team.TotalGoals.ToString(),
					team.TotalAssists.ToString(),
					team.MatchesPlayed.ToString(),
					team.AverageGoalsPerMatch.ToString("F2")
				);
			}

			AnsiConsole.Write(table);
		}
		catch (Exception ex)
		{
			AnsiConsole.MarkupLine($"[red]❌ Error: {ex.Message}[/]");
		}

		AnsiConsole.WriteLine();
		AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
		Console.ReadKey();
	}

	public async Task ShowMostExpensivePlayers()
	{
		Console.Clear();

		AnsiConsole.Write(
			new FigletText("JUGADORES CAROS")
				.Centered()
				.Color(Color.Green)
		);

		try
		{
			var teams = await _statsService.GetAllTeamsAsync();
			if (!teams.Any())
			{
				AnsiConsole.MarkupLine("[red]❌ No hay equipos disponibles.[/]");
				AnsiConsole.WriteLine();
				AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
				Console.ReadKey();
				return;
			}

			var teamChoice = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title("[bold yellow]Seleccione un equipo:[/]")
					.PageSize(10)
					.AddChoices(teams.Select(t => $"{t.Id}. {t.Name}")));

			var teamId = int.Parse(teamChoice.Split('.')[0]);
			var selectedTeam = teams.First(t => t.Id == teamId);

			AnsiConsole.MarkupLine($"[bold blue]💰 Jugadores más caros de: {selectedTeam.Name}[/]");
			AnsiConsole.WriteLine();

			var players = await _statsService.GetMostExpensivePlayersByTeamAsync(teamId);
			if (!players.Any())
			{
				AnsiConsole.MarkupLine("[yellow]⚠️  No hay jugadores con valor de mercado disponible.[/]");
				AnsiConsole.WriteLine();
				AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
				Console.ReadKey();
				return;
			}

			var table = new Table()
				.Title("[bold yellow]TOP 10 JUGADORES MÁS CAROS[/]")
				.AddColumn("Pos", column => column.Width(5).Alignment(Justify.Center))
				.AddColumn("Jugador", column => column.Width(30))
				.AddColumn("Valor (€)", column => column.Width(15).Alignment(Justify.Right))
				.AddColumn("Valor (M€)", column => column.Width(12).Alignment(Justify.Right))
				.AddColumn("Dorsal", column => column.Width(10).Alignment(Justify.Right))
				.AddColumn("Edad", column => column.Width(8).Alignment(Justify.Center));

			int position = 1;
			foreach (var ps in players)
			{
				var p = ps.Player;
				if (p == null) continue;

				var age = (int)((DateTime.Today - p.BirthDate).TotalDays / 365.25);
				var valueInMillions = p.MarketValue > 0 ? (p.MarketValue / 1000000).ToString("F1") + "M" : "N/A";

				table.AddRow(
					position++.ToString(),
					p.Name,
					p.MarketValue.ToString("N0"),
					valueInMillions,
					p.DorsalNumber.ToString(),
					age.ToString()
				);
			}

			AnsiConsole.Write(table);
		}
		catch (Exception ex)
		{
			AnsiConsole.MarkupLine($"[red]❌ Error: {ex.Message}[/]");
		}

		AnsiConsole.WriteLine();
		AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
		Console.ReadKey();
	}

	public async Task ShowPlayersBelowAverageAge()
	{
		Console.Clear();

		AnsiConsole.Write(
			new FigletText("JUGADORES JÓVENES")
				.Centered()
				.Color(Color.Green)
		);

		try
		{
			var teams = await _statsService.GetAllTeamsAsync();
			if (!teams.Any())
			{
				AnsiConsole.MarkupLine("[red]❌ No hay equipos disponibles.[/]");
				AnsiConsole.WriteLine();
				AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
				Console.ReadKey();
				return;
			}

			var teamChoice = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title("[bold yellow]Seleccione un equipo:[/]")
					.PageSize(10)
					.AddChoices(teams.Select(t => $"{t.Id}. {t.Name}")));

			var teamId = int.Parse(teamChoice.Split('.')[0]);
			var selectedTeam = teams.First(t => t.Id == teamId);

			var averageAge = await _statsService.GetAverageTeamAgeAsync(teamId);
			AnsiConsole.MarkupLine($"[bold blue]🎯 Jugadores menores al promedio de edad de: {selectedTeam.Name}[/]");
			AnsiConsole.MarkupLine($"[bold yellow]📊 Edad promedio del equipo: {averageAge:F1} años[/]");
			AnsiConsole.WriteLine();

			var players = await _statsService.GetPlayersBelowAverageAgeByTeamAsync(teamId);
			if (!players.Any())
			{
				AnsiConsole.MarkupLine("[yellow]⚠️  No hay jugadores menores al promedio de edad.[/]");
				AnsiConsole.WriteLine();
				AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
				Console.ReadKey();
				return;
			}

			var table = new Table()
				.Title("[bold yellow]JUGADORES MENORES AL PROMEDIO DE EDAD[/]")
				.AddColumn("Pos", column => column.Width(5).Alignment(Justify.Center))
				.AddColumn("Jugador", column => column.Width(30))
				.AddColumn("Edad", column => column.Width(8).Alignment(Justify.Center))
				.AddColumn("Fecha Nac.", column => column.Width(15).Alignment(Justify.Center))
				.AddColumn("Dorsal", column => column.Width(10).Alignment(Justify.Center))
				.AddColumn("Valor (M€)", column => column.Width(12).Alignment(Justify.Right));

			int position = 1;
			foreach (var ps in players)
			{
				var p = ps.Player;
				if (p == null) continue;

				var age = (int)((DateTime.Today - p.BirthDate).TotalDays / 365.25);
				var birthDate = p.BirthDate.ToString("yyyy-MM-dd");
				var valueInMillions = p.MarketValue > 0 ? (p.MarketValue / 1000000).ToString("F1") + "M" : "N/A";

				table.AddRow(
					position++.ToString(),
					p.Name,
					age.ToString(),
					birthDate,
					p.DorsalNumber.ToString(),
					valueInMillions
				);
			}

			AnsiConsole.Write(table);
		}
		catch (Exception ex)
		{
			AnsiConsole.MarkupLine($"[red]❌ Error: {ex.Message}[/]");
		}

		AnsiConsole.WriteLine();
		AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
		Console.ReadKey();
	}
}
