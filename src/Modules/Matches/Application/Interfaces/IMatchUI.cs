namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface IMatchUI
{
    // Menú principal de partidos
    Task ShowMatchMenu();
    
    // Opciones básicas del menú
    Task CreateMatch();
    void FinishMatch();
}
