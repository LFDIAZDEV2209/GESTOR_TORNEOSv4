using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Spectre.Console;

namespace GESTOR_TORNEOSv4.src.Modules.Application.UI;

public class TechnicalStaffUI : ITechnicalStaffUI
{
    private readonly IStaffService _staffService;
    private readonly ICountryService _countryService;

    public TechnicalStaffUI(IStaffService staffService, ICountryService countryService)
    {
        _staffService = staffService;
        _countryService = countryService;
    }

    public async Task ShowMenu()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Técnicos")
                .Centered()
                .Color(Color.Green)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Selecciona una opción")
                .AddChoices(new[] {
                    "1. Crear técnico",
                    "2. Buscar técnico",
                    "3. Eliminar técnico",
                    "4. Actualizar técnico",
                    "5. Salir",
                })
            );

            switch (selection[0])
            {
                case '1':
                    Console.Clear();
                    await ShowCreateTechnicalStaff();
                    break;
                case '2':
                    AnsiConsole.MarkupLine("[green]Funcionalidad no implementada[/]");
                    AnsiConsole.MarkupLine("[yellow]Presiona cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
                case '3':
                    AnsiConsole.MarkupLine("[green]Funcionalidad no implementada[/]");
                    AnsiConsole.MarkupLine("[yellow]Presiona cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
                case '4':
                    AnsiConsole.MarkupLine("[green]Funcionalidad no implementada[/]");
                    AnsiConsole.MarkupLine("[yellow]Presiona cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
                case '5':
                    AnsiConsole.MarkupLine("[green]Saliendo...[/]");
                    return;
                default:
                    AnsiConsole.MarkupLine("[red]Opción no válida[/]");
                    AnsiConsole.MarkupLine("[yellow]Presiona cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
            }
        }

    }

    public async Task ShowCreateTechnicalStaff()
    {
        AnsiConsole.Write(
            new FigletText("Crear técnico")
            .Centered()
            .Color(Color.Green)
        );

        var name = AnsiConsole.Ask<string>("[blue]Nombre del técnico[/]");

        var roles = await _staffService.GetStaffRolesByTypeAsync(1);

        var roleNames = roles.Select(r => $"{r.Id}: {r.Name}").ToList();

        var roleSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[blue]Selecciona el rol del técnico[/]")
            .AddChoices(roleNames)
        );

        var roleId = int.Parse(roleSelection.Split(':')[0]);

        var countries = await _countryService.GetAllAsync();

        var countryNames = countries.Select(c => $"{c.Id}: {c.Name}").ToList();

        var countrySelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[blue]Selecciona el país del técnico[/]")
            .AddChoices(countryNames)
        );

        var countryId = int.Parse(countrySelection.Split(':')[0]);

        var staff = new Staff
        {
            Name = name,
            RoleId = roleId,
            CountryId = countryId,
        };
        
        try
        {
            await _staffService.AddAsync(staff);
            AnsiConsole.MarkupLine("[green]Técnico creado correctamente. Presiona cualquier tecla para continuar...[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al crear el técnico: {ex.Message}[/]");
            AnsiConsole.MarkupLine("[yellow]Presiona cualquier tecla para continuar...[/]");
            Console.ReadKey();
        }
    }

}