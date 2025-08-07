namespace GESTOR_TORNEOSv4.src.Modules.Tournaments.Application.Interfaces;

public interface ITournamentUI
{
    Task ShowSearchTournaments();
    Task ShowAllTournaments();
    Task ShowAddTournament();
    Task ShowUpdateTournament();
    Task ShowDeleteTournament();
    Task ShowTournamentDetail();
    Task ShowMenu();
}