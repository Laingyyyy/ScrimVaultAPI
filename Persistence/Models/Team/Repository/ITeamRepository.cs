namespace Persistence.Models.Team.Repository;

public interface ITeamRepository
{
    Task<TeamEntity> GetTeamById(int id);
    Task<List<TeamEntity>> GetAllTeams();
    Task<TeamEntity> CreateTeam(string name, int ownerId);
    Task RemoveTeam(TeamEntity team);
    Task<TeamEntity> GetTeamByName(string name);
}