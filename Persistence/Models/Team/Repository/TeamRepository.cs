using Microsoft.EntityFrameworkCore;
using Persistence.Exceptions.Teams;

namespace Persistence.Models.Team.Repository;

public class TeamRepository : ITeamRepository
{
    private readonly ApiContext _db;
    
    public TeamRepository(ApiContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Gets the <see cref="TeamEntity"/> by its Id
    /// </summary>
    /// <param name="id">the <see cref="TeamEntity"/>'s Id</param>
    /// <returns><see cref="TeamEntity"/></returns>
    /// <exception cref="TeamNotFound">Fires when a team is not found</exception>
    public async Task<TeamEntity> GetTeamById(int id)
    {
        return await _db.Teams.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false)
            ??  throw new TeamNotFound(id);
    }

    /// <summary>
    /// Gets all the teams in the Database
    /// </summary>
    /// <returns><see cref="List{TeamEntity}"/></returns>
    public async Task<List<TeamEntity>> GetAllTeams()
    {
        return await _db.Teams.ToListAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Creates a <see cref="TeamEntity"/> and adds to database
    /// </summary>
    /// <param name="name">the name of the team</param>
    /// <param name="ownerId">the owner player id</param>
    /// <returns>the <see cref="TeamEntity"/> created</returns>
    public async Task<TeamEntity> CreateTeam(string name, int ownerId)
    {
        var team = new TeamEntity()
        {
            Name = name,
            OwnerPlayerId = ownerId
        };
        
        await _db.Teams.AddAsync(team);
        await _db.SaveChangesAsync().ConfigureAwait(false);
        return team;
    }

    /// <summary>
    /// Removes a <see cref="TeamEntity"/> from the database
    /// </summary>
    /// <param name="team"> the team you want removed</param>
    public async Task RemoveTeam(TeamEntity team)
    {
        _db.Teams.Remove(team);
        await _db.SaveChangesAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Gets the <see cref="TeamEntity"/> based on the team's name
    /// </summary>
    /// <param name="name">The name of the team</param>
    /// <returns></returns>
    /// <exception cref="TeamNotFound">Fires when there is no teams that have the name that matches <param name="name">Team.Name</param></exception>
    public async Task<TeamEntity> GetTeamByName(string name)
    {
        return await _db.Teams.FirstOrDefaultAsync(x => EF.Functions.Like(x.Name, name)).ConfigureAwait(false)
               ?? throw new TeamNotFound(name);
    }
}