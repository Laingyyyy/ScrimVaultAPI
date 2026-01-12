using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Mvc;
using ScrimVaultAPI.Models;

namespace ScrimVaultAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamController : ControllerBase
{
    private static List<Team> _teams = new List<Team>()
    {
        new Team()
        {
            Id = 1,
            Name = "Team 1",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            OwnerUserId = 1,
            TeamId = 1,
        },
        
        new Team()
        {  
            Id = 2,
            Name = "Team 2",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            OwnerUserId = 1,
            TeamId = 2,
        }
    };

    [HttpGet]
    public ActionResult<List<Team>> GetTeams()
    {
        return Ok(_teams);
    }

    [HttpGet("{id}")]
    public ActionResult<Team> GetTeam(int id)
    {
        var team = _teams.FirstOrDefault(x => x.Id == id);
        if (team == null)
        {
            return NotFound();
        }
        
        return Ok(team);
    }

    [HttpPost]
    public ActionResult<Team> CreateTeam(Team newTeam)
    {
        if (newTeam == null)
            return BadRequest();
        
        _teams.Add(newTeam);
        return CreatedAtAction(nameof(GetTeam), new { id = newTeam.Id }, newTeam);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTeam(int id, Team updatedTeam)
    {
        var team = _teams.FirstOrDefault(x => x.Id == id);

        if (team == null)
            return NotFound();

        team.TeamId = updatedTeam.TeamId;
        team.Name = updatedTeam.Name;
        team.OwnerUserId = updatedTeam.OwnerUserId;
        team.UpdatedAt = updatedTeam.UpdatedAt;
        team.CreatedAt = updatedTeam.CreatedAt;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTeam(int id)
    {
        var team = _teams.FirstOrDefault(x => x.TeamId  == id);
        if (team == null)
        {
            return NotFound();
        }
        
        _teams.Remove(team);
        return NoContent();
    }
}