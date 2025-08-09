using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Application.Services;
using GESTOR_TORNEOSv4.src.Modules.Application.UI;
using GESTOR_TORNEOSv4.src.Modules.Infrastructure;
using GESTOR_TORNEOSv4.src.Shared.Context;
using Spectre.Console;

namespace GESTOR_TORNEOS.src.Modules.MainMenu;

// Responsabilidad: Mostrar el menu principal y gestionar las opciones
public class MainMenu
{
    private readonly AppDbContext _dbContext;
    private readonly ITournamentUI _tournamentUI;
    private readonly ITeamUI _teamUI;
    private readonly IPlayerUI _playerUI;
    private readonly ITechnicalStaffUI _technicalStaffUI;

    public MainMenu(AppDbContext dbContext)
    {
        _dbContext = dbContext;

        var tournamentRepository = new TournamentRepository(_dbContext);
        var teamRepository = new TeamRepository(_dbContext);
        var playerRepository = new PlayerRepository(_dbContext);
        var cityRepository = new CityRepository(_dbContext);
        var tournamentTeamRepository = new TournamentTeamRepository(_dbContext);
        var staffRepository = new StaffRepository(_dbContext);
        var countryRepository = new CountryRepository(_dbContext);

        var tournamentService = new TournamentService(tournamentRepository);
        var teamService = new TeamService(teamRepository);
        var playerService = new PlayerService(playerRepository);
        var cityService = new CityService(cityRepository);
        var tournamentTeamService = new TeamTournamentService(tournamentTeamRepository);
        var staffService = new StaffService(staffRepository);
        var countryService = new CountryService(countryRepository);

        _tournamentUI = new TournamentUI(tournamentService);
        _teamUI = new TeamUI(teamService, cityService, tournamentTeamService, tournamentService);
        _playerUI = new PlayerUI(playerService);
        _technicalStaffUI = new TechnicalStaffUI(staffService, countryService);
    }

    public async Task Show()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Gestor de Torneos")
                .Centered()
                .Color(Color.Red)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]Seleccione una opción[/]")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "0. Torneos",
                    "1. Equipos",
                    "2. Jugadores",
                    "3. Cuerpo Técnico",
                    "4. Cuerpo Médico",
                    "5. Partidos",
                    "6. Estadísticas",
                    "7. Transferencias (Compra, Préstamo)",
                    "8. Salir"
                }));

            switch (selection[0])
            {
                case '0':
                    Console.Clear();
                    await _tournamentUI.ShowMenu();
                    break;
                case '1':
                    Console.Clear();
                    await _teamUI.ShowMenu();
                    break;
                case '2':
                    Console.Clear();
                    await  _playerUI.ShowMenu();
                    break;
                case '3':
                    Console.Clear();
                    await _technicalStaffUI.ShowMenu();
                    break;
                case '4':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de cuerpo médico en desarrollo...[/]");
                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
                case '5':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de partidos en desarrollo...[/]");
                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
                case '6':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de estadísticas en desarrollo...[/]");
                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
                case '7':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de transferencias en desarrollo...[/]");
                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
                case '8':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[red]Saliendo del programa...[/]");
                    return;
                default:
                    AnsiConsole.MarkupLine("[bold red]Opción no válida[/]");
                    break;
            }
        }
    }
}