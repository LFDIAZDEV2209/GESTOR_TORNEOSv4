namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface IStatsUI
{
    Task ShowStatsMenu();
    Task ShowPlayersWithMostAssists();
    Task ShowTeamsWithMostGoals();
    Task ShowMostExpensivePlayers();
    Task ShowPlayersBelowAverageAge();
}
