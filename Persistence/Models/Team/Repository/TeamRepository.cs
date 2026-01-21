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
}