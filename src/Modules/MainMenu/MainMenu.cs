using GESTOR_TORNEOS.src.Shared.Context;
using Spectre.Console;

namespace GESTOR_TORNEOS.src.Modules.MainMenu;

// Responsabilidad: Mostrar el menu principal y gestionar las opciones
public class MainMenu
{
    private readonly AppDbContext _dbContext;

    public MainMenu(AppDbContext dbContext)
    {
        _dbContext = dbContext;
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
                    "0. Gestión de Torneos",
                    "1. Gestión de Equipos",
                    "2. Gestión de Jugadores",
                    "3. Gestión de Cuerpo Técnico",
                    "4. Gestión de Cuerpo Médico",
                    "5. Gestión de Partidos",
                    "6. Gestión de Estadísticas",
                    "7. Gestión de Transferencias (Compra, Préstamo)",
                    "8. Salir"
                }));

            switch (selection[0])
            {
                case '0':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de torneos en desarrollo...[/]");
                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
                case '1':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de equipos en desarrollo...[/]");
                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
                case '2':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de jugadores en desarrollo...[/]");
                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
                case '3':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de cuerpo técnico en desarrollo...[/]");
                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                    Console.ReadKey();
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