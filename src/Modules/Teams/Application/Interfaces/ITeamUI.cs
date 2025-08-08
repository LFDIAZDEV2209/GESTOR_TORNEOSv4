
namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface ITeamUI
{
    Task ShowSearchTeams();
    Task ShowAllTeams();
    Task ShowAddTeam();
    Task ShowUpdateTeam();
    Task ShowDeleteTeam();
    Task ShowTeamDetail();
    Task ShowMenu();
    Task ShowTeamManagement();
}
