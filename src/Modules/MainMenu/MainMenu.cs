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
    private readonly IStaffUI _technicalStaffUI;
    private readonly IStaffUI _medicalStaffUI;
    private readonly IMatchUI _matchUI;
    private readonly IStatsUI _statsUI;
    private readonly ITransferUI _transferUI;

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
        var matchRepository = new MatchRepository(_dbContext);
        var statsRepository = new StatsRepository(_dbContext);
        var transferRepository = new TransferRepository(_dbContext);

        var tournamentService = new TournamentService(tournamentRepository);
        var teamService = new TeamService(teamRepository);
        var playerService = new PlayerService(playerRepository);
        var cityService = new CityService(cityRepository);
        var tournamentTeamService = new TeamTournamentService(tournamentTeamRepository);
        var staffService = new StaffService(staffRepository);
        var countryService = new CountryService(countryRepository);
        var matchService = new MatchService(matchRepository);
        var statsService = new StatsService(statsRepository, tournamentService, teamService);
        var transferService = new TransferService(transferRepository);

        _tournamentUI = new TournamentUI(tournamentService);
        _teamUI = new TeamUI(teamService, cityService, tournamentTeamService, tournamentService, staffService);
        _playerUI = new PlayerUI(playerService);
        _technicalStaffUI = new TechnicalStaffUI(staffService, countryService);
        _medicalStaffUI = new MedicalStaffUI(staffService, countryService);
        _matchUI = new MatchUI(matchService, tournamentService, teamService, tournamentTeamService);
        _statsUI = new StatsUI(statsService);
        _transferUI = new TransferUI(transferService, playerService, teamService);
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
                    "0. Crear Torneo",
                    "1. Registro Equipos",
                    "2. Registro Jugadores",
                    "3. Transferencia (Compra, Préstamo)",
                    "4. Estadísticas",
                    "5. Partidos",
                    "6. Salir"
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
                    await _playerUI.ShowMenu();
                    break;
                case '3':
                    Console.Clear();
                    await _transferUI.ShowTransferMenu();
                    break;
                case '4':
                    Console.Clear();
                    await _statsUI.ShowStatsMenu();
                    break;
                case '5':
                    Console.Clear();
                    await _matchUI.ShowMatchMenu();
                    break;
                case '6':
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