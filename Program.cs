using GESTOR_TORNEOS.src.Shared.Helpers;
using GESTOR_TORNEOS.src.Modules.MainMenu;
using GESTOR_TORNEOS.src.Shared.Context;

namespace GESTOR_TORNEOS;

class Program 
{
    private static async Task Main(string[] args)
    {
        try
        {
            // Crear el contexto de Entity Framework
            var dbContext = DbContextFactory.Create() as AppDbContext;
            
            if (dbContext == null)
            {
                throw new InvalidOperationException("No se pudo crear el contexto de base de datos");
            }

            // Crear y mostrar el menú principal
            var mainMenu = new MainMenu(dbContext);
            await mainMenu.Show();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}

