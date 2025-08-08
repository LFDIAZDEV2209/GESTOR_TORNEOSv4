using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface IPlayerUI
{
    Task ShowMenu();
    Task ShowSearchPlayer();
    Task ShowPlayerDetails();
    Task ShowAllPlayers();
    Task ShowAddPlayer();
    Task ShowUpdatePlayer();
    Task ShowDeletePlayer();
}
