using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Spectre.Console;

namespace GESTOR_TORNEOSv4.src.Modules.Application.UI;

public class TeamUI : ITeamUI
{
    private readonly ITeamService _teamService;
    private readonly ICityService _cityService;
    private readonly ITournamentTeamService _tournamentTeamService;
    private readonly ITournamentService _tournamentService;
    private readonly IStaffService _staffService;

    public TeamUI(ITeamService teamService, ICityService cityService, ITournamentTeamService tournamentTeamService, ITournamentService tournamentService, IStaffService staffService)
    {
        _teamService = teamService;
        _cityService = cityService;
        _tournamentTeamService = tournamentTeamService;
        _tournamentService = tournamentService;
        _staffService = staffService;
    }

    public async Task ShowMenu()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Equipos")
                .Centered()
                .Color(Color.Yellow)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]Seleccione una opción[/]")
                .AddChoices(new[]
                {
                    "0. Gestión de Equipos",
                    "1. Registrar Cuerpo Técnico",
                    "2. Registrar Cuerpo Médico",
                    "3. Inscribir Equipo en Torneo",
                    "4. Eliminar Equipo en Torneo",
                    "5. Notificaciones de Transferencia",
                    "6. Salir"
                }));

            switch (selection[0])
            {
                case '0':
                    Console.Clear();
                    await ShowTeamManagement();
                    break;
                case '1':
                    Console.Clear();
                    await ShowAssignTechnicalStaffToTeam();
                    break;
                case '2':
                    Console.Clear();
                    await ShowAssignMedicalStaffToTeam();
                    break;
                case '3':
                    Console.Clear();
                    await ShowInscribeTeamToTournament();
                    break;
                case '4':
                    Console.Clear();
                    await ShowRemoveTeamFromTournament();
                    break;
                case '5':
                    AnsiConsole.MarkupLine("[yellow]Funcionalidad en desarrollo[/]");
                    break;
                case '6':
                    return;
                default:
                    AnsiConsole.MarkupLine("[red]Opción no válida[/]");
                    break;
            }
        }
    }

    public async Task ShowTeamManagement()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Gestión de Equipos")
                .Centered()
                .Color(Color.Yellow)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]Seleccione una opción[/]")
                .AddChoices(new[]
                {
                    "0. Crear Equipo",
                    "1. Actualizar Equipo",
                    "2. Eliminar Equipo",
                    "3. Buscar Equipo",
                    "4. Salir"
                }));

            switch (selection[0])
            {
                case '0':
                    await ShowAddTeam();
                    break;
                case '1':
                    await ShowUpdateTeam();
                    break;
                case '2':
                    await ShowDeleteTeam();
                    break;
                case '3':
                    await ShowSearchTeams();
                    break;
                case '4':
                    return;
                default:
                    AnsiConsole.MarkupLine("[red]Opción no válida[/]");
                    break;
            }

        }
    }

    public async Task ShowAddTeam()
    {
        AnsiConsole.Write(
            new FigletText("Crear Equipo")
            .Centered()
            .Color(Color.Green));

        var name = AnsiConsole.Ask<string>("[blue]Nombre del Equipo:[/]");

        var cities = await _cityService.GetAllCitiesAsync();

        var cityNames = cities.Select(c => $"{c.Id}: {c.Name}").ToList();

        var citySelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[blue]Seleccione una ciudad:[/]")
            .PageSize(10)
            .AddChoices(cityNames));

        var cityId = int.Parse(citySelection.Split(':')[0]);

        var team = new Team
        {
            Name = name,
            CityId = cityId,
        };

        try
        {
            await _teamService.AddTeamAsync(team);
            AnsiConsole.MarkupLine("[green]Equipo creado exitosamente![/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al crear el Equipo: {ex.Message}[/]");
        }
    }

    public async Task ShowAllTeams()
    {
        try
        {
            var teams = await _teamService.GetAllTeamsAsync() 
                ?? throw new Exception("No se encontraron torneos.");

            var tableTeam = new Table();
            tableTeam.AddColumn("ID");
            tableTeam.AddColumn("Nombre");

            foreach (var t in teams)
            {
                tableTeam.AddRow(t.Id.ToString(), t.Name);
            }

            AnsiConsole.Write(tableTeam);
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

    public async Task ShowDeleteTeam()
    {
        AnsiConsole.Write(
            new FigletText("Eliminar Equipo")
            .Centered()
            .Color(Color.Red));

        var teams = await _teamService.GetAllTeamsAsync();

        foreach (var t in teams)
        {
            AnsiConsole.MarkupLine($"[blue]ID:[/] {t.Id} [blue]Nombre:[/] {t.Name}");
        }

        var id = AnsiConsole.Ask<int>("[blue]ID del Equipo a eliminar:[/]");

        try
        {
            await _teamService.DeleteTeamAsync(id);
            AnsiConsole.MarkupLine("[green]Equipo eliminado exitosamente![/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al eliminar el Equipo: {ex.Message}[/]");
        }
    }

    public async Task ShowSearchTeams()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.Write(
            new FigletText("Buscar Equipo")
            .Centered()
            .Color(Color.Yellow));
        
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Como desea buscar el equipo?")
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
                    await ShowTeamDetail();
                    break;
                case '2':
                    await ShowAllTeams();
                    break;
                case '3':
                    return;
                }
        }
    }

    public async Task ShowTeamDetail()
    {
        var id = AnsiConsole.Ask<int>("[blue]ID del Equipo:[/]");

        var team = await _teamService.GetTeamByIdAsync(id) 
            ?? throw new Exception($"Equipo con ID {id} no encontrado.");

        var tableTeam = new Table();
        tableTeam.AddColumn("ID");
        tableTeam.AddColumn("Nombre");
        tableTeam.AddRow(team.Id.ToString(), team.Name);

        AnsiConsole.Write(tableTeam);
        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }

    public async Task ShowUpdateTeam()
    {
        AnsiConsole.Write(
            new FigletText("Actualizar Torneo")
            .Centered()
            .Color(Color.Blue));

        var tournaments = await _teamService.GetAllTeamsAsync();

        foreach (var t in tournaments)
        {
            AnsiConsole.MarkupLine($"[blue]ID:[/] {t.Id} [blue]Nombre:[/] {t.Name}");
        }

        var id = AnsiConsole.Ask<int>("[blue]ID del torneo a actualizar:[/]");

        var team = await _teamService.GetTeamByIdAsync(id)
            ?? throw new Exception($"Torneo con ID {id} no encontrado.");

        var name = AnsiConsole.Ask<string>("[blue]Nuevo nombre del torneo:[/]", team.Name);

        var cities = await _cityService.GetAllCitiesAsync(); 
        var cityNames = cities.Select(c => $"{c.Id}: {c.Name}").ToList();
        var citySelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[blue]Seleccione una ciudad:[/]")
            .PageSize(10)
            .AddChoices(cityNames));

        var cityId = int.Parse(citySelection.Split(':')[0]);

        team.CityId = cityId;
        team.Name = name;

        try
        {
            await _teamService.UpdateTeamAsync(id, team);
            AnsiConsole.MarkupLine("[green]Torneo actualizado exitosamente![/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al actualizar el torneo: {ex.Message}[/]");
        }
    }

    public async Task ShowInscribeTeamToTournament()
    {
        AnsiConsole.Write(
            new FigletText("Inscribir Equipo a Torneo")
            .Centered()
            .Color(Color.Green));

        var teams = await _teamService.GetAllTeamsAsync();

        var teamNames = teams.Select(t => $"{t.Id}: {t.Name}").ToList();
        var teamSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[blue]Seleccione un equipo:[/]")
            .PageSize(10)
            .AddChoices(teamNames));
        var teamId = int.Parse(teamSelection.Split(':')[0]);

        var tournaments = await _tournamentService.GetTournamentsWhereTeamIsNotEnrolledAsync(teamId);

        if (tournaments == null || !tournaments.Any())
        {
            AnsiConsole.MarkupLine("[red]No hay torneos disponibles para inscribir el equipo.[/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
            return;
        }

        var tournamentNames = tournaments.Select(t => $"{t.Id}: {t.Name}").ToList();
        var tournamentSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[blue]Seleccione un torneo para inscribir el equipo:[/]")
            .PageSize(10)
            .AddChoices(tournamentNames));
        var tournamentId = int.Parse(tournamentSelection.Split(':')[0]);

        try
        {
            await _tournamentTeamService.InscribeTeamToTournamentAsync(tournamentId, teamId);
            AnsiConsole.MarkupLine("[green]Equipo inscrito al torneo exitosamente![/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al inscribir el equipo al torneo: {ex.Message}[/]");
        }
    }

    public async Task ShowRemoveTeamFromTournament()
    {
        AnsiConsole.Write(
            new FigletText("Eliminar Equipo de Torneo")
            .Centered()
            .Color(Color.Red));

        var teams = await _teamService.GetTeamsWithAtLeastOneTournamentAsync();

        var teamNames = teams.Select(t => $"{t.Id}: {t.Name}").ToList();
        var teamSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[blue]Seleccione un equipo:[/]")
            .PageSize(10)
            .AddChoices(teamNames));
        var teamId = int.Parse(teamSelection.Split(':')[0]);

        var tournaments = await _tournamentService.GetTournamentsByTeamIdAsync(teamId);

        var tournamentNames = tournaments.Select(t => $"{t.Id}: {t.Name}").ToList();
        var tournamentSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[blue]Seleccione un torneo para eliminar el equipo:[/]")
            .PageSize(10)
            .AddChoices(tournamentNames));
        var tournamentId = int.Parse(tournamentSelection.Split(':')[0]);

        try
        {
            await _tournamentTeamService.RemoveTeamFromTournamentAsync(tournamentId, teamId);
            AnsiConsole.MarkupLine("[green]Equipo eliminado del torneo exitosamente![/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al eliminar el equipo del torneo: {ex.Message}[/]");
        }
    }

    public async Task ShowAssignMedicalStaffToTeam()
    {
        AnsiConsole.Write(
            new FigletText("Asignar Médico a Equipo")
            .Centered()
            .Color(Color.Green));

        var teams = await _teamService.GetAllTeamsAsync();

        var teamNames = teams.Select(t => $"{t.Id}: {t.Name}").ToList();

        var teamSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[blue]Seleccione un equipo:[/]")
            .PageSize(10)
            .AddChoices(teamNames));
        var teamId = int.Parse(teamSelection.Split(':')[0]);
        
        var medicalStaff = await _staffService.GetUnassignedStaffByTypeAsync(2);

        if (medicalStaff == null || !medicalStaff.Any())
        {
            AnsiConsole.MarkupLine("[red]No hay médicos disponibles para asignar al equipo.[/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
            return;
        }

        var medicalStaffNames = medicalStaff.Select(s => $"{s.Id}: {s.Name}").ToList();
        var medicalStaffSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[blue]Seleccione un médico:[/]")
            .PageSize(10)
            .AddChoices(medicalStaffNames));
        var medicalStaffId = int.Parse(medicalStaffSelection.Split(':')[0]);

        try
        {
            await _staffService.AssignStaffToTeamAsync(medicalStaffId, teamId);
            AnsiConsole.MarkupLine("[green]Médico asignado al equipo exitosamente![/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al asignar el médico al equipo: {ex.Message}[/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
    }

    public async Task ShowAssignTechnicalStaffToTeam()
    {
        AnsiConsole.Write(
            new FigletText("Asignar Técnico a Equipo")
            .Centered()
            .Color(Color.Green));
        
        var teams = await _teamService.GetAllTeamsAsync();

        var teamNames = teams.Select(t => $"{t.Id}: {t.Name}").ToList();

        var teamSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[blue]Seleccione un equipo:[/]")
            .PageSize(10)
            .AddChoices(teamNames));
        var teamId = int.Parse(teamSelection.Split(':')[0]);

        var technicalStaff = await _staffService.GetUnassignedStaffByTypeAsync(1);

        if (technicalStaff == null || !technicalStaff.Any())
        {
            AnsiConsole.MarkupLine("[red]No hay técnicos disponibles para asignar al equipo.[/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
            return;
        }

        var technicalStaffNames = technicalStaff.Select(s => $"{s.Id}: {s.Name}").ToList();
        var technicalStaffSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[blue]Seleccione un técnico:[/]")
            .PageSize(10)
            .AddChoices(technicalStaffNames));
        var technicalStaffId = int.Parse(technicalStaffSelection.Split(':')[0]);

        try
        {
            await _staffService.AssignStaffToTeamAsync(technicalStaffId, teamId);
            AnsiConsole.MarkupLine("[green]Técnico asignado al equipo exitosamente![/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al asignar el técnico al equipo: {ex.Message}[/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
    }
}
