using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Spectre.Console;

namespace GESTOR_TORNEOSv4.src.Modules.Application.UI;

public class PlayerUI : IPlayerUI
{
    private readonly IPlayerService _playerService;

    public PlayerUI(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public async Task ShowMenu()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Jugadores")
                .Centered()
                .Color(Color.Yellow));

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Seleccione una opción")
                .AddChoices(new[] 
                { 
                    "0. Crear Jugador", 
                    "1. Buscar Jugador", 
                    "2. Eliminar Jugador",
                    "3. Actualizar Jugador",
                    "4. Regresar al menu principal"
                }));

            switch (selection[0])
            {
                case '0':
                    Console.Clear();
                    await ShowAddPlayer();
                    break;
                case '1':
                    Console.Clear();
                    await ShowSearchPlayer();
                    break;
                case '2':
                    Console.Clear();
                    await ShowDeletePlayer();
                    break;
                case '3':
                    Console.Clear();
                    await ShowUpdatePlayer();
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

    public async Task ShowSearchPlayer()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.Write(
            new FigletText("Buscar Jugadores")
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
                    await ShowPlayerDetails();
                    break;
                case '2':
                    await ShowAllPlayers();
                    break;
                case '3':
                    return;
                }
        }
    }

    public async Task ShowPlayerDetails()
    {
        var id = AnsiConsole.Ask<int>("[blue]ID del Jugador:[/]");

        var player = await _playerService.GetPlayerByIdAsync(id) 
            ?? throw new Exception($"Jugador con ID {id} no encontrado.");

        var tablePlayer = new Table();
        tablePlayer.AddColumn("ID");
        tablePlayer.AddColumn("Nombre");
        tablePlayer.AddColumn("Dorsal");
        tablePlayer.AddColumn("Fecha de nacimiento");
        tablePlayer.AddColumn("Valor de mercado");
        tablePlayer.AddRow(player.Id.ToString(), player.Name, player.DorsalNumber.ToString(), player.BirthDate.Date.ToShortDateString(), player.MarketValue.ToString("C"));

        AnsiConsole.Write(tablePlayer);
        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }

    public async Task ShowAllPlayers()
    {
        try
        {
            var players = await _playerService.GetAllPlayersAsync() 
                ?? throw new Exception("No se encontraron torneos.");

            var tablePlayer = new Table();
            tablePlayer.AddColumn("ID");
            tablePlayer.AddColumn("Nombre");
            tablePlayer.AddColumn("Dorsal");
            tablePlayer.AddColumn("Fecha de nacimiento");
            tablePlayer.AddColumn("Valor de mercado");

            foreach (var p in players)
            {
                tablePlayer.AddRow(p.Id.ToString(), p.Name, p.DorsalNumber.ToString(), p.BirthDate.Date.Date.ToString("dd/MM/yyyy"), p.MarketValue.ToString("C"));
            }

            AnsiConsole.Write(tablePlayer);
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

    public async Task ShowAddPlayer()
    {
        AnsiConsole.Write(
            new FigletText("Crear Jugador")
            .Centered()
            .Color(Color.Green));

        var name = AnsiConsole.Ask<string>("[blue]Nombre del jugador:[/]");
        var DorsalNumber = AnsiConsole.Ask<int>("[blue]Dorsal del jugador:[/]");
        var BirthDate = AnsiConsole.Ask<DateTime>("[blue]Fecha de nacimiento (dd/MM/yyyy):[/]");
        var MarketValue = AnsiConsole.Ask<decimal>("[blue]Valor de mercado: [/]");

        var player = new Player
        {
            Name = name,
            DorsalNumber = DorsalNumber,
            BirthDate = BirthDate,
            MarketValue = MarketValue
        };

        try
        {
            await _playerService.AddPlayerAsync(player);
            AnsiConsole.MarkupLine("[green]Jugador creado exitosamente![/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al crear el torneo: {ex.Message}[/]");
        }
    }

    public async Task ShowUpdatePlayer()
    {
        AnsiConsole.Write(
            new FigletText("Actualizar Juagador")
            .Centered()
            .Color(Color.Blue));

        var players = await _playerService.GetAllPlayersAsync();

        foreach (var t in players)
        {
            AnsiConsole.MarkupLine($"[blue]ID:[/] {t.Id} [blue]Nombre:[/] {t.Name}");
        }

        var id = AnsiConsole.Ask<int>("[blue]ID del jugador a actualizar:[/]");

        var player = await _playerService.GetPlayerByIdAsync(id)
            ?? throw new Exception($"Juagdor con ID {id} no encontrado.");

        var name = AnsiConsole.Ask<string>("[blue]Nuevo nombre del jugador:[/]", player.Name);
        var dorsalNumber = AnsiConsole.Ask<int>("[blue]Nuevo dorsal del jugador:[/]", player.DorsalNumber);
        var birthDate = AnsiConsole.Ask<DateTime>("[blue]Nueva fecha de nacimiento (dd/MM/yyyy):[/]", player.BirthDate);
        var marketValue = AnsiConsole.Ask<decimal>("[blue]Nuevo valor de mercado: [/] ", player.MarketValue);
        
        player.Name = name;
        player.DorsalNumber = dorsalNumber;
        player.BirthDate = birthDate;
        player.MarketValue = marketValue;

        try
        {
            await _playerService.UpdatePlayerAsync(id, player);
            AnsiConsole.MarkupLine("[green]Jugador actualizado exitosamente![/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al actualizar el Jugador: {ex.Message}[/]");
        }
    }

    public async Task ShowDeletePlayer()
    {
        AnsiConsole.Write(
            new FigletText("Eliminar Jugador")
            .Centered()
            .Color(Color.Red));

        var players = await _playerService.GetAllPlayersAsync();

        foreach (var p in players)
        {
            AnsiConsole.MarkupLine($"[blue]ID:[/] {p.Id} [blue]Nombre:[/] {p.Name}");
        }

        var id = AnsiConsole.Ask<int>("[blue]ID del Jugador a eliminar:[/]");

        try
        {
            await _playerService.DeletePlayerAsync(id);
            AnsiConsole.MarkupLine("[green]Jugador eliminado exitosamente![/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al eliminar el Jugador: {ex.Message}[/]");
        }
    }
}

