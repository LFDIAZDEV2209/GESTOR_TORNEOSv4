using GESTOR_TORNEOSv4.src.Modules.Tournaments.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Tournaments.Domain.Entities;
using Spectre.Console;

namespace GESTOR_TORNEOSv4.src.Modules.Tournaments.Application.UI;

public class TournamentUI : ITournamentUI
{
    private readonly ITournamentService _tournamentService;

    public TournamentUI(ITournamentService tournamentService)
    {
        _tournamentService = tournamentService;
    }

    public async Task ShowMenu()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Torneos")
                .Centered()
                .Color(Color.Yellow));

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Seleccione una opción")
                .AddChoices(new[] 
                { 
                    "0. Crear Torneo", 
                    "1. Buscar Torneo", 
                    "2. Eliminar Torneo",
                    "3. Actualizar Torneo",
                    "4. Regresar al menu principal"
                }));

            switch (selection[0])
            {
                case '0':
                    Console.Clear();
                    await ShowAddTournament();
                    break;
                case '1':
                    Console.Clear();
                    await ShowSearchTournaments();
                    break;
                case '2':
                    Console.Clear();
                    await ShowDeleteTournament();
                    break;
                case '3':
                    Console.Clear();
                    await ShowUpdateTournament();
                    break;
                case '4':
                    Console.WriteLine("Regresando al menu principal...");
                    return;
                default:
                    AnsiConsole.MarkupLine("[red]Opción no válida[/]");
                    break;
            }
        }
    }

    public async Task ShowSearchTournaments()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.Write(
            new FigletText("Buscar Torneos")
            .Centered()
            .Color(Color.Yellow));
        
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Como desea buscar el torneo?")
                .AddChoices(new[]
                {
                    "1. Por ID",
                    "2. Mostrar todos",
                    "3. Regresar al menu principal"
                })
            );

            switch (selection[0])
            {
                case '1':
                    await ShowTournamentDetail();
                    break;
                case '2':
                    await ShowAllTournaments();
                    break;
                case '3':
                    return;
                }
        }
    }

    public async Task ShowAllTournaments()
    {
        try
        {
            var tournaments = await _tournamentService.GetAllTournamentsAsync() 
                ?? throw new Exception("No se encontraron torneos.");

            var tableTournaments = new Table();
            tableTournaments.AddColumn("ID");
            tableTournaments.AddColumn("Nombre");
            tableTournaments.AddColumn("Fecha de inicio");
            tableTournaments.AddColumn("Fecha de fin");

            foreach (var t in tournaments)
            {
                tableTournaments.AddRow(t.Id.ToString(), t.Name, t.StartDate.Date.ToString("dd/MM/yyyy"), t.EndDate.Date.ToString("dd/MM/yyyy"));
            }

            AnsiConsole.Write(tableTournaments);
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al mostrar la lista de torneos: {ex.Message}[/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
    }

    public async Task ShowAddTournament()
    {
        AnsiConsole.Write(
            new FigletText("Crear Torneo")
            .Centered()
            .Color(Color.Green));

        var name = AnsiConsole.Ask<string>("[blue]Nombre del torneo:[/]");
        var startDate = AnsiConsole.Ask<DateTime>("[blue]Fecha de inicio (dd/MM/yyyy):[/]");
        var endDate = AnsiConsole.Ask<DateTime>("[blue]Fecha de fin (dd/MM/yyyy):[/]");

        var tournament = new Tournament
        {
            Name = name,
            StartDate = startDate,
            EndDate = endDate
        };

        try
        {
            await _tournamentService.AddTournamentAsync(tournament);
            AnsiConsole.MarkupLine("[green]Torneo creado exitosamente![/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al crear el torneo: {ex.Message}[/]");
        }

    }

    public async Task ShowUpdateTournament()
    {
        AnsiConsole.Write(
            new FigletText("Actualizar Torneo")
            .Centered()
            .Color(Color.Blue));

        var tournaments = await _tournamentService.GetAllTournamentsAsync();

        foreach (var t in tournaments)
        {
            AnsiConsole.MarkupLine($"[blue]ID:[/] {t.Id} [blue]Nombre:[/] {t.Name}");
        }

        var id = AnsiConsole.Ask<int>("[blue]ID del torneo a actualizar:[/]");

        var tournament = await _tournamentService.GetTournamentByIdAsync(id)
            ?? throw new Exception($"Torneo con ID {id} no encontrado.");

        var name = AnsiConsole.Ask<string>("[blue]Nuevo nombre del torneo:[/]", tournament.Name);
        var startDate = AnsiConsole.Ask<DateTime>("[blue]Nueva fecha de inicio (dd/MM/yyyy):[/]", tournament.StartDate);
        var endDate = AnsiConsole.Ask<DateTime>("[blue]Nueva fecha de fin (dd/MM/yyyy):[/]", tournament.EndDate);

        tournament.Name = name;
        tournament.StartDate = startDate;
        tournament.EndDate = endDate;

        try
        {
            await _tournamentService.UpdateTournamentAsync(id, tournament);
            AnsiConsole.MarkupLine("[green]Torneo actualizado exitosamente![/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al actualizar el torneo: {ex.Message}[/]");
        }
    }

    public async Task ShowDeleteTournament()
    {
        AnsiConsole.Write(
            new FigletText("Eliminar Torneo")
            .Centered()
            .Color(Color.Red));

        var tournaments = await _tournamentService.GetAllTournamentsAsync();

        foreach (var t in tournaments)
        {
            AnsiConsole.MarkupLine($"[blue]ID:[/] {t.Id} [blue]Nombre:[/] {t.Name}");
        }

        var id = AnsiConsole.Ask<int>("[blue]ID del torneo a eliminar:[/]");

        try
        {
            await _tournamentService.DeleteTournamentAsync(id);
            AnsiConsole.MarkupLine("[green]Torneo eliminado exitosamente![/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al eliminar el torneo: {ex.Message}[/]");
        }
    }

    public async Task ShowTournamentDetail()
    {
        var id = AnsiConsole.Ask<int>("[blue]ID del torneo:[/]");

        var tournament = await _tournamentService.GetTournamentByIdAsync(id) 
            ?? throw new Exception($"Torneo con ID {id} no encontrado.");

        var tableTournament = new Table();
        tableTournament.AddColumn("ID");
        tableTournament.AddColumn("Nombre");
        tableTournament.AddColumn("Fecha de inicio");
        tableTournament.AddColumn("Fecha de fin");
        tableTournament.AddRow(tournament.Id.ToString(), tournament.Name, tournament.StartDate.Date.ToString("dd/MM/yyyy"), tournament.EndDate.Date.ToString("dd/MM/yyyy"));

        AnsiConsole.Write(tableTournament);
        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }
}