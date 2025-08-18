using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Spectre.Console;

namespace GESTOR_TORNEOSv4.src.Modules.Application.UI;

public class TransferUI : ITransferUI
{
    private readonly ITransferService _transferService;
    private readonly IPlayerService _playerService;
    private readonly ITeamService _teamService;

    public TransferUI(ITransferService transferService, IPlayerService playerService, ITeamService teamService)
    {
        _transferService = transferService;
        _playerService = playerService;
        _teamService = teamService;
    }

    public async Task ShowTransferMenu()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Transferencias")
                    .Centered()
                    .Color(Color.Yellow)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold green]Seleccione una opción[/]")
                    .PageSize(10)
                    .AddChoices(new[]
                    {
                        "3.1. Comprar Jugador",
                        "3.2. Prestar Jugador",
                        "3.3. Regresar al Menú Principal"
                    }));

            switch (selection)
            {
                case "3.1. Comprar Jugador":
                    await BuyPlayer();
                    break;
                case "3.2. Prestar Jugador":
                    await LoanPlayer();
                    break;
                case "3.3. Regresar al Menú Principal":
                    return;
                default:
                    AnsiConsole.MarkupLine("[red]Opción no válida[/]");
                    break;
            }
        }
    }

    public async Task BuyPlayer()
    {
        Console.Clear();

        AnsiConsole.Write(
            new FigletText("Comprar Jugador")
                .Centered()
                .Color(Color.Green)
        );

        try
        {
            // Seleccionar jugador
            var players = await _playerService.GetAllPlayersAsync();
            if (!players.Any())
            {
                AnsiConsole.MarkupLine("[red]❌ No hay jugadores disponibles.[/]");
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            var playerChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold yellow]Seleccione el jugador a comprar:[/]")
                    .PageSize(10)
                    .AddChoices(players.Select(p => $"{p.Id}. {p.Name}")));

            var playerId = int.Parse(playerChoice.Split('.')[0]);
            var selectedPlayer = players.First(p => p.Id == playerId);

            // Seleccionar equipo destino
            var teams = await _teamService.GetAllTeamsAsync();
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
                    .Title("[bold yellow]Seleccione el equipo destino:[/]")
                    .PageSize(10)
                    .AddChoices(teams.Select(t => $"{t.Id}. {t.Name}")));

            var teamId = int.Parse(teamChoice.Split('.')[0]);
            var selectedTeam = teams.First(t => t.Id == teamId);

            // Ingresar monto
            var amount = AnsiConsole.Prompt(
                new TextPrompt<decimal>("[bold blue]Ingrese el monto de la transferencia (€):[/]")
                    .ValidationErrorMessage("[red]Monto inválido[/]")
                    .Validate(amount => amount > 0 ? ValidationResult.Success() : ValidationResult.Error("El monto debe ser mayor a 0")));

            // Crear transferencia
            var transfer = await _transferService.BuyPlayerAsync(playerId, teamId, amount);

            AnsiConsole.MarkupLine("[green]✅ Transferencia de compra realizada exitosamente![/]");
            AnsiConsole.MarkupLine($"[blue]💰 Jugador:[/] {selectedPlayer.Name}");
            AnsiConsole.MarkupLine($"[blue]🏆 Equipo:[/] {selectedTeam.Name}");
            AnsiConsole.MarkupLine($"[blue]💶 Monto:[/] €{amount:N2}");
            AnsiConsole.MarkupLine($"[blue]📅 Fecha:[/] {transfer.TransferDate:dd/MM/yyyy}");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]❌ Error: {ex.Message}[/]");
        }

        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    public async Task LoanPlayer()
    {
        Console.Clear();

        AnsiConsole.Write(
            new FigletText("Prestar Jugador")
                .Centered()
                .Color(Color.Green)
        );

        try
        {
            // Seleccionar jugador
            var players = await _playerService.GetAllPlayersAsync();
            if (!players.Any())
            {
                AnsiConsole.MarkupLine("[red]❌ No hay jugadores disponibles.[/]");
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            var playerChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold yellow]Seleccione el jugador a prestar:[/]")
                    .PageSize(10)
                    .AddChoices(players.Select(p => $"{p.Id}. {p.Name}")));

            var playerId = int.Parse(playerChoice.Split('.')[0]);
            var selectedPlayer = players.First(p => p.Id == playerId);

            // Seleccionar equipo destino
            var teams = await _teamService.GetAllTeamsAsync();
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
                    .Title("[bold yellow]Seleccione el equipo destino:[/]")
                    .PageSize(10)
                    .AddChoices(teams.Select(t => $"{t.Id}. {t.Name}")));

            var teamId = int.Parse(teamChoice.Split('.')[0]);
            var selectedTeam = teams.First(t => t.Id == teamId);

            // Crear préstamo
            var transfer = await _transferService.LoanPlayerAsync(playerId, teamId);

            AnsiConsole.MarkupLine("[green]✅ Préstamo de jugador realizado exitosamente![/]");
            AnsiConsole.MarkupLine($"[blue]💰 Jugador:[/] {selectedPlayer.Name}");
            AnsiConsole.MarkupLine($"[blue]🏆 Equipo:[/] {selectedTeam.Name}");
            AnsiConsole.MarkupLine($"[blue]📅 Fecha:[/] {transfer.TransferDate:dd/MM/yyyy}");
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
